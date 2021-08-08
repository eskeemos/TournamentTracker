using System.Collections.Generic;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection // x
    {
        void CreatePrize(ModelPrize prize);
        void CreatePerson(ModelPerson person);
        void CreateTeam(ModelTeam team);
        void CreateTournament(ModelTournament tournament);
        void UpdateMatchup(ModelMatchup matchup);
        void CompleteTournament(ModelTournament tournament);
        List<ModelPerson> GetPersons();
        List<ModelTeam> GetTeams();
        List<ModelTournament> GetTournaments();
    }
}
