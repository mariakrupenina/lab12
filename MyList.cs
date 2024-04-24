using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_for_lab10;

namespace lab12
{
    public class MyList<T> where T : Tool, IInit, ICloneable, new()//на T накладываем ограничения
    {
        private Point<T> beg = null; //начало списка
                                     

        // Метод для получения первого элемента списка
        public T GetFirstItem()
        {
            if (beg != null)
            {
                return beg.Data;
            }
            else
            {
                throw new Exception("Список пуст");
            }
        }
        
        Point<T> end = null; //конец списка

        int count = 0;

        public int Count => count;

        //вспомогательные функции
        Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }
        public void AddToBegin(T item) //добавление в начало списка
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList() { }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("размер меньше 0");
            beg = MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }

        public MyList(T[] collection)
        {
            if (collection == null)
                throw new Exception("коллекция не создана");
            if (collection.Length == 0)
                throw new Exception("количество элементов равно 0");
            T newData = (T)collection.Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 0; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("лист пустой");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        // Вывод списка с указанием позиций и значений элементов
        public void PrintListWithPositions()
        {
            if (count == 0)
            {
                Console.WriteLine("Список пустой");
                return;
            }

            Point<T> current = beg;
            int position = 1;
            while (current != null)
            {
                Console.WriteLine($"Позиция {position}: {current.Data}");
                current = current.Next;
                position++;
            }
        }

        Point<T> FindItem(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null)
                {
                    throw new Exception("Data is null");
                }

                // Проверяем на равенство, игнорируя возможные значения null
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return current;
                }

                current = current.Next;
            }
            return null;
        }

        public bool RemoveItem(T item)
        {
            if (beg == null) throw new Exception("лист пустой");
            Point<T>? pos = FindItem(item);
            if (pos == null) return false;
            count--;
            //one element
            if (beg == end)
            {
                beg = end = null;
                return true;
            }
            //the first
            if (pos.Pred == null)
            {
                beg = beg?.Next;
                beg.Pred = null;
                return true;
            }
            //the last
            if (pos.Next == null)
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            pos.Next.Pred = pred;
            pos.Pred.Next = next;
            return true;
        }

        //задание в варианте(Добавить в список элемент после элемента с заданным информационным полем (например, с заданным именем)
        public void AddAfterItem(T itemToFind, T newItem)
        {
            // Находим элемент, после которого нужно добавить новый элемент
            Point<T> foundPoint = FindItem(itemToFind);

            if (foundPoint == null)
            {
                throw new Exception($"Элемент с информационным полем '{itemToFind}' не найден в списке.");
            }

            // Создаем новый элемент для вставки
            T newData = (T)newItem.Clone();
            Point<T> newPoint = new Point<T>(newData);

            // Вставляем новый элемент после найденного элемента
            newPoint.Next = foundPoint.Next;
            newPoint.Pred = foundPoint;

            if (foundPoint.Next != null)
            {
                foundPoint.Next.Pred = newPoint;
            }
            else
            {
                end = newPoint; // Если добавляемый элемент становится последним, обновляем end
            }

            foundPoint.Next = newPoint; // Устанавливаем новый элемент после найденного элемента
            count++; // Увеличиваем счетчик элементов
        }

        //Удалить из списка все элементы, начиная с начала списка и
        //до элемента с заданным информационным полем (например, с заданным именем), и до конца списка
        public void RemoveUntilItem(T itemToRemove)
        {
            Point<T> itemToKeep = FindItem(itemToRemove);

            if (itemToKeep == null)
            {
                throw new Exception($"Элемент с информационным полем '{itemToRemove}' не найден в списке.");
            }

            // Удаляем все элементы до элемента, который нужно сохранить
            Point<T> current = beg;
            while (current != itemToKeep)
            {
                // Сохраняем ссылку на следующий элемент перед удалением текущего
                Point<T> next = current.Next;

                // Удаляем текущий элемент
                if (current.Pred != null)
                {
                    current.Pred.Next = null;
                }
                else
                {
                    beg = null; //Удаляем начало списка
                }

                //Перемещаемся к следующему элементу
                current = next;
                count--;
            }

            //Обновляем начало списка на элемент, который нужно сохранить (itemToKeep)
            beg = itemToKeep;
            if (beg != null)
            {
                beg.Pred = null; //Начало списка не имеет предыдущего элемента
            }
            else
            {
                end = null; //Если список полностью очищен, обнуляем и конец списка
            }
        }
    }
}
