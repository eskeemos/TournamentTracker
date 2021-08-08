using Logic.DataAccess.TextHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection // x
    {
        #region Interface

        public void CreatePerson(ModelPerson person)
        {
            List<ModelPerson> persons = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            person.Id = (persons.Count > 0) ? GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel().First().Id + 1 : 1;

            persons.Add(person);

            persons.SaveToPeopleFile();
        }
        public void CreatePrize(ModelPrize prize)
        {
            List<ModelPrize> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            prize.Id = (prizes.Count > 0) ? prizes.OrderByDescending((x) => x.Id).First().Id + 1 : 1;

            prizes.Add(prize);

            prizes.SaveToPrizeFile();
        }
        public void CreateTeam(ModelTeam team)
        {
            List<ModelTeam> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel();

            team.Id = (teams.Count > 0) ? teams.OrderByDescending((x) => x.Id).First().Id + 1 : 1;

            teams.Add(team);

            teams.SaveToTeamFile();
        }
        public void CreateTournament(ModelTournament tournament)
        {
            List<ModelTournament> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

            tournament.Id = (tournaments.Count > 0) ? tournaments.OrderByDescending((x) => x.Id).First().Id + 1 : 1;

            tournament.SaveRoundsToFile();

            tournaments.Add(tournament);

            tournaments.SaveToTournamentFile();

            Logic.AppLogic.UpdateTournamentResults(tournament);
        }
        public void UpdateMatchup(ModelMatchup matchup)
        {
            matchup.UpdateMatchupToFile();
        }
        public void CompleteTournament(ModelTournament tournament)
        {
            List<ModelTournament> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

            foreach (ModelTournament tournamentA in tournaments)
            {
                if(tournamentA.Id == tournament.Id)
                {
                    tournaments.Remove(tournamentA);
                    break;
                }
            }

            tournaments.SaveToTournamentFile();
        }
        public List<ModelPerson> GetPersons()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }
        public List<ModelTeam> GetTeams()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel();
        }
        public List<ModelTournament> GetTournaments()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();
        }

        #endregion
    }
}
