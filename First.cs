using System;

namespace Lesson_5.First
{
    abstract class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int PriceMarkup { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }

        public abstract void GetPrice();
    }

    class DigitalProduct : Product
    {
        public new const int Price = 150;
        public DigitalProduct(string name, int quantity, int priceMarkup)
        {
            Name = name;
            PriceMarkup = priceMarkup;
            Quantity = quantity;
        }
        public override void GetPrice()
        {
            Console.WriteLine($"Цена товара {Name} за 1шт. составляет {Price} руб.");
        }
        public void ShowMargin()
        {
            double selfPrice = Quantity * Price;
            double totalPrice = Quantity * (Price + PriceMarkup);
            double margin = totalPrice - selfPrice;
            Console.WriteLine($"Цена товара {Name} в количестве {Quantity} составляет {Math.Round(totalPrice, 2)} руб.");
            Console.WriteLine($"Себестоимость продукта составила: {Math.Round(selfPrice, 2)} руб.; Прибыль: {Math.Round(margin, 2)} руб.\n");
        }
    }

    class SingleProduct : Product
    {
        public SingleProduct(string name, int quantity, int priceMarkup)
        {
            Name = name;
            PriceMarkup = priceMarkup;
            Quantity = quantity;
            Price = DigitalProduct.Price * 2;
        }
        public override void GetPrice()
        {
            Console.WriteLine($"Цена товара {Name} за 1шт. составляет {Price} руб.");
        }
        public void ShowMargin()
        {
            double selfPrice = Quantity * Price;
            double totalPrice = Quantity * (Price + PriceMarkup);
            double margin = totalPrice - selfPrice;
            Console.WriteLine($"Цена товара {Name} в количестве {Quantity} составляет {Math.Round(totalPrice, 2)} руб.");
            Console.WriteLine($"Себестоимость продукта составила: {Math.Round(selfPrice, 2)} руб.; Прибыль: {Math.Round(margin, 2)} руб.\n");
        }
    }

    class WeightProduct : Product
    {
        public WeightProduct(string name, int price, double weight, int priceMarkup)
        {
            Name = name;
            Weight = weight;
            Price = price;
            PriceMarkup = priceMarkup;
        }
        public override void GetPrice()
        {
            Console.WriteLine($"Цена товара {Name} за 1кг. составляет {Price} руб.");
        }
        public void ShowMargin()
        {
            double selfPrice = Weight * Price;
            double totalPrice = Weight * (Price + PriceMarkup);
            double margin = totalPrice - selfPrice;
            Console.WriteLine($"Цена товара {Name} за {Math.Round(Weight, 2)} кг составляет {Math.Round(totalPrice, 2)} руб.");
            Console.WriteLine($"Себестоимость продукта составила: {Math.Round(selfPrice, 2)} руб.; Прибыль: {Math.Round(margin, 2)} руб.\n");
        }
    }

    class Run
    {
        static void Main()
        {
            Random rnd = new Random();

            var digit = new DigitalProduct("Зубная паста \"Чистая линия\"", rnd.Next(1, 20), rnd.Next(10, 200));
            digit.GetPrice();
            digit.ShowMargin();

            var single = new SingleProduct("Сырок \"Александров\"", rnd.Next(1, 20), rnd.Next(10, 200));
            single.GetPrice();
            single.ShowMargin();

            double rndWeight = rnd.NextDouble()*10;
            var weight = new WeightProduct("Печенье \"Милка\"", rnd.Next(100, 800), rndWeight, rnd.Next(10, 200));
            weight.GetPrice();
            weight.ShowMargin();
        }
    }
}
