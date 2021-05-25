using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace lab8_w61922
{
    public class Car : ICarRepository
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Manufactured { get; set; }
        public int EngineCapacity { get; set; }
        public double Power { get; set; }
        public string Type { get; set; }
        public string LicensePlate { get; set; }

        public void Add(string _man, string _model, int _Man, int _poj, double _moc, string _typ, string licencja)
        {
            var list = new List<Car>();
            list.Add(new Car()
            {
                Manufacturer = _man,
                Model = _model,
                Manufactured = _Man,
                EngineCapacity = _poj,
                Power = _moc,
                Type = _typ,
                LicensePlate = licencja
            });
        }
        public List<Car> GetAll()
        {
            List<Car> list;
            using (var sr = new StreamReader("cars.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            return list;
        }
    }

    public interface ICarRepository
    {
        List<Car> GetAll();
        void Add(string _man, string _model, int _Man, int _rok, double _moc, string _typ, string licencja);
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> list;
            using (var sr = new StreamReader("cars.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            var ileAUDI = list.Where(x => x.Manufacturer == "Audi").Count();
            var ilePowyzej2L = list.Where(x => x.EngineCapacity > 2000).Count();
            var ileBMW = list.Where(x => x.Manufacturer == "BMW").Count();
            var ilePonizej2L = list.Where(x => x.EngineCapacity < 2000).Count();

        }
    }
}
