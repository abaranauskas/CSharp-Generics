using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CollectIt.Test
{
    [TestClass]
    public class ListTest
    {
        [TestMethod]
        public void A_List_Can_Insert()
        {
            List<int> integers = new List<int> { 1, 2, 3 };

            integers.Insert(1, 6);

            Assert.AreEqual(6, integers[1]);
        }

        [TestMethod]
        public void A_List_Can_Remove()
        {
            List<int> integers = new List<int> { 1, 2, 3 };

            integers.Remove(2);

            Assert.AreEqual(3, integers[1]);
            Assert.IsTrue(integers.SequenceEqual(new[] { 1, 3 }));
        }

        [TestMethod]
        public void A_List_Can_Find()
        {
            List<int> integers = new List<int> { 13, 2, 3 };

            Assert.AreEqual(integers.IndexOf(13), 0);
          
        }
    }
}
