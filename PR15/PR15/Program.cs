using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PR15t
{
    internal class Program
    {
        static bool flag=false;
        public static void Error(string message, ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public struct Notebook
        {
            string lastname;
            string firstname;
            string phoneNumber;
            DateTime DateOfBirth;
            public Notebook(string lastname)
            {
                flag=false;
                phoneNumber = null;
                this.lastname = lastname;
                firstname = null;
                DateOfBirth = new DateTime();
                InfoAboutObjStruct();
            }
            void InfoAboutObjStruct()
            {
                Console.Write("\nФамилия: ");
                lastname = Console.ReadLine();
                Console.Write("Имя: ");
                firstname = Console.ReadLine();
                Console.Write("Полная дата рождения(ДД-ММ-ГГ): ");
                DateOfBirth = DateTime.Parse(Console.ReadLine());
                //Сделать while для проверки корректности 
                Console.Write("Телефонный номер(не менее семи цифр): ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber.Length < 6)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Ошибка, номер телефона слишком короткий");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            void OutputInfoObjStruct()
            {
                Console.WriteLine($"Фамилия: {lastname}, имя: {firstname}, телефонный номер: {phoneNumber},дата рождения:{DateOfBirth.ToShortDateString()}");
            }
            public void FindObjStruct2(string new_point2)
            {
                if (string.Compare(phoneNumber, new_point2) == 0)
                {
                    OutputInfoObjStruct();
                    flag = true;
                }
            }
            public void FindObjStruct(int new_point)
            {
                int month = DateOfBirth.Month;
                if (month == new_point)
                {
                    OutputInfoObjStruct();
                    flag = true;
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте\nПрактическая работа номер 15");
                Console.Write("Введите Y чтобы продолжить или N чтобы выйти ");
                string select_key = Console.ReadLine();
                switch (select_key)
                {
                    case "Y":
                        Console.Write("Укажите количество человек: ");
                        try
                        {
                            uint countPeople = UInt32.Parse(Console.ReadLine());
                            Notebook[] people = new Notebook[countPeople];
                            int i;
                            for (i = 0; i < countPeople; i++)
                                people[i] = new Notebook(null);
                            Console.Write("\nУкажите месяц для поиска: ");
                            int new_point = int.Parse(Console.ReadLine());
                            for (i = 0; i < countPeople; i++)
                            {
                                people[i].FindObjStruct(new_point);
                            }
                            if (!flag )
                                Console.WriteLine("Совпадений не найдено");
                            Console.Write("\nУкажите телефон для поиска: ");
                            string new_point2 = Console.ReadLine();
                            for (i = 0; i < countPeople; i++)
                            {
                                people[i].FindObjStruct2(new_point2);
                            }
                            if (!flag )
                                Console.WriteLine("Совпадений не найдено");
                            Console.ReadKey();
                        }
                        catch (FormatException fe)
                        {
                            Error("Что-то пошло не так. Ошибка: " + fe.Message, ConsoleColor.Red);
                        }
                        catch (Exception ex)
                        {
                            Error("Что-то пошло не так. Ошибка: " + ex.Message, ConsoleColor.Red);
                        }
                        Console.ReadKey();
                        break;
                    case "N":
                        Console.WriteLine("До свидания");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}


