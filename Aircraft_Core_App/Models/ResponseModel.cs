using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircraft_Core_App.Models
{
        public class FlightSegments
        {
            public string origin { get; set; }
            public string destination { get; set; }
            public DateTime onwardDate { get; set; }
            public DateTime returnDate { get; set; }
            public string airline { get; set; }
            public string flightNumber { get; set; }
            public string flightType { get; set; }

        }
        public class FlightDetails
        {
            public IList<FlightSegments> flightSegments { get; set; }

        }
        public class Application
        {           
            public IList<FlightDetails> flightDetails { get; set; }

        }
    
}
