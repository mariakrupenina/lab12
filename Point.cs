using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Pred { get; set; }

        public Point()
        {
            this.Data = default; //компилятор должен сам определить начальное значение для поля данных
            this.Pred = null;
            this.Next = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Pred = null;
        }

        public override string ToString()
        {
            //return Data == null ? "":Data.ToString();
            if (Data == null)
                return "";
            else
                return Data.ToString();
        }
        public override int GetHashCode()//на потом
        {
            return Data==null?0:Data.GetHashCode();
        }
    }
}
