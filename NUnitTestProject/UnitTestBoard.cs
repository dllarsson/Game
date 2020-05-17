using NUnit.Framework;
using SudokuClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTestProject
{
    public class Tests
    {
        [Test]
        public void TestThatListIsRandom()
        {
            Board b = new Board();

            List<int> orderdList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var randomList = b.GetRandomIndices();
            Assert.AreNotEqual(orderdList, randomList);
        }
        [Test]
        public void TestThatAllBoxesOnlyContainsNumberOnce()
        {
            Board b = new Board();

            b.FillBoard();
            b.SolveBoard();

            List<int[]> boxes = new List<int[]>();
            boxes.Add(b.GetCurrentBoxNumbers(0, 0));
            boxes.Add(b.GetCurrentBoxNumbers(0, 3));
            boxes.Add(b.GetCurrentBoxNumbers(0, 6));

            boxes.Add(b.GetCurrentBoxNumbers(3, 0));
            boxes.Add(b.GetCurrentBoxNumbers(3, 3));
            boxes.Add(b.GetCurrentBoxNumbers(3, 6));

            boxes.Add(b.GetCurrentBoxNumbers(6, 0));
            boxes.Add(b.GetCurrentBoxNumbers(6, 3));
            boxes.Add(b.GetCurrentBoxNumbers(6, 6));

            int counter = 0;
            foreach (var box in boxes)
            {
                var n = box.GroupBy(e => e).Where(e => ((e.Count() > 1) && (e.Key > 0))).Select(e => e.First());
                if (n.Count() > 0)
                {
                    
                    counter++;
                }
            }

            if (counter > 0)
            {
                Assert.Fail();
            }
        }
    }
}