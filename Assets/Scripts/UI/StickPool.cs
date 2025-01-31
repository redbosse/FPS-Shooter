namespace UI
{
    public static class StickPool
    {
        public static void Init(Stick stick)
        {
            switch (stick.Type)
            {
                case Stick.StickType.left:
                    Left = stick;
                    break;
                case Stick.StickType.right:
                    Rigth = stick;
                    break;
            }
        }

        public static Stick Left { get; private set; }

        public static Stick Rigth { get; private set; }
    }
}