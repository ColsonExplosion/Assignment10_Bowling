﻿using Assignment10_Bowling.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10_Bowling.Infrastructure
{
	//tag helpers to create the pagination dynamically in the html

	[HtmlTargetElement("div", Attributes = "page-info")]
	public class PaginationTagHelper : TagHelper
	{
		private IUrlHelperFactory urlInfo;
		public PaginationTagHelper (IUrlHelperFactory uhf)
		{
			urlInfo = uhf;
		}

		public PageNumberingInfo PageInfo { get; set; }
		

		[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
		public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

		[HtmlAttributeNotBound]
		[ViewContext]
		public ViewContext ViewContext { get; set; }

		public bool PageClassesEnabled { get; set; } = false;
		public string PageClass { get; set; }
		public string PageClassNormal { get; set; }
		public string PageClassesSelected { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{

			IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext);

			TagBuilder finishedTag = new TagBuilder("div");
			

			for (int i = 1; i <= PageInfo.NumPages; i++)
			{
				TagBuilder individualTag = new TagBuilder("a");

				KeyValuePairs["pageNum"] = i;
				individualTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);

				if (PageClassesEnabled)
				{
					individualTag.AddCssClass(PageClass);
					individualTag.AddCssClass(i == PageInfo.CurrentPage ? PageClassesSelected : PageClassNormal);

				}

				individualTag.InnerHtml.Append(i.ToString());

				finishedTag.InnerHtml.AppendHtml(individualTag);
			}

			output.Content.AppendHtml(finishedTag.InnerHtml);

		}
	}
}
