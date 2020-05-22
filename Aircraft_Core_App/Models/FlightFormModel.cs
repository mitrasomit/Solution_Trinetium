using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircraft_Core_App.Models
{
    public class FlightFormModel
    {
        public string Origin { get; set; }
        public string Designation { get; set; }
        public DateTime OnwardDate { set; get; }
        public DateTime ReturnDate { set; get; }        
        
    }
}
