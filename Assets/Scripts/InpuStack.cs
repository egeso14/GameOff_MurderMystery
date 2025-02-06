using UnityEngine;

using System;
using System.Collections.Generic;

public class InputStack<T>
{
    private LinkedList<T> stackList;

    public InputStack()
    {
        stackList = new LinkedList<T>();
    }

    // Push an element onto the stack
    public void Push(T item)
    {
        stackList.AddLast(item);
    }

    // Pop the top element from the stack
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        T value = stackList.Last.Value;
        stackList.RemoveLast();
        return value;
    }

    // Peek at the top element without removing it
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return stackList.Last.Value;
    }

    // Remove a specific element from the stack (regardless of its position)
    public bool Remove(T item)
    {
        return stackList.Remove(item); // Returns true if the item was found and removed
    }

    // Check if the stack is empty
    public bool IsEmpty()
    {
        return stackList.Count == 0;
    }

    // Get the number of elements in the stack
    public int Count()
    {
        return stackList.Count;
    }

    // Clear the stack
    public void Clear()
    {
        stackList.Clear();
    }

    // Display the stack for debugging purposes
    public void DisplayStack()
    {
        Console.WriteLine("Stack contents (top to bottom):");
        foreach (var item in stackList)
        {
            Console.WriteLine(item);
        }
    }
}