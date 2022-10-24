using System;
using Xunit;

namespace BinaryTree_Tests;

public class BinaryTreeTests
{
    [Fact]
    public void AddNewValueTest()
    {
        //arrange 
        var BinaryTreeHead = new BinaryTreeNode<int>(5);
        var actualValueInHead = BinaryTreeHead.Value;

        //act
        BinaryTreeHead.AddNewValue(4);
        BinaryTreeHead.AddNewValue(6);
        BinaryTreeHead.AddNewValue(1);

        //assert
        Assert.Equal(5, actualValueInHead);
        Assert.Equal(4, BinaryTreeHead.Left.Value);
        Assert.Equal(6, BinaryTreeHead.Right.Value);
        Assert.Equal(1, BinaryTreeHead.Left.Left.Value);
    }
    
    [Fact]
    public void IsValueInTree()
    {
        //arrange 
        var BinaryTreeHead = new BinaryTreeNode<int>(5);

        BinaryTreeHead.AddNewValue(4);
        BinaryTreeHead.AddNewValue(6);
        BinaryTreeHead.AddNewValue(1);

        //act
        var expectedBool1 = BinaryTreeHead.IsValueInTree(6);
        var expectedBool2 = BinaryTreeHead.IsValueInTree(5);
        var expectedBool3 = BinaryTreeHead.IsValueInTree(124);

        //assert
        Assert.True(expectedBool1);
        Assert.True(expectedBool2);
        Assert.False(expectedBool3);

    }

    [Fact]
    public void RotateRightTest()
    {
        var BinaryTreeHead = new BinaryTreeNode<int>(300);
        BinaryTreeHead.AddNewValue(400);
        BinaryTreeHead.AddNewValue(200);
        BinaryTreeHead.AddNewValue(250);
        BinaryTreeHead.AddNewValue(100);

        var expectedNewHead = BinaryTreeHead.Left;
        var expectedLeftOfOldHead = BinaryTreeHead.Left.Right;
        var expectedRightOfNewHead = BinaryTreeHead;

        BinaryTreeHead = BinaryTreeHead.RotateRight();

        var actualNewHead = BinaryTreeHead;
        var actualLeftOfOldHead = BinaryTreeHead.Right.Left;
        var actualRightOfNewHead = BinaryTreeHead.Right;

        Assert.Equal(expectedNewHead, actualNewHead);
        Assert.Equal(expectedLeftOfOldHead, actualLeftOfOldHead);
        Assert.Equal(expectedRightOfNewHead, actualRightOfNewHead);

    }

    //[Fact]
    //public void DoubleRotateRightTest()
    //{
    //    var BinaryTreeHead = new BinaryTreeNode<int>(500);
    //    BinaryTreeHead.AddNewValue(400);
    //    BinaryTreeHead.AddNewValue(300);
    //    BinaryTreeHead.AddNewValue(450);
    //    BinaryTreeHead.AddNewValue(475);
    //    BinaryTreeHead.AddNewValue(425);
    //    BinaryTreeHead.AddNewValue(600);

    //    var expectedNewHead = BinaryTreeHead.Left.Right;
    //    var expectedHeight = BinaryTreeHead.GetHeight() - 1;
    //    var expectedLeftOfNewHead = BinaryTreeHead;
    //    var expectedRightOfNewHead = BinaryTreeHead.Left;
    //    var expectedLeftOfRightNode = BinaryTreeHead.Left.Right.Right;
    //    var expectedRightOfLeftNode = BinaryTreeHead.Left.Right.Left;

    //    BinaryTreeHead = BinaryTreeHead.DoubleRotateRight();

    //    var actualNewHead = BinaryTreeHead;
    //    var actualHeight = BinaryTreeHead.GetHeight();
    //    var actualRightOfNewHead = BinaryTreeHead.Right;
    //    var actualLeftOfNewHead = BinaryTreeHead.Left;
    //    var actualLeftOfRightNode = BinaryTreeHead.Right.Left;
    //    var actualRightOfLeftNode = BinaryTreeHead.Left.Right;

    //    Assert.Equal(expectedNewHead, actualNewHead);
    //    Assert.Equal(expectedHeight, actualHeight);
    //    Assert.Equal(expectedLeftOfNewHead, actualRightOfNewHead);
    //    Assert.Equal(expectedRightOfNewHead, actualLeftOfNewHead);
    //    Assert.Equal(expectedLeftOfRightNode, actualLeftOfRightNode);
    //    Assert.Equal(expectedRightOfLeftNode, actualRightOfLeftNode);
    //}

    [Fact]
    public void RotateLeftTest() 
    {
        var BinaryTreeHead = new BinaryTreeNode<int>(300);
        BinaryTreeHead.AddNewValue(200);
        BinaryTreeHead.AddNewValue(400);
        BinaryTreeHead.AddNewValue(350);
        BinaryTreeHead.AddNewValue(500);

        var expectedNewHead = BinaryTreeHead.Right;
        var expectedLeftOfOldHead = BinaryTreeHead.Right.Left;
        var expectedRightOfNewHead = BinaryTreeHead;

        BinaryTreeHead = BinaryTreeHead.RotateLeft();

        var actualNewHead = BinaryTreeHead;
        var actualLeftOfOldHead = BinaryTreeHead.Left.Right;
        var actualRightOfNewHead = BinaryTreeHead.Left;

        Assert.Equal(expectedNewHead, actualNewHead);
        Assert.Equal(expectedLeftOfOldHead, actualLeftOfOldHead);
        Assert.Equal(expectedRightOfNewHead, actualRightOfNewHead);
    }
    
    //[Fact]
    //public void DoubleRotateLeftTest()
    //{
    //    var BinaryTreeHead = new BinaryTreeNode<int>(500);
    //    BinaryTreeHead.AddNewValue(600);
    //    BinaryTreeHead.AddNewValue(700);
    //    BinaryTreeHead.AddNewValue(550);
    //    BinaryTreeHead.AddNewValue(525);
    //    BinaryTreeHead.AddNewValue(575);
    //    BinaryTreeHead.AddNewValue(400);

    //    var expectedNewHead = BinaryTreeHead.Right.Left;
    //    var expectedHeight = BinaryTreeHead.GetHeight() - 1;
    //    var expectedLeftOfNewHead = BinaryTreeHead;
    //    var expectedRightOfNewHead = BinaryTreeHead.Right;
    //    var expectedRightOfLeftNode = BinaryTreeHead.Right.Left.Left;
    //    var expectedLeftOfRightNode = BinaryTreeHead.Right.Left.Right;

    //    BinaryTreeHead = BinaryTreeHead.DoubleRotateLeft();

    //    var actualNewHead = BinaryTreeHead;
    //    var actualHeight = BinaryTreeHead.GetHeight();
    //    var actualLeftOfNewHead = BinaryTreeHead.Left;
    //    var actualRightOfNewHead = BinaryTreeHead.Right;
    //    var actualRightOfLeftNode = BinaryTreeHead.Left.Right;
    //    var actualLeftOfRightNode = BinaryTreeHead.Right.Left;

    //    Assert.Equal(expectedNewHead, actualNewHead);
    //    Assert.Equal(expectedHeight, actualHeight);
    //    Assert.Equal(expectedLeftOfNewHead, actualLeftOfNewHead);
    //    Assert.Equal(expectedRightOfNewHead, actualRightOfNewHead);
    //    Assert.Equal(expectedRightOfLeftNode, actualRightOfLeftNode);
    //    Assert.Equal(expectedLeftOfRightNode, actualLeftOfRightNode);
    //}

}
