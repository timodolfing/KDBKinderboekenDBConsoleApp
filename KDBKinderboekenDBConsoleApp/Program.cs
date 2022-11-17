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
            Console.WriteLine("********************");
            Console.WriteLine("Uit welke bron wil je de boeken halen?");
            Console.WriteLine("********************");
            Console.WriteLine("1: Uit de hardcoded applicatie");
            Console.WriteLine("2: Uit een sql database");
            Console.WriteLine();
            string selectedDataSource = Console.ReadLine();
            IBoekDataService boekDataService = bookDataFactory.GetBoekDataService(selectedDataSource);
            List<Boek> completeBookList = boekDataService.GetAllBooks();
            bookList.AddRange(completeBookList);
            Console.WriteLine();
            foreach (var boek in bookList.OrderBy(Boek => Boek.Titel)) Console.WriteLine(boek.Titel);
            Console.WriteLine();
        }


        private static void SearchBook()
        {
            /**Eerst boekenlijst leegmaken**/
            bookList.Clear();

            /**Dan gewenste bron opvragen bij gebruiker**/
            Console.WriteLine("********************");
            Console.WriteLine("Uit welke bron wil je de boeken halen?");
            Console.WriteLine("********************");
            Console.WriteLine("1: Uit de hardcoded applicatie");
            Console.WriteLine("2: Uit een sql database");
            string selectedDataSource = Console.ReadLine();

            /**Nieuwe dataservice ophalen op basis van geselecteerde bron**/
            IBoekDataService boekDataService = bookDataFactory.GetBoekDataService(selectedDataSource);

            /**Zoekterm opvragen**/
            Console.WriteLine();
            Console.WriteLine("Welk boek wil je zoeken? Geef (een deel van) de titel");
            string searchTermBook = Console.ReadLine();

            /**Zoekfunctie uitvoeren mbv ingevoerde zoekterm**/
            bookList.AddRange(boekDataService.SearchBooks(searchTermBook));

            /**Resultaat printen naar console**/
            Console.WriteLine();
            Console.WriteLine("Ik heb dit voor je gevonden:");
            foreach (var boek in bookList.OrderBy(Boek => Boek.Titel))
            {
                Console.WriteLine();
                Console.WriteLine("Titel: " + boek.Titel);
                Console.WriteLine("Cijfer: " + boek.Cijfer);
                Console.WriteLine("Samenvatting: " + boek.Samenvatting);
                Console.WriteLine();
            }
        }
        private static void AddBook()
        {
            /**Maak een nieuw boekobject aan om weg te kunnen schrijven**/
            Boek NewBook = new Boek();

            /**Vraag de titel op en zet in variabele**/
            Console.WriteLine("Welk boek heb je gelezen?");
            NewBook.Titel = Console.ReadLine();

            /**Vraag het cijfer op, parse deze naar een int en zet in variabele**/
            Console.WriteLine("Welk cijfer geef je het boek? 1 is het laagst, 5 is het hoogst.");
            string cijferAsString = Console.ReadLine();
            NewBook.Cijfer = Int32.Parse(cijferAsString);

            /**Vraag de samenvatting op en zet in variabele**/
            Console.WriteLine("Geef nu een korte samenvatting van het verhaal.");
            NewBook.Samenvatting = Console.ReadLine();
        }   
    }
}