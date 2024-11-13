using System;
using System.Collections.Generic;
using System.Text;

namespace TrainRoute.Domain.Model
{
    public class Route
    {
        public string Start { get; set; }
        public string End { get; set; }
        public int Distance { get; set; }
    }
}
