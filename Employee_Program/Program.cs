//namespace Blaze;

//public static class IdGenerator
//{
//    private static int id = 1000;
//    public static int GenerateNewId()
//    {
//        return id++;
//    }
//}

//public static class DecimalExtensions
//{
//    public static string ToCurrencyFormat(this decimal value)
//    {
//        return $"{value:N2} ₽";
//    }
//}
//public static class EmployeeExtensions
//{
//    public static string DisplayFormalInfo(this Employee emp)
//    {
//        string position = emp switch
//        {
//            Manager => "Менеджер",
//            Developer => "Разработчик",
//            Intern => "Стажёр",
//            _ => "Сотрудник"
//        };
//        return String.Format("[{0}] {1}, ID: {2}", position, emp.FullName, emp.Id); //впиши параметры пж
//    }
//}

//public class Employee
//{
//    private decimal _salary;
//    public int Id { get; }
//    public string FullName { get; set; }

//    public decimal Salary
//    {
//        get => _salary;
//        set
//        {
//            if (value <= 0)
//                throw new ArgumentOutOfRangeException(value.ToString(), "Зарплата должна быть больше нуля.");
//            _salary = value;
//        }
//    }

//    public Employee(string fullName, decimal salary)
//    {
//        FullName = fullName;
//        Salary = salary;
//        Id = IdGenerator.GenerateNewId();
//    }
//    public virtual decimal CalculateBonus()
//    {
//        return Salary * 0.05m;
//    }
//}
//public class Intern : Employee
//{
//    public string SchoolName { get; set; }
//    public Intern(string fullName, decimal salary, string schoolName) : base(fullName, salary)
//    {
//        SchoolName = schoolName;
//    }
//    public override decimal CalculateBonus()
//    {
//        return 0m;
//    }
//}


//public class Manager : Employee
//{

//    public int ManagedTeamSize { get; set; }

//    public Manager(string fullName, decimal salary, int managedTeamSize) : base(fullName, salary)
//    {
//        ManagedTeamSize = managedTeamSize;
//    }
//    public override decimal CalculateBonus()
//    {
//        return Salary * 0.15m;
//    }
//}

//public class Developer : Employee
//{
//    public int ProjectComplexityScore { get; set; }

//    public Developer(string fullName, decimal salary, int projectComplexityScore) : base(fullName, salary)
//    {
//        ProjectComplexityScore = projectComplexityScore;
//    }
//    public override decimal CalculateBonus()
//    {
//        return Salary * (0.05m + 0.01m * ProjectComplexityScore);
//    }
//}

//public class PayrollProcessor
//{
//    public void Process(List<Employee> employees)
//    {
//        Console.WriteLine("\n--- Начисление бонусов ---");
//        foreach (var emp in employees)
//        {
//            Console.WriteLine(emp.DisplayFormalInfo());
//            decimal bonus = emp.CalculateBonus();
//            Console.WriteLine($"  Начислен бонус: {bonus.ToCurrencyFormat()}");
//            Console.WriteLine();
//        }
//    }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        Console.OutputEncoding = System.Text.Encoding.UTF8;

//        // --- Демонстрация ООП ---

//        // 1. Создание экземпляров дочерних классов
//        Manager manager1 = new Manager("Иванов И.И.", 70000m, 5);
//        Developer dev1 = new Developer("Петров П.П.", 50000m, 20); // 20% сложности
//        Developer dev2 = new Developer("Сидорова А.В.", 60000m, 10);
//        Intern intern1 = new Intern("Коч И.Э.", 30000m, "КФУ ИТИС");

//        Console.WriteLine("--- Созданные Объекты и ID (Статика) ---");
//        Console.WriteLine($"ID менеджера: {manager1.Id} (Ожидается 1001)");
//        Console.WriteLine($"ID разработчика 2: {dev2.Id} (Ожидается 1003)");

//        // 2. Инкапсуляция: Проверка валидации (покажите, что это вызовет исключение)
//        try
//        {
//            dev1.Salary = -5000m;
//        }
//        catch (ArgumentOutOfRangeException ex)
//        {
//            Console.WriteLine($"\n[Ошибка Инкапсуляции]: {ex.Message}");
//        }


//        // 3. Полиморфизм: Создание списка базовых типов
//        List<Employee> staff = new List<Employee>
//        {
//            manager1, // Manager представлен как Employee
//            dev1,     // Developer представлен как Employee
//            dev2,
//            intern1
//        };


//        // 4. Запуск полиморфического процесса
//        PayrollProcessor processor = new PayrollProcessor();
//        processor.Process(staff);


//        // 5. Демонстрация метода расширения (используется в Process)
//        decimal cash = 1234567.89m;
//        Console.WriteLine($"\nРасширение <Тип>Extensions: {cash.ToCurrencyFormat()}");
//    }
//}