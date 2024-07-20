using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class clientSocket
{

    static void Client()
    {
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(new IPEndPoint(IPAddress.Loopback,12345));
        string message= " sosi";
        byte[] messageBytes = Encoding.ASCII.GetBytes(message);
        clientSocket.Send(messageBytes);
        byte[] buffer = new byte[1024];
        int receivedBytes = clientSocket.Receive(buffer);
        string receivedMessage = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
        clientSocket.Close();


    }
}