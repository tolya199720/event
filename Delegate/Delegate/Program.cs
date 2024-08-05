using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            Ping ping1 = new Ping();
            Pong pong1 = new Pong();

            // Підписка об'єктів на події
            ping1.PingEvent += pong1.OnPingReceived;
            pong1.PongEvent += ping1.OnPongReceived;

            // Запуск гри для першої пари
            ping1.SendPing();

            Console.WriteLine();



        }


    }
}

//using System;

//public class Publisher
//{
//    public event EventHandler SomethingHappened;

//    public void RaiseEvent()
//    {
//        SomethingHappened?.Invoke(this, EventArgs.Empty);
//    }
//}

//public class Subscriber
//{
//    public void OnSomethingHappened(object sender, EventArgs e)
//    {
//        Console.WriteLine("worck!");
//    }
//}



//class Program
//{
//    static void Main()
//    {
//        Publisher publisher = new Publisher();
//        Subscriber subscriber = new Subscriber();

//        publisher.SomethingHappened += subscriber.OnSomethingHappened;
//        publisher.RaiseEvent();

//        publisher.SomethingHappened -= subscriber.OnSomethingHappened;
//        publisher.RaiseEvent();
//    }
//}