public static class StickPool
{
    private static Stick left;
    private static Stick rigth;

    public static void Init(Stick stick)
    {
        if (stick.Type == Stick.StickType.left)
        {
            left = stick;
        }
        else if (stick.Type == Stick.StickType.right)
        {
            Rigth = stick;
        }
    }

    public static Stick Left { get => left; set => left = value; }
    public static Stick Rigth { get => rigth; set => rigth = value; }
}