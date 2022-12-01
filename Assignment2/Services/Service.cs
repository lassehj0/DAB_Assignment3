using Assignment2.Controllers;
using Assignment2.Models;
using Assignment2.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;

namespace Assignment2.Services;

public class Service
{
	private readonly IMongoCollection<Booking> _bookingsCollection;
	private readonly IMongoCollection<Facility> _facilitiesCollection;
	private readonly IMongoCollection<User> _usersCollection;

	public Service(
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
				FacilityName = booking.Facility.facilityName,
				UserName = booking.User.name,
				BookingInterval = booking.hourInterval

			});
		}
		return result;
	}

	public async Task<List<CPRDTO>> GetBookingsWithCPR()
	{
		var bookings = await _bookingsCollection.Find(booking => true).ToListAsync();

		var result = new List<CPRDTO>();

		foreach (var booking in bookings)
		{
			result.Add(new CPRDTO
			{
				bookingID = booking.bookingID,
				CPRList = booking.CPR
			});
		}
		return result;
	}
    public async Task<ActionResult<IEnumerable<FFFF>>> GetListOfMaintenances()
    {
        var facilities = _facilitiesCollection.AsQueryable().ToList();

        List<FFFF> stuff = new();
        foreach (Facility facility in facilities)
        {
            foreach (Item item in facility.Items)
            {
                foreach (Maintainance maintainance in item.Maintainances)
                {
                    stuff.Add(new FFFF
                    {
                        date = maintainance.date,
                        description = maintainance.description,
                        itemID = maintainance.itemID,
                    });
                }
            }
        }


        return stuff;
    }
}
