
public class BTreeNode
{ 
    public BTreeNode(int value, int numOfCells)
    {
        MaxNumOfCells = numOfCells;
        HeadOfList = new BTreeCell(value);
    }

    public BTreeNode(BTreeCell cell, int numOfCells) : this(cell, numOfCells, null)
    {
        MaxNumOfCells = numOfCells;
        HeadOfList = cell;
    }

    public BTreeNode(BTreeCell cell, int numOfCells, BTreeNode? parentNode)
    {
        MaxNumOfCells = numOfCells;
        HeadOfList = cell;
        ParentNode = parentNode;
    }

    public BTreeCell HeadOfList { get; private set; }
    public BTreeNode? ParentNode { get; private set; }
    public int MaxNumOfCells { get; }
    public int NumOfCells => HeadOfList.GetCellCount();


    public BTreeNode AddNewValue(int newValue)
    {
        var cell = new BTreeCell(newValue);
        return AddNewValue(cell);
    }

    public BTreeNode AddNewValue(BTreeCell newCell)
    {
        var currentNode = this;
        var currentHeadNode = currentNode;
        BTreeCell medianCell;
        BTreeCell oldMedianCell = null;


        if (currentNode.HeadOfList.Left != null)
        {
            currentNode = currentNode.GoToLowerNode(newCell.Value);
        }        

        while(true)
        {
            if (currentNode.NumOfCells < currentNode.MaxNumOfCells)
            {
                currentNode.HeadOfList = currentNode.HeadOfList.AddNewValue(newCell);
                return currentHeadNode;
            }
            else
            {
                currentNode.HeadOfList = currentNode.HeadOfList.AddNewValue(newCell);
                medianCell = currentNode.HeadOfList.GetMedianCell(currentNode, newCell.Value, currentNode.MaxNumOfCells);
                
                if (medianCell.Left != null && medianCell.Left.HeadOfList.Left != null)
                {
                    if(medianCell.Value > oldMedianCell.Value)
                    {
                        oldMedianCell.Left.ParentNode = medianCell.Left;
                        oldMedianCell.Right.ParentNode = medianCell.Left;
                    }
                    else if(medianCell.Value < oldMedianCell.Value)
                    {
                        oldMedianCell.Left.ParentNode = medianCell.Right;
                        oldMedianCell.Right.ParentNode = medianCell.Right;
                    }
                    else
                    {
                        oldMedianCell.Left.ParentNode = medianCell.Left;
                        oldMedianCell.Right.ParentNode = medianCell.Right;
                    }
                }

                if (currentNode.ParentNode == null)
                {
                    currentNode.ParentNode = new BTreeNode(medianCell, currentNode.MaxNumOfCells);
                    medianCell.Right.ParentNode = currentNode.ParentNode;

                    return currentNode.ParentNode;
                }
                else
                {
                    oldMedianCell = medianCell;
                    currentNode = currentNode.ParentNode;
                    newCell = medianCell;
                    continue;
                }
            }
        }
    }

    public BTreeNode GoToLowerNode(int newValue)
    {
        var currentNode = this;

        while (true)
        {
            if (currentNode.HeadOfList.Left != null)
            {
                currentNode = currentNode.GetLinkToLowerNode(newValue);
            }
            else
            {
                return currentNode;
            }
        }
    }

    public BTreeNode GetLinkToLowerNode(int newValue) //method to find in LL proper link to lower Node (but why it returns Node???) // Better make private
    {
        var currentCell = this.HeadOfList;

        while (true)
        {
            if (newValue < currentCell.Value)
            {
                return currentCell.Left;
            }
            else if (currentCell.Next == null) //if .Next == null && value >= .Value
            {
                return currentCell.Right;
            }
            else if (currentCell.Next != null)
            {
                if (newValue >= currentCell.Next.Value)
                {
                    currentCell = currentCell.Next;
                    continue;
                }
                else
                {
                    return currentCell.Right;
                }
            }
        }
    }

    public int GetHeight(BTreeCell head)
    {
        var currentHead = head;
        var height = 1;
        
        if(head.Left != null)
        {
            height =+ head.Left.GetHeight(currentHead);
            return height;
        }
        else
        {
            return height;
        }
    }
}