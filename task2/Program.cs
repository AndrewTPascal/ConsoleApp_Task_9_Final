using System;

namespace task2
{
    class Person 
    {
        public delegate void Notify();
        public event Notify ChangeNumber;
        
        public int Sort;
        public string[] Name = new string[5];

        // Заполнение массива пользователем в конструкторе
        public Person() 
        {
            for (int i = 0; i < Name.Length; i++)
            {
                Console.Write($"Введите фамилию № {i + 1}: ");
                Name[i] = Console.ReadLine();
            }
        }
        
        // Выбор типа сортировки, вызов события ChangeNumber
        public void SortIn() 
        {
            while (true)
            {
                Console.Write("Введите способ сортировки. Число 1 - от А до Я, число 2 от Я до А: ");
                try
                {
                    int sort = Convert.ToInt32(Console.ReadLine());
                    if (sort == 1 || sort == 2)
                    {
                        Sort = sort;
                        ChangeNumber?.Invoke();
                        return; 
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                { Console.WriteLine("Введены некорректные данные!"); }
            }
        }

        // Сортировка массива
        public void Sorting() 
        {
            switch (Sort)
            {
                case 1: 
                    Array.Sort(Name);   // По возрастанию
                    break;
                case 2:
                    {
                        Array.Sort(Name);
                        Array.Reverse(Name);    // В обратном порядке
                    }
                        break;
             }
        }

        // Вывод массива в консоль
        public void ViewName()
        {
            foreach (string i in Name) Console.WriteLine(i);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            // Подписка на событие изменения поля Number
            person.ChangeNumber += person.Sorting;
            
            // Вызов события, сортировка массива, вывод к консоль
            person.SortIn();
            person.ViewName();

        }

    }
}
