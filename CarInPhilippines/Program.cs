using System;
using System.Collections.Generic;

namespace Cars
{
    public enum ExchangeRate
    {
        Usd = 47
    }

    public enum Countries
    {
        Europe = 1,
        Usa = 2,
        Japan = 3,
        China = 4
    }

    public enum CapacityInCcm
    {
        LessThanTwo = 1,
        LessThanFive = 2,
        GreaterThanFive = 3
    }

    public class TaxHelper
    {
        public static IDictionary<Countries, IDictionary<CapacityInCcm, int>> TaxImportRate =
            new Dictionary<Countries, IDictionary<CapacityInCcm, int>>
            {
               {
                   Countries.Europe, new Dictionary<CapacityInCcm, int>
                   {
                        {CapacityInCcm.LessThanTwo, 100},
                        {CapacityInCcm.LessThanFive, 120},
                        {CapacityInCcm.GreaterThanFive, 200}
                   }
               },
                {
                   Countries.Usa, new Dictionary<CapacityInCcm, int>
                   {
                        {CapacityInCcm.LessThanTwo, 75},
                        {CapacityInCcm.LessThanFive, 90},
                        {CapacityInCcm.GreaterThanFive, 150}
                   }
                },
                {
                   Countries.Japan, new Dictionary<CapacityInCcm, int>
                   {
                        {CapacityInCcm.LessThanTwo, 70},
                        {CapacityInCcm.LessThanFive, 80},
                        {CapacityInCcm.GreaterThanFive, 135}
                   }
                },
                {
                   Countries.China, new Dictionary<CapacityInCcm, int>
                   {
                        {CapacityInCcm.LessThanTwo, 0},
                        {CapacityInCcm.LessThanFive, 0},
                        {CapacityInCcm.GreaterThanFive, 0}
                   }
                }
            };
    }
}

namespace CarInPhilippines
{
    using Cars;
    public class CarInPhilippinesPayment 
    {
        private readonly decimal _vatRate = new decimal(0.12);
       
        public decimal CalculatePrice(Countries countries, CapacityInCcm capacityInCcm, int originalPrice)
        {
            var taxrate = TaxHelper.TaxImportRate[countries][capacityInCcm];
            var importTax = originalPrice * taxrate / 100;
            var vat = (originalPrice + importTax)*_vatRate;
            return originalPrice + importTax + vat;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
       
            var payment = new CarInPhilippinesPayment();
            var pesos = (int)ExchangeRate.Usd;
            Console.WriteLine("Benz G65 from Germany (Europe county), 6.0L,  original price $217,900 USD");
            Console.WriteLine("Price:{0} Pesos", pesos * payment.CalculatePrice(Countries.Europe, CapacityInCcm.LessThanFive, 217900));
            Console.WriteLine();

            Console.WriteLine("Honda Jazz 1.5L (Japan) original price $19,490 USD");
            Console.WriteLine("Price:{0} Pesos", pesos * payment.CalculatePrice(Countries.Japan, CapacityInCcm.LessThanTwo, 19490));
            Console.WriteLine();

            Console.WriteLine("Jeep wrangler 3.6L (USA) original price, $36,995 USD");
            Console.WriteLine("Price:{0} Pesos", pesos * payment.CalculatePrice(Countries.Usa, CapacityInCcm.LessThanFive, 36996));
            Console.WriteLine();

            Console.WriteLine("Chery QQ 1.0L (China) original price, $6,000 USD");
            Console.WriteLine("Price:{0} Pesos", pesos * payment.CalculatePrice(Countries.China, CapacityInCcm.LessThanTwo, 6000));
            Console.ReadLine();
        }
    }
}