﻿using System;
using System.Globalization;


namespace Desafio_Analize_Vendas_Um
{
    internal class Sale
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string Seller { get; set; }
        public int Items { get; set; }
        public double Total { get; set; }

        public Double AveragePrice()
        {
            return Total / Items;
        }

        public override string ToString()
        {
            return $"{Month}/{Year}, {Seller}, {Items}, {Total.ToString("F2", CultureInfo.InvariantCulture)}, pm = {AveragePrice().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
