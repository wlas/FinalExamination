using Animals.Model.Base;

namespace Animals.Service
{
    internal interface IAnimal
    {
        /// <summary>
        /// Метод создает конретного животного
        /// </summary>
        /// <param name="name">Имя животного</param>
        /// <param name="date">День рождение животного</param>
        /// <param name="animal">Вид животного</param>
        /// <returns></returns>
        public Animal CreateAnimal(string name, DateTime date, int animal);
        public void AddCommandAnimal(Animal animal, string command, string aboutCommand);
    }
}
