using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollectIt.Test
{
    [TestClass]
    public class SortedTest
    {
        [TestMethod]
        public void Can_Use_Sorted_List()
        {
            var list = new SortedList<int, string>();

            list.Add(3, "Three");
            list.Add(4, "four");
            list.Add(1, "one");
            list.Add(2, "Two");

            Assert.AreEqual(2, list.IndexOfKey(3));
            Assert.AreEqual(3, list.IndexOfValue("four"));
        }

        [TestMethod]
        public void Can_Use_Sorted_Set()
        {
            var list = new SortedSet<int>();  //tik unikalios value ir bus numeric order

            list.Add(3);
            list.Add(4);
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(1);

            Assert.AreEqual(4, list.Count);
            Assert.IsTrue(list.SetEquals(new List<int>() { 3, 4, 1, 2 }));

            var enumerator = list.GetEnumerator();
            Assert.AreEqual(enumerator.Current, 0);
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current, 1);


        }
    }
}
