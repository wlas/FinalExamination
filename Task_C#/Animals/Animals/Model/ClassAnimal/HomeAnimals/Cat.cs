using Animals.Model.Base;

namespace Animals.Model.ClassAnimal.HomeAnimals
{
    public class Cat : HomeAnimal
    {
        public Cat(string name, DateTime birthday) : base(name, birthday, ViewAnimal.CAT)
        {
            
        }
    }
}
