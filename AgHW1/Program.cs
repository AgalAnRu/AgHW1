namespace AgHW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();
            string menuFirst = @"Операции:
1. Сложение
2. Возведение в квадрат
3. Деление второго числа на первое
* Дополнительные варианты операций";
            string menuSecond = @"Операции:
1. Сложение
2. Возведение в квадрат
3. Деление второго числа на первое
4. Синус числа
5. Косинус числа
6. Возведение в степень
7. Извлечение натурального логарифма
8. Извлечение десятичного логарифма
9. Извлечение логарифма";
            string suggestionToSelectItem = "Наберите цифру соответствующей операции и нажмите ENTER: ";
            string anyKeyOrEscape = "Для продолжения нажмите любую клавишу (для выхода нажмите ESCAPE): ";
            string wrongInput = "\nНекорректный ввод";
            bool isExitFromConsole = false;
            bool isSecondTask = false;
            char keyFromConsole = ' ';
            while (!isExitFromConsole)
            {
                Console.Clear();
                if (!isSecondTask)
                {
                    Console.WriteLine(menuFirst);
                    Console.Write(suggestionToSelectItem);
                    keyFromConsole = Console.ReadKey().KeyChar;
                    if (keyFromConsole == '*') isSecondTask = true;
                }

                if (isSecondTask)
                {
                    Console.Clear();
                    Console.WriteLine(menuSecond);
                    Console.Write(suggestionToSelectItem);
                    keyFromConsole = Console.ReadKey().KeyChar;
                }
                switch (keyFromConsole)
                {
                    case '1':
                        calculate.Addition();
                        break;
                    case '2':
                        calculate.Square();
                        break;
                    case '3':
                        calculate.Division();
                        break;
                    default:
                        if (!isSecondTask)
                        {
                            Console.WriteLine(wrongInput);
                        }
                        break;
                }
                if (isSecondTask)
                {
                    switch (keyFromConsole)
                    {
                        case '4':
                            calculate.Sinus();
                            break;
                        case '5':
                            calculate.Cosinus();
                            break;
                        case '6':
                            calculate.Pow();
                            break;
                        case '7':
                            calculate.Ln();
                            break;
                        case '8':
                            calculate.Lg();
                            break;
                        case '9':
                            calculate.Log();
                            break;
                        default:
                            Console.WriteLine(wrongInput);
                            break;
                    }
                }
                Console.Write(anyKeyOrEscape);
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    isExitFromConsole = true;
                }
            }
        }
    }

    internal class Calculate
    {
        decimal firstNumber;
        decimal secondNumber;
        decimal result = 0;
        static readonly string askNumber = "\nВведите число: ";
        static readonly string askFirstNumber = "\nВведите первое число: ";
        static readonly string askSecondtNumber = "\nВведите второе число: ";
        private static decimal GetOnlyNumber()
        {
            char charFromKeybord;
            decimal returnValue;
            bool isComma = false;
            bool isFirstSymbole = true;
            string stringFromConsole = "0";
            ConsoleKeyInfo keyFromKeybord;
            while ((keyFromKeybord = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                charFromKeybord = keyFromKeybord.KeyChar;
                if (charFromKeybord == '-' && isFirstSymbole)
                {
                    Console.Write("-");
                    stringFromConsole = "-" + stringFromConsole;
                    isFirstSymbole = false;
                }
                if (Char.IsDigit(charFromKeybord))
                {
                    Console.Write(charFromKeybord);
                    stringFromConsole += charFromKeybord;
                    isFirstSymbole = false;
                }

                if ((charFromKeybord == ',' || charFromKeybord == '.') && !isComma)
                {
                    if (isFirstSymbole)
                    {
                        isFirstSymbole = false;
                        Console.Write('0');
                    }
                    Console.Write(',');
                    stringFromConsole += ',';
                    isComma = true;

                }
            }
            if (stringFromConsole == "0" || stringFromConsole == "" || stringFromConsole == null)
            {
                Console.Write(0);
                return 0;
            }
            returnValue = Convert.ToDecimal(stringFromConsole);
            return returnValue;
        }
        internal void Addition()
        {
            Console.Write(askFirstNumber);
            firstNumber = GetOnlyNumber();
            Console.Write(askSecondtNumber);
            secondNumber = GetOnlyNumber();
            result = firstNumber + secondNumber;
            Console.WriteLine($"\nРезультат сложения равен: {result} ");
        }

        internal void Square()
        {
            Console.Write(askNumber);
            firstNumber = GetOnlyNumber();
            result = firstNumber * firstNumber;
            Console.WriteLine($"\nРезультат возведения в квадрат равен: {result} ");
        }
        internal void Division()
        {
            Console.Write(askFirstNumber);
            firstNumber = GetOnlyNumber();
            Console.Write(askSecondtNumber);
            secondNumber = GetOnlyNumber();
            if (firstNumber == 0)
            {
                Console.WriteLine($"\nРезультат деления стремится к бесконечности");
            }
            if (firstNumber != 0)
            {
                result = secondNumber / firstNumber;
                Console.WriteLine($"\nРезультат деления равен: {result} ");
            }
        }
        internal void Sinus()
        {
            Console.Write(askNumber);
            firstNumber = GetOnlyNumber();
            result = (decimal)Math.Sin((double)firstNumber);
            Console.WriteLine($"\nСинус равен: {result}");
        }
        internal void Cosinus()
        {
            Console.Write(askNumber);
            firstNumber = GetOnlyNumber();
            result = (decimal)Math.Cos((double)firstNumber);
            Console.WriteLine($"\nКосинус равен: {result}");
        }
        internal void Pow()
        {
            Console.Write(askNumber);
            firstNumber = GetOnlyNumber();
            Console.Write("\nВведите степень числа: ");
            secondNumber = GetOnlyNumber();
            result = (decimal)Math.Pow((double)firstNumber, (double)secondNumber);
            Console.WriteLine($"\nЧисло {firstNumber} в степени {secondNumber} равно: {result}");
        }
        internal void Ln()
        {
            Console.Write(askNumber);
            firstNumber = GetOnlyNumber();
            result = (decimal)Math.Log((double)firstNumber);
            Console.WriteLine($"\nНатуральный логарифм от числа {firstNumber} равен: {result}");
        }
        internal void Lg()
        {
            Console.Write(askNumber);
            firstNumber = GetOnlyNumber();
            result = (decimal)Math.Log10((double)firstNumber);
            Console.WriteLine($"\nДесятичный логарифм от числа {firstNumber} равен: {result}");
        }
        internal void Log()
        {
            Console.Write(askNumber);
            firstNumber = GetOnlyNumber();
            Console.Write("\nВведите основание логарифма: ");
            secondNumber = GetOnlyNumber();
            result = (decimal)Math.Log((double)firstNumber, (double)secondNumber);
            Console.WriteLine($"\nЛогарифм от числа {firstNumber} по основанию {secondNumber} равен: {result}");
        }
    }
}