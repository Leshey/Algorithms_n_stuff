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

    public BTreeCell InsertValue(int newValue)
    {
        var currentHead = this;

        if (newValue < Value)
        {
            return new BTreeCell(newValue, this);
        }
        else
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (currentHead.Next != null)
                {
                    currentHead = currentHead.Next;
                }
                else
                {
                    currentHead.Next = new BTreeCell(newValue, this);
                    currentHead.Next.Value = newValue;
                    break;
                }
            }
        }
        return this;
    }

    public int GetCellNum()
    {
        if (Next == null)
        {
            return 1;
        }
        else
        {
            return 1 + Next.GetCellNum();
        }
    }

    public int GetMedianNum(int newValue, int maxNumOfCell)
    {
        int[] numArray = new int[maxNumOfCell + 1];
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
}