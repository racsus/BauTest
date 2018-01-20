using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Data
{
    public class Engineers
    {
        public IEnumerable<Models.Engineer> getList()
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                var res = db.Engineer.ToList();
                return res;
            }
        }
    }
}
