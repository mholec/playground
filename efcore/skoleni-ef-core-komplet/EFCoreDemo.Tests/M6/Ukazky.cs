using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreDemo.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreDemo.Tests.M6
{
    /// <summary>
    /// Všechny příklady pro M6
    /// </summary>
    [TestClass]
    public class Ukazky
    {
        private DemoDbContext context;

        [TestInitialize]
        public void TestInitialize()
        {
            context = new DemoDbContext();
        }

        [TestMethod]
        [Description("SaveChanges a Change Tracking")]
        public void SaveChangesChangeTracking()
        {
        }
    }
}
