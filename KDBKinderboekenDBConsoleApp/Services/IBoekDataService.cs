using System;
using KDBKinderboekenDBConsoleApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDBKinderboekenDBConsoleApp.Services
{
    public interface IBoekDataService
    {
        List<Boek> GetAllBooks();
        List<Boek> SearchBooks(string searchTerm);
        Boek GetBookByTitle(string Titel);
        int Insert(Boek boek);
        int Delete(Boek boek);
        int Update(Boek boek);
    }
}
