using Assignment2.Controllers;
using Assignment2.Models;
using Assignment2.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Assignment2.Services;

public class FacilitiesService
{
	private readonly IMongoCollection<Facility> _facilitiesCollection;

	public FacilitiesService(
		IOptions<mongoDBSettings> mongoDbSettings)
	{
		var mongoClient = new MongoClient(
			mongoDbSettings.Value.ConnectionString);

		var mongoDatabase = mongoClient.GetDatabase(
			mongoDbSettings.Value.DatabaseName);

		_facilitiesCollection = mongoDatabase.GetCollection<Facility>(
			mongoDbSettings.Value.FacilitiesCollectionName);
	}

	public async Task<ActionResult<IEnumerable<F>>> GetFacilityNamesAndAddresses()
	{
		var stuff = from f in _facilitiesCollection.AsQueryable()
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
		var stuff = from f in _facilitiesCollection.AsQueryable()
					select new FF
					{
						name = f.facilityName,
						address = f.coordinates,
						kind = f.kind,
					};
		return await stuff.ToListAsync();
	}

	public async Task<ActionResult<IEnumerable<FFF>>> GetBookedFacilitiesNamesWithBookingUserAndTimeslot()
	{
		var stuff = _facilitiesCollection.AsQueryable()
			.Where(f => f.bookings != null)
			.Select(f => new FFF
			{
				name = f.facilityName,
				user = f.bookings
					.Select(ff => ff.user)
					.Distinct()
					.ToList(),
				timeslot = f.bookings
					.GroupBy(ff => ff.userID)
					.Select(ff => ff
						.Select(fff => fff.hourInterval)
						.First())
					.ToList(),
			});

		return await stuff.ToListAsync();
	}

	public async Task<ActionResult<IEnumerable<List<CPR>>>> GetListOfCPRs()
	{
		var stuff = _facilitiesCollection.AsQueryable()
			.Select(b => b.CPR);

		return await stuff.ToListAsync();
	}

	public async Task<ActionResult<IEnumerable<FFFF>>> GetListOfMaintenances()
	{
		var stuff = _facilitiesCollection.AsQueryable()
			.Select(b => new FFFF
			{
				date = b.date,
				description = b.description,
				itemID = b.itemID
			});

		return await stuff.ToListAsync();
	}
}
