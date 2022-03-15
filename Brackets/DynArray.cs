/*
    Simple dynamic array example
    DKY
    14.02.2021
*/

using System;

public class DynArray
{
    private int Length;
    private int[] arr;
    private Random rnd;

    public DynArray() // Constructor
    {
        Length = 0;
        arr = new int[10];
        rnd = new Random();
    }

    public DynArray(int newLen) // Constructor 2
    {
        Length = newLen;
        arr = new int[Length * 2];
        rnd = new Random();
    }

    public int GetLength()
    {
        return Length;
    }

    public void FillRandom(int minValue, int maxValue)
    {
        for (var i = 0; i < Length; ++i)
            arr[i] = rnd.Next(minValue, maxValue);
    }

    public void Print()
    {
        foreach (var i in arr)
            Console.Write($"{i}, ");
        Console.WriteLine();
    }

    private void Resize(int newSize)
    {
        var newArr = new int[newSize];
        for (var i = 0; i < Length; ++i)
            newArr[i] = arr[i];
        arr = newArr;
    }

    public void Insert(int value, int index)
    {
        if (arr.Length <= Length)
            Resize(Length * 2);
        for (var i = Length; i > index; --i)
            arr[i] = arr[i - 1];
        arr[index] = value;
        ++Length;
    }

    public void PushBack(int value)
    {
        Insert(value, Length);
    }

    public int Delete(int index)
    {
        var value = arr[index];
        for (var i = index; i < Length - 1; ++i)
            arr[i] = arr[i + 1];
        --Length;
        arr[Length] = 0; // Debug
        return value;
    }

    public int PopBack()
    {
        return Delete(Length - 1);
    }
}
