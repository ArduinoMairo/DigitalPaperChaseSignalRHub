using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Schnitzeljagden
    {
        public Schnitzeljagden()
        {
            Links = new HashSet<Link>();
        }

        public int SchnitzeljagdId { get; set; }
        public int KategorieId { get; set; }
        public string Bezeichnung { get; set; }

        public virtual Kategorien Kategorie { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
