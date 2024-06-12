using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace Desafio_Analize_Vendas_Um
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre o caminho do arquivo: ");
            string path = Console.ReadLine();

            List<Sale> sales = new List<Sale>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        int month = int.Parse(fields[0]);
                        int year = int.Parse(fields[1]);
                        string seller = fields[2];
                        int items = int.Parse(fields[3]);
                        double total = double.Parse(fields[4], CultureInfo.InvariantCulture);

                        sales.Add(new Sale
                        {
                            Month = month,
                            Year = year,
                            Seller = seller,
                            Items = items,
                            Total = total
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return;
            }

            
            var topSales2016 = sales
                .Where(s => s.Year == 2016)
                .OrderByDescending(s => s.AveragePrice())
                .Take(5);

            Console.WriteLine("Cinco primeiras vendas de 2016 de maior preço médio:");
            foreach (var sale in topSales2016)
            {
                Console.WriteLine(sale);
            }

            
            double totalLogan = sales
                .Where(s => s.Seller.Equals("Logan") && (s.Month == 1 || s.Month == 7))
                .Sum(s => s.Total);

            Console.WriteLine($"Valor total vendido pelo vendedor Logan nos meses 1 e 7 = {totalLogan.ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}
