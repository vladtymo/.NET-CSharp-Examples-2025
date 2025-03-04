using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_events
{
    internal class Author
    {
        private Action<string> published;
        public event Action<string> Published // after publish
        {
            // [+=] - subscribe to the event
            add 
            {
                // additional logic
                published += value;
            }
            // [-=] - unsubscribe to the event
            remove 
            {
                // additional logics
                published -= value;
            }
        }

        public void Publish(string topic) 
        {
            // before

            Console.WriteLine($"Publishing the new article with topic: {topic}!");

            // after
            published?.Invoke(topic);
        }
    }
}
