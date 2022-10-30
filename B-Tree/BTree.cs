public class Program
{
    public static void Main()
    {

    }
}

public class BTree
{
    private BTreeNode _head;
    private readonly int _maxNumOfCells;

    public BTree(int maxNumOfCells)
    {
        _maxNumOfCells = maxNumOfCells;
    }

    //public void AddNewValue(int newValue)
    //{
    //    if (_head == null)
    //    {
    //        _head = new BTreeNode(newValue, _maxNumOfCells);
    //    }
    //    else
    //    {
    //        _head = _head.AddNewValue(newValue);
    //    }
    //}
}
