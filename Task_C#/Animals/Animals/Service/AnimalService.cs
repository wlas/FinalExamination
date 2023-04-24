using Animals.Model.Base;
using Animals.Model.ClassAnimal.HomeAnimals;
using Animals.Model.ClassAnimal.PackAnimals;

namespace Animals.Service
{
    public class AnimalService : IAnimal
    {        
        public void AddCommandAnimal(Animal animal, string command, string aboutCommand)
        {
            animal.AddCommand(command, aboutCommand);
        }
        
        public Animal CreateAnimal(string name, DateTime date, int animal)
        {
            switch (animal)
            {
                case 1:
                    return new Cat(name, date);
                case 2:
                    return new Dog(name, date);
                case 3:
                    return new Horse(name, date);
                case 4:
                    return new Camel(name, date);
                default:
                    Console.WriteLine("\nОшибка. Данного пункта в меню нет, выберете другой.");
                    break;
            }
            return null;
        }

    }
}
