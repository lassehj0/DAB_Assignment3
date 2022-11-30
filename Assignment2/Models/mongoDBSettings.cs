namespace Assignment2.Models
{
    public class mongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

		public string BookingsCollectionName { get; set; } = null!;

		public string CPRsCollectionName { get; set; } = null!;

		public string FacilitiesCollectionName { get; set; } = null!;

		public string ItemsCollectionName { get; set; } = null!;

		public string MaintainancesCollectionName { get; set; } = null!;

		public string UsersCollectionName { get; set; } = null!;
	}
}
