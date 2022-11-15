public class BTreeCell
{
    public BTreeCell(int value) : this(value, null)
    {
    }

    public BTreeCell(int value, BTreeCell? nextCell)
    {
        Next = nextCell;
        Value = value;
    }

    public BTreeCell? Next { get; set; } //removed private fot tests
    public int Value { get; private set; }
    public BTreeNode Left { get; private set; }
    public BTreeNode Right { get; private set; }

    
    public BTreeCell AddNewValue(BTreeCell newCell)
    {
        return this.InsertCell(newCell);
    }

    public BTreeCell InsertCell(BTreeCell newCell)
    {
        var currentCell = this;  

        if (newCell.Value < currentCell.Value)
        {
            newCell.Next = currentCell;
            if (newCell.Left != null && newCell.Right != null)
            {
                ShareLinksWithNeighborCells(newCell);
            }
            return newCell;
        }
        else
        {
            while(true)
            {
                if (currentCell.Next != null)
                {
                    if(newCell.Value < currentCell.Next.Value)
                    {
                        var tempCell = currentCell.Next;
                        currentCell.Next = newCell;
                        newCell.Next = tempCell;
                        break;
                    }
                    else
                    {
                        currentCell = currentCell.Next;
                        continue;
                    }                    
                }
                else
                {
                    currentCell.Next = newCell;
                    break;
                }
            }

            if (newCell.Left != null && newCell.Right != null)
            {
                ShareLinksWithNeighborCells(newCell);
            }
        }
        return this; 
    }

    public void ShareLinksWithNeighborCells(BTreeCell newCell)
    {
        var newCellIndex = GetCellIndex(newCell);
        var cellCount = GetCellCount();
        BTreeCell leftCell;
        BTreeCell rightCell;
                
        if (newCellIndex == 0 && newCell.Next != null)
        {
            rightCell = newCell.Next;
            rightCell.Left = newCell.Right;
        }
        else if (newCellIndex == cellCount - 1)
        {
            leftCell = GetCellByIndex(newCellIndex - 1);
            leftCell.Right = newCell.Left;
        }
        else
        {
            leftCell = GetCellByIndex(newCellIndex - 1);
            rightCell = newCell.Next;
            
            leftCell.Right = newCell.Left;
            rightCell.Left = newCell.Right;
        }
    }

    public BTreeCell GetMedianCell(BTreeNode node, int newValue, int maxNumOfCell)
    {
        var currentHead = node.HeadOfList;

        if (currentHead.GetCellCount() >= maxNumOfCell + 1) //Maybe unnecessary guard, since it's Node responsibility but eeeh 
        {
            var medianIndex = GetMedianIndex(newValue, maxNumOfCell);
            var medianCell = GetCellByIndex(medianIndex);
            medianCell.Left = node;
            medianCell.Right = new BTreeNode(GetCellByIndex(medianIndex + 1), maxNumOfCell, node.ParentNode);
            RemoveOldLinksInMedianCell(medianIndex);
            
            return medianCell;
        }
        else
        {
            return null;
        }

    }

    public int GetMedianIndex(int newValue, int maxNumOfCell)
    {
        int[] numArray = new int[maxNumOfCell + 1];
        var currentHead = this;

        for (int i = 0; i < numArray.Length; i++)
        {
            var valueToArray = currentHead.Value;
            numArray[i] = valueToArray;
            currentHead = currentHead.Next;
        }

        var oddOrEven = numArray.Length % 2;
        if (oddOrEven == 0)
        {
            var medianIndex = (numArray.Length / 2) - 1;
            return numArray[GetClosestMedian(medianIndex)];
        }
        else
        {
            var medianIndex = (numArray.Length / 2) - 1;
            return medianIndex + 1;
        }

        int GetClosestMedian(int medianIndexArg)
        {
            var candidate1 = numArray[medianIndexArg];
            var indexOfCandidate1 = medianIndexArg;
            var candidate2 = numArray[medianIndexArg + 1];
            var indexOfCandidate2 = medianIndexArg + 1;

            candidate1 = candidate1 > newValue ? candidate1 - newValue : newValue - candidate1;
            candidate2 = candidate2 > newValue ? candidate2 - newValue : newValue - candidate2;

            return candidate1 < candidate2 ? indexOfCandidate1 : indexOfCandidate2;
        }

    }

    public void RemoveOldLinksInMedianCell(int medianIndex)
    {
        if(medianIndex > 0)
        {
            var medianCell = GetCellByIndex(medianIndex);
            medianCell.Next = null;
            var tempCell = GetCellByIndex(medianIndex - 1);
            tempCell.Next = null;
            
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }
    
    public int GetCellCount()
    {
        if (Next == null)
        {
            return 1;
        }
        else
        {
            return 1 + Next.GetCellCount();
        }
    }

    public BTreeCell GetCellByIndex(int index)
    {
        var currentCell = this;

        for (int i = 0; i < index; i++)
        {
            if (currentCell.Next != null)
            {
                currentCell = currentCell.Next;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        return currentCell;
    }

    public int GetCellIndex(BTreeCell cell)
    {
        BTreeCell currentCell;
        var index = 0;

        if (cell.Next != null && cell.Next.Value == this.Value)
        {
            currentCell = cell;
        }
        else
        {
            currentCell = this;
        }

        while (true)
        {
            if(cell.Value == currentCell.Value)
            {
                return index;
            }
            else if(currentCell.Next != null)
            {
                currentCell = currentCell.Next;
                index += 1;
            }
            else
            {
                throw new ArgumentException($"Cannot find cell with '{cell.Value}' value in node");
            }
        }
    }
}