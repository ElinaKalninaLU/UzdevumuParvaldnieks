using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksKonsole
{
    public abstract class Animal
    {
        public virtual string Speak() => "Animal sound";
    }

    public class Dog : Animal
    {
        public override string Speak() => "Woof";
    }

}
