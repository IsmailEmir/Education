using System;
using System.Collections;
using System.Collections.Generic;

namespace Employee_Program;

public static class IdGenerator
{
    private static int id = 1000;
    public static int GenerateNewId()
    {
        return id++;
    }
}
public static class DecimalExtensions
{
    public static string ToCurrencyFormat(this decimal value) 
    {
        return $"{value:N2} ₽";
    }
}
public static class EmployeeExtensions
{
    public static string DisplayFormalInfo(this Employee emp)
    {
        string position = emp switch
        {
            Manager => "Менеджер",
            Developer => "Разработчик",
            Intern => "Стажёр",
            _ => "Сотрудник"
        };
        return String.Format("[{0}] {1}, ID: {2}", position, emp.FullName, emp.Id); //впиши параметры пж
    }
}
public class Employee
{
    private decimal _salary;
    public int Id { get; }
    public string FullName { get; set; }

    public decimal Salary
    {
        get => _salary;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(value.ToString(), "Зарплата должна быть больше нуля.");
            _salary = value;
        }
    }
        
    public Employee(string fullName, decimal salary)
    {
        FullName = fullName;
        Salary = salary;
        Id = IdGenerator.GenerateNewId();
    }
    public virtual decimal CalculateBonus()
    {
        return Salary * 0.05m;
    }
}
public class Intern : Employee
{
    public string SchoolName { get; set; }
    public Intern(string fullName, decimal salary, string schoolName) : base (fullName, salary)
    {
        SchoolName = schoolName;
    }
    public override decimal CalculateBonus()
    {
        return 0m;
    }
}
public class Manager : Employee
{

    public int ManagedTeamSize { get; set; }

    public Manager(string fullName, decimal salary, int managedTeamSize) : base( fullName, salary )
    {
        ManagedTeamSize = managedTeamSize;
    }
    public override decimal CalculateBonus()
    {
        return Salary * 0.15m;
    }
}
public class Developer : Employee
{
    public int ProjectComplexityScore { get; set; }

    public Developer(string fullName, decimal salary, int projectComplexityScore) : base( fullName, salary )
    {
        ProjectComplexityScore = projectComplexityScore;
    }
    public override decimal CalculateBonus()
    {
        return Salary * (0.05m + 0.01m * ProjectComplexityScore);
    }
}
public class PayrollProcessor
{
    public void Process(List<Employee> employees)
    {
        Console.WriteLine("\n--- Начисление бонусов ---");
        foreach (var emp in employees)
        {
            Console.WriteLine(emp.DisplayFormalInfo());
            decimal bonus = emp.CalculateBonus();
            Console.WriteLine($"  Начислен бонус: {bonus.ToCurrencyFormat()}");
            Console.WriteLine();
        }
    }
}

class Program
{
    public static void AddEmployee()
    {
        Console.WriteLine("\nВыберите должность сотрудника:");
        Console.WriteLine("1 - Стажёр");
        Console.WriteLine("2 - Обычный сортудник");
        Console.WriteLine("3 - Разработчик");
        Console.WriteLine("4 - Менеджер");

        string? typeInput = Console.ReadLine();
        if (!int.TryParse(typeInput, out int type) || type < 1 || type > 4)
        {
            Console.WriteLine("Неверный тип.");
            return;
        }

        Console.Write("Введите ФИО: ");
        string? fullName = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(fullName))
        {
            Console.WriteLine("ФИО не может быть пустым.");
            return;
        }

        Console.Write("Зарплата: ");
        string? salaryInput = Console.ReadLine();
        if (!decimal.TryParse(salaryInput, out decimal salary) || salary <= 0)
        {
            Console.WriteLine("Зарплата должна быть положительным числом.");
            return;
        }

