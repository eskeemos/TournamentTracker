using System.Configuration;
using TrackerLibrary.DataAccess;
using static TrackerLibrary.Enums;

namespace TrackerLibrary
{

    public static class GlobalConfig // x
    {
        #region Const

        public const string
            PrizesFile = "PrizeModels.csv",
            PeopleFile = "PersonModels.csv",
            TeamFile = "TeamModel.csv",
            TournamentFile = "TournamentModels.csv",
            MatchupFile = "MatchupModels.csv",
            MatchupEntryModels = "MatchupEntryModels.csv";

        #endregion

        #region GlobalFunctions

        public static IDataConnection Connection { get; private set; }
        public static void InitializeConnections(DatabaseType db)
        {
            switch (db)
            {
                case DatabaseType.Sql:
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;
                case DatabaseType.TextFiles:
                    TextConnector txt = new TextConnector();
                    Connection = txt;
                    break;
            }
        }
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static string AppKeyLookUp(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        #endregion

    }
}
