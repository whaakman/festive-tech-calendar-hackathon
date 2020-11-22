using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzFunctions
{
    public static class ProcessSignUps
    {
        [FunctionName("ProcessSignUps")]
        public static void Run(
            [QueueTrigger("signups", Connection = "storageAccountConnectionString")]string signupData, ILogger log,
            [CosmosDB("Hackathon", "SignUps", Id = "id", ConnectionStringSetting = "cosmosDBConnectionString")] out dynamic document)
        
        {
            List<SignupModel> signupsList = new List<SignupModel>();

            SignupModel signups = new SignupModel();
            signups = JsonConvert.DeserializeObject<SignupModel>(signupData);

            log.LogInformation(signupData);

             document = new { Name = signups.Name, 
             Email = signups.Email, 
             TwitterAccount = signups.TwitterAccount,
             SolutionURI = signups.SolutionUri,
             id = Guid.NewGuid() };
        }
    }
}
