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

        public string ImitateAnimal(BaseAnimal nextAnimal) 
        {
            if (NextAnimalImitation != null)
            {
                return NextAnimalImitation.ImitateAnimal(nextAnimal.NextAnimalImitation);
            }
            else
            {
                return DoSound();
            }
        }

    }
}
