using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollectIt.Test
{
    [TestClass]
    public class HashSetTest
    {
        [TestMethod]
        public void Intersect_Set()
        {
            HashSet<int> set1 = new HashSet<int>() {1,2,3 };
            HashSet<int> set2 = new HashSet<int>() { 2,3,4 };

            set1.IntersectWith(set2);

            Assert.IsTrue(set1.SetEquals(new HashSet<int> { 2, 3 }));
        }

        [TestMethod]
        public void Union_Set()
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int>() { 2, 3, 4 };

            set1.UnionWith(set2);

            Assert.IsTrue(set1.SetEquals(new HashSet<int> { 1,2, 3,4 }));
        }

        [TestMethod]
        public void SymetricExceptWith_Set()
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int>() { 2, 3, 4 };

            set1.SymmetricExceptWith(set2);

            Assert.IsTrue(set1.SetEquals(new HashSet<int> {1,4 }));
        }
    }
}
