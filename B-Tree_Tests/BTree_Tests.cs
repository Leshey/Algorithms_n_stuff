using Xunit;

namespace B_Tree_Tests;

public class BTree_Tests
{
    //[Fact]
    //public void InsertValueTest()
    //{
    //    var cell = new BTreeCell(3);
    //    cell.Next = new BTreeCell(6);

    //    cell = cell.InsertCell(5);
    //    cell = cell.InsertCell(7);
    //    cell = cell.InsertCell(1);

    //    var actualValue = cell.Value;
    //    var actualValue2 = cell.Next.Next.Value;
    //    var actualValue3 = cell.Next.Next.Next.Next.Value;

    //    //var expectedCellCount = cell.GetCellCount();
        
    //    Assert.Equal(1, actualValue);
    //    Assert.Equal(5, actualValue2);
    //    Assert.Equal(7, actualValue3);
    //    //Assert.Equal(5, expectedCellCount);
    //}

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
    public void AddNewValue_FullNodes_AndWithParentNodes_Test_1()
    {
        var BTree = new BTree(2);

        BTree.AddNewValue(50);
        BTree.AddNewValue(60);
        BTree.AddNewValue(70);
        BTree.AddNewValue(80);
        BTree.AddNewValue(90);
        BTree.AddNewValue(100);
        BTree.AddNewValue(110);

        //head
        var expectedHeadOfTreeValue = 80;
        //left branch
        var expectedLeftOfHeadValue = 60;
        var expectedLeftOfLeftValue = 50;
        var expectedRightOfLeftValue = 70;
        var expectedParentForLeftOfHead = BTree.Head;
        var expectedParentForLeftOfLeft = BTree.Head.HeadOfList.Left;
        var expectedParentForRightOfLeft = BTree.Head.HeadOfList.Left;
        //right branch
        var expectedRightOfHeadValue = 100;
        var expectedLeftOfRightValue = 90;
        var expectedRightOfRightValue = 110;
        var expectedParentForRightOfHead = BTree.Head;
        var expectedParentForLeftOfRight = BTree.Head.HeadOfList.Right;
        var expectedParentForRightOfRight = BTree.Head.HeadOfList.Right;

        //head
        var actualHeadOfTreeValue = BTree.Head.HeadOfList.Value;
        //left branch
        var actualLeftOfHeadValue = BTree.Head.HeadOfList.Left.HeadOfList.Value;
        var actualLeftOfLeftValue = BTree.Head.HeadOfList.Left.HeadOfList.Left.HeadOfList.Value;
        var actualRightOfLeftValue = BTree.Head.HeadOfList.Left.HeadOfList.Right.HeadOfList.Value;
        var actualParentForLeftOfHead = BTree.Head.HeadOfList.Left.ParentNode;
        var actualParentForLeftOfLeft = BTree.Head.HeadOfList.Left.HeadOfList.Left.ParentNode;
        var actualParentForRightOfLeft = BTree.Head.HeadOfList.Left.HeadOfList.Right.ParentNode;
        //right branch
        var actualRightOfHeadValue = BTree.Head.HeadOfList.Right.HeadOfList.Value; 
        var actualLeftOfRightValue = BTree.Head.HeadOfList.Right.HeadOfList.Left.HeadOfList.Value; 
        var actualRightOfRightValue = BTree.Head.HeadOfList.Right.HeadOfList.Right.HeadOfList.Value; ;
        var actualParentForRightOfHead = BTree.Head.HeadOfList.Right.ParentNode;
        var actualParentForLeftOfRight = BTree.Head.HeadOfList.Right.HeadOfList.Left.ParentNode;
        var actualParentForRightOfRight = BTree.Head.HeadOfList.Right.HeadOfList.Right.ParentNode;

        //head
        Assert.Equal(expectedHeadOfTreeValue, actualHeadOfTreeValue);
        //left branch
        Assert.Equal(expectedLeftOfHeadValue, actualLeftOfHeadValue);
        Assert.Equal(expectedLeftOfLeftValue, actualLeftOfLeftValue);
        Assert.Equal(expectedRightOfLeftValue, actualRightOfLeftValue);
        Assert.Equal(expectedParentForLeftOfHead, actualParentForLeftOfHead);
        Assert.Equal(expectedParentForLeftOfLeft, actualParentForLeftOfLeft);
        Assert.Equal(expectedParentForRightOfLeft, actualParentForRightOfLeft);
        //right branch
        Assert.Equal(expectedRightOfHeadValue, actualRightOfHeadValue);
        Assert.Equal(expectedLeftOfRightValue, actualLeftOfRightValue);
        Assert.Equal(expectedRightOfRightValue, actualRightOfRightValue);
        Assert.Equal(expectedParentForRightOfHead, actualParentForRightOfHead);
        Assert.Equal(expectedParentForLeftOfRight, actualParentForLeftOfRight);
        Assert.Equal(expectedParentForRightOfRight, actualParentForRightOfRight);
    }

