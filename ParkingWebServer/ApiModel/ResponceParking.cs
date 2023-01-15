using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Model;

namespace ParkingWebServer.ApiModel
{
    public class ResponceParking
    {
        public ResponceParking(Parking parking) 
        {
            this.ID = parking.ID;
            this.IDClient = parking.IDClient;
            this.DateStart = parking.DateStart;
            this.DateEnd = parking.DateEnd;
            this.Price = parking.Price;
            this.NumberParking = parking.NumberParking;     

        }
        public ResponceParking() { }
        public int ID { get; set; }
        public int IDClient { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public decimal Price { get; set; }
        public int NumberParking { get; set; }
    }
}
