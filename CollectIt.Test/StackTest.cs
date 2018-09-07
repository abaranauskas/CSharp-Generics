using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollectIt.Test
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void Can_Peek_At_The_Item_in_the_Line()
        {
            var stack = new Stack<int>();

            stack.Push(747);
            stack.Push(12);
            stack.Push(23);

            Assert.AreEqual(stack.Peek(), 23);
        }


        [TestMethod]
        public void Can_Search_with_Contains()
        {
            var stack = new Stack<int>();

            stack.Push(747);
            stack.Push(12);
            stack.Push(23);

            Assert.IsTrue(stack.Contains(747));
        }


        [TestMethod]
        public void Can_Convert_Stack_to_Array()
        {
            var stack = new Stack<int>();

            stack.Push(747);
            stack.Push(12);
            stack.Push(23);

            int[] array = stack.ToArray();


            Assert.AreEqual(stack.Peek(), array[0]);
            Assert.AreEqual(23, array[0]);
            stack.Pop();
            Assert.AreEqual(23, array[0]);
            Assert.AreEqual(stack.Peek(), 12);
            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(2, stack.Count);

        }
    }
}
