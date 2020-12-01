using ExpenseReport;
using Xunit;

namespace ExpenseReportTest
{
    public class ExpenseReportTest
    {
        [Fact]
        public void TestCalculateExpenseReportWith2Numbers()
        {
            Assert.Equal(514579, ExpenseReportApp.CalculateExpenseReportWith2Numbers(new int[] { 1721, 979, 366, 299, 675, 1456 }));
        }

        [Fact]
        public void TestCalculateExpenseReportWith3Numbers()
        {
            Assert.Equal(241861950, ExpenseReportApp.CalculateExpenseReportWith3Numbers(new int[] { 1721, 979, 366, 299, 675, 1456 }));
        }
    }
}
