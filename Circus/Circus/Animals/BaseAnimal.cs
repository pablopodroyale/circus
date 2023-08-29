using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus.Animals
{
    public abstract class BaseAnimal
    {
        public BaseAnimal NextAnimalImitation;

        public abstract string DoSound();
        
        //This method doesn't return a base object because only imitates one animal
        public void SetImitation(BaseAnimal nextHandler)
        {
            NextAnimalImitation = nextHandler;
        }

        public List<string> ImitateAnimal(BaseAnimal nextAnimal, bool isFirst = true) 
        {
            List<string> sounds = new List<string>();
           
            
            if (NextAnimalImitation != null)
            {
                var animalSounds = NextAnimalImitation.ImitateAnimal(NextAnimalImitation, false);
                sounds.AddRange(animalSounds);
            }
                   
            if(!isFirst) 
            {
                sounds.Add(DoSound());
            }

            return sounds;
        }
    }
}
