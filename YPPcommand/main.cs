using System.Data.Common;
using YPPcommand;

Main();
static void Main()
{
    Console.WriteLine("Введите размерность массива Col - , Row - ");
    string input = Console.ReadLine();
    char[] separators = { ' ', ',', ';', '\t' };
    string[] mass = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

    int nrow = int.Parse(mass[0]);
    int ncol = int.Parse(mass[1]);
    Person[] MD1 = new Person[nrow * ncol];
    for(int i = 0;i<MD1.Length;i++)
    {
        MD1.SetValue(new Person(),i); 
    }
    Person[,] MD2 = new Person[nrow, ncol];
    for (int i = 0; i < MD2.GetLength(0); i++)
    {
        for (int j = 0; j < MD2.GetLength(1); j++)
        {
            
            MD2.SetValue(new Person(),i,j);
        }
    }
    Person[][] MD2_j = new Person[nrow][];
    for (int i = 0; i < MD2_j.GetLength(0); i++)
    {
        MD2_j.SetValue(new Person[ncol],i);
        for (int j = 0; j < ncol; j++)
        {
            MD2.SetValue(new Person(),i,j);
        }
    }
    int start = Environment.TickCount;
    foreach(var item in MD1)
    {
        item.Year = 100;
    }
    int end = Environment.TickCount;
    ggggggggggg
}