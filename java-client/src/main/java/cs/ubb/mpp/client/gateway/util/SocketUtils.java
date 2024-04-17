package cs.ubb.mpp.client.gateway.util;

import java.io.*;
import java.net.Socket;
import java.nio.charset.StandardCharsets;

public class SocketUtils {
    public static String readString(Socket socket) {
        byte[] bytes = new byte[1024];
        StringBuilder data = new StringBuilder();
        try {
            InputStream inputStream = socket.getInputStream();
            while (true) {
                int numBytes = inputStream.read(bytes);
                if (numBytes == -1) {
                    break;
                }
                data.append(new String(bytes, 0, numBytes, StandardCharsets.US_ASCII));
                int eofIdx = data.indexOf("<EOF>");
                if (eofIdx > -1) {
                    data.delete(eofIdx, data.length());
                    break;
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return data.toString();
    }

    public static void writeString(Socket socket, String message) {
        try {
            OutputStream outputStream = socket.getOutputStream();
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(outputStream));
            writer.write(message);
            writer.write("<EOF>\n");
            writer.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
