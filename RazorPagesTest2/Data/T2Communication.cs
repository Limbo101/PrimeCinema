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

        /*
        public void startClient(String date)
        {
            
            client = new TcpClient(ip, port);
            Console.WriteLine("Client connected!");

            //sending
            Console.WriteLine("Sending date!");
            NetworkStream stream = client.GetStream();
            byte[] sendBytes = Encoding.UTF8.GetBytes(date);
            stream.Write(sendBytes, 0, sendBytes.Length);
            Console.WriteLine("Date has been sent!");
           
            // receiving
            byte[] buffer = new Byte[2048];
            
            int readBytes = client.GetStream().Read(buffer, 0, buffer.Length);
            string receivedJsonString = Encoding.UTF8.GetString(buffer, 0, readBytes);
            //readBytes.ToString();

            Console.WriteLine(receivedJsonString);

            // NEW_MOVIES = 
            List<Movie> NEW_MOVIES = JsonConvert.DeserializeObject<List<Movie>>(receivedJsonString);
            
            for(int i=0;i<NEW_MOVIES.Count;i++)
            {
                Console.WriteLine(NEW_MOVIES[i].title);
            }

            //client.Close();
            client.GetStream().Close();
            Console.WriteLine("Client terminated.");
            

        }

    */



        public async Task<String> getData()
        {
            Console.WriteLine("Creating client!");
            HttpClient client = new HttpClient();
            Console.WriteLine("Client created! Sending request!");  
            String response = await client.GetStringAsync("https://localhost:44307/api/Movie");

            return response;
        }

        public async Task<String> POSTRegistrationData(String userName, String password, String confirmPassword, String email)
        {
            String[] message = new String[4] { userName, password, confirmPassword , email };
            //String message = userName;
        Console.WriteLine("Creating client!");
            HttpClient client = new HttpClient();
            Console.WriteLine("Sending registration data!");
            //StringContent stringContent = new StringContent(JsonConvert.SerializeObject(message));
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            
            Console.WriteLine("Json serialized  content:"    +   JsonConvert.SerializeObject(message));
        
            Console.WriteLine("String   content printed out!!   (JSON)");
            var response = await client.PostAsync("https://localhost:5003/api/Movie", stringContent);
            Console.WriteLine("Works");
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Works");
            Console.WriteLine("Works");
            Console.WriteLine(result);
            return result;
        }


    }
}
