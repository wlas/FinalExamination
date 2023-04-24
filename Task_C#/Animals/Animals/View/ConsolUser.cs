namespace Animals.View
{
    public class ConsolUser : IUserInterface
    {
        public string StringWrite(string str)
        {            
            bool work = true;
            while (work)
            {
                Console.Write(str);
                string input = Console.ReadLine();
                if (input != null && input.Length != 0)
                {
                    work = false;
                    return input;
                }
                else
                {
                    Console.WriteLine("Ошибка. Повторите попытку.");
                }
            }
            return null;
        }

        public DateTime DateTimeWrite(string str)
        {
            bool work = true;
            DateTime dt = new DateTime();
            while (work)
            {
                Console.Write(str);
                string input = Console.ReadLine();
                if (DateTime.TryParse(input + " 00:00:00", out dt))
                {
                    work = false;
                    return dt;
                }
                else
                {
                    Console.WriteLine("Ошибка. Повторите попытку.");
                }
            }
            return dt;
        }

        /// <summary>
        /// Основное меню
        /// </summary>
        public void Menu()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("==============Питомник============");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Вывести всех животных.");
            Console.WriteLine("2. Добавить новое животное.");
            Console.WriteLine("3. Обучить новой команде животное.");
            Console.WriteLine("4. Выход.");
            Console.WriteLine("==================================");
        }

        /// <summary>
        /// Меню создания животных
        /// </summary>
        public void MenuCreateAnimal()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("==Какое животное хотите добавить?==");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Кошка.");
            Console.WriteLine("2. Собака.");
            Console.WriteLine("3. Лошадь.");
            Console.WriteLine("4. Верблюд.");
            Console.WriteLine("5. Отмена.");
            Console.WriteLine("==================================");
        }

        /// <summary>
        /// Вывод текста в консоль.
        /// </summary>
        /// <param name="str">Текст вывода</param>
        public void Write(string str)
        {
            Console.Write(str);
        }
        /// <summary>
        /// Вывод текста в консоль с новой строки.
        /// </summary>
        /// <param name="str">Текст вывода</param>
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