        try
        {
            Employee emp = type switch
            {
                1 => CreateIntern(fullName, salary),
                2 => new Employee(fullName, salary),
                3 => CreateDeveloper(fullName, salary),
                4 => CreateManager(fullName, salary),
                _ => throw new InvalidOperationException()
            };

            staff.Add(emp);
            Console.WriteLine($"{emp.DisplayFormalInfo()} добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    private static List<Employee> staff = new List<Employee>();
    private static Manager CreateManager(string fullName, decimal salary)
    {
        Console.Write("Размер команды: ");
        if (!int.TryParse(Console.ReadLine(), out int teamSize) || teamSize < 0)
            throw new ArgumentException("Размер команды должен быть >= 0");
        return new Manager(fullName, salary, teamSize);
    }

    private static Developer CreateDeveloper(string fullName, decimal salary)
    {
        Console.Write("Сложность проекта (баллы): ");
        if (!int.TryParse(Console.ReadLine(), out int score) || score < 0)
            throw new ArgumentException("Сложность не может быть отрицательной");
        return new Developer(fullName, salary, score);
    }

    private static Intern CreateIntern(string fullName, decimal salary)
    {
        Console.Write("Учебное заведение: ");
        string? school = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(school))
            throw new ArgumentException("Название вуза не может быть пустым");
        return new Intern(fullName, salary, school);
    }

    private static void RemoveEmployee()
    {
        if (staff.Count == 0)
        {
            Console.WriteLine("Список сотрудников пуст.");
            return;
        }

        ListEmployees();
        Console.Write("Введите ID сотрудника для удаления: ");

        if (!int.TryParse(Console.ReadLine(), out int idToDelete))
        {
            Console.WriteLine("Неверный ID.");
            return;
        }

        Employee? toRemove = null;
        foreach (var emp in staff)
        {
            if (emp.Id == idToDelete)
            {
                toRemove = emp;
                break;
            }
        }

        if (toRemove != null)
        {
            staff.Remove(toRemove);
            Console.WriteLine($"Сотрудник с ID {idToDelete} удалён.");
        }
        else
        {
            Console.WriteLine($"Сотрудник с ID {idToDelete} не найден.");
        }
    }

    private static void EditEmployee()
    {
        if (staff.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        ListEmployees();
        Console.Write("Введите ID сотрудника для редактирования: ");

        if (!int.TryParse(Console.ReadLine(), out int idToEdit))
        {
            Console.WriteLine("Неверный ID.");
            return;
        }

        Employee? target = null;
        foreach (var emp in staff)
        {
            if (emp.Id == idToEdit)
            {
                target = emp;
                break;
            }
        }

        if (target == null)
        {
            Console.WriteLine($"Сотрудник с ID {idToEdit} не найден.");
            return;
        }

        Console.WriteLine($"Текущие данные: {target.DisplayFormalInfo()}");
        Console.Write("Новое ФИО (оставьте пустым, чтобы не менять): ");
        string? newFullName = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(newFullName))
        {
            target.FullName = newFullName;
        }

        Console.Write("Новая зарплата (оставьте пустым, чтобы не менять): ");
        string? newSalaryStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newSalaryStr))
        {
            if (decimal.TryParse(newSalaryStr, out decimal newSalary) && newSalary > 0)
            {
                target.Salary = newSalary;
                Console.WriteLine("Зарплата обновлена.");
            }
            else
            {
                Console.WriteLine("Неверная зарплата. Изменение пропущено.");
            }
        }

        if (target is Manager mgr)
        {
            Console.Write($"Текущий размер команды: {mgr.ManagedTeamSize}. Новый (пусто — пропустить): ");
            string? teamInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(teamInput) && int.TryParse(teamInput, out int newTeam))
            {
                if (newTeam >= 0)
                    mgr.ManagedTeamSize = newTeam;
                else
                    Console.WriteLine("Размер команды не может быть отрицательным.");
            }
        }
        else if (target is Developer dev)
        {
            Console.Write($"Текущая сложность: {dev.ProjectComplexityScore}. Новая (пусто — пропустить): ");
            string? scoreInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(scoreInput) && int.TryParse(scoreInput, out int newScore))
            {
                if (newScore >= 0)
                    dev.ProjectComplexityScore = newScore;
                else
                    Console.WriteLine("Слонжость не может быть отрицательной.");
            }
        }
        else if (target is Intern intern)
        {
            Console.Write($"Текущий вуз: {intern.SchoolName}. Новый (пусто — пропустить): ");
            string? schoolInput = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(schoolInput))
            {
                intern.SchoolName = schoolInput;
            }
        }

        Console.WriteLine("Данные обновлены.");
    }

    private static void ListEmployees()
    {
        if (staff.Count == 0)
        {
            Console.WriteLine("\nСписок сотрудников пуст.");
            return;
        }

        Console.WriteLine("\nСписок сотрудников:");
        foreach (var emp in staff)
        {
            Console.WriteLine(emp.DisplayFormalInfo());
            Console.WriteLine($"  Бонус: {emp.CalculateBonus().ToCurrencyFormat()}");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Добро пожаловать в систему управления сотрудниками");
        Console.WriteLine("Команды: add, remove, edit, list, exit");

        string command;
        while ((command = Console.ReadLine()?.Trim().ToLower()) != "exit")
        {
            switch (command)
            {
                case "add":
                    AddEmployee();
                    break;
                case "remove":
                    RemoveEmployee();
                    break;
                case "edit":
                    EditEmployee();
                    break;
                case "list":
                    ListEmployees();
                    break;
                default:
                    Console.WriteLine("Неизвестная команда. Доступные: add, remove, edit, list, exit");
                    break;
            }
        }

        Console.WriteLine("Выход из системы.");
    }
}