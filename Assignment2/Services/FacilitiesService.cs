using Assignment2.Controllers;
using Assignment2.Models;
using Assignment2.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;

namespace Assignment2.Services;

public class FacilitiesService
{
    private readonly IMongoCollection<Booking> _bookingsCollection;
    private readonly IMongoCollection<Facility> _facilitiesCollection;
	private readonly IMongoCollection<User> _usersCollection;

	public FacilitiesService(
		IOptions<mongoDBSettings> mongoDbSettings)
	{
		var mongoClient = new MongoClient(
			mongoDbSettings.Value.ConnectionString);

		var mongoDatabase = mongoClient.GetDatabase(
			mongoDbSettings.Value.DatabaseName);

		_facilitiesCollection = mongoDatabase.GetCollection<Facility>(
			mongoDbSettings.Value.FacilitiesCollectionName);

		_usersCollection = mongoDatabase.GetCollection<User>(
			mongoDbSettings.Value.UsersCollectionName);

		_bookingsCollection = mongoDatabase.GetCollection<Booking>(
			mongoDbSettings.Value.BookingsCollectionName);
	}

	public async Task<ActionResult<IEnumerable<F>>> GetFacilityNamesAndAddresses()
	{
		IMongoQueryable<F> stuff = from f in _facilitiesCollection.AsQueryable()
					orderby f.kind
					select new F
					{
						name = f.facilityName,
						address = f.coordinates,
					};
		return await stuff.ToListAsync();
	}

	public async Task<ActionResult<IEnumerable<FF>>> GetFacilityNamesAndAddressesAndKinds()
	{
		IMongoQueryable<FF> stuff = from f in _facilitiesCollection.AsQueryable()
					select new FF
					{
						name = f.facilityName,
						address = f.coordinates,
						kind = f.kind,
					};
		var stuffSorted = stuff.OrderBy(f => f.kind);
		return await stuffSorted.ToListAsync();
	}

	public async Task<List<BookingDTO>> GetBookedFacilitiesNamesWithBookingUserAndTimeslot()
	{
        var bookings = await _bookingsCollection.Find(booking => true).ToListAsync();

        var result = new List<BookingDTO>();

        foreach (var booking in bookings)
        {
            result.Add(new BookingDTO
            {
                FacilityName = booking.facility.facilityName,
                UserName = booking.user.name,
                BookingInterval = booking.hourInterval
         
			});
        }
		return result;
        //IMongoQueryable<User> users = _usersCollection.AsQueryable();
        //List<int> userIDs = new List<int>();

        //foreach(var user in users)
        //{
        //	userIDs.Add(user.userID);
        //}

  //      List<int> temp = new List<int>();
		//temp.Add(1);
		//temp.Add(2);
		//temp.Add(3);

		//var filter = Builders<User>.Filter.Exists("userID");
		//var projection = Builders<User>.Projection.Exclude("_id");
		//List<User> users = _usersCollection.Find(filter).ToList();

		//IMongoQueryable<FFF> stuff = from f in _facilitiesCollection.AsQueryable()
		//							 select new FFF
		//							 {
		//								 name = f.facilityName,
		//								 user = (List<User>)(from ff in f.bookings
		//													 where temp.Contains(ff.userID)
		//													 select from fff in users
		//															where fff.userID == ff.userID
		//															select fff)
		//							 };

		//IMongoQueryable<FFF> stuff = _facilitiesCollection.AsQueryable()
		//	.Where(f => f.bookings != null)
		//	.Select(f => new FFF
		//	{
		//		name = f.facilityName,
		//		user = f.bookings
		//			.Where(b => users.Select(bb => bb.userID).Contains(b.userID))
		//			.Select(b => users.Where(u => u.userID == b.userID).FirstOrDefault())
		//			.Distinct()
		//			.ToList(),
		//		//timeslot = f.bookings
		//		//	.GroupBy(ff => ff.userID)
		//		//	.Select(ff => ff
		//		//		.Select(fff => fff.hourInterval)
		//		//		.First())
		//		//	.ToList(),
		//	});

		//return await stuff.ToListAsync();
	}

	//public async Task<ActionResult<IEnumerable<List<CPR>>>> GetListOfCPRs()
	//{
	//	var stuff = _facilitiesCollection.AsQueryable()
	//		.Select(f => f.bookings.Select(b => b.CPR));

	//	return await stuff.ToListAsync();
	//}

	//public async Task<ActionResult<IEnumerable<FFFF>>> GetListOfMaintenances()
	//{
	//	var stuff = _facilitiesCollection.AsQueryable()
	//		.Select(b => new FFFF
	//		{
	//			date = b.date,
	//			description = b.description,
	//			itemID = b.itemID
	//		});

	//	return await stuff.ToListAsync();
	//}
}
