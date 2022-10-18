namespace Algorithms_n_stuff;

public class Program
{
    //public static void Main()
    //{
    //    var virtualMemory = new VirtualMemory();
    //    var arrayPoint = virtualMemory.Alloc(5);

    //    for (int i = 0; i < 5; i++)
    //    {
    //        virtualMemory.SetData(arrayPoint, i, i);
    //    }

    //    for (int i = 0; i < 5; i++)
    //    {
    //        Console.WriteLine(virtualMemory.GetData(arrayPoint, i));
    //    }

    //    virtualMemory.Free(arrayPoint);

    //    Console.WriteLine(virtualMemory.Alloc(34));
    //    Console.WriteLine(" ");

    //    for (int i = 0; i < 128; i++)
    //    {
    //        Console.WriteLine(virtualMemory._data[i]);
    //    }

    //    var virtualMemory = new VirtualMemory();

    //    var head = CreateNewLinkedList(virtualMemory, 11111);

    //    AddNewNodeInTail(virtualMemory, head, 22222);
    //    virtualMemory.Alloc(5);
    //    AddNewNodeInTail(virtualMemory, head, 33333);
    //    virtualMemory.Alloc(10);
    //    virtualMemory.Alloc(5);
    //    AddNewNodeInTail(virtualMemory, head, 44444);
    //    AddNewNodeInTail(virtualMemory, head, 55555);
    //    virtualMemory.Alloc(5);
    //    AddNewNodeInTail(virtualMemory, head, 66666);


    //    head = DeleteNodeByIndex(virtualMemory, head, 5);

    //    for (int i = 0; i < virtualMemory._data.Length; i++)
    //    {
    //        Console.WriteLine($"{i}|{virtualMemory._data[i]}");
    //    }

    //}

    // -3 == null
    public static int CreateNewLinkedList(VirtualMemory virtualMemory, int value)
    {
        var nodePoint = virtualMemory.Alloc(2);
        virtualMemory.SetData(nodePoint, 0, value);
        virtualMemory.SetData(nodePoint, 1, -3);

        return nodePoint;
    }

    public static void AddNewNodeInTail(VirtualMemory virtualMemory, int headNodePoint, int value)
    {
        var nextNodePoint = headNodePoint;

        while (true)
        {
            var tempNodePoint = virtualMemory.GetData(nextNodePoint, 1);

            if(tempNodePoint == -3)
            {
                break;
            }

            nextNodePoint = tempNodePoint;
        }

        var newNode = virtualMemory.Alloc(2);

        virtualMemory.SetData(newNode, 0, value);
        virtualMemory.SetData(newNode, 1, -3);

        virtualMemory.SetData(nextNodePoint, 1, newNode);

    }

    public static int DeleteNodeByIndex(VirtualMemory virtualMemory, int headNodePoint, int nodeIndex)
    {
        var currentNodePoint = headNodePoint;
        var previousNodePoint = -1;
        
        if (nodeIndex == 0) //116-117 lines are the way to solve this IF~!
        {
            var oldHeadPoint = headNodePoint;
            headNodePoint = virtualMemory.GetData(headNodePoint, 1);
            virtualMemory.Free(oldHeadPoint);

            return headNodePoint;
        }

        for(int i = 0; i < nodeIndex; i++)
        {
            var tempNodePoint = virtualMemory.GetData(currentNodePoint, 1);

            if (i == nodeIndex - 1)
            {
                previousNodePoint = currentNodePoint;
            }

            if (tempNodePoint == -3)
            {
                throw new IndexOutOfRangeException();
            }

            currentNodePoint = tempNodePoint;
        }

        var nextNodePoint = virtualMemory.GetData(currentNodePoint, 1);
        virtualMemory.SetData(previousNodePoint, 1, nextNodePoint);
        virtualMemory.Free(currentNodePoint);

        return headNodePoint;
    }
}


public class VirtualMemory
{
    public readonly int[] _data;

    public VirtualMemory()
    {
        _data = Enumerable.Repeat(-1, 128).ToArray();
    }

    public int Alloc(int size)
    {
        var point = -1;
        var freeSpace = 0;
        var realSize = size + 2;

        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i] == -2)
            {
                i = (i + 1) + _data[i + 1];
                freeSpace = 0;
            }
            else if (_data[i] == -1)
            {
                point = i;
                freeSpace += 1;
                if (freeSpace == realSize)
                {
                    _data[point - (realSize - 1)] = -2;
                    _data[(point + 1) - (realSize - 1)] = size;
                    return point + 1 - size;
                }
            }
        }
        throw new OutOfMemoryException();
    }

    public void Free(int point)
    {
        var offset = _data[point - 1] - 1;
        GuardPoint(point, offset);

        for(int i = point - 2; i < point + offset + 1; i++)
        {
            _data[i] = -1;
        }
    }
    
    public void SetData(int point, int offset, int value)
    {
        GuardPoint(point, offset);
        _data[point + offset] = value;
    }

    public int GetData(int point, int offset)
    {
        GuardPoint(point, offset);
        return _data[point + offset];
    }

    private void GuardPoint(int point, int offset)
    {
        if (_data[point - 2] != -2)
        {
            throw new IndexOutOfRangeException();
        }

        var maxOffset = _data[point - 1] - 1;

        if (offset > maxOffset)
        {
            throw new IndexOutOfRangeException();
        }
    }
}

