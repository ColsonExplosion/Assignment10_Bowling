using Assignment10_Bowling.Models;
using Assignment10_Bowling.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10_Bowling.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private BowlingLeagueContext context { get; set;}

		public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
		{
			_logger = logger;
			context = ctx;			
		}


		public IActionResult Index(long? teamnameid, string teamname = "All Teams", int pageNum = 0)
		{
			int pageSize = 5;
			

			return View(new IndexViewModel
			{
				//filters out bowlers by teams
				Bowlers = (context.Bowlers
				.Where(t => t.TeamId == teamnameid || teamnameid == null)
				.OrderBy(t => t.TeamId)
				.Skip((pageNum - 1) * pageSize)
				.Take(pageSize)
				.ToList()),


				//info for pagination
				PageNumberingInfo = new PageNumberingInfo
				{
					NumItemsPerPage = pageSize,
					CurrentPage = pageNum,
					TotalNumItems = (teamnameid == null ? context.Bowlers.Count() : context.Bowlers.Where(t => t.TeamId == teamnameid).Count()),
					CurrentTeam = teamnameid

				},



				TeamCategory = teamname
			}) ;

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
