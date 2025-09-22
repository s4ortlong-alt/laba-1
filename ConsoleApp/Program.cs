using Core;
using System.Security.Cryptography.X509Certificates;
namespace ConsoleApp
{
    
    class ConsoleApp
    {

        static Jerboa Jerboa = new Jerboa();

        static void Main(string[] args)
        {
            
            Console.WriteLine("=== ПУСТЫНЯ С ТУШКАНЧИКАМИ ДОСТУПНА ===");
            while (true)
            {

                Console.WriteLine("----------------------------------------------------" +
                    "МЕНЮ\n" +
                    "1. Отобразить всех тушканчиков\n" +
                    "2. Добавить тушканчика\n" +
                    "3. Удалить тушканчика\n" +
                    "4. Погладить тушканчика\n" +
                    "5. Покормить тушканчика\n" +
                    "0. Выход\n" +
                    "---------------------------------------------------------\n" +
                    "Выберите дейcтвие >");
              
                string choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":
                        var desert = Jerboa.GetDesert();

                        int ct = desert.Count;
                        if (ct == 0)
                        {
                            Console.WriteLine("Пустыня пуста (- <-)");
                        }
                        else
                        {
                            foreach (var j in desert)
                            {
                                Console.WriteLine($"ID: {j.Id}, Имя: {j.Name}, Цвет: {j.Color} " +
                                    $"Гладили: {j.countOfTouches} раз, Кормили {j.countOfFeedings} раз");
                            }

                        }
                        
                        break;

                    case "2":
                        
                        Console.WriteLine("Введите имя >");
                        string _name = Console.ReadLine();

                        Console.WriteLine("Введите цвет >");
                        string _color = Console.ReadLine();

                        var jerboa = Jerboa.Make_Jerboa(_name, _color);

                        break;

                    case "3":
                        
                        int _id;
                        int valid_id;
                        while (true)
                        {
                            Console.WriteLine("Введите айди тушканчика, которого хотите удалить >");
                            string input = Console.ReadLine();
                            if(int.TryParse(input, out _id))
                            {
                                if(Jerboa.GetJerboaById(_id) != null)
                                {
                                    valid_id = _id;
                                    bool scssf = Jerboa.Remove_Jerboa(valid_id);
                                    if (scssf == true)
                                    {
                                        Console.WriteLine("Тушканчик успешно удален (Т0Т)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("ошибка.");
                                        Console.WriteLine("попробуйте еще раз...");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("не найден.");
                                    Console.WriteLine("попробуйте еще раз...");
                                }
                            }
                            else
                            {
                                Console.WriteLine("введите корректное число.");
                                Console.WriteLine("попробуйте еще раз...");
                            }
                            
                            break;
                        }
                        break;
                        
                    case "4":
                        
                        Console.WriteLine("Введите айди тушканчика, которого хотите погладить >");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            if (Jerboa.Pet(id))
                            {
                                Console.WriteLine("Тушканчик поглажен! (^ ^)");
                            }
                            else
                            {
                                Console.WriteLine("Тушканчик с таким ID не найден. (T0T)");
                            }
                        }

                        break;
                    case "5":

                        Console.WriteLine("Введите айди тушканчика, которого хотите покормить >");
                        if (int.TryParse(Console.ReadLine(), out int ID))
                        {
                            if (Jerboa.Feed(ID))
                            {
                                Console.WriteLine("Тушканчик покормлен! (^ ^)");
                            }
                            else
                            {
                                Console.WriteLine("Тушканчик с таким ID не найден. (T0T)");
                            }
                        }

                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! (- <-)");
                        break;

                }
            }

        }
    }
}