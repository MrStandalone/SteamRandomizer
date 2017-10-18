using MySteamApp.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace MySteamApp.API.Core.Classes
{
	public class HttpClientAdaptor : IHttpClient
	{
		HttpClient _httpClient = new HttpClient();

		public async Task<HttpResponseMessage> GetAsync(string path)
		{
			return await _httpClient.GetAsync(path);
		}

		public async Task<HttpResponseMessage> GetAsync(Uri uri)
		{
			return await _httpClient.GetAsync(uri);
		}
	}
}
