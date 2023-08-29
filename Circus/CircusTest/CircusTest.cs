using Circus;
using Circus.Animals;
using Moq;

namespace CircusTest
{
    public class Tests
    {
        private Circus.Circus underTest;
      
        [SetUp]
        public void Setup()
        {
            underTest = new Circus.Circus();
        }

        [Test]
        public void ShowTest()
        {
            BaseAnimal dog = new Dog();
            BaseAnimal cat = new Cat();
            BaseAnimal bird = new Bird();
            BaseAnimal monkey = new Monkey();
            List<BaseAnimal> animals = new List<BaseAnimal>();
            dog.SetImitation(new Cat());
            cat.SetImitation(new Dog());
            bird.SetImitation(new Monkey());
            monkey.SetImitation(new Bird());
            underTest.SetAnimal(dog);
            underTest.SetAnimal(cat);
            underTest.SetAnimal(bird);
            underTest.SetAnimal(monkey);

            List<string> sounds = underTest.Show();
            Assert.That(dog.NextAnimalImitation.DoSound(), Is.EqualTo(expected: cat.DoSound()));
            Assert.That(cat.NextAnimalImitation.DoSound(), Is.EqualTo(expected: dog.DoSound()));
            Assert.That(bird.NextAnimalImitation.DoSound(), Is.EqualTo(expected: monkey.DoSound()));
            Assert.That(monkey.NextAnimalImitation.DoSound(), Is.EqualTo(expected: bird.DoSound()));
            Assert.That(cat.DoSound(), Is.EqualTo(sounds[0]));
            Assert.That(dog.DoSound(), Is.EqualTo(sounds[1]));
            Assert.That(monkey.DoSound(), Is.EqualTo(sounds[2]));
            Assert.That(bird.DoSound(), Is.EqualTo(sounds[3]));
        }

        [Test]
        //Here the dog can imitate 2 animals
        public void ShowTestDoubleImitiation()
        {
            BaseAnimal dog = new Dog();
            BaseAnimal cat = new Cat();
            cat.SetImitation(new Bird());
            dog.SetImitation(cat);
            underTest.SetAnimal(dog);
            List<string> sounds = underTest.Show();
            Assert.That(sounds.Count, Is.EqualTo(2));
            Assert.That(sounds[0], Is.EqualTo(new Bird().DoSound()));
            Assert.That(sounds[1], Is.EqualTo(new Cat().DoSound()));
        }
    }
}