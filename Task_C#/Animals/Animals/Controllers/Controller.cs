using Animals.Model;
using Animals.Service;
using Animals.View;

namespace Animals.Controllers
{
    public class Controller
    {
        ConsolUser user = new ConsolUser();
        IAnimal animal = new AnimalService();
        GroupAnimal groupAnimal = new GroupAnimal();
        bool work = true;
        public void Start()
        {
            try
            {
                StartMenu();
            }
            catch (Exception ex)
            {
                user.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Запуск основого меню программы
        /// </summary>
        private void StartMenu()
        {
            while (work)
            {
                user.Menu();
                user.Write("Выберете нужный пункт из меню: ");

                var ss = Console.ReadLine();
                if (int.TryParse(ss, out int res))
                {
                    switch (res)
                    {
                        case 1:
                            PrintAnimals();
                            break;
                        case 2:
                            CreateAnimal();
                            break;
                        case 3:
                            AddCommandAnimal();
                            break;
                        case 4:
                            work = false;
                            return;
                        default:
                            Console.WriteLine("\nОшибка. Данного пункта в меню нет, выберете другой.");
                            break;
                    }
                }
                else
                {
                    user.WriteLine("\nОшибка. Укажите номер из меню цифрой.");
                }
                Console.Write("\n");
            }
        }
        /// <summary>
        /// Добавление новой команды животному
        /// </summary>
        private void AddCommandAnimal()
        {
            if (groupAnimal.GetAnimals().Count > 0)
            {
                user.Write("Укажите id животного, которому нужно добавить новую команду: ");

                if (int.TryParse(Console.ReadLine(), out int rez))
                {
                    if (groupAnimal.GetAnimals().Exists(x => x.GetId() == rez))
                    {
                        animal.AddCommandAnimal(groupAnimal.GetAnimals().FindLast(x => x.GetId() == rez), user.StringWrite("Укажите название команды: "), user.StringWrite("Укажите описание команды: "));
                    }
                    else
                    {
                        user.WriteLine($"\nЖивотное с номером id {rez} отсутствует.");
                    }
                }
                else
                {
                    user.WriteLine("\nОшибка. Укажите id цифрой.");
                }
            }
            else
            {
                user.WriteLine("\nЖивотные отсутствуют.");
            }
        }
        /// <summary>
        /// Метод по созданию животного
        /// </summary>
        private void CreateAnimal()
        {
            bool creat = true;
            while (creat)
            {
                user.MenuCreateAnimal();
                user.Write("Выберете нужный пункт из меню: ");

                if (int.TryParse(Console.ReadLine(), out int rez))
                {
                    var createAnimal = animal.CreateAnimal(user.StringWrite("Укажите имя питомца: "), user.DateTimeWrite("Укажите дату рождения (Формат даты: 24.01.2023): "), rez);
                    if (createAnimal != null)
                    {
                        groupAnimal.AddAnimals(createAnimal);
                        creat = false;
                    }
                    else
                    {
                        user.WriteLine("\nОшибка создания.");
                    }
                }
                else
                {
                    user.WriteLine("\nОшибка. Укажите номер из меню цифрой.");
                }

            }
        }
        /// <summary>
        /// Вывод всех живтоных
        /// </summary>
        private void PrintAnimals()
        {
            if (groupAnimal.GetAnimals().Count > 0)
            {
                foreach (var item in groupAnimal.GetAnimals())
                {
                    user.WriteLine(item.ToString());
                }
            }
            else
            {
                user.WriteLine("\nЖивотные отсутствуют.");
            }
        }
    }
}
