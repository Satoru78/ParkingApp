using ParkingApp.Context;
using ParkingApp.Model;
using ParkingWebServer.ApiModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ParkingWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Инициализация сервера
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:21231/");

            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            server.Start();

            while (true)
            {
                HttpListenerContext context = server.GetContext();

                ///Api запрос на отображение данных из БД 
                if (context.Request.HttpMethod == "GET")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/parking/")
                        {
                            var parkingList = Data.db.Parking.ToList();
                            string response = JsonSerializer.Serialize(Data.db.Parking.ToList().ConvertAll(c => new ResponceParking(c)));
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            context.Response.ContentType = "application/json;charset=utf-8";
                            using (Stream stream = context.Response.OutputStream)
                            {
                                context.Response.StatusCode = 200;
                                stream.Write(data, 0, data.Length);
                            }
                        }
                    }
                    ///Обработка исключений
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 200;
                        context.Response.Close();
                    }

                }
                 ///Api запрос на удаление данных из БД 
                else if (context.Request.HttpMethod == "DELETE")
                {
                    try
                    {
                        if (context.Request.QueryString.Count == 1)
                        {
                            if (context.Request.QueryString.Keys[0] == "id")
                            {
                                int id = Convert.ToInt32(context.Request.QueryString.Get(0));
                                var currentParking = Data.db.Parking.FirstOrDefault(c => c.ID == id);
                                if (currentParking != null)
                                {
                                    Data.db.Parking.Remove(currentParking);
                                    Data.db.SaveChanges();
                                    context.Response.StatusCode = 200;
                                    context.Response.Close();
                                }
                            }
                        }
                    }
                    ///Обработка исключений
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();

                    }
                }
                ///Api запрос на добавление данных из БД 
                else if (context.Request.HttpMethod == "POST")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/parking/")
                        {
                            if (context.Request.ContentType == "application/json")
                            {
                                string request = "";
                                byte[] data = new byte[context.Request.ContentLength64];
                                using (Stream stream = context.Request.InputStream)
                                {
                                    stream.Read(data, 0, data.Length);
                                }
                                request = UTF8Encoding.UTF8.GetString(data);
                                var parkingList = JsonSerializer.Deserialize<List<ResponceParking>>(request);
                                foreach (var item in parkingList)
                                {
                                    Parking park = new Parking();
                                    park.IDClient = item.IDClient;
                                    park.DateStart = item.DateStart;
                                    park.DateEnd = item.DateEnd;
                                    park.Price = item.Price;
                                    park.NumberParking = item.NumberParking;
                                    Data.db.Parking.Add(park);
                                }
                                Data.db.SaveChanges();
                                context.Response.StatusCode = 200;
                                context.Response.Close();
                            }
                        }

                    }
                    ///Обработка исключений
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }
        }
    }
}
