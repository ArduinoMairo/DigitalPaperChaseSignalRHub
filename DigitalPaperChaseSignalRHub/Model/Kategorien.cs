using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Kategorien
    {
        public Kategorien()
        {
            Fragens = new HashSet<Fragen>();
            Schnitzeljagdens = new HashSet<Schnitzeljagden>();
        }

        public int KategorieId { get; set; }
        public int FachbereichId { get; set; }
        public string Bezeichnung { get; set; }

        public virtual Fachbereiche Fachbereich { get; set; }
        public virtual ICollection<Fragen> Fragens { get; set; }
        public virtual ICollection<Schnitzeljagden> Schnitzeljagdens { get; set; }
    }
}
