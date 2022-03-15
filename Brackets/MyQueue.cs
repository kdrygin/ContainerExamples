/*
    Simple stack example
    DKY
    14.02.2021
*/

public class MyQueue
{
    DynArray arr;

    public MyQueue()
    {
        arr = new DynArray();
    }

    public bool IsEmpty()
    {
        return arr.GetLength() == 0;
    }

    public void Push(int value)
    {
        arr.Insert(0, value);
    }

    public int Pop()
    {
        return arr.PopBack();
    }

    public void Print()
    {
        arr.Print();
    }
}
