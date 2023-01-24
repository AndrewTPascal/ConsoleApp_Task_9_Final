using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание массива с исключениями
            Exception[] arrex = new Exception[5];
            arrex[0] = new ArgumentException();
            arrex[1] = new IndexOutOfRangeException();
            arrex[2] = new InvalidCastException();
            arrex[3] = new DivideByZeroException();
            arrex[4] = new Exception("Моя ошибка");     // Создание собственного исключения

            // Вывод текста исключений в консоль
            foreach (Exception ex in arrex)
            {
                try
                {
                     throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }
    }
}
