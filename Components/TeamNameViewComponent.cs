using Assignment10_Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10_Bowling.Components
{
	public class TeamNameViewComponent : ViewComponent
	{
		private BowlingLeagueContext context;
		public TeamNameViewComponent(BowlingLeagueContext ctx)
		{
			context = ctx;
		}
		public IViewComponentResult Invoke()
		{
			//viewbag for category highlighting
			ViewBag.SelectedTeam = RouteData?.Values["teamname"];

			//returns teams in order
			return View(context.Teams
				.Distinct()
				.OrderBy(x => x));
		}
	}
}