    [Fact]
    public void AddNewValue_FullNodes_AndWithParentNodes_Test_2()
    {
        var BTree = new BTree(2);

        BTree.AddNewValue(50);
        BTree.AddNewValue(40);
        BTree.AddNewValue(60);
        BTree.AddNewValue(20);
        BTree.AddNewValue(30);
        BTree.AddNewValue(35);
        BTree.AddNewValue(45);

        //head
        var expectedHeadOfTreeValue = 40;
        //left branch
        var expectedLeftOfHeadValue = 30;
        var expectedLeftOfLeftValue = 20;
        var expectedRightOfLeftValue = 35;
        var expectedParentForLeftOfHead = BTree.Head;
        var expectedParentForLeftOfLeft = BTree.Head.HeadOfList.Left;
        var expectedParentForRightOfLeft = BTree.Head.HeadOfList.Left;
        //right branch
        var expectedRightOfHeadValue = 50;
        var expectedLeftOfRightValue = 45;
        var expectedRightOfRightValue = 60;
        var expectedParentForRightOfHead = BTree.Head;
        var expectedParentForLeftOfRight = BTree.Head.HeadOfList.Right;
        var expectedParentForRightOfRight = BTree.Head.HeadOfList.Right;

        //head
        var actualHeadOfTreeValue = BTree.Head.HeadOfList.Value;
        //left branch
        var actualLeftOfHeadValue = BTree.Head.HeadOfList.Left.HeadOfList.Value;
        var actualLeftOfLeftValue = BTree.Head.HeadOfList.Left.HeadOfList.Left.HeadOfList.Value;
        var actualRightOfLeftValue = BTree.Head.HeadOfList.Left.HeadOfList.Right.HeadOfList.Value;
        var actualParentForLeftOfHead = BTree.Head.HeadOfList.Left.ParentNode;
        var actualParentForLeftOfLeft = BTree.Head.HeadOfList.Left.HeadOfList.Left.ParentNode;
        var actualParentForRightOfLeft = BTree.Head.HeadOfList.Left.HeadOfList.Right.ParentNode;
        //right branch
        var actualRightOfHeadValue = BTree.Head.HeadOfList.Right.HeadOfList.Value;
        var actualLeftOfRightValue = BTree.Head.HeadOfList.Right.HeadOfList.Left.HeadOfList.Value;
        var actualRightOfRightValue = BTree.Head.HeadOfList.Right.HeadOfList.Right.HeadOfList.Value; ;
        var actualParentForRightOfHead = BTree.Head.HeadOfList.Right.ParentNode;
        var actualParentForLeftOfRight = BTree.Head.HeadOfList.Right.HeadOfList.Left.ParentNode;
        var actualParentForRightOfRight = BTree.Head.HeadOfList.Right.HeadOfList.Right.ParentNode;

        Assert.Equal(1, 1);

        //head
        Assert.Equal(expectedHeadOfTreeValue, actualHeadOfTreeValue);
        //left branch
        Assert.Equal(expectedLeftOfHeadValue, actualLeftOfHeadValue);
        Assert.Equal(expectedLeftOfLeftValue, actualLeftOfLeftValue);
        Assert.Equal(expectedRightOfLeftValue, actualRightOfLeftValue);
        Assert.Equal(expectedParentForLeftOfHead, actualParentForLeftOfHead);
        Assert.Equal(expectedParentForLeftOfLeft, actualParentForLeftOfLeft);
        Assert.Equal(expectedParentForRightOfLeft, actualParentForRightOfLeft);
        //right branch
        Assert.Equal(expectedRightOfHeadValue, actualRightOfHeadValue);
        Assert.Equal(expectedLeftOfRightValue, actualLeftOfRightValue);
        Assert.Equal(expectedRightOfRightValue, actualRightOfRightValue);
        Assert.Equal(expectedParentForRightOfHead, actualParentForRightOfHead);
        Assert.Equal(expectedParentForLeftOfRight, actualParentForLeftOfRight);
        Assert.Equal(expectedParentForRightOfRight, actualParentForRightOfRight);
    }

