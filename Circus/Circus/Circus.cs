using Circus.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus
{
    public class Circus
    {
        private readonly List<BaseAnimal> animals;
        public Circus() 
        {
            animals = new List<BaseAnimal>();
        }

        public List<string> Show() 
        {
            List<string> sounds = new List<string>();
            foreach (var animal in animals) 
            {
                 sounds.AddRange(animal.ImitateAnimal(animal.NextAnimalImitation));
            }

            return sounds;
        }

        public void SetAnimal(BaseAnimal animal)
        {
            if (animal == null) 
            {
                throw new ArgumentNullException("Error. Animal is required");
            }

            if (animals.Any(x => x.GetType() == animal.GetType())) 
            {
                throw new Exception("Error. Animal already added");
            }

            animals.Add(animal);
        }

        private BaseAnimal GetAnimalRandom(BaseAnimal animal)
        {
            IEnumerable<BaseAnimal> animalsDiferent = animals.Where(x => x.GetType() != animal.GetType());
            BaseAnimal animalRandom = animalsDiferent.ElementAt(new Random().Next(0, animalsDiferent.Count()));
            return animalRandom;
        }
    }
}
