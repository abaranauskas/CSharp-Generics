using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CollectIt.Test
{
	[TestClass]
	public class QueueTest
	{
		[TestMethod]
		public void Can_Peek_At_The_Item_in_the_Line()
		{
            var queue = new Queue<int>();

            queue.Enqueue(747);
            queue.Enqueue(12);
            queue.Enqueue(23);

            Assert.AreEqual(queue.Peek(), 747);
        }


        [TestMethod]
        public void Can_Search_with_Contains()
        {
            var queue = new Queue<int>();

            queue.Enqueue(747);
            queue.Enqueue(12);
            queue.Enqueue(23);

            Assert.IsTrue(queue.Contains(23));
        }


        [TestMethod]
        public void Can_Convert_Queue_to_Array()
        {
            var queue = new Queue<int>();

            queue.Enqueue(747);
            queue.Enqueue(12);
            queue.Enqueue(23);

            int[] array = queue.ToArray();


            Assert.AreEqual(queue.Peek(), array[0]);
            Assert.AreEqual(747, array[0]);
            queue.Dequeue();
            Assert.AreEqual(747, array[0]);
            Assert.AreEqual(queue.Peek(), 12);
            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(2, queue.Count);

        }

    }
}
