using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aircraft_Core_App.Models;
using Aircraft_Core_App.Services;

namespace Aircraft_Core_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostManServices _postManServices;

        /// <summary>
        /// Dependency Injection achived through constructor 
        /// </summary>
        /// <param name="postManServices"></param>
        public HomeController(IPostManServices postManServices)
        {
            _postManServices = postManServices;
        }

        /// <summary>
        /// Get the home page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// This method is for making a http call to main service layer 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Application>> FlightSearch(FlightFormModel viewModel)
        {
            var flightData = new Application();            
            try
            {
                flightData = await _postManServices.GetFlightDetails(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;

            }            
            return PartialView("ResponseView", flightData);
        }
    }
}
