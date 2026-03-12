using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with distinct priorities and dequeue them
    // Expected Result: Items removed in descending priority order
    // Defect(s) Found: Items may not be removed by highest priority in previous implementation
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 3);
        pq.Enqueue("Bob", 5);
        pq.Enqueue("Charlie", 2);

        Assert.AreEqual("Bob", pq.Dequeue());
        Assert.AreEqual("Alice", pq.Dequeue());
        Assert.AreEqual("Charlie", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with the same priority and dequeue them
    // Expected Result: Items with same priority removed FIFO
    // Defect(s) Found: Previous implementation may remove last occurrence instead of first
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 3);
        pq.Enqueue("Bob", 3);
        pq.Enqueue("Charlie", 3);

        Assert.AreEqual("Alice", pq.Dequeue());
        Assert.AreEqual("Bob", pq.Dequeue());
        Assert.AreEqual("Charlie", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities, multiple items
    // Expected Result: Highest priority removed first, FIFO tie-breaking
    // Defect(s) Found: Priority or order may not have been respected previously
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 2);
        pq.Enqueue("Bob", 5);
        pq.Enqueue("Charlie", 5);
        pq.Enqueue("David", 1);

        Assert.AreEqual("Bob", pq.Dequeue());
        Assert.AreEqual("Charlie", pq.Dequeue());
        Assert.AreEqual("Alice", pq.Dequeue());
        Assert.AreEqual("David", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: May not throw correct exception or message previously
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Add items with negative and zero priorities
    // Expected Result: Highest priority (0 > negative) dequeued first
    // Defect(s) Found: May not handle negative or zero priorities correctly previously
    public void TestPriorityQueue_NegativeAndZeroPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", -1);
        pq.Enqueue("Bob", 0);
        pq.Enqueue("Charlie", -5);

        Assert.AreEqual("Bob", pq.Dequeue());
        Assert.AreEqual("Alice", pq.Dequeue());
        Assert.AreEqual("Charlie", pq.Dequeue());
    }
}