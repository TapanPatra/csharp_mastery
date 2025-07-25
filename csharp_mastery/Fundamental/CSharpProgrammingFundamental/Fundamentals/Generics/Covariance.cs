using CSharpFundamentals.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Generics
{
    class Animal
    { 
        public string Name; 
        public int NumberOfLegs = 4; 
    }

    internal interface IGetFirst<out T>
    {
        T GetFirst();
    }
    class ReturnFirst<T> : IGetFirst<T>
    {
        public T[] items = new T[2];
        public T GetFirst() { return items[0]; }
    }


    class Dog : Animal
    {
        
    }

    delegate T Factory<out T>(); //delegate Factory

    delegate void Action1<in T>(T a);


    [TestFixture]
    public  class Covariance
    {
        [Test]
        public void AssignmentCompatibility()
        {
            //Assignment compatibility means that you can assign a reference of a more derived type to a variable of a less derived type
            Animal a1 = new Animal();
            Animal a2 = new Dog();
            Console.WriteLine($"Number of dog legs: {a2.NumberOfLegs}");
        }

        [Test]
        public void CovarianceTest()
        {
            Factory<Dog> dogMaker = MakeDog;
            Factory<Animal> animalMaker = dogMaker;
            Console.WriteLine(animalMaker().NumberOfLegs.ToString());

        }

        Dog MakeDog()
        {
            return new Dog();
        }

        [Test]
        public void ContravarianceTest()
        {
            Action1<Animal> act1 = ActOnAnimal;
            Action1<Dog> dog1 = act1;
            dog1(new Dog());
        }

        static void ActOnAnimal(Animal a) 
        { 
            Console.WriteLine(a.NumberOfLegs); 
        }

        [Test]
        public void CovarianceAndContravarianceInInterfaces()
        {
            ReturnFirst<Dog> dogReturner = new ReturnFirst<Dog>();
            dogReturner.items[0] = new Dog() { Name = "Avonlea" };

            IGetFirst<Animal> animalReturner = dogReturner;

            DoSomething(dogReturner);
        }

        static void DoSomething(IGetFirst<Animal> returner)
        {
            Console.WriteLine(returner.GetFirst().Name);
        }

        [Test]
        public void VarianceTest()
        {
            Factory<Animal> animalMaker1 = MakeDog; // Coerced implicitly
            Factory<Dog> dogMaker = MakeDog;
            Factory<Animal> animalMaker2 = dogMaker; // Requires the out specifier
            Factory<Animal> animalMaker3 = new Factory<Dog>(MakeDog); // Requires the out specifier
        }
    }
}
