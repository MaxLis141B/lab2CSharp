using System;

public class Program
{
    static void task1_1()
    {
        Console.Write("Введіть розмір одновимірного масиву: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[] array = new int[n];
            int sum = 0;
            Random rand = new Random();

            Console.WriteLine("Елементи масиву:");
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(1, 100); 
                Console.Write(array[i] + " ");

                if (array[i] % 9 == 0)
                {
                    sum += array[i];
                }
            }

            Console.WriteLine($"\nСума елементів, кратних 9: {sum}");
        }
    }
    static void task1_2()
    {
        Console.Write("Введіть кількість рядків: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        int sum = 0;
        Random rand = new Random();

        Console.WriteLine("\nМатриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(1, 100);
                Console.Write(matrix[i, j] + "\t");

                if (matrix[i, j] % 9 == 0)
                {
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\nСума елементів, кратних 9: {sum}");
    }

    public static (int max, int index) FindMaxElement(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Масив не може бути порожнім");

        int maxValue = array[0];
        int firstMaxIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
            {
                maxValue = array[i];
                firstMaxIndex = i;
            }
        }
        return (maxValue, firstMaxIndex);
    }

    static void task2()
    {
        Console.Write("Введіть розмір масиву: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[] array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-50, 51);
                Console.Write(array[i] + " ");
            }

            var result = FindMaxElement(array);

            Console.WriteLine($"\nМаксимум: {result.max}, Індекс: {result.index}");
        }
    }

    static void task3()
    {
       
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців (m): ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, m];
        Random rand = new Random();

        Console.WriteLine("\nПочаткова матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = rand.Next(1, 100);
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        if (m % 2 == 0)
        {
            Console.WriteLine("\nКількість стовпців парна. Виконуємо обмін...");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j += 2)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, j + 1];
                    matrix[i, j + 1] = temp;
                }
            }

            Console.WriteLine("\nМатриця після перестановки стовпців:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("\nКількість стовпців непарна. Масив залишено без змін.");
        }
    }

    static void task4()
    {
        Console.Write("Введіть кількість рядків: ");
        if (!int.TryParse(Console.ReadLine(), out int n)) return;

        int[][] jagged = new int[n][];
        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть кількість стовпців для рядка {i}: ");
            if (int.TryParse(Console.ReadLine(), out int m))
            {
                jagged[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    jagged[i][j] = rand.Next(-20, 81);
                }
            }
        }

        Console.WriteLine("\nСхідчастий масив:");
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.Write($"Рядок {i}: ");
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nРезультати:");
        for (int i = 0; i < jagged.Length; i++)
        {
            int foundIndex = -1;
            for (int j = 0; j < jagged[i].Length; j++)
            {
                if (jagged[i][j] < 0)
                {
                    foundIndex = j;
                    break;
                }
            }

            if (foundIndex != -1)
            {
                Console.WriteLine($"Рядок {i}: індекс {foundIndex} (номер {foundIndex + 1})");
            }
            else
            {
                Console.WriteLine($"Рядок {i}: від'ємних елементів немає");
            }
        }
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.WriteLine("\nЗавдання 4:");
        task4();
    }
}