
public class LinkedList
{
    public LinkedListElement Head { get; set; }

    public int GetValueByIndex(int index)
    {
        var currentElement = GetLinkedListElementByIndex(index);

        return currentElement.Value;
    }

    public void Insert(int value, int index)
    {
        var element = GetLinkedListElementByIndex(index - 1);
        var element2 = element.Next;

        var newElement = new LinkedListElement
        {
            Value = value,
            Next = element2
        };

        element.Next = newElement;
    }

    public void InsertAfter(int value, LinkedListElement element)
    {
        var element2 = element.Next;

        var newElement = new LinkedListElement
        {
            Value = value,
            Next = element2
        };

        element.Next = newElement;
    }

    public void CreateNewLastElement(int value)
    {
        var currentElement = Head;

        for (int i = 0; i < int.MaxValue; i++)
        {
            if (currentElement.Next != null)
            {
                currentElement = currentElement.Next;
            }
            else
            {
                currentElement.Next = new LinkedListElement();
                currentElement.Next.Value = value;
            }
        }
    }

    public void DeleteElementByIndex(int index)
    {
        var currentElement = Head;
        LinkedListElement previousElement = null;

        for (int i = 0; i < index + 1; i++)
        {
            if (index == index - 1)
            {
                previousElement.Next = currentElement.Next; // check if possible without tempElement with var
            }
            
            if (currentElement.Next != null)
            {
                currentElement = currentElement.Next;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        

    }

    private LinkedListElement GetLinkedListElementByIndex(int index)
    {
        var currentElement = Head;

        for (int i = 0; i < index; i++)
        {
            if (currentElement.Next != null)
            {
                currentElement = currentElement.Next;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        return currentElement;
    }


}