using Lava.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.MSSQLDB
{
    public class BaseDao
    {
        protected LavaEntities db = new LavaEntities();
    }
}
