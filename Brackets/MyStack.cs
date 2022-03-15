/*
    Simple stack example
    DKY
    14.02.2021
*/

public class MyStack
{
    DynArray arr;

    public MyStack()
    {
        arr = new DynArray();
    }

    public bool IsEmpty()
    {
        return arr.GetLength() == 0;
    }

    public void Push(int value)
    {
        arr.PushBack(value);
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
