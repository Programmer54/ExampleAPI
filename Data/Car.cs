using ExampleAPI.Data.Base;

namespace ExampleAPI.Data
{
    public class Car : Vehicle
    {
        public bool HeadLights { get; set; } = false;

        public int Wheels { get; set; } = 0;
    }
}
