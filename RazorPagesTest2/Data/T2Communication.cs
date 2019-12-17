using Newtonsoft.Json;
using RazorPagesTest2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace RazorPagesTest2.Data
{
    public class T2Communication // implement this with singleton
    {

        public async Task<String> getData()
        {
            Console.WriteLine("Creating client!");
            HttpClient client = new HttpClient();
            Console.WriteLine("Client created! Sending request!");  
            String response = await client.GetStringAsync("https://localhost:44307/api/Movie");

            return response;
        }

        public async Task<String> GETMovieData(String date){
            String message = date;
            HttpClient client = new HttpClient();
            Console.WriteLine("https://localhost:5003/api/Movie/date?date=" + date);
            var response = await client.GetAsync("https://localhost:5003/api/Movie/date?date="+date);
            var result = response.Content.ReadAsStringAsync().Result;
            var deserialised  =  JsonConvert.DeserializeObject(result);
            Console.WriteLine(result);
            return result;
        }

        public async Task<String> POSTRegistrationData(String username, String password, String confirmPassword, String email){
            String[] message = new String[4] { username, password, confirmPassword , email };
            HttpClient client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5003/api/Movie/register", stringContent);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        public async Task<String> POSTLoginData(String username, String password)
        {
            String[] message = new String[2] { username, password };
            HttpClient client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5003/api/Movie/login", stringContent);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        public async Task<String> POSTBookingData(String username, String title, String hour, String date)
        {

            String[] message = new String[4] { username, title, date, hour };
            HttpClient client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5003/api/Movie/booking", stringContent);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;

        }


    }
}
