using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Punkte
    {
        public int SpielerId { get; set; }
        public int SchnitzeljagdId { get; set; }
        public int Punkte1 { get; set; }

        public virtual Schnitzeljagden Schnitzeljagd { get; set; }
        public virtual Spieler Spieler { get; set; }
    }
}
