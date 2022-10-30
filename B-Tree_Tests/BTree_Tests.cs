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

        Assert.Equal(3, expectedMedian1);
        Assert.Equal(7, expectedMedian2);
    }

    [Fact]
    public void InsertValueTest()
    {
        var cell = new BTreeCell(3);
        cell.Next = new BTreeCell(6);

        cell = cell.InsertCell(5);
        cell = cell.InsertCell(7);
        cell = cell.InsertCell(1);

        var expectedValue1 = cell.Value;
        var expectedValue2 = cell.Next.Next.Value;
        var expectedValue3 = cell.Next.Next.Next.Next.Value;

        //var expectedCellCount = cell.GetCellCount();
        
        Assert.Equal(1, expectedValue1);
        Assert.Equal(5, expectedValue2);
        Assert.Equal(7, expectedValue3);
        //Assert.Equal(5, expectedCellCount);
    }

}
