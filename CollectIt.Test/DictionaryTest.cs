using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollectIt.Test
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void Can_Use_Dictionary_As_A_Map()
        {
            var map = new Dictionary<int, string>();

            map.Add(1, "one");
            map.Add(2, "two");

            Assert.AreEqual("one", map[1]);
        }

        [TestMethod]
        public void Can_Search_Key_with_ContainsKey()
        {
            var map = new Dictionary<int, string>();

            map.Add(1, "one");
            map.Add(2, "two");

            Assert.IsTrue(map.ContainsKey(2));
            Assert.IsTrue(map.ContainsValue("one"));
        }

        [TestMethod]
        public void Can_Remoe_By_Key()
        {
            var map = new Dictionary<int, string>();

            map.Add(1, "one");
            map.Add(2, "two");           

            Assert.AreEqual(2, map.Count);
            map.Remove(2);
            Assert.AreEqual(1, map.Count);

        }
    }
}
