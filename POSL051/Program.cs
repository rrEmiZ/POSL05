using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace POSL051
{
    public class Fruit
    {
        [JsonProperty(PropertyName = "fruit")]
        public string Type { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }

    public class Indicator
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class Statistic
    {
        public Indicator indicator { get; set; }
        public Country country { get; set; }
        public string value { get; set; }
        public string @decimal { get; set; }
        public string date { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Statistic> list;

            //Otwieramy stream pliku sample.txt
            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Statistic>>(json);
            }


            //List<Fruit> list;

            ////Otwieramy stream pliku sample.txt
            //using (var sr = new StreamReader("sample.json"))
            //{
            //    var json = sr.ReadToEnd();

            //    list = JsonConvert.DeserializeObject<List<Fruit>>(json);
            //}


            //list.Add(new Fruit()
            //{
            //    Color = "Black",
            //    Type = "Banana",
            //    Size = "small"
            //});


            //using (var sw = new StreamWriter("sample.json"))
            //{
            //    var json = JsonConvert.SerializeObject(list);

            //    sw.WriteLine(json);
            //}


            Console.ReadLine();
        }
    }
}
