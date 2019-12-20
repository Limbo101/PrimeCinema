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
    public class T2Communication
    {

        private HttpClient client;
        private static T2Communication instance;

        private T2Communication()
        {
            client = new HttpClient();
        }

        public static T2Communication getInstance()
        {
            if (instance == null) instance = new T2Communication();
            return instance;
        }


        public async Task<List<Movie>> GETMovieData(String date){
            List<Movie> movies = new List<Movie>();
            String message = date;
            Console.WriteLine("https://localhost:5003/api/Movie/date?date=" + date);
            var response = await client.GetAsync("https://localhost:5003/api/Movie/date?date="+date);  //
            var result = response.Content.ReadAsStringAsync().Result;
            movies =  JsonConvert.DeserializeObject<List<Movie>>(result);
            Console.WriteLine(result);
            return movies;
        }

        public async Task<String> POSTRegistrationData(String username, String password, String confirmPassword, String email){
            String[] message = new String[4] { username, password, confirmPassword , email };
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5003/api/Movie/register", stringContent);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        public async Task<String> POSTLoginData(String username, String password)
        {
            String[] message = new String[2] { username, password };
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5003/api/Movie/login", stringContent);
            String result = response.Content.ReadAsStringAsync().Result;
            var deserialised = JsonConvert.DeserializeObject<string>(result);
            Console.WriteLine(result);
            Console.WriteLine("Printing out login result: "+deserialised);
            return deserialised;
        }

        public async Task<String> POSTBookingData(String username, String title, String hour, String date)
        {
            String[] message = new String[4] { username, title, date, hour };
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5003/api/Movie/booking", stringContent);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

    }
}
