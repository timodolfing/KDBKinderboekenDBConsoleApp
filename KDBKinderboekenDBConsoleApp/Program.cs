using System;
using System.Collections.Generic;
using KDBKinderboekenDBConsoleApp.Models;
using KDBKinderboekenDBConsoleApp.Services;
using System.Linq;

namespace KDBKinderboekenDBConsoleApp
{
    partial class Program
    {
        private static List<Boek> bookList = new List<Boek>();
        private static BookDataFactory bookDataFactory = new BookDataFactory();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************");
            Console.WriteLine("* De Grote Kiers-Dolfing-Bruce Kinderboeken Database *");
            Console.WriteLine("***********************************");
            Console.ForegroundColor = ConsoleColor.White;

            string userSelection;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("********************");
                Console.WriteLine("* Selecteer hier wat je wilt doen *");
                Console.WriteLine("********************");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("1: Alle boeken in de database bekijken");
                Console.WriteLine("2: Een boek zoeken");
                Console.WriteLine("3: Een boek toevoegen");
                Console.WriteLine("4: Een schrijver zoeken");
                Console.WriteLine("5: Een schrijver toevoegen");
                Console.WriteLine("9: De applicatie beëindigen");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        GetAllBooks();
                        break;
                    case "2":
                        SearchBook();
                        break;
                    case "3":
                        AddBook();
                        break;
                    case "4":
                        SearchWriter();
                        break;
                    case "5":
                        AddWriter();
                        break;
                    case "9": break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "9");

            Console.WriteLine("Leuk dat je de KinderboekenDB hebt gebruikt! Tot snel!");
            Console.Read();

        }

        private static void GetAllBooks()
        {
            bookList.Clear();
            Console.WriteLine("Uit welke bron wil je de boeken halen?");
            Console.WriteLine("1: Uit de hardcoded applicatie");
            Console.WriteLine("2: Uit een sql database");
            string selectedDataSource = Console.ReadLine();
            IBoekDataService boekDataService = bookDataFactory.GetBoekDataService(selectedDataSource);
            List<Boek> completeBookList = boekDataService.GetAllBooks();
            bookList.AddRange(completeBookList);
            foreach (var boek in bookList.OrderBy(Boek => Boek.Titel)) Console.WriteLine(boek.Titel);            
        }



            private static void AddWriter()
        {
            Console.WriteLine("Een boek toevoegen");
            Console.Write("Welk boek zoek je?");
            string searchTerm = Console.ReadLine();
        }

        private static void SearchWriter()
        {
            throw new NotImplementedException();
        }

        private static void AddBook()
        {
            throw new NotImplementedException();
        }

        private static void SearchBook()
        {
            bookList.Clear();
            Console.WriteLine("Uit welke bron wil je de boeken halen?");
            Console.WriteLine("1: Uit de hardcoded applicatie");
            Console.WriteLine("2: Uit een sql database");
            string selectedDataSource = Console.ReadLine();
            IBoekDataService boekDataService = bookDataFactory.GetBoekDataService(selectedDataSource);
            Console.WriteLine("Welk boek wil je zoeken? Geef (een deel van) de titel");
            string searchTermBook = Console.ReadLine();
            bookList.AddRange(boekDataService.SearchBooks(searchTermBook));
            Console.WriteLine("Ik heb dit voor je gevonden:");
            foreach (var boek in bookList.OrderBy(Boek => Boek.Titel)) Console.WriteLine("Titel: " + boek.Titel);
            foreach (var boek in bookList.OrderBy(Boek => Boek.Titel)) Console.WriteLine("Cijfer: " + boek.Cijfer);
            foreach (var boek in bookList.OrderBy(Boek => Boek.Titel)) Console.WriteLine("Samenvatting: " + boek.Samenvatting);
        }
    }
}
