
public class BTreeNode
{ 
    public BTreeNode(int value, int numOfCells)
    {
        MaxNumOfCells = numOfCells;
        HeadOfList = new BTreeCell(value);
    }
    
    public BTreeCell HeadOfList { get; private set; }
    public int MaxNumOfCells { get; }
    public int NumOfCells => HeadOfList.GetCellCount();

    //public BTreeCell AddNewValue(int newValue)
    //{
    //    if (HeadOfList.Left == null)
    //    {
    //        if (NumOfCells < MaxNumOfCells)
    //        {
    //            return HeadOfList = HeadOfList.InsertValue(newValue);
    //        }
    //        else
    //        {

    //        }
    //    }

    //}

    public int GetHeight(BTreeCell head)
    {
        var currentHead = head;
        var height = 1;
        
        if(head.Left != null)
        {
            height =+ head.Left.GetHeight(currentHead);
        }
        else
        {
            return height;
        }
        return height; // is there better way to write it?
    }
}
