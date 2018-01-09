using System;
using System.Collections.Generic;
using System.Text;

namespace HittaLekparker
{

    public class Rootobject
    {
        public PlayGround[] PlayGrounds { get; set; }
    }

    public class PlayGround
    {
        public Geographicalposition GeographicalPosition { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
    }

    public class Geographicalposition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}
