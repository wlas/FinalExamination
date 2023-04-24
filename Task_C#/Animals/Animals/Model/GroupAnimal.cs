using Animals.Model.Base;

namespace Animals.Model
{
    public class GroupAnimal
    {
        private List<Animal> animals; //список животных
        /// <summary>
        /// Конструктор создает новый список
        /// </summary>
        public GroupAnimal() 
        {
            animals = new List<Animal>();
        }
        /// <summary>
        /// Добавлние животного в список
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimals(Animal animal) 
        {
            animals.Add(animal);
        }
        /// <summary>
        /// Возврощает список животных
        /// </summary>
        /// <returns>Список с животными</returns>
        public List<Animal> GetAnimals() => animals;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
