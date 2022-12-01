using Assignment2.Controllers;
using Assignment2.Models;
using Assignment2.Views;
using Assignment2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Assignment2.Services;

public class FacilitiesService
{
	private readonly IMongoCollection<Facility> _facilitiesCollection;
	private readonly IMongoCollection<User> _usersCollection;
	private readonly IMongoCollection<Booking> _bookingsCollection;

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

	public async Task<ActionResult<IEnumerable<FFF>>> GetBookedFacilitiesNamesWithBookingUserAndTimeslot()
	{
		var users = _usersCollection.AsQueryable().ToList();
		var facilities = _facilitiesCollection.AsQueryable().ToList();
		var bookings = _bookingsCollection.AsQueryable().ToList();

		List<FFF> stuff = new();
		foreach (var booking in bookings)
		{
			string nam = "hej";
			string usr = "bruh";
			string time = "nulltime";

			foreach (var facility in facilities)
			{
				if (facility.facilityID == booking.facilityID)
				{
					nam = facility.facilityName;
					time = booking.hourInterval;
				}
			}

			foreach (var user in users)
			{
				if (user.userID == booking.userID)
					usr = user.name;
			}

			stuff.Add(new FFF { name = nam, user = usr, timeslot = time });
		}

		return stuff;
	}

	public async Task<ActionResult<IEnumerable<FFFFF>>> GetListOfCPRs()
	{
		var bookings = _bookingsCollection.AsQueryable().ToList();

		List<FFFFF> stuff = new();
		foreach (var booking in bookings)
		{
			int bookingId = booking.bookingID;
			List<CPR> cpr = new();

			foreach (CPR cPR in booking.CPR)
			{
				cpr.Add(cPR);
			}

			stuff.Add(new FFFFF{ bookingID = bookingId, cpr = cpr});
		}

		return stuff;
	}

	public async Task<ActionResult<IEnumerable<FFFF>>> GetListOfMaintenances()
	{
		var facilities = _facilitiesCollection.AsQueryable().ToList();

		List<FFFF> stuff = new();
		foreach (Facility facility in facilities)
		{
			foreach (Item item in facility.items)
			{
				foreach (Maintainance maintainance in item.maintainances)
				{
					stuff.Add(new FFFF { 
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
