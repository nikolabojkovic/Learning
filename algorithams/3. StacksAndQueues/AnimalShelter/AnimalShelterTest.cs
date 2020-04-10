using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xunit;

namespace AnimalShelter
{
    public class AnimalSherterTest
    {
        [Fact]
        public void DequeueDog_ShouldDequeueDogFromDogsList()
        {
            // Arrange
            var animals = new List<Animal>{ 
                new Cat(new DateTime(2020, 3, 1)),
                new Dog(new DateTime(2020, 3, 4)),
                new Dog(new DateTime(2020, 3, 13)),
                new Cat(new DateTime(2020, 3, 14)),
                new Dog(new DateTime(2020, 3, 24))
            };

            AnimalQueue animalQueue = new AnimalQueue();
            foreach(var animal in animals)
                animalQueue.Enqueue(animal);  

            // Act
            var oldestDog = animalQueue.DequeueDog();
            var secondOldestDog = animalQueue.DequeueDog();            
            var oldestAnimalInQueue = animalQueue.DequeueAny();                      
            var lastCat = animalQueue.DequeueCat();

            // Assert
            Assert.Equal(animals[1] is Dog, oldestDog is Dog);
            Assert.Equal(animals[1].AdoptionDate, oldestDog.AdoptionDate);
            Assert.Equal(animals[2] is Dog, secondOldestDog is Dog);            
            Assert.Equal(animals[0] is Cat, oldestAnimalInQueue is Cat);
            Assert.Equal(animals[0].AdoptionDate, oldestAnimalInQueue.AdoptionDate);
            Assert.Equal(animals[3] is Cat, oldestAnimalInQueue is Cat);
            Assert.Equal(animals[3].AdoptionDate, lastCat.AdoptionDate);
        }

        [Fact]
        public void DequeueAny_ShouldThrowEmptyQueueException()
        {
            // Arrange
            AnimalQueue animalQueue = new AnimalQueue();            

            // Act
            // Assert
            Assert.Throws<EmptyQueueException>(() => animalQueue.DequeueAny());
        }

        [Fact]
        public void DequeueCatAndThenDog_ShouldThrowEmptyQueueException()
        {
            // Arrange
            AnimalQueue animalQueue = new AnimalQueue();
            animalQueue.Enqueue(new Cat(new DateTime()));
            animalQueue.Enqueue(new Dog(new DateTime()));            
            animalQueue.Enqueue(new Dog(new DateTime()));

            // Act
            animalQueue.DequeueCat();
            animalQueue.DequeueDog();
            animalQueue.DequeueAny();

            // Assert
            Assert.Throws<EmptyQueueException>(() => animalQueue.DequeueDog());
        }
    }

    public class AnimalQueue
    {
        private readonly List<Animal> _dogs;
        private readonly List<Animal> _cats;

        public AnimalQueue()
        {
            _dogs = new List<Animal>();
            _cats = new List<Animal>();
        }

        public void Enqueue(Animal animal)
        {
            if (animal == null) throw new ArgumentException("Animal is null");

            if (animal is Dog)
                _dogs.Add(animal);

            if (animal is Cat)
                _cats.Add(animal);
        }

        public Dog DequeueDog()
        {
            if (_dogs.IsEmpty())
                throw new EmptyQueueException();

            Dog dog = _dogs[0] as Dog;
            _dogs.RemoveAt(0);

            return dog;
        }

        public Cat DequeueCat()
        {
            if (_cats.IsEmpty())
                throw new EmptyQueueException();

            Cat cat = _cats[0] as Cat;
            _cats.RemoveAt(0);

            return cat;
        }

        public Animal DequeueAny()
        {
            if (_cats.IsEmpty() && _dogs.IsEmpty())
                throw new EmptyQueueException();

            if (_cats.IsEmpty())            
                return DequeueDog();
                
            if (_dogs.IsEmpty())
                return DequeueCat();

            // is older if it has less milisecons
            if (_dogs[0].AdoptionDate < _cats[0].AdoptionDate)
                return DequeueDog();
            else
                return DequeueCat();
        }
    }

    public static class Extensions
    {
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count == 0;
        }
    }

    [Serializable]
    internal class EmptyQueueException : Exception
    {
        public EmptyQueueException()
        {
        }

        public EmptyQueueException(string message) : base(message)
        {
        }

        public EmptyQueueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyQueueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class Animal
    {
        public DateTime AdoptionDate { get; private set; }

        public Animal(DateTime adoptionDate)
        {
            AdoptionDate = adoptionDate;
        }
    }

    public class Dog : Animal
    {
        public Dog(DateTime adoptionDate) : base(adoptionDate) {}
    }

    public class Cat : Animal
    {
        public Cat(DateTime adoptionDate) : base(adoptionDate) {}
    }
}
