using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_For14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_For14.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void NoMatch()
        {
            int[] numbers = new int[] { 1, 2, 2, 3, 3, 3, 2, 2 };
            int n = 4;
            Assert.AreEqual(Logic.Execution(numbers, n), "Пары не найдены");
        }

        [TestMethod()]
        public void Match()
        {
            int[] numbers = new int[] { 1, 2, 2, 3, 3, 3, 2, 2 };
            int n = 3;
            Assert.AreEqual(Logic.Execution(numbers, n), "Номера первой найденной 3-ки: 4 5 6 ");
        }

        [TestMethod()]
        public void FewMatches()
        {
            int[] numbers = new int[] { 1, 2, 2, 3, 3, 3, 2, 2 };
            int n = 2;
            Assert.AreEqual(Logic.Execution(numbers, n), "Номера первой найденной 2-ки: 2 3 ");
        }
    }
}