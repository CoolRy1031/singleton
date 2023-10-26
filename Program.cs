public sealed class Singleton
{
    private static Singleton instance = null;

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
public sealed class Singleton2
{
    private static Singleton2 instance = null;
    private static readonly object padlock = new object();

    Singleton2()
    {
    }

    public static Singleton2 Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Singleton2();
                }
                return instance;
            }
        }
    }
}
public sealed class Singleton3
{
    private static Singleton3 instance = null;
    private static readonly object padlock = new object();

    Singleton3()
    {
    }

    public static Singleton3 Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton3();
                    }
                }
            }
            return instance;
        }
    }
}
public sealed class Singleton4
{
    private static readonly Singleton4 instance = new Singleton4();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static Singleton4()
    {
    }

    private Singleton4()
    {
    }

    public static Singleton4 Instance
    {
        get
        {
            return instance;
        }
    }
}
public sealed class SingletonLazy
{
    private SingletonLazy()
    {
    }

    public static SingletonLazy Instance { get { return Nested.instance; } }

    private class Nested
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Nested()
        {
        }

        internal static readonly SingletonLazy instance = new SingletonLazy();
    }
}