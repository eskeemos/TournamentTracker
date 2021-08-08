namespace TrackerLibrary.Models
{
    public class ModelPerson // x
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName 
        { 
            get 
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
