namespace ST2001681076
{
    /// <summary>
    /// Facade Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.FacadeMethodOne();
            facade.FacadeMethodTwo();
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'SubClassA' class
    /// </summary>
    public class SubClassA
    {
        public void SubClassAMethod()
        {
            Console.WriteLine(" SubClassA Method");
        }
    }
    /// <summary>
    /// The 'SubClassB' class
    /// </summary>
    public class SubClassB
    {
        public void SubClassBMethod()
        {
            Console.WriteLine(" SubClassB Method");
        }
    }
    /// <summary>
    /// The 'SubClassC' class
    /// </summary>
    public class SubClassC
    {
        public void SubClassCMethod()
        {
            Console.WriteLine(" SubClassC Method");
        }
    }
    /// <summary>
    /// The 'SubClassD' class
    /// </summary>
    public class SubClassD
    {
        public void SubClassDMethod()
        {
            Console.WriteLine(" SubClassD Method");
        }
    }
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    public class Facade
    {
        private SubClassA _one;
        private SubClassB _two;
        private SubClassC _three;
        private SubClassD _four;

        public Facade()
        {
            _one = new SubClassA();
            _two = new SubClassB();
            _three = new SubClassC();
            _four = new SubClassD();
        }

        public void FacadeMethodOne()
        {
            Console.WriteLine("\nFacadeMethodOne() ---- ");
            _one.SubClassAMethod();
            _two.SubClassBMethod();
            _four.SubClassDMethod();
        }

        public void FacadeMethodTwo()
        {
            Console.WriteLine("\nFacadeMethodTwo() ---- ");
            _two.SubClassBMethod();
            _three.SubClassCMethod();
        }
    }
}

