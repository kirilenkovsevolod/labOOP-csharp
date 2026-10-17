using System;


namespace Lab5OOP
{
    internal class Program
    {
        static int ReadInt(string prompt)
        {
            bool isInputValid;
            int value;
            do
            {
                Console.Write(prompt);
                isInputValid = int.TryParse(Console.ReadLine(), out value);
                if (!isInputValid)
                    Console.WriteLine("Некорректный ввод! Повторите.");
            } while (!isInputValid);
            return value;
        }
        static int ReadInt(string prompt, int min, int max)
        {
            bool isInputValid;
            int value;
            do
            {
                Console.Write(prompt);
                isInputValid = int.TryParse(Console.ReadLine(), out value);
                if (!isInputValid || (value > max || value < min))
                    Console.WriteLine("Некорректный ввод! Повторите.");
            } while (!isInputValid || (value > max || value < min));
            return value;
        }
        static void PrintMenu() //вывод главного меню
        {
            Console.WriteLine("1. Работа с двумерным массивами\n2. Работа с рваными массивами\n3. Работа с текстом\n4. Выход");
        }
        static void PrintArrMenu()  //вывод внутреннего меню
        {
            Console.WriteLine("1. Создать массив вручную\n2. Создать массив случайно\n3. Напечатать массив\n4. Обработать массив\n5. Назад");
        }
        static int[,] CreateMatrixManual()  //создание двум.массива вручную
        {
            int strings, columns;
            strings = ReadInt("Введите количество строк: ", 1, 20);
            columns = ReadInt("Введите количество столбцов: ", 1, 20);
            int[,] matrix = new int[strings, columns];
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = ReadInt($"Элемент [{i}][{j}] = ");

                }
            }
            return matrix;
        }
        static int[,] CreateMatrixRandom()  //создание двум.массива случайно
        {
            Random rnd = new Random();
            int strings, columns;
            strings = ReadInt("Введите количество строк: ", 1, 20);
            columns = ReadInt("Введите количество столбцов: ", 1, 20);
            int[,] matrix = new int[strings, columns];
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(1, 100);

                }
            }
            return matrix;
        }
        static void PrintMatrix(int[,] matrix) //вывод массива
        {
            if (matrix == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
        static int[,] AddStringsToBegin(int[,] matrix) //задание Добавить К строк в начало матрицы
        {
            if (matrix == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return matrix;
            }
            int cnt = ReadInt("Сколько строк добавить в начало? ", 1, 20);
            int oldStrings = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[,] resMatrix = new int[cnt + oldStrings, columns];
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resMatrix[i, j] = 0;
                }
            }
            for (int i = 0; i < oldStrings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resMatrix[i + cnt, j] = matrix[i, j];
                }
            }
            Console.WriteLine($"Добавлено {cnt} строк");
            return resMatrix;
        }
        static int[][] CreateJagManual()  //создание рваного массива вручную
        {
            int strings = ReadInt("Введите количество строк:", 1, 20);
            int[][] jag = new int[strings][];
            for (int i = 0; i < strings; i++)
            {
                int columns = ReadInt($"Введите длину строки {i + 1}:", 1, 20);
                jag[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                    jag[i][j] = ReadInt($"Элемент [{i}][{j}] = ");
            }
            return jag;
        }
        static int[][] CreateJagRandom()  //создание рваного массива случайно
        {
            Random rnd = new Random();
            int strings = ReadInt("Введите количество строк:", 1, 20);
            int[][] jag = new int[strings][];
            for (int i = 0; i < strings; i++)
            {
                int columns = ReadInt($"Введите длину строки {i + 1}:", 1, 20);
                jag[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                    jag[i][j] = rnd.Next(1, 100);
            }
            return jag;
        }
        static void PrintJag(int[][] jag) //вывод рваного массива
        {
            if (jag == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return;
            }
            for (int i = 0; i < jag.Length; i++)
            {
                for (int j = 0; j < jag[i].Length; j++)
                {
                    Console.Write($"{jag[i][j]}\t");
                }
                Console.WriteLine();
            }
        }
        static int[][] DeleteStringByNumber(int[][] jag) //задание Удалить строку с заданным номером
        {
            if (jag == null)
            {
                Console.WriteLine("Массив еще не создан.");
                return jag;
            }
            if (jag.Length == 0)
            {
                Console.WriteLine("Массив пуст, удалять нечего.");
                return jag;
            }
            int num = ReadInt("Введите номер строки для удаления: ", 1, jag.Length);
            int index = num - 1;
            int[][] resJag = new int[jag.Length - 1][];
            int k = 0;
            for (int i = 0; i < jag.Length; i++)
            {
                if (i == index)
                    continue;
                resJag[k] = jag[i];
                k++;
            }
            Console.WriteLine($"Строка {num} удалена.");
            return resJag;
        }
        static string ReadText()
        {
            Console.Write("Введите строку: ");
            return Console.ReadLine();
        }

        static string GetTestText()
        {
            return "В лесу родилась елка! В лесу она росла. Зимой и летом была стройная, зеленая!";
        }

        static void PrintText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Строка пуста.");
                return;
            }
            Console.WriteLine(text);
        }
        static void PrintTextMenu()
        {
            Console.WriteLine("1. Ввести строку с клавиатуры\n2. Тестовая строка\n3. Напечатать строку\n4. Обработать строку\n5. Назад");
        }
        static string ReverseWord(string word)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        static string ReverseWords(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Строка пуста.");
                return text;
            }
            char[] endPuncts = { ',', '.', '!', '?', ';', ':' };
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int wordNumber = 0;
            for (int i = 0; i < words.Length; i++)
            {
                string core = words[i].TrimEnd(endPuncts);
                string tail = words[i].Substring(core.Length);

                wordNumber++;

                if (wordNumber == core.Length)
                    words[i] = ReverseWord(core) + tail;

                if (tail.IndexOfAny(new char[] { '.', '!', '?' }) >= 0)
                    wordNumber = 0;
            }
            return string.Join(" ", words);
        }
        static void Main(string[] args)
        {
            int[,] matrix = null;
            int[][] jag = null;
            string text = null;
            int choice;
            do
            {
                PrintMenu();
                choice = ReadInt("Ваш выбор: ", 1, 4);
                switch (choice)
                {
                    case 1:
                        int matrixChoice;
                        do
                        {
                            PrintArrMenu();
                            matrixChoice = ReadInt("Ваш выбор: ", 1, 5);
                            switch (matrixChoice)
                            {
                                case 1: matrix = CreateMatrixManual(); break;
                                case 2: matrix = CreateMatrixRandom(); break;
                                case 3: PrintMatrix(matrix); break;
                                case 4: matrix = AddStringsToBegin(matrix); break;
                                case 5: break;

                            }
                        } while (matrixChoice != 5); break;
                    case 2:
                        int jagChoice;
                        do
                        {
                            PrintArrMenu();
                            jagChoice = ReadInt("Ваш выбор: ", 1, 5);
                            switch (jagChoice)
                            {
                                case 1: jag = CreateJagManual(); break;
                                case 2: jag = CreateJagRandom(); break;
                                case 3: PrintJag(jag); break;
                                case 4: jag = DeleteStringByNumber(jag); break;
                                case 5: break;

                            }
                        } while (jagChoice != 5); break;
                    case 3:
                        int strChoice;
                        do
                        {
                            PrintTextMenu();
                            strChoice = ReadInt("Ваш выбор: ", 1, 5);
                            switch (strChoice)
                            {
                                case 1: text = ReadText(); break;
                                case 2: text = GetTestText(); break;
                                case 3: PrintText(text); break;
                                case 4: text = ReverseWords(text); break;
                                case 5: break;
                            }
                        } while (strChoice != 5); break;
                    case 4: break;
                }
            } while (choice != 4);
        }
    }
}
