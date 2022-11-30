namespace Assignment2.Views
{
    public class User
    {
        public int userID { get; set; }
        public string category { get; set; }
        public int? CVR { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string name { get; set; }

        public List<Booking> bookings { get; set; }
    }
}
