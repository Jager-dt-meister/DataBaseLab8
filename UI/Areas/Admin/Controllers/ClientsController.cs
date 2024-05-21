﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Enums;
using Common.Search;
using BL;
using UI.Areas.Admin.Models;
using UI.Areas.Admin.Models.ViewModels;
using UI.Other;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = nameof(UserRole.Admin))]
	public class ClientsController : Controller
	{
		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var searchResult = await new ClientsBL().GetAsync(new ClientsSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModel = new SearchResultViewModel<ClientModel>(ClientModel.FromEntitiesList(searchResult.Objects), 
				searchResult.Total, searchResult.RequestedStartIndex, searchResult.RequestedObjectsCount, 5);
			return View(viewModel);
		}

		public async Task<IActionResult> Update(int? id)
		{
			var model = new ClientModel();
			if (id != null)
			{
				model = ClientModel.FromEntity(await new ClientsBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			return View(model);
		}


		public async Task<IActionResult> Select(int? id)
		{
			var model = new ClientModel();
			if (id != null)
			{
				model = ClientModel.FromEntity(await new ClientsBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			const int objectsPerPage = 20;
			var PurchsearchResult = await new PurchasesBL().GetAsync(new PurchasesSearchParams
			{
				StartIndex = 0,
				ObjectsCount = objectsPerPage,
			});
			var PurchviewModel = new SearchResultViewModel<PurchaseModel>(PurchaseModel.FromEntitiesList(PurchsearchResult.Objects),
				PurchsearchResult.Total, PurchsearchResult.RequestedStartIndex, PurchsearchResult.RequestedObjectsCount, 5);

			var ClientPurchsearchResult = await new ClientsBL().GetAsync(new ClientsSearchParams
			{
				StartIndex = 0,
				ObjectsCount = objectsPerPage,
			});
			var ClientPurchviewModel = new SearchResultViewModel<ClientModel>(ClientModel.FromEntitiesList(ClientPurchsearchResult.Objects),
				ClientPurchsearchResult.Total, ClientPurchsearchResult.RequestedStartIndex, ClientPurchsearchResult.RequestedObjectsCount, 5);
			var viewModel = new ClientViewModel
			{
				purchase_model = PurchviewModel,
				client_model = ClientPurchviewModel
			};
			ViewBag.Client = model;
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(ClientModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await new ClientsBL().AddOrUpdateAsync(ClientModel.ToEntity(model));
			TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var result = await new ClientsBL().DeleteAsync(id);
			if (result)
				TempData[OperationResultType.Success.ToString()] = "Объект удален";
			else
				TempData[OperationResultType.Error.ToString()] = "Объект не найден";
			return RedirectToAction("Index");
		}
	}
}
