using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
            :base("name=BAUConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Models.Engineer> Engineer { get; set; }
        public DbSet<Models.Calendar> Calendar { get; set; }
    }
}
