using System;
using System.Collections.Generic;

namespace TacoBells
{ /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser 
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3 )
            {
                return null;
            }
            string lat = cells[0];
            string log = cells[1];
            string city = cells[2];

            double _lat = double.Parse(lat);
            double _log = double.Parse(log);

            TacoBell belli = new TacoBell();
            belli.Name = city;
            belli.Location = new Point { Latitude = _lat, Longitude = _log };

            return belli;
            
        }
    }
}
