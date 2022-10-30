public class BTreeCell
{
    public BTreeCell(int value) : this(value, null)
    {
        Value = value;
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

    public BTreeCell InsertCell(int newValue)
    {
        var currentCell = GetNodeToInsert(newValue); // pray it works (NEED TESTING!)

        if (newValue < currentCell.Value)
        {
            return new BTreeCell(newValue, this);
        }
        else
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (currentCell.Next != null)
                {
                    if(currentCell.Next.Value > newValue)
                    {
                        var tempCell = currentCell.Next;
                        currentCell.Next = new BTreeCell(newValue, tempCell);
                        break;
                    }
                    else
                    {
                        currentCell = currentCell.Next;
                    }                    
                }
                else
                {
                    currentCell.Next = new BTreeCell(newValue);
                    break;
                }
            }
        }
        return this;
    }

    public BTreeCell GetNodeToInsert(int value)
    {
        var currentCell = this;
        
        for(int i = 0; i < int.MaxValue; i++)
        {
            if(currentCell.Left != null)
            {
                currentCell = GetNeededLowerNode(value).HeadOfList; // why...
            }
            else
            {
                return currentCell;
            }
        }
        return this;
    }

    public BTreeNode GetNeededLowerNode(int value) //method to find in LL proper link to lower Node (but why it returns Node???)
    {
        var currentCell = this;

        for(int i = 0; i < int.MaxValue; i++)
        {
            if (value < currentCell.Value)
            {
                return currentCell.Left;
            }
            else if (currentCell.Next == null) //if .Next == null && value >= .Value
            {
                return currentCell.Right;
            }
            else if (currentCell.Next != null)
            {
                if(value >= currentCell.Next.Value)
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
        return null; // ??? Don't know how to solve this without such code
    }

    public int GetMedianNum(int newValue, int maxNumOfCell)
    {
        int[] numArray = new int[maxNumOfCell + 1]; //Do not forget to remove +1 if logic will change to (maxNumOfCell + 1) Cells in Node for easier median finding.
        bool isNewValueInArray = false;
        var currentHead = this;
        

        for (int i = 0; i < numArray.Length; i++)
        {
            var valueToArray = currentHead.Value;
            if (newValue < valueToArray && isNewValueInArray == false)
            {
                numArray[i] = newValue;
                i += 1;
                numArray[i] = valueToArray;
                isNewValueInArray = true;
            }
            else
            {
                numArray[i] = valueToArray;
            }
            currentHead = currentHead.Next;
        }
    
        var oddOrEven = numArray.Length % 2;
        if(oddOrEven == 0)
        {
            var medianIndex = (numArray.Length / 2) - 1;
            return numArray[GetClosestMedian(medianIndex)];
        }
        else
        {
            var medianIndex = (numArray.Length / 2) - 1;
            return numArray[medianIndex + 1];
        }
        
        //local method cuz why not
        //looking for closest median to new value in node
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
}