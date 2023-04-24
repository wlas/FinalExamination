namespace Animals.Model.Base
{
    public abstract class PackAnimal : Animal
    {
        public PackAnimal(string name, DateTime birthday, ViewAnimal viewAnimal) : base(name, birthday, TypeAnimal.PACKANIMAL, viewAnimal)
        {
            base.AddCommand("Кушать","Идет кушать.");
            base.AddCommand("Но","Начинает движение.");
            base.AddCommand("Пить","Начинает пить воду.");
        }
    }
}
