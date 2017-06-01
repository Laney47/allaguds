using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                WorkerQueue q = new WorkerQueue();
                // TODO: Replace the following with your own logic.
                while (!cancellationToken.IsCancellationRequested)
                {
                    String peekedMessage = q.peekMessage();

                    if (peekedMessage != null)
                    {
                        Trace.TraceInformation(peekedMessage);
                        Trace.TraceInformation(peekedMessage);

                        ApiConnector ApiC = new ApiConnector();
                        char delimitor = '*';
                        String[] substrings = peekedMessage.Split(delimitor);
                        //we splitstring to seperate the command ([0]) from the message body
                        if (substrings[0].Equals("validateinfo"))
                        {
                            

                            ApiC.validateLogin(substrings[1]);

                            Trace.TraceInformation("Validate the credentials: " + substrings[1]);
                            //Validate the info return message in queue
                            //q.sendMessage();
                        }
                        else if (substrings[0].Equals("getLocation"))
                        {

                            ApiC.GetLocationDataForUser(substrings[1]);

                            Trace.TraceInformation("get location for :" + substrings[1]);
                            //use the parameters in the other substring to get correct info and return it
                            //q.sendMessage();
                        }
                        else if (substrings[0].Equals("getAccel"))
                        {

                            ApiC.GetAccelDataForUser(substrings[1]);

                            Trace.TraceInformation("get accel data for :" + substrings[1]);
                        }
                        else if (substrings[0].Equals("getHeartRate"))
                        {
                            ApiC.GetHeartRateDataForUser(substrings[1]);

                            Trace.TraceInformation("get heartrate info for :" + substrings[1]);
                        }

                    }

                    Trace.TraceInformation("Working");
                    await Task.Delay(1000);
                }
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.StackTrace);
            }
        }
    }
}
