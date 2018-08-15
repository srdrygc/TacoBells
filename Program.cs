//using System;
//using System.Linq;
//using System.IO;
//using GeoCoordinatePortable;
//using System.Collections.Generic;
//namespace LoggingKata
//{
//    class Program
//    {
//        static readonly ILog logger = new TacoLogger();
//        const string csvPath = "TacoBell-US-AL.csv";
//        static void Main(string[] args)
//        {
//            logger.LogInfo("Log initialized");
//            var lines = File.ReadAllLines(csvPath);
//            logger.LogInfo($"Lines: {lines[0]}");
//            var parser = new TacoParser();
//            var locations = lines.Select(parser.Parse);
//            TODO: Find the two Taco Bells in Alabama that are the furthest from one another.
//            TacoParser coordinates = new TacoParser();
//            TacoBell firstLocation = new TacoBell();
//            TacoBell secondLocation = new TacoBell();
//            Point firstPoint = new Point();
//            Point secondPoint = new Point();
//            firstPoint.Longitude = double.Parse(null);
//            firstPoint.Latitude = double.Parse(null);
//            secondPoint.Longitude = double.Parse(null);
//            secondPoint.Latitude = double.Parse(null);
//            List<TacoBell> longtitude = new List<TacoBell>();
//            firstLocation.Name = null;
//            secondLocation.Name = null;
//            firstLocation.Location = firstPoint;
//            secondLocation.Location = secondPoint;
//            double latDistance = firstPoint.Latitude - secondPoint.Latitude;
//            double lonDistance = firstPoint.Longitude - secondPoint.Longitude;
//            GeoCoordinate ourPlace = new GeoCoordinate(latDistance, lonDistance);
//            Console.WriteLine(ourPlace);
//            Console.ReadLine();
//        }
//    }
//}

using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections;
using System.Collections.Generic;

// TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
// HINT:  You'll need two nested forloops
// Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;

namespace TacoBells
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            var lines = File.ReadAllLines(csvPath);     //string array with list of all locations = lines

            logger.LogInfo($"Lines: ");

            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse);

            double distance = 0;
            double maxDistance = 0;
            string store1 = "";
            string store2 = "";
            foreach (var line in locations)
            {
                GeoCoordinate corA = new GeoCoordinate();
                corA.Latitude = line.Location.Latitude;
                corA.Longitude = line.Location.Longitude;

                foreach (var line2 in locations)
                {
                    GeoCoordinate corB = new GeoCoordinate();


                    corB.Latitude = line2.Location.Latitude;
                    corB.Longitude = line2.Location.Longitude;
                    distance = corA.GetDistanceTo(corB);

                    if (maxDistance < distance)
                    {
                        store1 = line.Name;
                        store2 = line2.Name;

                        maxDistance = distance;
                    }

                }

            }
            Console.WriteLine(store1 + store2 + maxDistance);
            Console.ReadLine();
        }
    }
}


//            // Log and error if you get 0 lines and a warning if you get 1 line
//            if (lines.Length == 0)
//            {
//                logger.LogError("No lines!");
//            }
//            if (lines.Length == 1)
//            {
//                logger.LogWarning("Must have at least two lines!");
//            }
//            // Create a new instance of your TacoParser class
//            var parser = new TacoParser();
//            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
//            var locations = lines.Select(parser.Parse);  //list with names and point(lat+long) of all locations  //first list we need to loop through
//            // Create two `ITrackable` variables with initial values of `null`
//            //These will be used to store your two taco bells that are the furthest from each other.
//            ITrackable furthestLocation1 = new TacoBell();
//            ITrackable furthestLocation2 = new TacoBell();
//            Point furthestPoint1 = new Point();
//            Point furthestPoint2 = new Point();
//            furthestPoint1.Longitude = double.Parse(null);
//            furthestPoint1.Latitude = double.Parse(null);
//            furthestPoint2.Longitude = double.Parse(null);
//            furthestPoint2.Latitude = double.Parse(null);
//            furthestLocation1.Name = null;
//            furthestLocation2.Name = null;
//            furthestLocation1.Location = furthestPoint1;
//            furthestLocation2.Location = furthestPoint2;
//            // Create a `double` variable to store the distance
//            double Distance = new double();  //dont know which one to use yet, think this is right
//            /*double latDistance = new double();
//            double longDistance = new double(); 
//            Point distance = new Point();
//            distance.Latitude = latDistance;
//            distance.Longitude = longDistance;*/
//            //var sCoord = new GeoCoordinate(sLatitude, sLongitude);
//            //var eCoord = new GeoCoordinate(eLatitude, eLongitude);
//            //Do a loop for your locations to grab each location as the origin(perhaps: `locA`)
//            ITrackable locA = new TacoBell();//origin 
//            Point pointA = new Point();
//            double latA = pointA.Latitude;
//            double longA = pointA.Longitude;
//            locA.Location = pointA;
//            //for(double i=locations.First(); i<237;)
//            foreach (var location in locations)
//            {
//                for (double i = 0; i < 237; i++)
//                {
//                    locA = location;
//                    Console.WriteLine(locA);
//                    Console.ReadLine();
//                }
//            }
//            //for(double i=0;i<237;i++)  //used 237 because thats the number of locations in csv file/wouldn't let me use locations.Length
//            //foreach (var location in locations)   //what I want to use but doesn't work, think we need for loop like above
//            //{ locA = location; 
//            //need to loop through locations list and set eadh location as locA
//            //}
//            // Create a new corA Coordinate with your locA's lat and long
//            GeoCoordinate corA = new GeoCoordinate(latA, longA);
//            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
//            ITrackable locB = new TacoBell();     //destination
//            Point pointB = new Point();
//            double latB = pointB.Latitude;
//            double longB = pointB.Longitude;
//            locB.Location = pointB;
//            foreach (var location in locations)
//            {
//                for (double i = 0; i < 237; i++)
//                {
//                    locB = location;
//                }
//                //same issue as above once I figure out the correct format for these loops we'll be g
//            }
//            // Create a new Coordinate with your locB's lat and long
//            GeoCoordinate corB = new GeoCoordinate(latB, longB);
//            List<double> distanceList = new List<double>();
//            // Now, compare the two using `.GetDistanceTo()`, which returns a double
//            Distance = corA.GetDistanceTo(corB);
//            distanceList.Add(Distance);
//            //distanceList.Max();  //need to get the coordinates from this distance and set them to furthestlocation1and2
//            double maxDistance = 0;
//            foreach (double distance in distanceList)
//            {
//                if (distance > maxDistance)
//                {
//                    maxDistance = distance;
//                }
//            }
//        }
//    }
//}
// If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
//put distances in list then find max distance   //store into the furthest location variables up top
// Once you've looped through everything, you've found the two Ta
