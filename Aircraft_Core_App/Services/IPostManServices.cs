using Aircraft_Core_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircraft_Core_App.Services
{
   public interface IPostManServices
    {
        /// <summary>
        /// This method is used to get the response from the PostManServices
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<Application> GetFlightDetails(FlightFormModel task);
    }
}
