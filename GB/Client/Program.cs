using Network;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static UdpClient udpClient = new UdpClient();
        static IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                SentMessage("Artem", i);
            }
            Console.ReadLine();

        }


        public static void SentMessage(string From, int i, string ip = "127.0.0.1")
        {

         




        }
        public static void m1()
        {
            Message message = new Message() { Text = "ПРивет", NicknameFrom = "Artem", NicknameTo = "Server", DateTime = DateTime.Now, command = Commands.Register };
            string json = message.SerializeMessageToJson();

            byte[] data = Encoding.UTF8.GetBytes(json);
            udpClient.Send(data, data.Length, iPEndPoint);
        }
        public static void m2()
        {
            Message message = new Message() { Text = "ПРивет", NicknameFrom = "Vasa", NicknameTo = "Server", DateTime = DateTime.Now, command = Commands.Register };
            string json = message.SerializeMessageToJson();

            byte[] data = Encoding.UTF8.GetBytes(json);
            udpClient.Send(data, data.Length, iPEndPoint);
        }
        public static void m3()
        {
            Message message = new Message() { Text = "ПРивет", NicknameFrom = "Artem", NicknameTo = "Vasa", DateTime = DateTime.Now };
            string json = message.SerializeMessageToJson();

            byte[] data = Encoding.UTF8.GetBytes(json);
            udpClient.Send(data, data.Length, iPEndPoint);
        }
        public static void m4()
        {
            Message message = new Message() { Text = "ПРивет", NicknameFrom = "Artem", NicknameTo = "Server", DateTime = DateTime.Now, command = Commands.Delete };
            string json = message.SerializeMessageToJson();

            byte[] data = Encoding.UTF8.GetBytes(json);
            udpClient.Send(data, data.Length, iPEndPoint);
        }
    }
}