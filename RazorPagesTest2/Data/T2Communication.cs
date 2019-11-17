using Newtonsoft.Json;
using RazorPagesTest2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace RazorPagesTest2.Data
{
    public class T2Communication
    {
        private TcpClient client;
        private String ip = "10.152.192.62";
        private int port = 4545;

        public List<Movie> NEW_MOVIES { get; set; }

        public T2Communication()
        {
            NEW_MOVIES = new List<Movie>();

        }

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





    }
}
