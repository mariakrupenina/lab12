using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_for_lab10;

namespace lab12
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            //Создаем список из некоторых элементов
            MyList<Tool> myList = new MyList<Tool>(5);
            MyList<Tool> list = new MyList<Tool>();

            int answer = 1;
            while (answer != 6)
            {

                try
                {
                    PrintMenu();

                    answer = int.Parse(Console.ReadLine());
                    //answer = GetValidSizeFromInput();

                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("создаём массив");
                            int size = GetValidSizeFromInput();
                            list = new MyList<Tool>(size);
                            Console.WriteLine("Список создан");
                            break;

                        case 2:
                            list.PrintListWithPositions();
                            break;
                        //Добавить в список элемент после элемента с заданным информационным полем (например, с заданным именем)
                        case 3:
                            //Выводим список до добавления нового элемента
                            Console.WriteLine("Список до добавления нового элемента:");
                            list.PrintList();

                            Tool find = new Tool();
                            find.Init();

                            try
                            {
                                // Пытаемся добавить новый элемент после найденного элемента
                                list.AddAfterItem(find, find);

                                // Выводим список после добавления нового элемента
                                Console.WriteLine("\nСписок после добавления нового элемента:");
                                list.PrintListWithPositions();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при добавлении элемента: {ex.Message}");
                            }
                            Console.ReadLine();
                            break;

                        case 4:
                            //Выводим список до добавления нового элемента
                            Console.WriteLine("Список до удаления:");
                            list.PrintList();

                            Tool remove = new Tool();
                            remove.Init();

                            try
                            {
                                // Пытаемся удалить новый элемент после найденного элемента
                                list.RemoveUntilItem(remove);

                                // Выводим список после удаления элемента
                                Console.WriteLine("\nСписок после удаления:");
                                list.PrintList();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
                            }

                            Console.ReadLine();

                            break;

                        //case 5:
                        //    Console.WriteLine("\n Исходный список:");
                        //    myList.PrintList();
                        //    Console.WriteLine();
                        //    // Создаем новый экземпляр списка для клонирования
                        //    MyList<Tool> clonedList = new MyList<Tool>();

                        //    //Перебираем существующий список myList и добавляем каждый элемент в клонированный список
                        //    Point<Tool>? current = myList.beg;
                        //    while (current != null)
                        //    {
                        //        // Глубоко клонируем текущий элемент и добавляем его в клонированный список
                        //        Tool clonedItem = (Tool)current.Data.Clone(); // Вызываем метод Clone() для глубокого копирования (в 10 лабе переделала!)
                        //        clonedList.AddToEnd(clonedItem);

                        //        current = current.Next; // Переходим к следующему элементу в исходном списке
                        //    }

                        //    Console.WriteLine("Список успешно склонирован");
                        //    Console.WriteLine();
                        //    Console.WriteLine("Склонированный список:");
                        //    clonedList.PrintList();
                        //    Console.WriteLine();
                        //    break;

                        case 6:
                            myList = null; //Присваиваем переменной myList значение null, чтобы разрешить сборщику мусора удалить список из памяти
                            Console.WriteLine("Список успешно удален из памяти");

                            try
                            {
                                myList.PrintList();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Список уже удалён!его нет: {ex.Message}");
                            }

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Задать число для размера списка");
            Console.WriteLine("2. Печать двунаправленного списка");
            Console.WriteLine("3. Добавить в список элемент после элемента с заданным информационным полем");
            Console.WriteLine("4. Удалить из списка все элементы, начиная с начала списка и до элемента с заданным информационным полем (например, с заданным именем), и до конца списка");
            Console.WriteLine("5. Uлубокое клонирование списка");
            Console.WriteLine("6. Удалить список из памяти");
            Console.WriteLine();

        }
        public static int GetValidSizeFromInput()
        {
            int choice;
            bool isConvert; 
            do
            {
                Console.WriteLine("Введите размер: \n");
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out choice);
                if (!isConvert || choice <= 0)
                {
                    Console.WriteLine("неправильно введено число. \nПопробуйте ещё раз.");
                }
            } while (!isConvert);

            return choice;
        }
    }
}
