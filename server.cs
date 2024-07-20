using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void serv()
    {
        // Создаем сокет
        Socket serversocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        serversocket.Bind(new IPEndPoint(IPAddress.Any,12345));
        serversocket.Listen(10);
        Socket clientSocket =serversocket.Accept();
        byte[] data = new byte[1024];
        int receivedBytes = clientSocket.Receive(data);
        string responseMessage = "hello";
        byte[] responseBytes = Encoding.UTF8.GetBytes(responseMessage);
        clientSocket.Send(responseBytes);
        clientSocket.Close();
        serversocket.Close();


    }
}