using ExampleAPI.Data;
using ExampleAPI.Data.Base;
using ExampleAPI.Data.Enums;

namespace ExampleAPI
{
    public class ExampleData
    {
        public static List<Vehicle> Vehicles { get; set; }

        static ExampleData()
        {
            Vehicles = new List<Vehicle>()
            {
                new Car { ID =0, Color = Colors.Red, HeadLights=false, Wheels=4 },
                new Car { ID =1, Color = Colors.Blue, HeadLights=false, Wheels=6 },
                new Car { ID =2, Color = Colors.Black, HeadLights=false, Wheels=8 },
                new Car { ID =3, Color = Colors.White, HeadLights=false, Wheels=3 },

                new Boat { ID=4, Color = Colors.Red},
                new Boat { ID=5, Color = Colors.Blue},
                new Boat { ID=6, Color = Colors.Black},
                new Boat { ID=7, Color = Colors.White},

                new Bus { ID=8, Color = Colors.Red},
                new Bus { ID=9,Color = Colors.Blue},
                new Bus { ID=10,Color = Colors.Black},
                new Bus { ID=11,Color = Colors.White},
            };
        }
    }
}
