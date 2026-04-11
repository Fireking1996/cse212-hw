public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
    {
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else if (value > Data) // ✅ ONLY go right if greater
    {
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
    // ✅ if equal, do nothing (prevents duplicates)
    }

    public bool Contains(int value)
    {
        if (value == Data)
    {
        return true;
    }
    else if (value < Data)
    {
        if (Left is null)
            return false;

        return Left.Contains(value);
    }
    else
    {
        if (Right is null)
            return false;

        return Right.Contains(value);
    }
        return false;
    }

    public int GetHeight()
    {
       int leftHeight = 0;
    int rightHeight = 0;

    if (Left != null)
        leftHeight = Left.GetHeight();

    if (Right != null)
        rightHeight = Right.GetHeight();

    return 1 + Math.Max(leftHeight, rightHeight);
    }
}