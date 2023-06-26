using System;
using System.Collections.Generic;

public class Fruits
{
    public string fruit { get; set; }
    public double costOfKilo { get; set; }
    public double weight { get; set; }
    public double finalCost { get; set; }

    public void Print()
    {
        Console.WriteLine($"\tФрукт: {fruit}\tЦена за килограмм: {costOfKilo}");
    }
}

class Program
{
    public static void PrintTovChek(List<Fruits> fruits)
    {
        Console.WriteLine("\tТоварный чек на покупку");
        double fCost = 0;
        foreach (Fruits fruit in fruits)
        {
            if (fruit.finalCost > 0)
            {
                Console.WriteLine($"\tФрукт: {fruit.fruit}\tВес: {fruit.weight} кг\tЦена:{fruit.finalCost}");
                fCost += fruit.finalCost;
            }
        }
        fCost = Math.Round(fCost, 2);
        Console.WriteLine($"\n\tИтоговая стоимость покупки: {fCost} рублей");
        Console.WriteLine("\n\t CПАСИБО ЗА ПОКУПКУ!");
    }


    static void Main()
    {
        List<Fruits> fruits = new List<Fruits>();
        fruits.Add(new Fruits() { fruit = "Яблоки", costOfKilo = 49.95 });
        fruits.Add(new Fruits() { fruit = "Груши", costOfKilo = 74.95 });
        fruits.Add(new Fruits() { fruit = "Бананы", costOfKilo = 108.45 });
        Console.WriteLine("\tДобро пожаловать в Фруктовый рай!\n");
        foreach (Fruits fruit in fruits)
        {
            fruit.Print();
        }

        Console.WriteLine("\nВыберите какие фрукты и какое количество вы хотите приобрести\n\tВводите в формате [Фрукт килограммы] [Апельсины 2,45]\n");
        for(; ; )
        {
            string[] fruit = (Console.ReadLine()).Split(new char[] { ' ' });
            string frt = fruit[0];
            double weight = double.Parse(fruit[1]);
            foreach (Fruits fr in fruits)
            {
                if (frt == fr.fruit)
                {
                    fr.weight = weight;
                    fr.finalCost = Math.Round(fr.weight * fr.costOfKilo, 2);
                }
            }

            Console.WriteLine("\nХотите ли вы завершить покупку и получить товарный чек? [д]/[н]");
            string approve = Console.ReadLine();
            if (approve == "Да") break;
        }

        PrintTovChek(fruits);

        Console.ReadKey();
    }
}