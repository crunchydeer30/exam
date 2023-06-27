
public class Calc
{
    public double a;
    public Calc() 
    {
        for(; ; )
        {
                Console.WriteLine("Введите число");
                string astr = Console.ReadLine();
                if (double.TryParse(astr, out var x))
                {
                    a = double.Parse(astr);
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                    Console.WriteLine("Вводите только числа! Пример [123,45]");
                }
        }
        Console.WriteLine("\tОтлично! Какой результат вы хотите получить? [синус]/[косинус]");
        if (Console.ReadLine() == "синус") 
        {
            Sin();        
        } else {
            Cos(); 
        }
        Console.WriteLine("\tПродолжить расчеты с этим числом или ввести новое?[да]/[нет]");
        if (Console.ReadLine() == "да")
        {
            Console.WriteLine("\tКакой результат вы хотите получить? [синус]/[косинус]");
            if (Console.ReadLine() == "синус")
            {
                Sin();
            }
            else
            {
                Cos();
            }
        }
        else
        {
             var b = new Calc();
        }

    }

    public void Print()
    {
        Console.WriteLine($"Ваше число: {a}");
    }
    public void Sin()
    {
        Console.WriteLine($"Синус числа {a} равен {Math.Sin(a)}");
    }
    public void Cos()
    {
        Console.WriteLine($"Косинус числа {a} равен {Math.Cos(a)}");
    }
}

class ИнженерныйКалькулятор
{
    static void Main()
    {
        Console.WriteLine("\tВас приветствует Инженерный калькулятор");
        var a = new Calc();
        Console.ReadKey();
    }
}