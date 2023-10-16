using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using arsp.Models;
using arsp.Repositories;

namespace arsp.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorsRepository _visitorsRepository;

        public VisitorsController(IVisitorsRepository VisitorsRepository)
        {
            _visitorsRepository = VisitorsRepository;
        }

        [HttpGet("/visitors/getall")]

        public async Task<ActionResult<IEnumerable<Visitors>>> GetAll()
        {
            var visData = await _visitorsRepository.GetAll();
            return Ok(visData);
        }

        [HttpGet("/visitors/topten")]

        public async Task<ActionResult<IEnumerable<Visitors>>> GetTopTen()
        {
            var visData = await _visitorsRepository.GetTopVisited();
            return Ok(visData);
        }
    }
}
