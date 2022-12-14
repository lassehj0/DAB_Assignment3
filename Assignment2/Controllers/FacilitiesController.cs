using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using Assignment2.Views;
using Assignment2.Services;

namespace Assignment2.Controllers
{
	public class F
	{
		public string name { get; set; }
		public double[] address { get; set; }
	}

	public class FF
	{
		public string name { get; set; }
		public double[] address { get; set; }
		public string kind { get; set; }
	}

	public class FFF
	{
		public string name { get; set; }
		public string user { get; set; }
		public string timeslot { get; set; }
	}

	public class FFFF
	{
		public string date { get; set; }
		public string description { get; set; }
		public int itemID { get; set; }
	}

	public class FFFFF
	{
		public int bookingID { get; set; }
		public List<CPR> cpr { get; set; }
	}

	[Route("api/[controller]")]
	[ApiController]
	public class FacilitiesController : ControllerBase
	{
		private readonly FacilitiesService _facilitiesService;

		public FacilitiesController(FacilitiesService facilitiesService) =>
			_facilitiesService = facilitiesService;

		// GET: api/Facilities
		[HttpGet]
		public async Task<ActionResult<IEnumerable<F>>> GetFacilityNamesAndAddresses() =>
			await _facilitiesService.GetFacilityNamesAndAddresses();

		[HttpGet]
		[Route("idkman")]
		public async Task<ActionResult<IEnumerable<FF>>> GetFacilityNamesAndAddressesAndKinds() =>
			await _facilitiesService.GetFacilityNamesAndAddressesAndKinds();


		[HttpGet]
		[Route("stopaskingfornewnames")]
		public async Task<ActionResult<IEnumerable<FFF>>> GetBookedFacilitiesNamesWithBookingUserAndTimeslot() =>
			await _facilitiesService.GetBookedFacilitiesNamesWithBookingUserAndTimeslot();

		[HttpGet]
		[Route("bruh")]
		public async Task<ActionResult<IEnumerable<FFFFF>>> GetListOfCPRs() =>
			await _facilitiesService.GetListOfCPRs();

		[HttpGet]
		[Route("bruh2")]
		public async Task<ActionResult<IEnumerable<FFFF>>> GetListOfMaintenances() =>
			await _facilitiesService.GetListOfMaintenances();
	}
}
