using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MySteamApp.API.Core.Interfaces
{
    public interface IHttpClient
    {
		Task<HttpResponseMessage> GetAsync(string path);
		Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}
