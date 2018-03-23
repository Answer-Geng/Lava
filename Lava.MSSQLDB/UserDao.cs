using Lava.Entity;
using Lava.ViewModel.Login;
using System.Collections.Generic;
using System.Linq;

namespace Lava.MSSQLDB
{
    public class UserDao : BaseDao
    {
        public List<LAVA_USERS> GetUser(UserLoginInput userInput)
        {
            return db.LAVA_USERS.Where(u => u.USERNAME == userInput.UserName && u.PASSWORD == userInput.Password).ToList();
        }
    }
}
