using SpaceFleetDispatcher;

namespace Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //E:\aip\Spaceships\Information.txt
            Console.WriteLine("Введите расположение файла:");
            string location = Console.ReadLine();
            Dispatcher.SetDataAndGetOutData(location);
            Console.WriteLine("Программа завершена успешно");
            Console.ReadLine();
        }
    }
}