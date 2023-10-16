using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arsp.Models;

namespace arsp.Repositories
{
    public interface IVisitorsRepository
    {
        Task<IEnumerable<Visitors>> GetAll();
        
        Task<IEnumerable<Visitors>> GetTopVisited();
    }
}