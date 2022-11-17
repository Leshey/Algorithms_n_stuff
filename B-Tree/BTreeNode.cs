
public class BTreeNode
{ 
    public BTreeNode(int value, int numOfCells)
    {
        MaxNumOfCells = numOfCells;
        HeadOfList = new BTreeCell(value);
    }
    /* думаю такие конструкторы стоит приватить
     * плюс мне видется это место проблемным т.к. нужно смотреть что бы только один инстанс
     * поэтому его точно нужно заприватить ибо управление инстанцем BTreeCell не должно выходить
     * за пределы BTreeNode
     *
     * Так же смотря на перый конструктор он вполне бы мог его вызывать
     *
     * Так же есть конфликт со строчками
     * MaxNumOfCells = numOfCells;
     * HeadOfList = cell;
     * повтори эту тему - https://learn.microsoft.com/en-ca/dotnet/csharp/programming-guide/classes-and-structs/constructors
     */
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

    /*
     * Как и классе BTree проблема с нейменгом
     */
    public BTreeNode AddNewValue(int newValue)
    {
        var cell = new BTreeCell(newValue);
        return AddNewValue(cell);
    }

    /*
     * Проблемное место, держать публичным его не стоит, т.к. нужно "правельный" BTreeCell прокинуть
     */
    public BTreeNode AddNewValue(BTreeCell newCell)
    {
        var currentNode = this;
        // зачем эта переменная? она ни как не изменяется и хранит ссылку на this
        var currentHeadNode = currentNode;
        BTreeCell medianCell;
        // не хватает ?
        BTreeCell oldMedianCell = null;

        /*
         * не очень понятный хак для челвоека со стороны. Для того что бы его понять нужно знать правила B-Tree
         * Для читаьельности нужно вынести в свойство и станет более читабельно и информативней
         *
         */
        if (currentNode.HeadOfList.Left != null)
        {
            currentNode = currentNode.GoToLowerNode(newCell.Value);
        }        

        while(true)
        {
            /*
             * А разве во время цикла меняется количество ячеек? Я думаю это можно проверить один раз до цикла
             */
            if (currentNode.NumOfCells < currentNode.MaxNumOfCells)
            {
                /*
                 * такой код у тебя повторяется постоянно, логику нужно вынести в метод для избежаний ошибок
                 */
                currentNode.HeadOfList = currentNode.HeadOfList.AddNewValue(newCell);
                return currentHeadNode;
            }
            // else в данным случи не нужно т.к. если попали в if выше мы олтдаем управление выходя из метода
            else
            {
                /*
                 * такой код у тебя повторяется постоянно, логику нужно вынести в метод для избежаний ошибок
                 */
                currentNode.HeadOfList = currentNode.HeadOfList.AddNewValue(newCell);
                medianCell = currentNode.HeadOfList.GetMedianCell(currentNode, newCell.Value, currentNode.MaxNumOfCells);

                // можно упростить до medianCell.Left?.HeadOfList.Left != null
                /*
                 * А воо что что тут за магия творится? Зачем ты смотришь на то что бы у медины были ссылки на ноды
                 * и у тех нод были еще свои ноды?
                 * Очень специфичный случай
                 */
                if (medianCell.Left != null && medianCell.Left.HeadOfList.Left != null)
                {
                    // потенциальный nullref т.к. рание мы положили в эту переменную null
                    if(medianCell.Value > oldMedianCell.Value)
                    {
                        // опять же почему мы так уверены в том что у старой медианы есть дочерние ноды
                        // и какая-то странная магия, я как понял тут ссылки на головы проставляется, но как-то очень странно и избирательно
                        oldMedianCell.Left.ParentNode = medianCell.Left;
                        oldMedianCell.Right.ParentNode = medianCell.Left;
                    }
                    else if(medianCell.Value < oldMedianCell.Value)
                    {
                        // опять же почему мы так уверены в том что у старой медианы есть дочерние ноды
                        oldMedianCell.Left.ParentNode = medianCell.Right;
                        oldMedianCell.Right.ParentNode = medianCell.Right;
                    }
                    else
                    {
                        // опять же почему мы так уверены в том что у старой медианы есть дочерние ноды
                        oldMedianCell.Left.ParentNode = medianCell.Left;
                        oldMedianCell.Right.ParentNode = medianCell.Right;
                    }
                }

                if (currentNode.ParentNode == null)
                {
                    currentNode.ParentNode = new BTreeNode(medianCell, currentNode.MaxNumOfCells);
                    // а вдруг у медианы нет дочерних нод?
                    medianCell.Right.ParentNode = currentNode.ParentNode;

                    return currentNode.ParentNode;
                }
                // else в данным случи не нужно т.к. если попали в if выше мы олтдаем управление выходя из метода
                else
                {
                    oldMedianCell = medianCell;
                    currentNode = currentNode.ParentNode;
                    newCell = medianCell;
                    // не нужный continue
                    continue;
                }
            }
        }
    }
    // Читая это мне кажется изменится какое-то состоянии, но это не так, в таких случаях лучше использовать get
    public BTreeNode GoToLowerNode(int newValue)
    {
        var currentNode = this;
        // а зачем тут цикл? GetLinkToLowerNode разве не найдет нижнию ноду
        // вообще какая разница между GetLinkToLowerNode и GoToLowerNode?
        while (true)
        {
            // писал ранее, сложный хак, который повторяется вынести в метод (лучше всего свойство)
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

    // Читая это мне кажется изменится какое-то состоянии, но это не так, в таких случаях лучше использовать get
    // перегрузка нэминга получая инстанс класса это так и так ссылка слово Link излишня
    // в целом омжно упростить до GetLowerNode
    public BTreeNode GetLinkToLowerNode(int newValue) //method to find in LL proper link to lower Node (but why it returns Node???) // Better make private
    {
        var currentCell = this.HeadOfList;

        while (true)
        {
            if (newValue < currentCell.Value)
            {
                // возможен нулл реф
                return currentCell.Left;
            }
            // else не требуется
            else if (currentCell.Next == null) //if .Next == null && value >= .Value
            {
                // возможен нулл реф
                return currentCell.Right;
            }
            // else не требуется
            else if (currentCell.Next != null)
            {
                // верхний if можно обьяденить
                if (newValue >= currentCell.Next.Value)
                {
                    currentCell = currentCell.Next;
                    continue;
                }
                else
                {
                    // возможен нулл реф
                    return currentCell.Right;
                }
            }
        }
    }
    /*
     * Так высоту или глубину?
     * А еще почему на нужно получить в агрмуенте ссылку на целл, она же есть в этом классе
     * Плюс методом же ни кто не пользуется
     */
    public int GetHeight(BTreeCell head)
    {
        // переменная ни как не изменяется она нам не нужна
        var currentHead = head;
        var height = 1;
        
        if(head.Left != null)
        {
            height =+ head.Left.GetHeight(currentHead);
            return height;
        }
        // else не требуется
        else
        {
            return height;
        }
    }
}