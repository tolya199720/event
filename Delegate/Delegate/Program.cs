using System;
using Delegate;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Delegate.generics;

namespace Delegate
{
    public delegate int MyDelegate(object obj, MyDelegate Step);
    internal class Program
    {
        public class Ping
        {
            // Оголошення події
            public event EventHandler PingEvent;

            // Метод для виклику події
            public void SendPing()
            {
                Console.WriteLine("Ping відправлений.");
                PingEvent?.Invoke(this, EventArgs.Empty);
            }

            // Метод для обробки події Pong
            public void OnPongReceived(object sender, EventArgs e)
            {
                Console.WriteLine("Ping отриманий Pong.");
                SendPing();
            }
        }
        public class Pong
        {
            // Оголошення події
            public event EventHandler PongEvent;

            // Метод для виклику події
            public void SendPong()
            {
                Console.WriteLine("Pong відправлений.");
                PongEvent?.Invoke(this, EventArgs.Empty);
            }

            // Метод для обробки події Ping
            public void OnPingReceived(object sender, EventArgs e)
            {
                Console.WriteLine("Pong отримав Ping.");
                SendPong();
            }
        }
        public delegate void myDelegate(object obj, myDelegate step);



        static void Main(string[] args)
        {
            NewGenerics gen = new NewGenerics();
            
        }


    }
}
