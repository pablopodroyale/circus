using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus.Animals
{
    public class Dog : BaseAnimal
    {
        public override string DoSound()
        {
            return "Woof";
        }
    }
}
