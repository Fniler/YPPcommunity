using System.Data.Common;
using YPPcommand;

Main1();
static void Main1()
{
    Console.WriteLine("Введите размерность массива Col - , Row - ");
    string input = Console.ReadLine();
    char[] separators = { ' ', ',', ';', '\t' };
    string[] mass = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

    int nrow = int.Parse(mass[0]);
    int ncol = int.Parse(mass[1]);
    Person[] MD1 = new Person[nrow * ncol];
    for (int i = 0; i < MD1.Length; i++)
    {
        MD1.SetValue(new Person(), i);
    }
    Person[,] MD2 = new Person[nrow, ncol];
    for (int i = 0; i < MD2.GetLength(0); i++)
    {
        for (int j = 0; j < MD2.GetLength(1); j++)
        {

            MD2.SetValue(new Person(), i, j);
        }
    }
    Person[][] MD2_j = new Person[nrow][];
    for (int i = 0; i < MD2_j.GetLength(0); i++)
    {
        MD2_j.SetValue(new Person[ncol], i);
        for (int j = 0; j < ncol; j++)
        {
            MD2_j[i][j] = new Person();
        }
    }
    Console.WriteLine("Начало испытания для одномерного массива");
    DateTime start = DateTime.Now;
    foreach (var item in MD1)
    {
        item.Year = 100;
    }
    DateTime end = DateTime.Now;
    TimeSpan total = end - start;
    Console.WriteLine($"Конец испытания время:{total}");

    Console.WriteLine("Начало испытания для двумерного массива");
    start = DateTime.Now;
    foreach (var item in MD2)
    {
        item.Year = 10;
    }
    end = DateTime.Now;
    total = end - start;
    Console.WriteLine($"Конец испытания время:{total}");

    Console.WriteLine("Начало испытания для двумерного массива котрый ступнчатый");
    start = DateTime.Now;
    foreach (var item1 in MD2_j)
    {
        foreach (var item2 in item1)
        {
            item2.Year = 52;
        }
    }
    end = DateTime.Now;
    total = end - start;
    Console.WriteLine($"Конец испытания время:{total}");
}
