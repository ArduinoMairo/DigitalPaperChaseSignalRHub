using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Loesungen
    {
        public int LoesungId { get; set; }
        public int FragenId { get; set; }
        public string Inhalt { get; set; }
        public bool Korrekt { get; set; }

        public virtual Fragen Fragen { get; set; }
    }
}
