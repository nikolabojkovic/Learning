using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterpreterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sandwhich = new Sandwhich(
                new WheatBread(),
                new CondimentList(
                    new List<Condiment> {new MayoCondiment(), new MustardCondiment()}),
                new IngredientList(
                    new List<Ingredient> {new LettuceIngredient(), new ChickenIngredient()}),
                new CondimentList(new List<Condiment> {new KetchupCondiment()}),
                new WheatBread());
              
            sandwhich.Interpret(new Context());
            
            
            Console.ReadKey();
        }
    }
}
