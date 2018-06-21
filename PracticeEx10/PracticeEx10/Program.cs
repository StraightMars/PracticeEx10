using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx10
{
    public class Point
    {
        public double data;
        public Point prev, next;
        public override string ToString()
        {
            return data + " ";
        }
        public Point(double value = 0)
        {
            data = value;
            prev = null;
            next = null;
        }
        static double GetValue()
        {
            double nData = Program.ScanDouble();
            Console.WriteLine("Элемент {0} добавляется в список.\n", nData);
            return nData;
        }
        public static Point MakeAPoint(double value)
        {
            Point nPoint = new Point(value);
            return nPoint;
        }
        public static Point MakeList(int size)
        {
            if (size == 0)
                return null;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите значение 1-го элемента: ");
            Console.ResetColor();
            Point beg = MakeAPoint(GetValue());
            Point cur = beg;
            for (int i = 1; i < size; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите значение {0}-го элемента: ", i + 1);
                Console.ResetColor();
                Point nPoint = MakeAPoint(GetValue());
                cur.next = nPoint;
                nPoint.prev = cur;
                cur = cur.next;
            }
            return beg;
        }
        public void ShowList()
        {
            Console.Write(ToString());
            if (next != null)
                next.ShowList();
        }
        public double Solving(Point beg)
        {
            double result = 1;
            Point cur = beg;
            Point end = beg;
            while (end.next != null)
                end = end.next;
            while (cur.next
                != null)
            {
                result *= (cur.data + cur.next.data + (2 * end.data));
                cur = cur.next;
                end = end.prev;
            }
            return result;
        }
    }
    class Program
    {
        public static double ScanDouble()
        {
            bool ok;
            double buf;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out buf);
                if (!ok)
                    Console.WriteLine("Ошибка ввода! Введите действительное число.");
            } while (!ok);
            return buf;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Сформируйте двунаправленный список.");
            Console.WriteLine("Введите N: ");
            bool ok;
            int N;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if (!ok)
                    Console.WriteLine("Ошибка ввода! Введите натуральное число.");
                if (N <= 0)
                {
                    Console.WriteLine("Ошибка ввода! Введите натуральное число.");
                    ok = false;
                }
            } while (!ok);
            Point point = Point.MakeList(N);
            Console.WriteLine("Ваш список выглядит следующим образом:");
            point.ShowList();
            double result = point.Solving(point);
            Console.WriteLine("\nРезультат вычисления выражения: {0}", result);
        }
    }
}
