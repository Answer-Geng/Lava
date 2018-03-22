using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lava.Entity;
using System.Linq;

namespace Lava.UnitTest.EntityLayer
{
    [TestClass]
    public class EntityFramework
    {
        [TestMethod]
        public void UserQuery()
        {
            var context = new LavaEntities();
            var users = context.LAVA_USER.Where(u => u.USERNAME == "Admin").ToList();
            Assert.AreEqual(1, users.Count());
           
        }
    }
}
