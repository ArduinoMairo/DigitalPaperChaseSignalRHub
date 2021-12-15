using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Fragen
    {
        public Fragen()
        {
            Loesungens = new HashSet<Loesungen>();
        }

        public int FragenId { get; set; }
        public int KategorieId { get; set; }
        public string Inhalt { get; set; }

        public virtual Kategorien Kategorie { get; set; }
        public virtual ICollection<Loesungen> Loesungens { get; set; }
    }
}
