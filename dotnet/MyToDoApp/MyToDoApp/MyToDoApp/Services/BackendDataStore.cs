using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyToDoApp.Models;
using Newtonsoft.Json;

namespace MyToDoApp.Services
{
	public class BackendDataStore : IDataStore<Item>
	{
		public const string BACKEND_URL = "https://serverless-workshop-dotnet.azurewebsites.net/api/";

		public async Task<bool> AddItemAsync(Item item)
		{
			try
			{
				item.Id = Guid.NewGuid().ToString();

				var json = JsonConvert.SerializeObject(new[] { item });

				using (var httpClient = GetClient())
				{
					httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

					var result = await httpClient.PostAsync("ToDoPost",
									new StringContent(json, Encoding.UTF8,
									"application/json"));

					return result.IsSuccessStatusCode;
				}
			}
			catch (HttpRequestException ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}
		}

		private HttpClient GetClient()
		{
			return new HttpClient { BaseAddress = new Uri(BACKEND_URL) };
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			try
			{
				using (var httpClient = GetClient())
				{
					var json = await httpClient.GetStringAsync("ToDoGet");

					return JsonConvert.DeserializeObject<Item[]>(json);
				}
			}
			catch (HttpRequestException ex)
			{
				Debug.WriteLine(ex.Message);
				return new Item[0];
			}
		}

		public Task<bool> DeleteItemAsync(string id)
		{
			return Task.FromResult(false);
		}

		public Task<Item> GetItemAsync(string id)
		{
			return Task.FromResult(new Item());
		}

		public Task<bool> UpdateItemAsync(Item item)
		{
			return Task.FromResult(false);
		}
	}
}
