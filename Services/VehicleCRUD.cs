using ExampleAPI.Data.Base;
using ExampleAPI.Data;
using ExampleAPI.Data.Enums;
using System.Linq;
using System.Drawing;

namespace ExampleAPI.Services
{
    public class VehicleCRUD
    {
        
        public List<Tip> GetVehiclesByColor<Tip>(Colors renk) where Tip : Vehicle
            => ExampleData.Vehicles.Where(p => p.Color.Equals(renk) && p.GetType()==typeof(Tip)).Cast<Tip>().ToList();

        public Vehicle? UpdateVehicle(int id)
        {
            Vehicle? arac = ExampleData.Vehicles.FirstOrDefault(p => p.ID == id);
            if (arac is null)
                return null;
            else
                return arac;
        }

        public bool DeleteVehicle(int id) 
        {
            Vehicle? vehicle= ExampleData.Vehicles.FirstOrDefault(p=>p.ID == id);
            if (vehicle is null) return false;
            else
            {
                ExampleData.Vehicles.Remove(vehicle);
                return true;
            }
        }

        //Özel Fonksiyonlar

        public bool UpdateCar(int id)
        {
            //Car car = (Car)Vehicles.FirstOrDefault(c => c.ID == id);
            Car? car = ExampleData.Vehicles.Cast<Car>().FirstOrDefault(c => c.ID == id);
            if (car is null) 
                return false;
            else
            {
                car.HeadLights = true;
                return true;
            }

        }

        public bool DeleteCar(int id)
        {
            Car? car = ExampleData.Vehicles.Cast<Car>().FirstOrDefault(c => c.ID == id);
            if (car is null) return false;
            else
            {
                ExampleData.Vehicles.Remove(car);
                return true;
            }
        }



    }
}
