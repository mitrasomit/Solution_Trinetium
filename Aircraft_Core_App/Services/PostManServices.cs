using Aircraft_Core_App.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aircraft_Core_App.Services
{
    public class PostManServices : IPostManServices
    {

        private readonly IOptions<AppKeyValue> _appSettings;
        private readonly HttpClient _client;

        /// <summary>
        /// Here Dependencies are injected using Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="appKeyOptions"></param>
        public PostManServices(HttpClient httpClient, IOptions<AppKeyValue> appKeyOptions)
        {
            _client = httpClient;
            _appSettings = appKeyOptions;
        }

        /// <summary>
        /// This method is used to get the response from the main service
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task<Application> GetFlightDetails(FlightFormModel task)
        {
            var BaseUrl = _appSettings.Value.TangoServiceURL;
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Error on server side");
            }

            var createdTask = JsonConvert.DeserializeObject<Application>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }
    }
}
