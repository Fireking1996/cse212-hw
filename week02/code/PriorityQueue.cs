using System;
using System.Collections.Generic;

/// <summary>
/// A queue where each item has a priority. Items are dequeued by highest priority.
/// If multiple items share the same highest priority, the first added is removed first (FIFO).
/// </summary>
public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the item with the highest priority.
    /// If multiple items share the highest priority, remove the first one (FIFO).
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Find the first item with the highest priority
        int highPriorityIndex = 0;
        int maxPriority = _queue[0].Priority;

        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > maxPriority)
            {
                maxPriority = _queue[i].Priority;
                highPriorityIndex = i;
            }
        }

        // Remove and return the item
        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    /// <summary>
    /// Returns a string representation of the queue
    /// </summary>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

/// <summary>
/// Internal class representing a single item in the priority queue
/// </summary>
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}