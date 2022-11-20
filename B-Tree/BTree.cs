public class Program
{
    public static void Main()
    {

    }
}

public class BTree
{
    // Если поле может иметь null то это нужно явно укзаать BTreeNode?
    private BTreeNode _head;
    /*
     * Верная сортировка полей но лучше всего разделять на три группы, изменяймфе поля, только для чтения поля статичные поля и после константы
     * Я лично выношу константы на самый верз, потом только для чтения и потом изменяныймы поля и потом статичные
     * Скажем так привычка, но так не сильно много кто делает.
    */
    private readonly int _maxNumOfCells;

    public BTree(int maxNumOfCells)
    {
        /*  Тут должен быть гвард, который смотрим что бы ячеек было от 1 и более */
        _maxNumOfCells = maxNumOfCells;
    }

    // Авто проперти? и см коментарий на 11 строке
    public BTreeNode Head { get { return _head; } private set { _head = value; } }

    /*
     * Повторение которе ну нужно
     * public void Add(int newValue) - вполне достаточно
     * В целом по конвенции функция Add это добавление нового значения, перезагружать названия не стоит
     */
    public void AddNewValue(int newValue)
    {
        if (_head == null)
        {
            _head = new BTreeNode(newValue, _maxNumOfCells);
        }
        else
        {
            _head = _head.AddNewValue(newValue);
        }
    }
}
