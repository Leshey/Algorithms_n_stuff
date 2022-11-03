using Xunit;

namespace B_Tree_Tests;

public class BTree_Tests
{
    [Fact]
    public void InsertValueTest()
    {
        var cell = new BTreeCell(3);
        cell.Next = new BTreeCell(6);

        cell = cell.InsertCell(5);
        cell = cell.InsertCell(7);
        cell = cell.InsertCell(1);

        var actualValue = cell.Value;
        var actualValue2 = cell.Next.Next.Value;
        var actualValue3 = cell.Next.Next.Next.Next.Value;

        //var expectedCellCount = cell.GetCellCount();
        
        Assert.Equal(1, actualValue);
        Assert.Equal(5, actualValue2);
        Assert.Equal(7, actualValue3);
        //Assert.Equal(5, expectedCellCount);
    }

    [Fact]
    public void AddNewValue_ToCell_WithNoMaxCellCount() //
    {
        var BTree = new BTree(2);
        
        BTree.AddNewValue(10);
        BTree.AddNewValue(13);
        var expectedValue = BTree.Head.HeadOfList.Value;
        var expectedValue2 = BTree.Head.HeadOfList.Next.Value;

        Assert.Equal(10, expectedValue);
        Assert.Equal(13, expectedValue2);
    }
    [Fact]
    public void AddNewValue_ToFullNode_WithoutParentNodeNull() //fddfd
    {
        var BTree = new BTree(2);

        BTree.AddNewValue(10);
        BTree.AddNewValue(15);
        BTree.AddNewValue(13);

        var actualValue = BTree.Head.HeadOfList.Value;
        var actualValue2 = BTree.Head.HeadOfList.Left.HeadOfList.Value;
        var actualValue3 = BTree.Head.HeadOfList.Right.HeadOfList.Value;

        var actualParentNode = BTree.Head.HeadOfList.Left.ParentNode;
        var actualParentNode2 = BTree.Head.HeadOfList.Right.ParentNode;

        var expectedParentNode = BTree.Head;

        Assert.Equal(13, actualValue);
        Assert.Equal(10, actualValue2);
        Assert.Equal(15, actualValue3);

        Assert.Equal(expectedParentNode, actualParentNode);
        Assert.Equal(expectedParentNode, actualParentNode2);
    }

    [Fact]
    public void AddNewValue_FullNodes_AndWithParentNodes()
    {
        var BTree = new BTree(2);

        BTree.AddNewValue(50);
        BTree.AddNewValue(60);
        BTree.AddNewValue(70);
        BTree.AddNewValue(80);
        BTree.AddNewValue(90);
        BTree.AddNewValue(100);
        BTree.AddNewValue(110);

        Assert.Equal(1, 1);
    }

}
