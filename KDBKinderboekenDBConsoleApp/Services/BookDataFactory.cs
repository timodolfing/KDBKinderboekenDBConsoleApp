using KDBKinderboekenDBConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDBKinderboekenDBConsoleApp.Services
{
    public class BookDataFactory
    {
        public enum dataSource
        {
            HardCodedSampleDataRepository,
            SqlDatabase
        }
        public string selectedDataSource;

        public IBoekDataService GetBoekDataService(string selectedDataSource)
        {
            if (selectedDataSource == "1") 
            {
                return new HardCodedSampleDataRepository();
            }
            else if (selectedDataSource == "2")
            {
                return new BoekenDAO();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
