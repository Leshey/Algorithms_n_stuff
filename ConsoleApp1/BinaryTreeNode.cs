public class Program
{
    public static void Main()
    {
        var BinaryTree = new BinaryTree<int>();
        BinaryTree.AddNewValue(50);
        BinaryTree.AddNewValue(60);
        BinaryTree.AddNewValue(40);
        BinaryTree.AddNewValue(70);
        BinaryTree.AddNewValue(30);
        BinaryTree.AddNewValue(37);
        BinaryTree.AddNewValue(35);
        BinaryTree.AddNewValue(43);
        BinaryTree.AddNewValue(55);
        BinaryTree.AddNewValue(75);
        BinaryTree.AddNewValue(37);
        BinaryTree.AddNewValue(27);
        BinaryTree.RemoveValue(45);


        BinaryTree.ShowHeight();

        //BinaryTree.PrintVerySpecificTree();


        //var one = 1;
        //var two = 2;
        
        //Console.WriteLine(one.CompareTo(two));
        //Console.WriteLine(two.CompareTo(one));
    }

}

public class BinaryTreeNode<TValue>
    where TValue : IComparable<TValue>
{
    public BinaryTreeNode(TValue value)
    {
        Value = value;
    }

    public TValue Value { get; }
    public BinaryTreeNode<TValue>? Left { get; set; }
    public BinaryTreeNode<TValue>? Right { get; set; }

    public BinaryTreeNode<TValue> AddNewValue(TValue newValue)
    {
        var order = newValue.CompareTo(Value);
        if (order < 0)
        {
            if (Left == null)
            {
                Left = new BinaryTreeNode<TValue>(newValue);
            }
            else
            {
                Left = Left.AddNewValue(newValue);
                return Balance();
            }
        }
        else
        {
            if (Right == null)
            {
                Right = new BinaryTreeNode<TValue>(newValue);
            }
            else
            {
                Right = Right.AddNewValue(newValue);
                return Balance();
            }
        }
        return this;
    }

    public BinaryTreeNode<TValue> RemoveValue(TValue valueToRemove)
    {
        if (IsValueInTree(valueToRemove) == false)
        {
            throw new ArgumentException();
        }
        else
        {
            var order = valueToRemove.CompareTo(Value);
            if (order < 0 && Left != null)
            {
                Left = Left.RemoveValue(valueToRemove);
            }
            else if (order > 0 && Right != null)
            {
                Right = Right.RemoveValue(valueToRemove);
            }
            else
            {
               if (Left != null)
                {
                    if(Left.Right != null)
                    {
                        var tempNode = Left.Right;
                        while(tempNode.Right != null)
                        {
                            tempNode = tempNode.Right;
                        }
                        return tempNode;
                    }
                    else
                    {
                        return Left;
                    }
                }
                else if (Right != null)
                {
                    return Right;
                }
                else
                {
                    return null;
                }
            }
        } return this;
    }

    public bool IsValueInTree(TValue value)
    {
        var order = value.CompareTo(Value);
        if (order == 0)
        {
            return true;
        }
        else if (order < 0)
        {
            if (Left != null)
            {
                return Left.IsValueInTree(value);
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (Right != null)
            {
                return Right.IsValueInTree(value);
            }
            else
            {
                return false;
            }
        }
    }

    public BinaryTreeNode<TValue> RotateRight()
    {
        var newHeadNode = Left;
        Left = Left.Right;
        newHeadNode.Right = this;

        return newHeadNode;
    }

    public BinaryTreeNode<TValue> DoubleRotateRight()
    {
        var newHeadNode = Left.Right;
        Left.Right = newHeadNode.Left;
        newHeadNode.Left = Left;
        Left = newHeadNode.Right;
        newHeadNode.Right = this;

        return newHeadNode;
    }

    public BinaryTreeNode<TValue> RotateLeft()
    {
        var newHeadNode = Right;
        Right = newHeadNode.Left;
        newHeadNode.Left = this;

        return newHeadNode;
    }

    public BinaryTreeNode<TValue> DoubleRotateLeft()
    {
        var newHeadNode = Right.Left;
        Right.Left = newHeadNode.Right;
        newHeadNode.Right = Right;
        Right = newHeadNode.Left;
        newHeadNode.Left = this;

        return newHeadNode;
    }

    public int GetHeight()
    {
        int leftHeight = 1;
        int rightHeight = 1;

        if (Left == null && Right == null)
        {
            return 1;
        }

        if (Right != null)
        {
            rightHeight += Right.GetHeight();
        }
        if (Left != null)
        {
            leftHeight += Left.GetHeight();
        }

        if (leftHeight >= rightHeight)
        {
            return leftHeight;
        }
        else
        {
            return rightHeight;
        }
    }


    //int test = Right?.GetHeight() ?? 0;

    public BinaryTreeNode<TValue> Balance()
    {
        int leftHeight;
        int rightHeight;
        int heightDiff;

        if (Left != null)
        {
            leftHeight = Left.GetHeight();
        }
        else
        {
            leftHeight = 0;
        }

        if (Right != null)
        {
            rightHeight = Right.GetHeight();
        }
        else
        {
            rightHeight = 0;
        }


        if (leftHeight >= rightHeight)
        {
            heightDiff = leftHeight - rightHeight;
        }
        else
        {
            heightDiff = rightHeight - leftHeight;
        }

        if (heightDiff >= 2 && leftHeight > rightHeight)
        {
            leftHeight = Left.Left?.GetHeight() ?? 0;
            rightHeight = Left.Right?.GetHeight() ?? 0;

            if (leftHeight >= rightHeight)
            {
                return RotateRight();
            }
            else if (leftHeight < rightHeight)
            {
                return DoubleRotateRight();
            }
        }
        else if (heightDiff >= 2 && rightHeight > leftHeight)
        {
            leftHeight = Right.Left?.GetHeight() ?? 0;
            rightHeight = Left.Right?.GetHeight() ?? 0;

            if (leftHeight <= rightHeight)
            {
                return RotateLeft();
            }
            else if (leftHeight > rightHeight)
            {
                return DoubleRotateLeft();
            }
        }
        return this;
    }
}
