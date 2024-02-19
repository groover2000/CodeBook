using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared
{

    public partial class Person : System.Object
    {
        // Поля класса
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();

        public readonly DateTime Instantiated;
// Поля класса

// Конструкторы класса
        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
            DateOfBirth = DateTime.Now;
        }

        public Person(string initialName)
        {
            Name = initialName;
        }
// Конструкторы класса


// Методы класса 
        public void WriteToConsole()
        {
            Console.WriteLine($"INSTATIATED: {Instantiated}");
        }

        public string GetOrigin()
        {
            return "SuckSOMEDICK";
        }

        public (string Name, int Number) GetFruit()
        {
            return (Name: "Apples", Number: 5);
        }
// Методы класса 


// Деконструкция класса
        public void Deconstruct(out string name, out DateTime dob)
        {
            name = Name;
            dob = DateOfBirth;
        }

        public void Deconstruct(out string name,
                                out DateTime dob, out WondersOfTheAncientWorld fav)
        {
            name = Name;
            dob = DateOfBirth;
            fav = FavoriteAncientWonder;
        }
// Деконструкция класса
    }


}