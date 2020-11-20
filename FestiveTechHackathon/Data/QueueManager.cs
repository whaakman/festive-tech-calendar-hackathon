using System; // Namespace for Console output
using System.Configuration; // Namespace for ConfigurationManager
using System.Threading.Tasks; // Namespace for Task
using Azure.Storage.Queues; // Namespace for Queue storage types
using Azure.Storage.Queues.Models; // Namespace for PeekedMessage
using Newtonsoft.Json;
namespace FestiveTechHackathon.Data
{
    public class QueueManager
    {
        string connectionString = Environment.GetEnvironmentVariable("storageAccountConnectionString");
        string queueName = Environment.GetEnvironmentVariable("storageQueue");
        private static string Base64Encode(string plainText)
        {
            // Convert to Base64 As this is what Azure Queues require
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public void InsertMessage(SignupModel signup)
        {           
            // Create Queue Client for interaction with Storage Accounts queues
           QueueClient queueClient = new QueueClient(connectionString, queueName);
          
          if (queueClient.Exists())
            {
                string messageJson;
                messageJson = JsonConvert.SerializeObject(signup);
                var message = Base64Encode(messageJson);
                // Send a message to the queue
                queueClient.SendMessage(message);
            }
        }
    }

    
}