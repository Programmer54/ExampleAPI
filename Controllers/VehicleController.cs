using ExampleAPI.Data;
using ExampleAPI.Data.Enums;
using ExampleAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExampleAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        VehicleCRUD _operations;

        public VehicleController(VehicleCRUD operations)
        {
            _operations= operations;
        }

        [HttpGet]
        public string Get() => "Lütfen apiden araç kategorisi renlk girerek istek yapınız. Araçlar: Car,Boat,Bus <///> Renkler: Kırmızı,Mavi,Siyah,Beyaz";

        [HttpGet("car/{renk}")]
        public JsonResult? GetCarsByColur(string renk)
        {
            Colors color = GetColors(renk);

            if (color == Colors.Empty)
                return new JsonResult("İstediğiniz renkte araçlar bulunamadı.");
            else
                return new JsonResult(_operations.GetVehiclesByColor<Car>(color));
        }

        [HttpGet("boat/{renk}")]
        public JsonResult? GetBoatsByColur(string renk)
        {
            Colors color = GetColors(renk);
            
            if (color == Colors.Empty)
                return new JsonResult("İstediğiniz renkte araçlar bulunamadı.");
            else
                return new JsonResult(_operations.GetVehiclesByColor<Boat>(color));
        }

        [HttpGet("bus/{renk}")]
        public JsonResult? GetBusesByColur(string renk)
        {
            Colors color = GetColors(renk);
            
            if (color == Colors.Empty)
                return new JsonResult("İstediğiniz renkte araçlar bulunamadı.");
            else
                return new JsonResult(_operations.GetVehiclesByColor<Bus>(color));
        }
        //Yukaıdaki get istekleri direkt olarak arama çıbuğundan parametre alacak şekilde oluşturulmuştur,
        //fakat şimdi yazılanlar body kısmından okunacaktır.
        [HttpPost("upcar")]//Dikkat normalde viewmodel json okunması gerek fakar string bir json formatına uygun yapı değil. İstek yaparken direkt yapın => "değer"
        public bool UpdateCar([FromBody]string id)
        {
            try
            {
                int ID = int.Parse(id);
                bool result = _operations.UpdateCar(ID);

                if(result)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteCar([FromBody]string id)
        {
            try
            {
                int ID = int.Parse(id);
                bool result = _operations.DeleteCar(ID);

                if (result)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        [NonAction]
        public Colors GetColors(string renk)
        {
            switch (renk)
            {
                case "Kırmızı":
                case "kırmızı":
                case "Red":
                case "red":
                    {
                        return Colors.Red;
                    }

                case "Mavi":
                case "mavi":
                case "Blue":
                case "blue":
                    {
                        return Colors.Blue;
                    }

                case "Siyah":
                case "siyah":
                case "Black":
                case "black":
                    {
                        return Colors.Black;
                    }
                    
                case "Beyaz":
                case "beyaz":
                case "White":
                case "white":
                    {
                        return Colors.White;
                    }
                    
                default:
                    return Colors.Empty;
                    
            }
        }

    }
    
}
