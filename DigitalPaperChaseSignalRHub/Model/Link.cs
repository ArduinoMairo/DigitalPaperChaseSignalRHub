using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Link
    {
        public int LinkId { get; set; }
        public int SchnitzeljagdId { get; set; }
        public int QuellfrageId { get; set; }
        public int ZielfrageId { get; set; }

        public virtual Schnitzeljagden Schnitzeljagd { get; set; }
    }
}
