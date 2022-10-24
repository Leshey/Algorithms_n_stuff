
public class BTreeNode
{ 
    public BTreeNode(int value, int numOfCells)
    {
        MaxNumOfCells = numOfCells;
        HeadOfList = new BTreeCell(value);
    }
    
    public BTreeCell HeadOfList { get; private set; }
    public int MaxNumOfCells { get; }
    public int NumOfCells => HeadOfList.GetCellNum();

    //public BTreeCell AddNewValue(int newValue)
    //{
    //    if(HeadOfList.Left == null)
    //    {
    //        if(NumOfCells < MaxNumOfCells)
    //        {
    //            return HeadOfList = HeadOfList.InsertValue(newValue);
    //        }
    //        else
    //        {

    //        }
    //    }
        
    //}

}
