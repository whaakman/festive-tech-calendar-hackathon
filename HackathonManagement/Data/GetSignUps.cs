using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HackathonManagement
{
    public class GetSignUps
    {
        public async Task<List<SignupModel>> GetSignUpsFromFunction()
        {
        string azureFunctionAddress = Environment.GetEnvironmentVariable("AzureFunctionAddress");
        HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(azureFunctionAddress);

        var signups = JsonConvert.DeserializeObject<List<SignupModel>>(
            await response.Content.ReadAsStringAsync());
            return signups;
        }
    }
}