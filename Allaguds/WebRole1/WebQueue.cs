using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types

namespace WebRole1
{
    public class WebQueue
    {
        public void sendMessage(String queueMessage)
        {
            // Retrieve storage account from connection string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("messagequeue");
            // Create the queue if it doesnt already exist
            queue.CreateIfNotExists();
            //take the parameters and create a message from them
            CloudQueueMessage message = new CloudQueueMessage(queueMessage);
            queue.AddMessage(message);


        }
        public String peekMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("responsequeue");

            CloudQueueMessage peekedMessage = queue.GetMessage();
            String message = "";
            if (peekedMessage != null)
            {
                message = peekedMessage.AsString;
                queue.DeleteMessage(peekedMessage);
            }



            //foreach (CloudQueueMessage message in queue.GetMessages(20, TimeSpan.FromMinutes(5)))
            //{
            //    // Process all messages in less than 5 minutes, deleting each message after processing.
            //    queue.DeleteMessage(message);
            //}

            return message;
        }

    }

}