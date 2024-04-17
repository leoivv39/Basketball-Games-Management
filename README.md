# Basketball-Games-Management

A C#/.NET desktop application for managing ticket sales for a basketball competition. 

The system consists of two modules: a server responsible for data persistence and client communication, and a client module with a GUI for displaying match details and selling tickets. Staff members can log in to their accounts to access the system. The server and client communicate at a low level via sockets using the TCP protocol. The server also supports event notification, informing clients of ticket sales in real-time. Development adhered to best practices with a layered architecture, utilizing Windows Forms for the GUI and an SQLite database for data storage.
