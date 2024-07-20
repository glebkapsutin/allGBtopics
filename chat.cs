using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Chat
{
    private UdpClient ucl;
    public Chat(string ip,int port)
    {
        this.ucl = new UdpClient(ip, port);
        ucl.Connect(ip,port);
    }
    public static void Server()
    {
        IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);
        UdpClient ucl = new UdpClient(12345);
        Console.WriteLine("Сервер ожидает сообщения от клиента");
        
        while (true)
        {
            try
            {
                byte[] data = ucl.Receive(ref localEP);
                string str1 = Encoding.UTF8.GetString(data);
                Message mes = Message.FromJson(str1);
                if (mes!= null)
                {
                    Console.WriteLine(mes);
                    string ackMessage = "Сообщение получено!";
                    byte[] ack = Encoding.UTF8.GetBytes(ackMessage);
                    ucl.Send(ack);

                }
            }
            catch (System.Exception e)
            {
                
                Console.WriteLine("" + e.Message);
            }
        }
       
    }
    public static void Client(string mes)
    {
        IPEndPoint localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        UdpClient ucl = new UdpClient();
        string nik = Console.ReadLine();
        while (true)
        {
            Console.WriteLine("Введите сообщение");
            string texxt = Console.ReadLine();
            if (string.IsNullOrEmpty(texxt))
            {
                break;
            }
            Message newMEss = new Message(nik,texxt);
            string js = newMEss.ToJson();
            byte[] bytes = Encoding.UTF8.GetBytes(js);
            ucl.Send(bytes,localEP);

            byte[] data = ucl.Receive(ref localEP);
            string ackMessage= Encoding.UTF8.GetString(data);
            Console.WriteLine("Сообщение получено");
        }
    }
}