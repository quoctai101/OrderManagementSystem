using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    abstract class Pizza
    {
        protected double mPrice;
        protected bool mIsFamilySize;

        protected bool mHasCheese;
        protected byte mNumCheese;
        protected bool mHasHam;
        protected byte mNumHam;
        protected bool mHasOnion;
        protected byte mNumOnion;
        protected bool mHasPineapple;
        protected byte mNumPineapple;
        protected bool mHasSalami;
        protected byte mNumSalami;

        public double GetPrice()
        {
            if (mIsFamilySize) return mPrice + 4.15;
            else return mPrice;
        }

        public abstract string GetDescription();
    }
    class MargheritaPizza : Pizza
    {
        public MargheritaPizza(PizzaBuilder builder)
        {
            this.mPrice = builder.Price;
            this.mIsFamilySize = builder.IsFamilySize;
            this.mHasCheese = builder.HasCheese;
            this.mNumCheese = builder.NumCheese;
            this.mHasHam = builder.HasHam;
            this.mNumHam = builder.NumHam;
            this.mHasOnion = builder.HasOnion;
            this.mNumOnion = builder.NumOnion;
            this.mHasPineapple = builder.HasPineapple;
            this.mNumPineapple = builder.NumPineapple;
            this.mHasSalami = builder.HasSalami;
            this.mNumSalami = builder.NumSalami;
        }
        public override string GetDescription()
        {
            var description = new StringBuilder();
            description.Append($"Pizza Margherita (tomato, cheese). ");
            if (mHasCheese || mHasHam || mHasOnion || mHasPineapple || mHasSalami)
            {
                description.Append($"( With ");
                if (mHasCheese) description.Append($"{this.mNumCheese} Cheese ");
                if (mHasHam) description.Append($"{this.mNumHam} Ham ");
                if (mHasOnion) description.Append($"{this.mNumOnion} Onion ");
                if (mHasPineapple) description.Append($"{this.mNumPineapple} Pineapple ");
                if (mHasSalami) description.Append($"{this.mNumSalami} Salami ");
                description.Append($"). ");
            }
            if(mIsFamilySize) description.Append($"\nFamily Size");
            description.Append($"\nPrice {this.mPrice:c}");
            return description.ToString();
        }
    }
    class HawaiianPizza : Pizza
    {
        public HawaiianPizza(PizzaBuilder builder)
        {
            this.mPrice = builder.Price;
            this.mIsFamilySize = builder.IsFamilySize;
            this.mHasCheese = builder.HasCheese;
            this.mNumCheese = builder.NumCheese;
            this.mHasHam = builder.HasHam;
            this.mNumHam = builder.NumHam;
            this.mHasOnion = builder.HasOnion;
            this.mNumOnion = builder.NumOnion;
            this.mHasPineapple = builder.HasPineapple;
            this.mNumPineapple = builder.NumPineapple;
            this.mHasSalami = builder.HasSalami;
            this.mNumSalami = builder.NumSalami;
        }
        public override string GetDescription()
        {
            var description = new StringBuilder();
            description.Append($"Hawaiian Pizza (tomato, cheese, ham, pineapple). ");
            if (mHasCheese || mHasHam || mHasOnion || mHasPineapple || mHasSalami)
            {
                description.Append($"( With ");
                if (mHasCheese) description.Append($"{this.mNumCheese} Cheese ");
                if (mHasHam) description.Append($"{this.mNumHam} Ham ");
                if (mHasOnion) description.Append($"{this.mNumOnion} Onion ");
                if (mHasPineapple) description.Append($"{this.mNumPineapple} Pineapple ");
                if (mHasSalami) description.Append($"{this.mNumSalami} Salami ");
                description.Append($"). ");
            }
            if (mIsFamilySize) description.Append($"\nFamily Size");
            description.Append($"\nPrice {this.mPrice:c}");
            return description.ToString();
        }
    }
    class SalamiPizza : Pizza
    {
        public SalamiPizza(PizzaBuilder builder)
        {
            this.mPrice = builder.Price;
            this.mIsFamilySize = builder.IsFamilySize;
            this.mHasCheese = builder.HasCheese;
            this.mNumCheese = builder.NumCheese;
            this.mHasHam = builder.HasHam;
            this.mNumHam = builder.NumHam;
            this.mHasOnion = builder.HasOnion;
            this.mNumOnion = builder.NumOnion;
            this.mHasPineapple = builder.HasPineapple;
            this.mNumPineapple = builder.NumPineapple;
            this.mHasSalami = builder.HasSalami;
            this.mNumSalami = builder.NumSalami;
        }
        public override string GetDescription()
        {
            var description = new StringBuilder();
            description.Append($"Salami Pizza (tomato, cheese, salami). ");
            if (mHasCheese || mHasHam || mHasOnion || mHasPineapple || mHasSalami)
            {
                description.Append($"( With ");
                if (mHasCheese) description.Append($"{this.mNumCheese} Cheese ");
                if (mHasHam) description.Append($"{this.mNumHam} Ham ");
                if (mHasOnion) description.Append($"{this.mNumOnion} Onion ");
                if (mHasPineapple) description.Append($"{this.mNumPineapple} Pineapple ");
                if (mHasSalami) description.Append($"{this.mNumSalami} Salami ");
                description.Append($"). ");
            }
            if (mIsFamilySize) description.Append($"\nFamily Size");
            description.Append($"\nPrice {this.mPrice:c}");
            return description.ToString();
        }
    }
    class PizzaBuilder
    {
        public double Price;
        public bool IsFamilySize;

        public bool HasCheese;
        public byte NumCheese;
        public bool HasHam;
        public byte NumHam;
        public bool HasOnion;
        public byte NumOnion;
        public bool HasPineapple;
        public byte NumPineapple;
        public bool HasSalami;
        public byte NumSalami;

        public PizzaBuilder()
        {

        }
        private double totalTopping()
        {
            return this.NumCheese * 0.69 + this.NumHam * 0.99 + this.NumOnion * 0.69
                + this.NumPineapple * 0.79 + this.NumSalami * 0.99;
        }
        public PizzaBuilder AddCheese()
        {
            this.HasCheese = true;
            this.NumCheese++;
            return this;
        }
        public PizzaBuilder AddHam()
        {
            this.HasHam = true;
            this.NumHam++;
            return this;
        }
        public PizzaBuilder AddOnion()
        {
            this.HasOnion = true;
            this.NumOnion++;
            return this;
        }
        public PizzaBuilder AddPineapple()
        {
            this.HasPineapple = true;
            this.NumPineapple++;
            return this;
        }
        public PizzaBuilder AddSalami()
        {
            this.HasSalami = true;
            this.NumSalami++;
            return this;
        }
        public Pizza Build()
        {
            if(this.HasHam && this.HasPineapple)
            {
                this.NumHam--;
                this.HasHam = this.NumHam > 0 ? true : false;
                this.NumPineapple--;
                this.HasPineapple = this.NumPineapple > 0 ? true : false;
                this.Price = 6.49 + totalTopping();
                return new HawaiianPizza(this);
            }
            else if(this.HasSalami)
            {
                this.NumSalami--;
                this.HasSalami = this.NumSalami > 0 ? true : false;
                this.Price = 5.99 + totalTopping();
                return new SalamiPizza(this);
            }
            else
            {
                this.Price = 4.99 + totalTopping();
                return new MargheritaPizza(this);
            }
        }
    }
}
