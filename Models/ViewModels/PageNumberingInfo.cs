using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10_Bowling.Models.ViewModels
{
	//info for pagination
	public class PageNumberingInfo
	{
		public int NumItemsPerPage { get; set; }
		public int CurrentPage { get; set; }
		public int TotalNumItems { get; set; }

		public long? CurrentTeam { get; set; }


		//Calculate Number of Pages
		public int NumPages => (int) (Math.Ceiling((decimal) TotalNumItems / NumItemsPerPage));


	}
}
