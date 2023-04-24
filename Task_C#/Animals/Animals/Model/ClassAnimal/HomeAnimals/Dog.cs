using Animals.Model.Base;

namespace Animals.Model.ClassAnimal.HomeAnimals
{
    public class Dog : HomeAnimal
    {
        public Dog(string name, DateTime birthday) : base(name, birthday, ViewAnimal.DOG)
        {
        }
    }
}
