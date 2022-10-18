using System.Collections;

public class Program
{
    public static void Main()
    {
        StackMem stack = new StackMem();
    }

}

public class StackMem
{
    private int[] _stack;
    private int _arrLength;

    public StackMem()
    {
        _stack = new int[5] { 1, 2, 3, 4, 5 };
        _arrLength = _stack.Length;
    }

    public int[] Stack { get { return _stack; } }
    public int ArrLength { get { return _arrLength; } }

    public void Push(int num)
    {
        if (_arrLength < _stack.Length + 1)
        {
            int resizeNum = _stack.Length * 2;
            Array.Resize(ref _stack, resizeNum);
        }
        _arrLength += 1;
        _stack[_arrLength - 1] = num;
    }

    public int Pop()
    {
        var num = _stack[_arrLength - 1];
        _arrLength -= 1;
        return num;
    }

    public void Drop()
    {
        _arrLength -= 1;
    }

    public void Swap()
    {
        var first = Pop();
        var second = Pop();
        Push(first);
        Push(second);
    }

    public void Duplicate()
    {
        var num = _stack[_arrLength - 1];
        Push(num);
    }

    public void Over()
    {
        var first = Pop();
        var second = _stack[_arrLength - 1];
        Push(first);
        Push(second);
    }

    public void Rol()
    {
        var arr = new int[_arrLength];
        for (int i = arr.Length; i < 0; i--)
        {
            arr[i - 1] = Pop();
        }
        for (int i = 0; i < arr.Length; i++)
        {
            Push(arr[i]);
        }
    }

    public void Nip()
    {
        Swap();
        Pop();
    }
}