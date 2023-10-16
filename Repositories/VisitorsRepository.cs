using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using arsp.Models;
using arsp.Data;
using Newtonsoft.Json;

namespace arsp.Repositories
{
    public class VisitorsRepository : IVisitorsRepository
    {
        private readonly IDataContext _context;
        private readonly ILogger<VisitorsRepository> _logger;
        public VisitorsRepository(IDataContext context, ILogger<VisitorsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Visitors>> GetAll()
        {
            SaveData();
            return await _context.Visitors.ToListAsync();
        }

        public async Task<IEnumerable<Visitors>> GetTopVisited()
        {
            var q = _context.Visitors
                .OrderByDescending(avgVisitors => avgVisitors.averagemonthlyvisitors)
                .Take(10)
                .ToListAsync();

            return await q;
        }

        public void SaveData()
        {
            // Check if the table is empty before we load the data else skip the Extract Transform Load process
            var res_dataset = _context.Visitors.ToList();
            if (res_dataset.Count() == 0)
            {
                 _logger.LogError("No Data");
                 Console.WriteLine("No Data");
                // ENTER YOUR UNIQUE FILE PATH HERE \/
                var geoJSON = File.ReadAllText("FILE PATH");
                dynamic? jsonObj = JsonConvert.DeserializeObject(geoJSON);
                foreach (var feature in jsonObj["features"])
                {
                    // Extract values from the file object using the fields
                    string str_statepark = feature["properties"]["statepark"];
                    string str_county = feature["properties"]["county"];
                    string str_avgmonthlyvisitors = feature["properties"]["averagemonthlyvisitors"];
                    string str_riverlake = feature["properties"]["riverLake"];
                    string str_size = feature["properties"]["size"];
                    double dbl_latitude = feature["geometry"]["coordinates"][1];
                    double dbl_longitude = feature["geometry"]["coordinates"][0];

                    // Convert string to integer
                    int avgMthlyV = Convert.ToInt32(str_avgmonthlyvisitors);
                    int sizeInt = Convert.ToInt32(str_size);

                    // Load the data into our table
                    Visitors v = new()
                    {
                        statepark = str_statepark,
                        county = str_county,
                        averagemonthlyvisitors = avgMthlyV,
                        riverlake = str_riverlake,
                        size = sizeInt,
                        latitude = dbl_latitude,
                        longitude = dbl_longitude, 
                    };

                    _context.Visitors.Add(v);
                    
                }
            _context.SaveChanges();
            }
            else
            {
                _logger.LogError("Data Loaded");
            }
        }
    }
}