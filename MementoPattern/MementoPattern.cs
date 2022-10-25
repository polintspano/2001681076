namespace ST2001681076
{
    /// <summary>
    /// Main entity class
    /// </summary>
    public class Employee
    {
        private const string Unknown = "unknown";
        private string _id;
        private string _firstName;
        private string _lastName;
        private int _salary;

        public string Id { get => _id; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Salary { get => _salary; set => _salary = value; }

        public Employee()
        {
            _id = Unknown;
            _firstName = Unknown;
            _lastName = Unknown;
            _salary = 0;
        }

        public Employee(string id, string firstName, string lastName, int salary)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _salary = salary;
        }

        public MementoEmployee CreateMementoEmployee()
        {
            return new MementoEmployee(this);
        }

        public void RestoreToMemento(MementoEmployee mementoEmployee)
        {
            _id = mementoEmployee.Id;
            _firstName = mementoEmployee.FirstName;
            _lastName = mementoEmployee.LastName;
            _salary = mementoEmployee.Salary;
        }
    }

    /// <summary>
    /// Memento class
    /// </summary>
    public class MementoEmployee
    {
        private string _id;
        private string _firstName;
        private string _lastName;
        private int _salary;

        public string Id { get => _id; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Salary { get => _salary; set => _salary = value; }

        public MementoEmployee(Employee employee)
        {
            _id = employee.Id;
            _firstName = employee.FirstName;
            _lastName = employee.LastName;
            _salary = employee.Salary;
        }
    }

    /// <summary>
    /// Care taker class
    /// </summary>
    public class MementoEmployeeCareTaker
    {
        private Dictionary<string, MementoEmployee> _mementoEmployes = new Dictionary<string, MementoEmployee>();

        public Dictionary<string, MementoEmployee> MementoEmployees { get => _mementoEmployes; }
    }

    /// <summary>
    /// Entry point
    /// </summary>
    public class MainAppMemento
    {
        private static readonly Random random = new Random();

        public static void Main()
        {
            MementoEmployeeCareTaker mementoEmployeeCareTaker = new MementoEmployeeCareTaker();
            List<Employee> employees = new List<Employee> {
                new Employee("employee1", "Mihaela", "FIleva", 5000),
                new Employee("employee2", "Ivan", "Duhov", 3600)
            };

            employees.ForEach((employee) =>
            {
                mementoEmployeeCareTaker.MementoEmployees.Add(employee.Id, employee.CreateMementoEmployee());
                Console.Write($"Смяна на заплата за {employee.FirstName} {employee.LastName} от {employee.Salary} на ");
                employee.Salary = random.Next(1000, 10_000);
                Console.WriteLine($"{employee.Salary}.");
            });

            employees.ForEach((employee) =>
            {
                Console.Write($"Връшане на стара заплата на {employee.FirstName} {employee.LastName} на ");
                employee.RestoreToMemento(mementoEmployeeCareTaker.MementoEmployees[employee.Id]);
                Console.WriteLine($"{employee.Salary}.");
            });

            Console.ReadKey();
        }
    }
}