using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using Assignment2.Services;
using Assignment2.Models.DTO;

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
		public List<User> user { get; set; }
		//public List<string> timeslot { get; set; }
	}

	public class FFFF
	{
		public string date { get; set; }
		public string description { get; set; }
		public int itemID { get; set; }
	}

	[Route("api/[controller]")]
	[ApiController]
	public class FacilitiesController : ControllerBase
	{
		private readonly Service _service;

		public FacilitiesController(Service facilitiesService) =>
			_service = facilitiesService;

		// GET: api/Facilities
		[HttpGet]
		public async Task<ActionResult<IEnumerable<F>>> GetFacilityNamesAndAddresses() =>
			await _service.GetFacilityNamesAndAddresses();

		[HttpGet]
		[Route("idkman")]
		public async Task<ActionResult<IEnumerable<FF>>> GetFacilityNamesAndAddressesAndKinds() =>
			await _service.GetFacilityNamesAndAddressesAndKinds();


		[HttpGet]
		[Route("stopaskingfornewnames")]
        public async Task<List<BookingDTO>> GetBookedFacilitiesNamesWithBookingUserAndTimeslot() =>
			await _service.GetBookedFacilitiesNamesWithBookingUserAndTimeslot();

        [HttpGet]
        [Route("GetBookingsWithCPR")]
        public async Task<List<CPRDTO>> GetBookingsWithCPR() =>
			await _service.GetBookingsWithCPR();

        [HttpGet]
        [Route("bruh2")]
        public async Task<ActionResult<IEnumerable<FFFF>>> GetListOfMaintenances() =>
			await _service.GetListOfMaintenances();
    }
}
