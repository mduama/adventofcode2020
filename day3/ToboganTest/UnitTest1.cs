using System;
using Tobogan;
using Xunit;

namespace ToboganTest
{
    public class UnitTest1
    {
        private readonly ToboganApp app;
        private int numTrees1r1d;
        private int numTrees3r1d;
        private int numTrees5r1d;
        private int numTrees7r1d;
        private int numTrees1r2d;

        public UnitTest1()
        {
            app = new ToboganApp();
            numTrees1r1d = app.CountTrees("../../../input.txt", 1, 1);
            numTrees3r1d = app.CountTrees("../../../input.txt", 3, 1);
            numTrees5r1d = app.CountTrees("../../../input.txt", 5, 1);
            numTrees7r1d = app.CountTrees("../../../input.txt", 7, 1);
            numTrees1r2d = app.CountTrees("../../../input.txt", 1, 2);
        }

        [Fact]
        public void CountTreesTest()
        {
            Assert.Equal(2, numTrees1r1d);
            Assert.Equal(7, numTrees3r1d);
            Assert.Equal(3, numTrees5r1d);
            Assert.Equal(4, numTrees7r1d);
            Assert.Equal(2, numTrees1r2d);
            Assert.Equal(336, numTrees1r1d * numTrees3r1d * numTrees5r1d * numTrees7r1d * numTrees1r2d);
        }

        [Fact]
        public void ConvertAllInputsToMapTest()
        {
            var output = new int[2][];
            output[0] = new int[] { ToboganApp.open, ToboganApp.open, ToboganApp.tree, ToboganApp.tree, ToboganApp.open, ToboganApp.open, ToboganApp.open,
                ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.open };
            output[1] = new int[] { ToboganApp.tree, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.tree, ToboganApp.open, ToboganApp.open,
                ToboganApp.open, ToboganApp.tree, ToboganApp.open, ToboganApp.open };
            app.ConvertAllInputsToMap(new string[] { "..##.......", "#...#...#.." });
            Assert.Equal(output, app.ConvertedInputs);
        }

        [Fact]
        public void ConvertOneInputToMapTest()
        {
            var output = new int[] { ToboganApp.open, ToboganApp.tree, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.open,
                ToboganApp.open, ToboganApp.open, ToboganApp.tree, ToboganApp.open, ToboganApp.open, ToboganApp.tree, ToboganApp.tree, ToboganApp.tree,
                ToboganApp.tree, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.tree, ToboganApp.open,
                ToboganApp.open, ToboganApp.tree, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.open, ToboganApp.open,
                ToboganApp.open };
            Assert.Equal(output, app.ConvertOneInputToMap(".#......#..####.....#..#......."));
        }

        [Fact]
        public void GetLocationItemTest()
        {
            Assert.Equal(ToboganApp.open, app.GetLocationItem(new int[] { 0, 0 }));
            Assert.Equal(ToboganApp.tree, app.GetLocationItem(new int[] { 0, 3 }));
            Assert.Equal(ToboganApp.tree, app.GetLocationItem(new int[] { 1, 11 }));
            Assert.Equal(ToboganApp.open, app.GetLocationItem(new int[] { 1, 3 }));
            Assert.Equal(ToboganApp.tree, app.GetLocationItem(new int[] { 2, 6 }));
            Assert.Equal(ToboganApp.open, app.GetLocationItem(new int[] { 3, 9 }));
        }
    }
}
