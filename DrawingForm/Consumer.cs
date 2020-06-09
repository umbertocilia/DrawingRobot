using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace WebSocketTools
{

    class Consumer
    {
        bool abort = false;
        Queue<double[]> queue;
        Object lockObject;
        WebSocketSharp.WebSocket ws;
        public Consumer(Queue<double[]> queue, Object lockObject, WebSocketSharp.WebSocket ws)
        {
            this.queue = queue;
            this.lockObject = lockObject;
            this.ws = ws;
        }

        public void consume()
        {
            ws.Connect();
            while (!abort)
            {
                lock (lockObject)
                {
                    if (queue.Count == 0)
                    {
                        continue;
                    }

                    SendDot(queue.Dequeue(), ws);

                    Thread.Sleep(30);
                }
                
            }
        }

        public void SendDot(double[] dot, WebSocket ws)
        {

            if (dot != null)
            {
                string result = "#" + dot[0].ToString() + "#" + dot[1].ToString();
                ws.Send(result);
            }
        }

        public void Stop()
        {
            abort = true;
        }
    }
}

