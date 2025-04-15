using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //Step 1: Event Data Class - holds the event data 
    public class PubSubEventArgs: EventArgs
    {
        public string Message { get; set; }
        public int Number { get; set; }
        public PubSubEventArgs(string message, int number)
        {
            Message = message;
            Number = number;
        }
    }
    //Step 2: Declare the Delegate 
    public delegate void PubSubEventHandler(object sender, PubSubEventArgs e);

    //Step 3: Publisher class which raises the notifications 
    public class Publisher
    {
        //Step 3.1: Partial instantiation of the delegate 
        public PubSubEventHandler PubSubEvent;
        //Step 3.2: Method to raise the event 
        protected virtual void OnPubSubEvent(string message, int number)
        {
            //Step 3.3: Create an instance of the event data class
            PubSubEventArgs e = new PubSubEventArgs(message, number);
            //Step 3.4 Check if there are any subscriptions
            if (PubSubEvent != null)
            {
                //Step 3.5: Invoke the delegate 
                PubSubEvent.Invoke(this, e); 
            }
        }
        //Step 3.6: Method to trigger notifications
        public void TriggerNotifications()
        {
            for (int i = 0; i < 10; i++)
            {
                if(i == 5 || i==6)
                {
                    //Step 3.7: Call the method to raise the event 
                    OnPubSubEvent($"Threshold reached", i);
                }
            }
        }
    }
    //Step 4: Subscriber class which subscribes to the notifications
    public class Subscriber
    {
        //Step 4.1: Method to handle the event which matches the delegate singature 
        public void HandleNotifications(object sender, PubSubEventArgs e)
        {
            Console.WriteLine($"Received notification: {e.Message} with number: {e.Number}");
        }
    }

    internal class DelegateEvents
    {
        internal static void Test()
        {
            //Step 5: Create an instance of the publisher
            Publisher publisher = new Publisher();

            //Step 6: Create an instance of the subscriber
            Subscriber subscriber = new Subscriber();
            
            //Step 7: Subscribe to the event 
            publisher.PubSubEvent += new PubSubEventHandler(subscriber.HandleNotifications);
            
            //Step 8: Trigger notifications
            publisher.TriggerNotifications();
            
        }
    }
}
