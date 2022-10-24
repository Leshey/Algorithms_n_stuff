using Xunit;

namespace B_Tree_Tests;

public class BTreeCell_Tests
{
    [Fact]
    public void GetMedianNumTest()
    {
        var cell = new BTreeCell(2);
        cell.Next = new BTreeCell(3);
        cell.Next.Next = new BTreeCell(5);
        cell.Next.Next.Next = new BTreeCell(7);
        cell.Next.Next.Next.Next = new BTreeCell(10);

        var expectedMedian1 = cell.GetMedianNum(1, 5);
        var expectedMedian2 = cell.GetMedianNum(8, 5);

        //Assert.Equal(5, expectedMedian1);
        Assert.Equal(7, expectedMedian2);
    }
}
