using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO). When GetNextPerson is called, the next person
/// is returned and re-added to the back of the queue according to their remaining turns.
/// A turns value of 0 or less means the person has an infinite number of turns.
/// If a person has no remaining turns, they are not re-enqueued.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    /// <summary>
    /// Gets the number of people currently in the queue
    /// </summary>
    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// If the person still has turns remaining or has infinite turns,
    /// they are re-enqueued. Throws an exception if the queue is empty.
    /// </summary>
    /// <returns>The next person in the queue</returns>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Re-enqueue logic
        if (person.Turns > 1)
        {
            // Finite turns > 1 → decrement and re-enqueue
            person.Turns--;
            _people.Enqueue(person);
        }
        else if (person.Turns <= 0)
        {
            // Infinite turns (0 or negative) → always re-enqueue
            _people.Enqueue(person);
        }
        // Turns == 1 → person not re-enqueued

        return person;
    }

    /// <summary>
    /// Returns a string representation of the queue
    /// </summary>
    /// <returns>String containing the people in the queue</returns>
    public override string ToString()
    {
        return _people.ToString();
    }
}