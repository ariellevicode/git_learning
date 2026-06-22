using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace project_learn
{
    internal class CellcomServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is starting...");

            SerialPort serverPort = new SerialPort("COM3", 9600);
            serverPort.NewLine = "\r";
            List<SerialPort> activePorts = new List<SerialPort>();
            for (int i = 0; i < 10; i++)
            {
                // נייצר שמות פורטים: COM10, COM11, COM12 ... עד COM19
                string portName = "COM" + (10 + i);

                try
                {
                    SerialPort port = new SerialPort(portName, 9600);
                    port.NewLine = "\r";
                    port.Open();

                    activePorts.Add(port);
                    Console.WriteLine($"[+] Listening on {portName}");

                    // כאן הקסם: אנחנו שולחים Task נפרד שירוץ ברקע עבור הפורט הזה ספציפית!
                    Task.Run(() => ListenToClient(port));
                }
                catch (Exception ex)
                {
                    // אם הפורט לא קיים (כי עוד לא יצרת אותו ב-com0com), נדפיס שגיאה קטנה ונמשיך הלאה
                    Console.WriteLine($"[-] Could not open {portName}: {ex.Message}");
                }
            }
            Console.WriteLine("\nServer is fully operational! Waiting for messages...");
            Console.ReadLine();




        }
        public static void ListenToClient(SerialPort port)
        {
            
        }
    }
}
