using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class Links
    {
        public int LinkId { get; set; }
        public int SchnitzljagdId { get; set; }
        public int QuellfrageId { get; set; }
        public int ZielfrageId { get; set; }

        public virtual Schnitzeljagden Schnitzljagd { get; set; }
    }
}
