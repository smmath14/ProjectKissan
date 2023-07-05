using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissanSarthi.Models;
using KissanSarthiPro.Models;

namespace KissanSarthi.Models
{
    public class DbCtx: DbContext
    {
        public DbCtx(DbContextOptions<DbCtx> options) : base(options)
        {

        }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<UserInput> AgriShow { get; set; }
        public List<UserInput> SearchAgri(Filter req)
        {
            return this.AgriShow.FromSql("EXECUTE UserFilter @p0,@p1,@p2,@p3,@p4,@p5", new[] { req.Country, req.State, req.City, req.Area_of_land.ToString(), req.Type_of_Crops, req.Categories_of_Crops }).ToList();
        }
        public DbSet<KissanSarthi.Models.Filter> Filter { get; set; }
        
    }
}
