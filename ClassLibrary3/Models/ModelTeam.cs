using System.Collections.Generic;

namespace TrackerLibrary.Models // x
{
    public class ModelTeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<ModelPerson> TeamMembers { get; set; } = new List<ModelPerson>();
    }
}
