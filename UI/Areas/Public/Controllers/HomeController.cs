using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using UI.Areas.Public.Models;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	public class HomeController : Controller
	{
		static string connectionString = "Data Source=DESKTOP-182AIPK\\SQLEXPRESS;Initial Catalog=TestDB8;Integrated security=true;TrustServerCertificate=True;";

		public IActionResult Index()
		{
			return View();
		}

		[Route("robots.txt")]
		public IActionResult Robots()
		{
			string filename;
			if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
			{
				filename = "robotsDevelopment.txt";
			}
			else
			{
				filename = "robotsProduction.txt";
			}
			
			string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
			byte[] filedata = System.IO.File.ReadAllBytes(filepath);
			string contentType = "text/plain";

			return File(filedata, contentType);
		}

		public IActionResult ClientPurchase(string status)
		{
			string sqlExpression = "PurchInfo";

			int purchCount = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);
				command.Parameters.AddWithValue("@name", status);
				command.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				command.CommandType = System.Data.CommandType.StoredProcedure;

				var reader = command.ExecuteReader();


				purchCount = (int)command.Parameters["@count"].Value;
			}

			return View(purchCount);
		}

		public IActionResult SubInfoMethod(int price)
		{
			string sqlExpression = "SubsInfo";


			List<SubInfoViewModel> subInfoViewModel = new List<SubInfoViewModel>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);

				command.Parameters.AddWithValue("@price", price);

				command.CommandType = System.Data.CommandType.StoredProcedure;
				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						SubInfoViewModel view3row = new SubInfoViewModel
						{
							name = reader.GetString(1),
							duration = reader.GetInt32(3),
						};

						subInfoViewModel.Add(view3row);
					}
				}
				reader.Close();

			}

			return View(subInfoViewModel);
		}

		public IActionResult CountSch()
		{
			string sqlExpression = "SELECT * FROM CountSch";


			List<CountSchViewModel> countschViewModel = new List<CountSchViewModel>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						CountSchViewModel view3row = new CountSchViewModel
						{
							name = reader.GetString(0),
							CountSch = reader.GetInt32(1),
						};

						countschViewModel.Add(view3row);
					}
				}
				reader.Close();

			}

			return View(countschViewModel);
		}

		public IActionResult CountEQ()
		{
			string sqlExpression = "SELECT * FROM CountEq";


			List<CountEqViewModel> countEqViewModel = new List<CountEqViewModel>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						CountEqViewModel view3row = new CountEqViewModel
						{
							name = reader.GetString(0),
							CountEq = reader.GetInt32(1),
						};

						countEqViewModel.Add(view3row);
					}
				}
				reader.Close();

			}

			return View(countEqViewModel);
		}

	}
}