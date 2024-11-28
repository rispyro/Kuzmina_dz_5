using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/// <summary>
/// класс, который описывает студента
/// </summary>
class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int BirthYear { get; set; }
    public string Exam { get; set; }
    public int Score { get; set; }

    public Student(string lastName, string firstName, int birthYear, string exam, int score) => (LastName, FirstName, BirthYear, Exam, Score) = (lastName, firstName, birthYear, exam, score);

    public override string ToString()
    {
        return $"{LastName} {FirstName}, {BirthYear} год рождения, экзамен: {Exam}, баллы: {Score}";
    }
}

class Program
{
    static List<Student> students = new List<Student>();
    /// <summary>
    /// метод итает информацию о студентах из файла с указанным именем
    /// </summary>
    /// <param name="filename"></param>
    static void ReadStudentsFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 5)
                {
                    string lastName = parts[0].Trim();
                    string firstName = parts[1].Trim();
                    if (int.TryParse(parts[2].Trim(), out int birthYear) && int.TryParse(parts[4].Trim(), out int score))
                    {
                        string exam = parts[3].Trim();
                        students.Add(new Student(lastName, firstName, birthYear, exam, score));
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка при чтении данных студента: {line}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Файл не найден. Студенты не были загружены.");
        }
    }
    /// <summary>
    /// метод для добавления студента в список
    /// </summary>
    static void AddNewStudent()
    {
        Console.Write("Введите фамилию: ");
        string lastName = Console.ReadLine();
        Console.Write("Введите имя: ");
        string firstName = Console.ReadLine();
        int birthYear;
        while (true)
        {
            Console.Write("Введите год рождения: ");
            if (int.TryParse(Console.ReadLine(), out birthYear))
                break;
            else
                Console.WriteLine("Неверный ввод. Пожалуйста, введите корректный год.");
        }

        Console.Write("Введите экзамен: ");
        string exam = Console.ReadLine();

        int score;
        while (true)
        {
            Console.Write("Введите количество баллов: ");
            if (int.TryParse(Console.ReadLine(), out score))
                break;
            else
                Console.WriteLine("Неверный ввод. Пожалуйста, введите корректное количество баллов.");
        }
        students.Add(new Student(lastName, firstName, birthYear, exam, score));
        Console.WriteLine("Новый студент добавлен.");
    }
    /// <summary>
    /// метод для удаления студента из списка
    /// </summary>
    static void RemoveStudent()
    {
        Console.Write("Введите фамилию студента для удаления: ");
        string lastName = Console.ReadLine();
        Console.Write("Введите имя студента для удаления: ");
        string firstName = Console.ReadLine();
        var studentToRemove = students.FirstOrDefault(s => s.LastName == lastName && s.FirstName == firstName);
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine("Студент удален.");
        }
        else
        {
            Console.WriteLine("Студент не найден.");
        }
    }
    /// <summary>
    /// метод для сортировки студентов
    /// </summary>
    static void SortStudentsByScore()
    {
        students = students.OrderBy(s => s.Score).ToList();
        Console.WriteLine("Студенты отсортированы по баллам (по возрастанию).");
        DisplayStudents();
    }
    /// <summary>
    /// метод с информацией обо всех студентах в списке
    /// </summary>
    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Нет студентов для отображения.");
        }
        else
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();

        Console.ReadKey();
    }
    static void Task1()
    {

    }
    static void Task2()
    {
        Console.WriteLine("Задание 2");

        ReadStudentsFromFile("students.txt");
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Новый студент");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Сортировать студентов по баллам");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите действие (1-4): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewStudent();
                    break;

                case "2":
                    RemoveStudent();
                    break;

                case "3":
                    SortStudentsByScore();
                    break;

                case "4":
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
    static void Task3()
    {

    }
    static void Task4()
    {

    }
}
