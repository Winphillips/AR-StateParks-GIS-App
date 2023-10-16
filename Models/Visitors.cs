using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arsp.Models
{
    public class Visitors
    {
        public int id { get; set; }
        public string statepark  { get; set; } = "";
        public string county  { get; set; } = "";
        public int averagemonthlyvisitors  { get; set; }
        public string? riverlake  { get; set; } = "";
        public int size  { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}