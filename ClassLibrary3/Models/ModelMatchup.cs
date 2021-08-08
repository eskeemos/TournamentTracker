using System.Collections.Generic;

namespace TrackerLibrary.Models
{
    public class ModelMatchup // x
    {
        public int Id { get; set; }
        public List<ModelMatchupEntry> Entries { get; set; } = new List<ModelMatchupEntry>();
        public int WinnerId { get; set; }
        public ModelTeam Winner { get; set; }
        public int MatchupRound { get; set; }
        public string DisplayName 
        {
            get
            {
                string output = "";

                foreach (ModelMatchupEntry entry in Entries)
                {
                    if(entry.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = entry.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. {entry.TeamCompeting.TeamName}";
                        }
                    }
                    else
                    {
                        output = "Matchup Not Yet Determined";
                    }
                }

                return output;
            }
        }
    }
}