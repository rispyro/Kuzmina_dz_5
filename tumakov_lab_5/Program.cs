using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace tumakov_lab_5
{
    internal class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();

            Console.ReadKey();
        }
        /// <summary>
        /// перечисление месяцев
        /// </summary>
        enum Month
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        /// <summary>
        /// метод вычисления средней температуры для каждого месяца упр6.3
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        static double[] CalculateMonthlyAverages(int[,] temperature)
        {
            double[] averageTemperatures = new double[12];

            for (int i = 0; i < 12; i++)
            {
                double sum = 0;
                for (int j = 0; j < 30; j++)
                {
                    sum += temperature[i, j];
                }
                averageTemperatures[i] = sum / 30.0;
            }

            return averageTemperatures;
        }
        /// <summary>
        /// метод для умножения матриц упр6.2
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return resultMatrix;
        }
        /// <summary>
        /// метод для вывода матрицыупр6.2
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMatrix(int[,] matrix)
        {
            int rowsCount = matrix.GetLength(0);
            int colsCount = matrix.GetLength(1);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// метод вычисления средней температуры для каждого месяца дз6.3
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        static Dictionary<string, double> CalculateMonthlyAverages(Dictionary<string, int[]> temperature)
        {
            Dictionary<string, double> averageTemperatures = new Dictionary<string, double>();
            foreach (var month in temperature)
            {
                double sum = 0;
                foreach (var temp in month.Value)
                {
                    sum += temp;
                }
                averageTemperatures[month.Key] = sum / month.Value.Length;
            }
            return averageTemperatures;
        }
        /// <summary>
        /// Метод для умножения матриц дз6.2
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static LinkedList<LinkedList<int>> MatrixMultiplication(LinkedList<LinkedList<int>> matrix1, LinkedList<LinkedList<int>> matrix2)
        {
            int rows1 = matrix1.Count;
            int cols1 = matrix1.First.Value.Count;
            int rows2 = matrix2.Count;
            int cols2 = matrix2.First.Value.Count;
            LinkedList<LinkedList<int>> resultMatrix = new LinkedList<LinkedList<int>>();

            var row1 = matrix1.First;
            while (row1 != null)
            {
                LinkedList<int> resultRow = new LinkedList<int>();
                var col2 = matrix2.First;
                while (col2 != null)
                {
                    int sum = 0;
                    var element1 = row1.Value.First;
                    var element2 = col2.Value.First;

                    while (element1 != null && element2 != null)
                    {
                        sum += element1.Value * element2.Value;
                        element1 = element1.Next;
                        element2 = element2.Next;
                    }
                    resultRow.AddLast(sum);
                    col2 = col2.Next;
                }

                resultMatrix.AddLast(resultRow);
                row1 = row1.Next;
            }

            return resultMatrix;
        }
        /// <summary>
        /// Метод для вывода матрицы дз6.2
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// метод для подсчета количесвтва гласных и согласных букв
        /// </summary>
        /// <param name="text"></param>
        /// <param name="vowelCount"></param>
        /// <param name="consonantCount"></param>
        static void CountVowelsAndConsonants(string text, out int vowelCount, out int consonantCount)
        {
            vowelCount = 0;
            consonantCount = 0;
            string vowels = "aeiouyAEIOUYаеёиоуыэюяАЕЁИОУЫЭЮЯ";
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                {
                    if (vowels.Contains(c))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }
        }
        static void CountVowelsAndConsonants1(List<char> text, out int vowelCount, out int consonantCount)
        {
            vowelCount = 0;
            consonantCount = 0;
            string vowels = "aeiouyAEIOUYаеёиоуыэюяАЕЁИОУЫЭЮЯ";
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                {
                    if (vowels.Contains(c))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }
        }
        static void Task1()
        {
            Console.WriteLine("Упражнение 6.1");
            //Написать программу, которая вычисляет число гласных и согласных букв в
            //файле.Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
            //заносится в массив символов.Количество гласных и согласных букв определяется проходом
            //по массиву.Предусмотреть метод, входным параметром которого является массив символов.
            //Метод вычисляет количество гласных и согласных букв.
            string fileName = "fordz.txt";
            if (File.Exists(fileName))
            {
                try
                {
                    string text = File.ReadAllText(fileName);

                    int vowelsCount, consonantsCount;
                    CountVowelsAndConsonants(text, out vowelsCount, out consonantsCount);

                    Console.WriteLine($"Гласных букв: {vowelsCount}");
                    Console.WriteLine($"Согласных букв: {consonantsCount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
        }
        static void Task2()
        {
            Console.WriteLine("\nУпражнение 6.2");
            //Написать программу, реализующую умножению двух матриц, заданных в
            //виде двумерного массива.В программе предусмотреть два метода: метод печати матрицы,
            //метод умножения матриц(на вход две матрицы, возвращаемое значение – матрица).
            int[,] matrix1 = new int[2, 3]
            {
                {1, 2, 3},
                {4, 5, 6}
            };
            int[,] matrix2 = new int[3, 2]
            {
                {7,8},
                {9,10},
                {11,12}
            };
            int[,] resultMatrix = MatrixMultiplication(matrix1, matrix2);
            Console.WriteLine("Матрица №1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матрица №2:");
            PrintMatrix(matrix2);
            Console.WriteLine("Результат умножения матриц:");
            PrintMatrix(resultMatrix);

        }
        static void Task3()
        {
            Console.WriteLine("\nУпражение 6.3");
            //Написать программу, вычисляющую среднюю температуру за год. Создать
            //двумерный рандомный массив temperature[12, 30], в котором будет храниться температура
            //для каждого дня месяца(предполагается, что в каждом месяце 30 дней).Сгенерировать
            //значения температур случайным образом. Для каждого месяца распечатать среднюю
            //температуру.Для этого написать метод, который по массиву temperature[12, 30] для каждого
            //месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            //средних температур.Полученный массив средних температур отсортировать по возрастанию.
            Random rand = new Random();
            int[,] temperature = new int[12, 30];

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = rand.Next(-20, 31);
                }
            }

            double[] averageTemperatures = CalculateMonthlyAverages(temperature);
            Console.WriteLine("Средняя температура для каждого месяца:");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"{(Month)(i)}: {averageTemperatures[i]:0.0}°C");
            }
            Array.Sort(averageTemperatures);
            Console.WriteLine("\nОтсортированные средние температуры по возрастанию:");
            foreach (var temp in averageTemperatures)
            {
                Console.WriteLine($"{temp:0.0}°C");
            }

        }
        static void Task4()
        {
            Console.WriteLine("\nДомашнее задание 6.1");
            //Упражнение 6.1 выполнить с помощью коллекции List<T>.
            string fileName1 = "fordz.txt";
            if (File.Exists(fileName1))
            {
                try
                {
                    string fileContent = File.ReadAllText(fileName1);
                    List<char> textList = new List<char>(fileContent.ToCharArray());
                    int vowelsCount, consonantsCount;
                    CountVowelsAndConsonants1(textList, out vowelsCount, out consonantsCount);

                    Console.WriteLine($"Гласных букв: {vowelsCount}");
                    Console.WriteLine($"Согласных букв: {consonantsCount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Файл не существует.");
                return;
            }
        }
        static void Task5()
        {
            Console.WriteLine("\nДомашнее задание 6.2");
            //Упражнение 6.2 выполнить с помощью коллекций LinkedList<LinkedList<T>>.
            LinkedList<LinkedList<int>> matrix1 = new LinkedList<LinkedList<int>>();
            matrix1.AddLast(new LinkedList<int>(new[] { 1, 2, 3 }));
            matrix1.AddLast(new LinkedList<int>(new[] { 4, 5, 6 }));

            LinkedList<LinkedList<int>> matrix2 = new LinkedList<LinkedList<int>>();
            matrix2.AddLast(new LinkedList<int>(new[] { 7, 8 }));
            matrix2.AddLast(new LinkedList<int>(new[] { 9, 10 }));
            matrix2.AddLast(new LinkedList<int>(new[] { 11, 12 }));

            LinkedList<LinkedList<int>> resultMatrix = MatrixMultiplication(matrix1, matrix2);

            Console.WriteLine("Матрица №1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матрица №2:");
            PrintMatrix(matrix2);
            Console.WriteLine("Результат умножения матриц:");
            PrintMatrix(resultMatrix);
        }
        static void Task6()
        {
            Console.WriteLine("\nДомашнее задание 6.3");
            //Написать программу для упражнения 6.3, использовав класс
            //Dictionary<TKey, TValue>.В качестве ключей выбрать строки – названия месяцев, а в
            //качестве значений – массив значений температур по дням.
            Random rand = new Random();
            Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();
            foreach (var month in Enum.GetValues(typeof(Month)))
            {
                string monthName = Enum.GetName(typeof(Month), month);
                int[] dailyTemperatures = new int[30];

                for (int i = 0; i < 30; i++)
                {
                    dailyTemperatures[i] = rand.Next(-20, 31);
                }

                temperature[monthName] = dailyTemperatures;
            }
            var averageTemperatures = CalculateMonthlyAverages(temperature);

            Console.WriteLine("Средняя температура для каждого месяца:");
            foreach (var month in averageTemperatures)
            {
                Console.WriteLine($"{month.Key}: {month.Value:0.0}°C");
            }
            var sortedAverages = new List<KeyValuePair<string, double>>(averageTemperatures);
            sortedAverages.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            Console.WriteLine("\nОтсортированные средние температуры по возрастанию:");
            foreach (var temp in sortedAverages)
            {
                Console.WriteLine($"{temp.Key}: {temp.Value:0.0}°C");
            }
        }
    }
}
