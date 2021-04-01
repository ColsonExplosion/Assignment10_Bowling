using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//view model for the index

namespace Assignment10_Bowling.Models.ViewModels
{
	public class IndexViewModel
	{
		public List<Bowlers> Bowlers { get; set; }
		public PageNumberingInfo PageNumberingInfo { get; set; }

		public  string TeamCategory { get; set; }
		public long CurrentTeam { get; set; }

	}

	
}
