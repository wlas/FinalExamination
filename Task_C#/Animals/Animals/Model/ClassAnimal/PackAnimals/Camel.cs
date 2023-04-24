using Animals.Model.Base;

namespace Animals.Model.ClassAnimal.PackAnimals
{
    public class Camel : PackAnimal
    {
        public Camel(string name, DateTime birthday) : base(name, birthday, ViewAnimal.CAMEL)
        {
        }
    }
}
