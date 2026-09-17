using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FoodItem> menu = new List<FoodItem> {

        new FoodItem { ID = 1, Namefood = "Бургер", Price = 250.00m, Descriptionfood = "Сочный бургер" },
        new FoodItem { ID = 2, Namefood = "Кола", Price = 100.00m, Descriptionfood = "Холодный напиток" },
        new FoodItem { ID = 3, Namefood = "Пицца", Price = 450.00m, Descriptionfood = "Пепперони 30см" }
            };
    

            
            Order myOrder = new Order(101);

            Console.WriteLine("--- ДОБРО ПОЖАЛОВАТЬ В НАШЕ КАФЕ ---");

            while (true)
            {
                Console.WriteLine("\n--- МЕНЮ ТОВАРОВ ---");
                foreach (var food in menu)
                {
                    Console.WriteLine($"[{food.ID}] {food.Namefood} — {food.Price} руб. ({food.Descriptionfood})");
                }
                Console.WriteLine("[0] Выйти и посчитать сумму заказа");

                Console.Write("\nВведите номер блюда для добавления в заказ: ");
                string input = Console.ReadLine();

             
                if (input == "0")
                {
                    break;
                }

               
                if (int.TryParse(input, out int chosenId))
                {
                  
                    FoodItem selectedFood = menu.Find(f => f.ID == chosenId);

                    if (selectedFood != null)
                    {
                        myOrder.Items.Add(selectedFood);
                        Console.WriteLine($"Успешно добавлено: {selectedFood.Namefood}");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Блюдо с таким номером не найдено!");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Пожалуйста, введите корректное число!");
                }
            }

            
            Console.WriteLine("\n=============================");
            Console.WriteLine($"ИТОГ К ОПЛАТЕ по заказу №{myOrder.ID}:");
            Console.WriteLine($"Всего товаров в корзине: {myOrder.Items.Count}");
            Console.WriteLine($"Общая сумма: {myOrder.GetTotalSum()} рублей.");
            Console.WriteLine("=============================");

            Console.ReadLine(); 
        }

    }
    }
     public class FoodItem 
    {
        public int  ID { get; set; }
        public string Namefood { get; set; }
        public string Descriptionfood { get; set; }

        public decimal Price { get; set; }
    }
    public class Order
    {
        public int ID { get; set; }
        public List<FoodItem> Items { get; set; }
        public Order(int ID) 
        {
            ID = ID ;
            Items = new List<FoodItem>();
        }
        public decimal GetTotalSum()
        { 
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            return total;
        }
    }




