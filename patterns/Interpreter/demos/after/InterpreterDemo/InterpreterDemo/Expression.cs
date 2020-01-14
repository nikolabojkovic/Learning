using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterpreterDemo
{
    public interface Expression
    {
        void Interpret(Context context);
    }

    public class Context
    {
        public string Output { get; set; }
    }

    // BNF:
    // <sandwhich> ::= <bread> <condimentList> <ingredientList> <condimentList> <bread>
    // <condimentList> ::= { <condiment> }
    // <ingredientList> ::= { <ingredient> }
    // <bread> ::= <whiteBread> | <wheatBread>
    // <condiment> ::= <mayoCondiment> | <mustardCondiment> | <ketchupCondiment>
    // <ingredient> ::= <lettuceIngredient> | <tomatoIngredient> | <chickenIngredient>

    public class Sandwhich : Expression
    {
        private readonly Bread topBread;
        private readonly CondimentList topCondiments;
        private readonly IngredientList ingredients;
        private readonly CondimentList bottomCondiments;
        private readonly Bread bottomBread;

        public Sandwhich(Bread topBread, CondimentList topCondiments, IngredientList ingredients, CondimentList bottomCondiments, Bread bottomBread)
        {
            this.topBread = topBread;
            this.topCondiments = topCondiments;
            this.ingredients = ingredients;
            this.bottomCondiments = bottomCondiments;
            this.bottomBread = bottomBread;
        }

        public void Interpret(Context context)
        {
            context.Output += "|";
            topBread.Interpret(context);
            context.Output += "|";
            context.Output += "<--";
            topCondiments.Interpret(context);
            context.Output += "-";
            ingredients.Interpret(context);
            context.Output += "-";
            bottomCondiments.Interpret(context);
            context.Output += "-->";
            context.Output += "|";
            bottomBread.Interpret(context);
            context.Output += "|";
            Console.WriteLine(context.Output);
        }
    }

    public class IngredientList : Expression
    {
        private readonly List<Ingredient> ingredients;

        public IngredientList(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public void Interpret(Context context)
        {
            foreach(var ingredient in ingredients)
                ingredient.Interpret(context);
        }
    }

    public interface Ingredient : Expression {}

    public class TomatoIngredient : Ingredient
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Tomato");
        }
    }

    public class LettuceIngredient : Ingredient
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Lettuce");
        }
    }

    public class ChickenIngredient : Ingredient
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Chicken");
        }
    }

    public class CondimentList : Expression
    {
        private readonly List<Condiment> condiments;

        public CondimentList(List<Condiment> condiments )
        {
            this.condiments = condiments;
        }

        public void Interpret(Context context)
        {
            foreach(var condiment in condiments)
                condiment.Interpret(context);
        }
    }

    public interface Condiment : Expression {}


    public class MayoCondiment : Condiment
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Mayo");
        }
    }

    public class MustardCondiment : Condiment
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Mustard");
        }
    }

    public class KetchupCondiment : Condiment
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Ketchup");
        }
    }

    public interface Bread : Expression {}

    public class WhiteBread : Bread
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "White-Bread");
        }
    }

    public class WheatBread : Bread
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Wheat-Bread");
        }
    }
}
