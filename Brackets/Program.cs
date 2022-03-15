/*
    Simple stack example
    DKY
    14.02.2021
*/
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool isCorrect = false;

        // () correct
        isCorrect = IsValidParentheses("((2+3)*5 - (7-3) / 3) * 8 ");
        Console.WriteLine(isCorrect ? "Yes" : "No");

        // () correct
        isCorrect = IsValidParenthesesWithStack("((2+3)*5 - (7-3) / 3) * 8 ");
        Console.WriteLine(isCorrect ? "Yes" : "No");

        // () incorrect 
        isCorrect = IsValidParenthesesWithStack("((2+3)*5 - 7-3) / 3) * 8 ");
        Console.WriteLine(isCorrect ? "Yes" : "No");

        // {([])} correct 
        isCorrect = IsValidBrackets("{ int[] a = new int[10]; a[1] = (2-3)*4; } ");
        Console.WriteLine(isCorrect ? "Yes" : "No");

        // {([])} incorrect 
        isCorrect = IsValidBrackets("{ int[] a = new int[10]; a[1] = (2-3*4; } ");
        Console.WriteLine(isCorrect ? "Yes" : "No");

        // {([])} correct 
        isCorrect = IsValidBracketsWithDictionatry("{ int[] a = new int[10]; a[1] = (2-3)*4; } ");
        Console.WriteLine(isCorrect ? "Yes" : "No");

        // {([])} incorrect 
        isCorrect = IsValidBracketsWithDictionatry("{ int[] a = new int[10]; a[1] = 2-3)*4; } ");
        Console.WriteLine(isCorrect ? "Yes" : "No");
    }

    static void RunStack()
    {
        var myStack = new MyStack();
        myStack.Push(1);
        myStack.Print();
        myStack.Push(2);
        myStack.Print();
        myStack.Pop();
        myStack.Print();
        myStack.Pop();
        myStack.Print();
    }

    static bool IsValidParentheses(string str)
    {
        int count = 0;
        foreach(var ch in str)
        {
            if (ch == '(')
            {
                ++count;
            }
            else if (ch == ')')
            {
                --count;
            }    
        }
        return count == 0;
    }

    static bool IsValidParenthesesWithStack(string str)
    {
        MyStack stack = new MyStack();
        foreach (var ch in str)
        {
            if (ch == '(')
            {
                stack.Push(ch);
            }
            else if (ch == ')')
            {
                if (stack.IsEmpty())
                {
                    return false;
                }
                stack.Pop();
            }
        }
        return stack.IsEmpty();
    }

    static bool IsValidBrackets(string str)
    {
        MyStack stack = new MyStack();
        foreach (var ch in str)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}')
            {
                if (stack.IsEmpty())
                {
                    return false;
                }
                char popCh = (char)stack.Pop();
                if (!(popCh == '(' && ch == ')' ||
                      popCh == '[' && ch == ']' ||
                      popCh == '{' && ch == '}'))
                {
                    return false;
                }
            }
        }
        return stack.IsEmpty();
    }

    static bool IsValidBracketsWithDictionatry(string str)
    {
        var brackets = new Dictionary<char, char>() {{')', '('},
                                                     {'}', '{'},
                                                     {']', '['}};
        MyStack stack = new MyStack();
        foreach (var ch in str)
        {
            if (brackets.ContainsValue(ch))
            {
                stack.Push(ch);
            }
            else if (brackets.ContainsKey(ch))
            {
                if (stack.IsEmpty() || (char)stack.Pop() != brackets[ch])
                {
                    return false;
                }
            }
        }
        return stack.IsEmpty();
    }
}
