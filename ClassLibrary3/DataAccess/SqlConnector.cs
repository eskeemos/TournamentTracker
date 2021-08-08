using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection // x
    {
        #region Readonly

        private readonly string db = "TournamentTracker";

        #endregion

        #region Interface

        public void CreatePerson(ModelPerson person)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var dp = new DynamicParameters();

                dp.Add("@FirstName", person.FirstName);
                dp.Add("@LastName", person.LastName);
                dp.Add("@EmailAddress", person.EmailAddress);
                dp.Add("@PhoneNumber", person.PhoneNumber);
                dp.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute("dbo.People_insert", dp, commandType: CommandType.StoredProcedure);

                person.Id = dp.Get<int>("@Id");
            }
        }  
        public void CreatePrize(ModelPrize prize)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var dp = new DynamicParameters();

                dp.Add("@PlaceNumber", prize.PlaceNumber);
                dp.Add("@PlaceName", prize.PlaceName);
                dp.Add("@PrizeAmount", prize.PrizeAmount);
                dp.Add("@PrizePercentage", prize.PrizePercentage);
                dp.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute("dbo.Prizes_insert", dp, commandType: CommandType.StoredProcedure);

                prize.Id = dp.Get<int>("@Id");
            }
        }
        public void CreateTeam(ModelTeam team)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var dp = new DynamicParameters();

                dp.Add("TeamName", team.TeamName);
                dp.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute("dbo.Teams_insert", dp, commandType: CommandType.StoredProcedure);

                team.Id = dp.Get<int>("@Id");

                foreach (ModelPerson person in team.TeamMembers)
                {
                    dp = new DynamicParameters();

                    dp.Add("TeamId", team.Id);
                    dp.Add("PersonId", person.Id);

                    conn.Execute("dbo.TeamMembers_insert", dp, commandType: CommandType.StoredProcedure);
                }
            }
        }
        public void CreateTournament(ModelTournament tournament)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                SaveTournament(conn, tournament);

                SaveTournamentPrizes(conn, tournament);

                SaveTournamentEntries(conn, tournament);

                SaveTournamentRounds(conn, tournament);

                Logic.AppLogic.UpdateTournamentResults(tournament);
            }
        }
        public void UpdateMatchup(ModelMatchup matchup)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var dp = new DynamicParameters();

                if (matchup.Winner != null)
                {
                    dp.Add("Id", matchup.Id);
                    dp.Add("WinnerId", matchup.Winner.Id);

                    conn.Execute("dbo.Matchups_update", dp, commandType: CommandType.StoredProcedure);
                }

                foreach (ModelMatchupEntry entry in matchup.Entries)
                {
                    if (entry.TeamCompeting != null)
                    {
                        dp = new DynamicParameters();

                        dp.Add("Id", entry.Id);
                        dp.Add("TeamCompetingId", entry.TeamCompeting.Id);
                        dp.Add("Score", entry.Score);

                        conn.Execute("dbo.MatchupEntries_update", dp, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }
        public void CompleteTournament(ModelTournament model)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var dp = new DynamicParameters();

                dp.Add("Id", model.Id);

                conn.Execute("dbo.Tournaments_complete", dp, commandType: CommandType.StoredProcedure);
            }
        }
        public List<ModelPerson> GetPersons()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                return conn.Query<ModelPerson>("dbo.People_getAll").ToList();
            }
        }
        public List<ModelTeam> GetTeams()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<ModelTeam> teams = conn.Query<ModelTeam>("dbo.Teams_getAll").ToList();

                foreach (ModelTeam team in teams)
                {
                    var dp = new DynamicParameters();

                    dp.Add("@TeamID", team.Id);

                    team.TeamMembers = conn.Query<ModelPerson>("dbo.TeamMembers_getByTeam", dp, commandType: CommandType.StoredProcedure).ToList();
                }

                return teams;
            }
        }
        public List<ModelTournament> GetTournaments()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<ModelTournament> tournaments = conn.Query<ModelTournament>("dbo.Tournaments_getAll").ToList();

                foreach (ModelTournament tournament in tournaments)
                {
                    var dp = new DynamicParameters();

                    dp.Add("@TournamentId", tournament.Id);

                    tournament.Prizes = conn.Query<ModelPrize>("dbo.Prizes_getByTournament", dp, commandType: CommandType.StoredProcedure).ToList();

                    dp = new DynamicParameters();

                    dp.Add("@TournamentId", tournament.Id);

                    tournament.EnteredTeams = conn.Query<ModelTeam>("dbo.Teams_getByTournament", dp, commandType: CommandType.StoredProcedure).ToList();

                    foreach (ModelTeam team in tournament.EnteredTeams)
                    {
                        dp = new DynamicParameters();

                        dp.Add("@EntryId", team.Id);

                        team.TeamMembers = conn.Query<ModelPerson>("dbo.People_getByTeam", dp, commandType: CommandType.StoredProcedure).ToList();
                    }

                    dp = new DynamicParameters();

                    dp.Add("@TournamentId", tournament.Id);

                    List<ModelMatchup> matchups = conn.Query<ModelMatchup>("dbo.Matchups_getByTournament", dp, commandType: CommandType.StoredProcedure).ToList();

                    foreach (ModelMatchup matchup in matchups)
                    {
                        dp = new DynamicParameters();

                        dp.Add("MatchupId", matchup.Id);

                        matchup.Entries = conn.Query<ModelMatchupEntry>("dbo.MatchupEntries_getByTournament", dp, commandType: CommandType.StoredProcedure).ToList();

                        List<ModelTeam> teams = GetTeams();

                        if (matchup.WinnerId > 0)
                        {
                            matchup.Winner = teams.Where((x) => x.Id == matchup.WinnerId).First();
                        }

                        foreach (var team in matchup.Entries)
                        {
                            if (team.TeamCompetingId > 0)
                            {
                                team.TeamCompeting = teams.Where((x) => x.Id == team.TeamCompetingId).First();
                            }
                            if (team.ParentMatchupId > 0)
                            {
                                team.ParentMatchup = matchups.Where((x) => x.Id == team.ParentMatchupId).FirstOrDefault();
                            }
                        }
                    }

                    List<ModelMatchup> Row = new List<ModelMatchup>();
                    int currRound = 1;

                    foreach (ModelMatchup matchup in matchups)
                    {
                        if (matchup.MatchupRound > currRound)
                        {
                            tournament.Rounds.Add(Row);
                            Row = new List<ModelMatchup>();
                            currRound += 1;
                        }
                        Row.Add(matchup);
                    }

                    tournament.Rounds.Add(Row);
                }
                return tournaments;
            }
        }

        #endregion

        #region DataSave

        private void SaveTournamentRounds(IDbConnection conn, ModelTournament tournament)
        {
            foreach (List<ModelMatchup> rounds in tournament.Rounds)
            {
                foreach (ModelMatchup matchup in rounds)
                {
                    var dp = new DynamicParameters();

                    dp.Add("@TournamentId", tournament.Id);
                    dp.Add("@MatchupRound", matchup.MatchupRound);
                    dp.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                    conn.Execute("dbo.Matchups_insert", dp, commandType: CommandType.StoredProcedure);

                    matchup.Id = dp.Get<int>("@Id");

                    foreach (ModelMatchupEntry entry in matchup.Entries)
                    {
                        dp = new DynamicParameters();

                        dp.Add("@MatchupID", matchup.Id);

                        if (entry.ParentMatchup == null) dp.Add("@ParentMatchupId", null);
                        else dp.Add("@ParentMatchupId", entry.ParentMatchup.Id);

                        if (entry.TeamCompeting == null) dp.Add("@TeamCompetingId", null);
                        else dp.Add("@TeamCompetingId", entry.TeamCompeting.Id);
                        
                        dp.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                        conn.Execute("dbo.MatchupEntries_insert", dp, commandType: CommandType.StoredProcedure);

                        entry.Id = dp.Get<int>("@Id");
                    }
                }
            }
        }
        private void SaveTournament(IDbConnection conn, ModelTournament tournament)
        {
            var dp = new DynamicParameters();

            dp.Add("@TournamentName", tournament.TournamentName);
            dp.Add("@EntryFee", tournament.EntryFee);
            dp.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

            conn.Execute("dbo.Tournaments_insert", dp, commandType: CommandType.StoredProcedure);

            tournament.Id = dp.Get<int>("@Id");
        }
        private void SaveTournamentPrizes(IDbConnection conn, ModelTournament tournament)
        {
            foreach (ModelPrize prize in tournament.Prizes)
            {
                var dp = new DynamicParameters();

                dp.Add("@TournamentId", tournament.Id);
                dp.Add("PrizeId", prize.Id);
                dp.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute("dbo.TournamentPrizes_insert", dp, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentEntries(IDbConnection conn, ModelTournament tournament)
        {
            foreach (ModelTeam team in tournament.EnteredTeams)
            {
                var dp = new DynamicParameters();

                dp.Add("@TournamentId", tournament.Id);
                dp.Add("TeamId", team.Id);
                dp.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute("dbo.TournamentEntries_insert", dp, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion
    }
}