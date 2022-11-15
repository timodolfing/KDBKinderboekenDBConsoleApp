using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDBKinderboekenDBConsoleApp.Models
{
    using System.ComponentModel;
    public class Boek
    {
        [DisplayName("Id nummer")]
        public int Id { get; set; }
        [DisplayName("Titel van het boek")]
        public string Titel { get; set; }
        [DisplayName("Waar het boek over gaat")]
        public string Samenvatting { get; set; }
        [DisplayName("Cijfer voor het boek")]
        public int Cijfer { get; set; }
    }
}