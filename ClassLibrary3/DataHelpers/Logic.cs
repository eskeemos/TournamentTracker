using Logic.DataHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace Logic
{
    public static class AppLogic 
    {

        public static void CreateRounds(ModelTournament tournament)
        {
            List<ModelTeam> teams = RandomizeTeams(tournament.EnteredTeams);

            int rounds = FindNumberOfRounds(teams.Count);
            int bots = FindNumberOfBots(rounds, teams.Count);

            tournament.Rounds.Add(CreateFirstRound(bots, teams));

            CreateOtherRounds(tournament, rounds);
        }
        private static void CreateOtherRounds(ModelTournament tournament, int rounds)
        {
            int round = 2;
            List<ModelMatchup> roundBefore = tournament.Rounds[0];
            List<ModelMatchup> roundNow = new List<ModelMatchup>();
            ModelMatchup matchupNow = new ModelMatchup();

            while(round <= rounds)
            {
                foreach (ModelMatchup matchup in roundBefore)
                {
                    matchupNow.Entries.Add(new ModelMatchupEntry { ParentMatchup = matchup });

                    if(matchupNow.Entries.Count > 1)
                    {
                        matchupNow.MatchupRound = round;
                        roundNow.Add(matchupNow);
                        matchupNow = new ModelMatchup();
                    }
                }
                tournament.Rounds.Add(roundNow);
                roundBefore = roundNow;
                roundNow = new List<ModelMatchup>();
                round += 1;
            }
        }
        private static List<ModelMatchup> CreateFirstRound(int bot, List<ModelTeam> teams)
        {
            List<ModelMatchup> firstRound = new List<ModelMatchup>();
            ModelMatchup matchupNow = new ModelMatchup();
            foreach (ModelTeam team in teams)
            {
                matchupNow.Entries.Add(new ModelMatchupEntry { TeamCompeting = team });
                if((bot > 0) || (matchupNow.Entries.Count > 1))
                {
                    matchupNow.MatchupRound = 1;
                    firstRound.Add(matchupNow);
                    matchupNow = new ModelMatchup();

                    if (bot > 0) bot -= 1;
                }
            }
            return firstRound;
        }
        private static int FindNumberOfBots(int rounds, int teamCount)
        {
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++) totalTeams *= 2;
            
            return totalTeams - teamCount;
        }
        private static int FindNumberOfRounds(int teamsCount)
        {

            int rounds = 1,
                value = 2;

            while(value < teamsCount)
            {
                rounds += 1;
                value *= 2;
            }
            return rounds;
        }
        private static List<ModelTeam> RandomizeTeams(List<ModelTeam> teams)
        {
            return teams.OrderBy((x) => Guid.NewGuid()).ToList();
        }
        public static void UpdateTournamentResults(ModelTournament tournament)
        {
            int startRound = tournament.CheckCurrentRound();
            List<ModelMatchup> toScore = new List<ModelMatchup>();

            foreach (List<ModelMatchup> matchupList in tournament.Rounds)
            {
                foreach (ModelMatchup matchup in matchupList)
                {
                    if(matchup.Winner == null && matchup.Entries.Any((x) => x.Score != 0) || matchup.Entries.Count == 1)
                    {
                        toScore.Add(matchup);
                    }
                }
            }

            MarkWinnerInMatchup(toScore);

            AdvanceWinners(toScore, tournament);

            toScore.ForEach((x) => GlobalConfig.Connection.UpdateMatchup(x));

            int finishRound = tournament.CheckCurrentRound();

            if(finishRound > startRound)
            {
                tournament.AlertUsersToNewRound();
            }
        }
        public static void AlertUsersToNewRound(this ModelTournament tournament)
        {
            int currRound = tournament.CheckCurrentRound();
            List<ModelMatchup> currMatchups = tournament.Rounds.Where(x => x.First().MatchupRound == currRound).First();

            foreach (ModelMatchup matchup in currMatchups)
            {
                foreach (ModelMatchupEntry entry in matchup.Entries)
                {
                    foreach (var person in entry.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(person, entry.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != entry.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }
        private static void AlertPersonToNewRound(ModelPerson person, string teamName, ModelMatchupEntry entry)
        {
            if(person.EmailAddress.Length == 0)
            {
                return;
            }

            StringBuilder body = new StringBuilder();
            string subject;

            if (entry != null)
            {
                subject = $"Hello {teamName}! You have a new matchup with {entry.TeamCompeting.TeamName}.";

                body.AppendLine("<h1>New Matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.Append(entry.TeamCompeting.TeamName);
                body.AppendLine("<p>Have a great time! ~ Tournament Tracker</p>");
            }
            else
            {
                subject = $"Hello {teamName}! You go throught this round.";
                body.AppendLine("<h1>Round Off Info</h1>");
                body.AppendLine("<p>Enjoy your round off! ~ Tournament Tracker</p>");
            }

            string to = person.EmailAddress;

            EmailLogic.SendEmail(to, subject, body.ToString());
        }
        private static int CheckCurrentRound(this ModelTournament tournament)
        {
            int currRound = 1;

            foreach (List<ModelMatchup> matchupList in tournament.Rounds)
            {
                if(matchupList.All(x => x.Winner != null))
                {
                    currRound += 1;
                }
                else
                {
                    return currRound;
                }
            }
            CompleteTournament(tournament);
            return currRound - 1;
        }
        public static void CompleteTournament(ModelTournament tournament)
        {
            GlobalConfig.Connection.CompleteTournament(tournament);
            ModelTeam winner = tournament.Rounds.Last().First().Winner;
            ModelTeam runnerUp = tournament.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winner).First().TeamCompeting;

            decimal winnerPrize = 0;
            decimal runnerUpPrize = 0;

            if(tournament.Prizes.Count > 0)
            {
                decimal income = tournament.EnteredTeams.Count * tournament.EntryFee;
                ModelPrize firstPrize = tournament.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                ModelPrize secondPrize = tournament.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if (firstPrize != null)
                {
                    winnerPrize = firstPrize.CalculatePrize(income);
                }
                if (secondPrize != null)
                {
                    runnerUpPrize = secondPrize.CalculatePrize(income);
                }
            }

            StringBuilder body = new StringBuilder();
            string subject;

            subject = $"In {tournament.TournamentName}, {winner.TeamName} has won!";

            body.AppendLine("<h1>We have a WINNER!</h1>");
            body.AppendLine("<p>Congratulations to our winner on a great tournament!</p>");
            body.AppendLine("<br>");

            if(winnerPrize > 0)
            {
                body.AppendLine($"<p>{winner.TeamName} will receive ${winnerPrize}</p>");
            }
            if (runnerUpPrize > 0)
            {
                body.AppendLine($"<p>{runnerUp.TeamName} will receive ${runnerUpPrize}</p>");
            }
            body.AppendLine("<p>Thanks for a great tournament everyone!</p>");
            body.AppendLine("~Tournament Tracker");

            List<string> bcc = new List<string>();

            foreach (ModelTeam team in tournament.EnteredTeams)
            {
                foreach (ModelPerson person in team.TeamMembers)
                {
                    if (person.EmailAddress.Length > 0)
                    {
                        bcc.Add(person.EmailAddress);
                    }
                }
            }

            EmailLogic.SendEmail(new List<string>() ,bcc, subject, body.ToString());

            tournament.CompleteTournament();
        }
        private static decimal CalculatePrize(this ModelPrize prize, decimal income)
        {
            decimal totalPrize;
            if (prize.PrizeAmount > 0)
            {
                totalPrize = prize.PrizeAmount;
            }
            else
            {
                totalPrize = Decimal.Multiply(income, Convert.ToDecimal(prize.PrizePercentage / 100));
            }
            return totalPrize;
        }
        private static void AdvanceWinners(List<ModelMatchup> matchupList, ModelTournament tournament)
        {
            foreach (ModelMatchup parentMatchup in matchupList)
            {
                foreach (List<ModelMatchup> listOfMatchups in tournament.Rounds)
                {
                    foreach (ModelMatchup matchup in listOfMatchups)
                    {
                        foreach (ModelMatchupEntry entry in matchup.Entries)
                        {
                            if((entry.ParentMatchup != null)&&(entry.ParentMatchup.Id == parentMatchup.Id))
                            {
                                entry.TeamCompeting = parentMatchup.Winner;
                                GlobalConfig.Connection.UpdateMatchup(matchup);
                            }
                        }
                    }        
                }
            }
        }
        private static void MarkWinnerInMatchup(List<ModelMatchup> matchups)
        {
            string scoreDirection = ConfigurationManager.AppSettings["greatherWins"];

            foreach (ModelMatchup matchup in matchups)
            {
                if(matchup.Entries.Count == 1)
                {
                    matchup.Winner = matchup.Entries[0].TeamCompeting;
                    continue;
                }
                if (scoreDirection == "0")
                {
                    if (matchup.Entries[0].Score < matchup.Entries[1].Score)
                    {
                        matchup.Winner = matchup.Entries[0].TeamCompeting;
                    }
                    else if (matchup.Entries[1].Score < matchup.Entries[0].Score)
                    {
                        matchup.Winner = matchup.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We don't allow ties in this App.");
                    }
                }
                else
                {
                    if (matchup.Entries[0].Score > matchup.Entries[1].Score)
                    {
                        matchup.Winner = matchup.Entries[0].TeamCompeting;
                    }
                    else if (matchup.Entries[1].Score > matchup.Entries[0].Score)
                    {
                        matchup.Winner = matchup.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We don't allow ties in this App.");
                    }
                }
            }
        }
    }
}
