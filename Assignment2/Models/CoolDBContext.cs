using Assignment2.Views;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Reflection.Metadata;

namespace Assignment2.Models
{
	public class CoolDBContext : DbContext
	{
        public CoolDBContext(DbContextOptions<CoolDBContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
		public DbSet<Facility> Facilities { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Maintainance> Maintainances { get; set; }
		public DbSet<User> users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region CPR
			modelBuilder.Entity<CPR>()
				.HasOne(c => c.booking)
				.WithMany(b => b.CPR)
				.HasForeignKey(c => c.bookingID);
			modelBuilder.Entity<CPR>()
				.HasKey(c => new { c.CPRID });

			modelBuilder.Entity<CPR>()
				.HasData(
				new CPR
				{
					CPRID = 1,
					CPRs = "010101-1111",
					bookingID = 1,
				},
                new CPR
                {
                    CPRID = 2,
                    CPRs = "020202-2",
                    bookingID = 1,
                },
                new CPR
                {
                    CPRID = 3,
                    CPRs = "030303-3333",
                    bookingID = 1,
                },
                new CPR
                {
                    CPRID = 4,
                    CPRs = "040404-4",
                    bookingID = 1,
                },
                new CPR
                {
                    CPRID = 5,
                    CPRs = "050505-5555",
                    bookingID = 1,
                },
                new CPR
                {
                    CPRID = 6,
                    CPRs = "060606-6",
                    bookingID = 2,
                },
                new CPR
                {
                    CPRID = 7,
                    CPRs = "070707-7777",
                    bookingID = 2,
                },
                new CPR
                {
                    CPRID = 8,
                    CPRs = "080808-8888",
                    bookingID = 2,
                },
                new CPR
                {
                    CPRID = 9,
                    CPRs = "090909-9999",
                    bookingID = 3,
                },
                new CPR
                {
                    CPRID = 10,
                    CPRs = "101010-1010",
                    bookingID = 3,
                },
                new CPR
                {
                    CPRID = 11,
                    CPRs = "111110-1110",
                    bookingID = 4,
                },
                new CPR
                {
                    CPRID = 12,
                    CPRs = "121212-1212",
                    bookingID = 4,
                },
                new CPR
                {
                    CPRID = 13,
                    CPRs = "131313-1313",
                    bookingID = 4,
                });
			#endregion

			#region Booking 
			modelBuilder.Entity<Booking>()
				.HasOne(b => b.facility)
				.WithMany(f => f.bookings)
				.HasForeignKey(b => b.facilityID);
			modelBuilder.Entity<Booking>()
				.HasOne(b => b.user)
				.WithMany(u => u.bookings)
				.HasForeignKey(b => b.userID);
			modelBuilder.Entity<Booking>()
				.HasMany(b => b.CPR)
				.WithOne(c => c.booking);
			modelBuilder.Entity<Booking>()
				.HasKey(b => new { b.bookingID });

			modelBuilder.Entity<Booking>()
				.HasData(
				new Booking
				{
					bookingID = 1,
					note = "We might be done early",
					category = "school",
					hourInterval = "10:00-15:00",
					participants = 5,
					authentication = "AA8B420OP69",
					facilityID = 1,
					userID = 1,
				},
                new Booking
                {
                    bookingID = 2,
                    category = "school",
                    hourInterval = "12:00-13:00",
                    participants = 3,
                    authentication = "HHSV7728JJD",
                    facilityID = 1,
                    userID = 1,
                },
                new Booking
                {
                    bookingID = 3,
                    category = "private",
                    hourInterval = "09:00-11:30",
                    participants = 2,
                    authentication = "UUA0339JDBN",
                    facilityID = 2,
                    userID = 2,
                },
                new Booking
                {
                    bookingID = 4,
                    category = "private",
                    hourInterval = "14:30-16:00",
                    participants = 3,
                    authentication = "UBDJA8AB659",
                    facilityID = 2,
                    userID = 3,
                });
            #endregion

            #region Facility
            modelBuilder.Entity<Facility>()
				.HasMany(f => f.items)
				.WithOne(i => i.facility);
			modelBuilder.Entity<Facility>()
				.HasMany(f => f.bookings)
				.WithOne(b => b.facility);
			modelBuilder.Entity<Facility>()
				.HasKey(f => new { f.facilityID });

			modelBuilder.Entity<Facility>()
				.HasData(
					new Facility 
					{ 
						facilityID = 1,
						maxOccupants = 5, 
						reservable = true, 
						description = "A shelter located in Risskov forest", 
						utilities = "Sink",
                        coordinates = new Point(-122.3330, 47.6097) { SRID = 4326 }, 
						kind = "Shelter", 
						facilityName = "Risskov shelter"
					},
					new Facility
					{
						facilityID = 2,
						maxOccupants = 3,
						reservable = true,
						coordinates = new Point(-10.2454, 88.2342) { SRID = 4326 },
						kind = "Firplace",
						facilityName = "Aarhus central forest fireplace"
					}
				);
            #endregion

            #region User
            modelBuilder.Entity<User>()
				.HasMany(u => u.bookings)
				.WithOne(b => b.user);
			modelBuilder.Entity<User>()
				.HasKey(u => new { u.userID });

			modelBuilder.Entity<User>()
				.HasData(
					new User 
					{ 
						userID = 1,
						category = "school",
						CVR = 12345678,
						email = "sdbck@mail.com",
						phoneNumber = 12345678,
						name = "Lasse"
					},
					new User
					{
						userID = 2,
						category = "private",
						email = "dasd@mail.com",
						phoneNumber = 12345678,
						name = "Aske"
					},
					new User
					{
						userID = 3,
						category = "private",
						email = "adsd@mail.com",
						phoneNumber = 12345678,
						name = "Marcus"
					}
				);
            #endregion

            #region Item
            modelBuilder.Entity<Item>()
				.HasOne(i => i.facility)
				.WithMany(f => f.items)
				.HasForeignKey(i => i.facilityID);
			modelBuilder.Entity<Item>()
				.HasKey(i => i.itemId);

			modelBuilder.Entity<Item>()
				.HasData(
				new Item { itemId = 1, name = "Shovel", facilityID = 1 },
                new Item { itemId = 2, name = "Pan", facilityID = 1 },
                new Item { itemId = 3, name = "Shovel", facilityID = 2 });
            #endregion

            #region Maintainance
            modelBuilder.Entity<Maintainance>()
				.HasOne(m => m.item)
				.WithMany(i => i.maintainances)
				.HasForeignKey(m => m.itemID);
			modelBuilder.Entity<Maintainance>()
				.HasKey(m => new { m.maintainanceID });

			modelBuilder.Entity<Maintainance>()
				.HasData(
					new Maintainance 
					{ 
						maintainanceID = 1,
						date = new DateTime(), 
						description = "Is getting a bit rusty, might need replacing soon", 
						itemID = 1 
					},
					new Maintainance 
					{
                        maintainanceID = 2,
                        date = new DateTime(), 
						itemID = 1 
					},
					new Maintainance 
					{
                        maintainanceID = 3,
                        date = new DateTime(), 
						description = "A bit bent but still fine", 
						itemID = 2 
					},
					new Maintainance 
					{
                        maintainanceID = 4,
                        date = new DateTime(), 
						itemID = 3 
					},
					new Maintainance 
					{
                        maintainanceID = 5,
                        date = new DateTime(), 
						description = "The handle had fallen off but is reattached", 
						itemID = 3 
					}
				);
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=master;Integrated Security=True",
				x => x.UseNetTopologySuite());
    }
}
