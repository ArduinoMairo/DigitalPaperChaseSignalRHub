using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Fachbereiche
    {
        public Fachbereiche()
        {
            Kategoriens = new HashSet<Kategorien>();
        }

        public int FachbereichId { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<Kategorien> Kategoriens { get; set; }
    }
}
