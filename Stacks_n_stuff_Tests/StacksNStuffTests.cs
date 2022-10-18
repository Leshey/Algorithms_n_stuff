using Xunit;
using System.Linq;

namespace Stacks_n_stuff_Tests;

public class StacksNStuffTests
{
    [Fact]
    public void PushTest()
    {
        var stack = new StackMem();
        var num = 100;

        stack.Push(num);
        var expected = stack.Stack[5];
        Assert.Equal(expected, num);
    }

    [Fact]
    public void PopTest()
    {
        var stack = new StackMem();
        var expected = stack.Stack[4];
        
        var actual = stack.Pop();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DropTest()
    {
        var stack = new StackMem();
        var actualLenght = stack.ArrLength;

        stack.Drop();
        var expectedLenght = actualLenght - 1;

        Assert.Equal(expectedLenght, stack.ArrLength);
    }

    [Fact]
    public void SwapTest()
    {
        var stack = new StackMem();
        var actualFirst = stack.Stack[4];
        var actualSecond = stack.Stack[3];

        stack.Swap();

        Assert.Equal(stack.Stack[4], actualSecond);
        Assert.Equal(stack.Stack[3], actualFirst);
    }

    [Fact]
    public void DuplicateTest()
    {
        var stack = new StackMem();
        var expected = stack.Stack[4];
        var expectedLenght = stack.ArrLength + 1;

        stack.Duplicate();

        Assert.Equal(expected, stack.Stack[5]);
        Assert.Equal(expectedLenght, stack.ArrLength);
    }

    [Fact]
    public void OverTest()
    {
        var stack = new StackMem();
        var expected = stack.Stack[3];
        var expectedLenght = stack.ArrLength + 1;

        stack.Over();

        Assert.Equal(expected, stack.Stack[5]);
        Assert.Equal(expectedLenght, stack.ArrLength);
    }

    [Fact]
    public void RolTest()
    {
        var stack = new StackMem();
        var expectedArr = new int[stack.ArrLength];
        for(int i = expectedArr.Length; i > 0; i--)
        {
            expectedArr[i - 1] = stack.Stack[i - 1];
        }

        stack.Rol();

        for(int i = 0; i < expectedArr.Length; i++)
        {
            Assert.Equal(expectedArr[i], stack.Stack[i]);
        }
    }

    [Fact]
    public void NipTest()
    {
        var stack = new StackMem();
        var expectedFirst = stack.Stack[4];
        var expectedLength = stack.ArrLength - 1;

        stack.Nip();

        Assert.Equal(expectedFirst, stack.Stack[3]);
        Assert.Equal(expectedLength, stack.ArrLength);
    }
}
