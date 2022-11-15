using KDBKinderboekenDBConsoleApp.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDBKinderboekenDBConsoleApp.Services
{
    public class HardCodedSampleDataRepository : IBoekDataService
    {
        public List<Boek> boekenlijst = new List<Boek>();
        public List<Boek> searchResult = new List<Boek>();


        public int Delete(Boek boek)
        {
            throw new NotImplementedException();
        }

        public List<Boek> GetAllBooks()
        {
            boekenlijst.Add(new Boek { Id = 1, Titel = "Ronja de Roversdochter", Samenvatting = "Het gaat over een meisje", Cijfer = 5 });
            boekenlijst.Add(new Boek { Id = 2, Titel = "De Heksen", Samenvatting = "Het gaat over een stel gevaarlijke heksen", Cijfer = 5 });
            boekenlijst.Add(new Boek { Id = 3, Titel = "Harry Potter", Samenvatting = "Het gaat over een tovernaar", Cijfer = 5 });

            return boekenlijst;
        }

        public Boek GetBookByTitle(string Titel)
        {
            throw new NotImplementedException();
        }

        public int Insert(Boek boek)
        {
            throw new NotImplementedException();
        }

        public List<Boek> SearchBooks(string searchTerm)
        {
            boekenlijst.Add(new Boek { Id = 1, Titel = "Ronja de Roversdochter", Samenvatting = "Het gaat over een meisje", Cijfer = 5 });
            boekenlijst.Add(new Boek { Id = 2, Titel = "De Heksen", Samenvatting = "Het gaat over een stel gevaarlijke heksen", Cijfer = 5 });
            boekenlijst.Add(new Boek { Id = 3, Titel = "Harry Potter", Samenvatting = "Het gaat over een tovernaar", Cijfer = 5 });

            List<Boek> searchResult = new List<Boek>();

            searchResult = boekenlijst.FindAll(
                delegate (Boek book)
                {
                    return book.Titel == searchTerm;
                }
                );
            return searchResult;
        }

        public int Update(Boek boek)
        {
            throw new NotImplementedException();
        }        
    }
}