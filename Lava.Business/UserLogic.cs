using Lava.MSSQLDB;
using Lava.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Business
{
    public class UserLogic
    {
        private UserDao userDao = new UserDao();
        public bool IsValid(UserLoginInput userInput)
        {
            return userDao.GetUser(userInput).Count > 0 ? true : false;
        }
    }
}
