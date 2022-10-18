
public class BinaryTree<TValue>
    where TValue : IComparable<TValue>
{
    private BinaryTreeNode<TValue> _head;


    public void AddNewValue
        (TValue newValue)
    {
        if (_head == null)
        {
            _head = new BinaryTreeNode<TValue>(newValue);
        }
        else
        {
            _head = _head.AddNewValue(newValue);
        }
    }

    public void ShowHeight()
    {
        Console.WriteLine(_head.GetHeight());
    }

    public void PrintVerySpecificTree()
    {
        Console.WriteLine($"   {_head.Value}");
        Console.WriteLine($"  {_head.Left.Value} {_head.Right.Value}");
        Console.WriteLine($" {_head.Left.Left.Value} {_head.Left.Right.Value} {_head.Right.Right.Value}");
    }

}