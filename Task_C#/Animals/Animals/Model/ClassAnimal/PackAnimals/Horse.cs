using Animals.Model.Base;

namespace Animals.Model.ClassAnimal.PackAnimals
{
    public class Horse : PackAnimal
    {
        public Horse(string name, DateTime birthday) : base(name, birthday, ViewAnimal.HORSE)
        {
        }
    }
}
