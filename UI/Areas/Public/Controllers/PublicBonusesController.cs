using BL;
using Common.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Areas.Admin.Models.ViewModels;
using UI.Areas.Admin.Models;

namespace UI.Areas.Public.Controllers
{
	public class PublicBonusesController : Controller
	{
		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var searchResult = await new BonusesBL().GetAsync(new BonusesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModel = new SearchResultViewModel<BonuseModel>(BonuseModel.FromEntitiesList(searchResult.Objects),
				searchResult.Total, searchResult.RequestedStartIndex, searchResult.RequestedObjectsCount, 5);
			return View(viewModel);
		}
	}
}
