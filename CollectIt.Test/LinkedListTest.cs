using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollectIt.Test
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void Can_Add_After()
        {
            LinkedList<string> list = new LinkedList<string>();

            list.AddFirst("Hello");
            list.AddLast("World");
            list.AddBefore(list.Last, "there");

            Assert.AreEqual("there", list.First.Next.Value);
        }

        [TestMethod]
        public void Can_Remoe_Last()
        {
            LinkedList<string> list = new LinkedList<string>();

            list.AddFirst("Hello");
            list.AddLast("World");
            //list.RemoveLast();
            //list.RemoveFirst();
            list.Remove("Hello"); //su visais siaip rebus testas praeis

            Assert.AreEqual(list.Last, list.First);
        }

        [TestMethod]
        public void Can_Find_Items()
        {
            LinkedList<string> list = new LinkedList<string>();

            list.AddFirst("Hello");
            list.AddLast("World");
            list.AddAfter(list.First, "there");


            Assert.IsTrue(list.Contains("there"));
        }
    }
}