    [Fact]
    public void AddNewValue_FullNodes_AndWithParentNodes_Test_3()
    {
        var BTree = new BTree(2);

        BTree.AddNewValue(110);
        BTree.AddNewValue(100);
        BTree.AddNewValue(90);
        BTree.AddNewValue(80);
        BTree.AddNewValue(70);
        BTree.AddNewValue(60);
        BTree.AddNewValue(50);

        //head
        var expectedHeadOfTreeValue = 80;
        //left branch
        var expectedLeftOfHeadValue = 60;
        var expectedLeftOfLeftValue = 50;
        var expectedRightOfLeftValue = 70;
        var expectedParentForLeftOfHead = BTree.Head;
        var expectedParentForLeftOfLeft = BTree.Head.HeadOfList.Left;
        var expectedParentForRightOfLeft = BTree.Head.HeadOfList.Left;
        //right branch
        var expectedRightOfHeadValue = 100;
        var expectedLeftOfRightValue = 90;
        var expectedRightOfRightValue = 110;
        var expectedParentForRightOfHead = BTree.Head;
        var expectedParentForLeftOfRight = BTree.Head.HeadOfList.Right;
        var expectedParentForRightOfRight = BTree.Head.HeadOfList.Right;

        //head
        var actualHeadOfTreeValue = BTree.Head.HeadOfList.Value;
        //left branch
        var actualLeftOfHeadValue = BTree.Head.HeadOfList.Left.HeadOfList.Value;
        var actualLeftOfLeftValue = BTree.Head.HeadOfList.Left.HeadOfList.Left.HeadOfList.Value;
        var actualRightOfLeftValue = BTree.Head.HeadOfList.Left.HeadOfList.Right.HeadOfList.Value;
        var actualParentForLeftOfHead = BTree.Head.HeadOfList.Left.ParentNode;
        var actualParentForLeftOfLeft = BTree.Head.HeadOfList.Left.HeadOfList.Left.ParentNode;
        var actualParentForRightOfLeft = BTree.Head.HeadOfList.Left.HeadOfList.Right.ParentNode;
        //right branch
        var actualRightOfHeadValue = BTree.Head.HeadOfList.Right.HeadOfList.Value;
        var actualLeftOfRightValue = BTree.Head.HeadOfList.Right.HeadOfList.Left.HeadOfList.Value;
        var actualRightOfRightValue = BTree.Head.HeadOfList.Right.HeadOfList.Right.HeadOfList.Value; ;
        var actualParentForRightOfHead = BTree.Head.HeadOfList.Right.ParentNode;
        var actualParentForLeftOfRight = BTree.Head.HeadOfList.Right.HeadOfList.Left.ParentNode;
        var actualParentForRightOfRight = BTree.Head.HeadOfList.Right.HeadOfList.Right.ParentNode;


        Assert.Equal(1, 1);

        //head
        Assert.Equal(expectedHeadOfTreeValue, actualHeadOfTreeValue);
        //left branch
        Assert.Equal(expectedLeftOfHeadValue, actualLeftOfHeadValue);
        Assert.Equal(expectedLeftOfLeftValue, actualLeftOfLeftValue);
        Assert.Equal(expectedRightOfLeftValue, actualRightOfLeftValue);
        Assert.Equal(expectedParentForLeftOfHead, actualParentForLeftOfHead);
        Assert.Equal(expectedParentForLeftOfLeft, actualParentForLeftOfLeft);
        Assert.Equal(expectedParentForRightOfLeft, actualParentForRightOfLeft);
        //right branch
        Assert.Equal(expectedRightOfHeadValue, actualRightOfHeadValue);
        Assert.Equal(expectedLeftOfRightValue, actualLeftOfRightValue);
        Assert.Equal(expectedRightOfRightValue, actualRightOfRightValue);
        Assert.Equal(expectedParentForRightOfHead, actualParentForRightOfHead);
        Assert.Equal(expectedParentForLeftOfRight, actualParentForLeftOfRight);
        Assert.Equal(expectedParentForRightOfRight, actualParentForRightOfRight);
    }
}
