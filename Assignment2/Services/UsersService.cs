using Assignment2.Controllers;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Assignment2.Services;

public class UsersService
{
	private readonly IMongoCollection<User> _usersCollection;

	public UsersService(
		IOptions<mongoDBSettings> mongoDbSettings)
	{
		var mongoClient = new MongoClient(
			mongoDbSettings.Value.ConnectionString);

		var mongoDatabase = mongoClient.GetDatabase(
			mongoDbSettings.Value.DatabaseName);

		_usersCollection = mongoDatabase.GetCollection<User>(
			mongoDbSettings.Value.UsersCollectionName);
	}

	public async Task<ActionResult<IEnumerable<User>>> GetUsers() =>
		await _usersCollection.Find(_ => true).ToListAsync();
}
