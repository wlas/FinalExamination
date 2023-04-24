namespace Animals.Model.Base
{
    public abstract class HomeAnimal : Animal
    {
        protected HomeAnimal(string name, DateTime birthday, ViewAnimal viewAnimal) : base(name, birthday, TypeAnimal.HOMEANIMAL, viewAnimal)
        {
            base.AddCommand("Кушать", "Идет кушать.");
        }
    }
}
