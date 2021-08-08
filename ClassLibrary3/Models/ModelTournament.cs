using System;
using System.Collections.Generic;

namespace TrackerLibrary.Models
{
    public class ModelTournament // x
    {
        public event EventHandler<DateTime> OnTournamentComplete;
        public int Id { get; set; }
        public string TournamentName { get; set; }
        public int EntryFee { get; set; }
        public List<ModelTeam> EnteredTeams { get; set; } = new List<ModelTeam>();
        public List<ModelPrize> Prizes { get; set; } = new List<ModelPrize>();
        public List<List<ModelMatchup>> Rounds { get; set; } = new List<List<ModelMatchup>>();
        public void CompleteTournament()
        {
            OnTournamentComplete?.Invoke(this, DateTime.Now);
        }
    }
}
