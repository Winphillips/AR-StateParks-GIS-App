using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using arsp.Models;


namespace arsp.Data
{
    public interface IDataContext
    {
        DbSet<Visitors> Visitors { get; set; }

        int SaveChanges();
    }
}