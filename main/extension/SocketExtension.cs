using System.Net.Sockets;
using System.Text;

namespace main.extension
{
    public static class SocketExtension
    {
        public static string ReadString(this Socket socket)
        {
            byte[] bytes = new byte[1024];
            string data = "";

            while (true)
            {
                int numByte = socket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, numByte);
                int eofIdx = data.IndexOf("<EOF>");
                if (eofIdx > -1)
                {
                    data = data.Remove(eofIdx);
                    break;
                }
            }
            return data;
        }
                
        public static void WriteString(this Socket socket, string str)
        {
            socket.Send(Encoding.ASCII.GetBytes(str + "<EOF>"));
        }

        public static bool IsSocketAvailable(this Socket socket)
        {
            return !((socket.Poll(1000, SelectMode.SelectRead) && (socket.Available == 0)) || !socket.Connected);
        }
    }
}
