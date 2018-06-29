using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VetService.ClassLibary
{
    public class APIClient
    {
        public async Task<List<Owner>> GetOwners()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            HttpResponseMessage response = await client.GetAsync("ownerviews");

            var content = await response.Content.ReadAsStringAsync();

            List<Owner> OwnerList = JsonConvert.DeserializeObject<List<Owner>>(content);

            return OwnerList;
        }

        public async Task<List<Pet>> GetPets()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            HttpResponseMessage response = await client.GetAsync("petviews");

            var content = await response.Content.ReadAsStringAsync();

            List<Pet> PetList = JsonConvert.DeserializeObject<List<Pet>>(content);

            return PetList;
        }

        public async Task<List<Procedure>> GetProcedures()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            HttpResponseMessage response = await client.GetAsync("procedureviews");

            var content = await response.Content.ReadAsStringAsync();

            List<Procedure> ProcedureList = JsonConvert.DeserializeObject<List<Procedure>>(content);

            return ProcedureList;
        }

        public async Task<List<Treatment>> GetTreatments()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            HttpResponseMessage response = await client.GetAsync("treatmentviews");

            var content = await response.Content.ReadAsStringAsync();

            List<Treatment> TreatmentList = JsonConvert.DeserializeObject<List<Treatment>>(content);

            return TreatmentList;
        }

        public async Task CreateOwner(Owner pNewOwner)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            string newClientJSON = JsonConvert.SerializeObject(pNewOwner, Formatting.None);

            var content = new StringContent(newClientJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("owners", content);

        }

        public async Task<int> NextOwnerID()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            HttpResponseMessage response = await client.GetAsync("ownerviews");

            var content = await response.Content.ReadAsStringAsync();

            List<Owner> tourClients = JsonConvert.DeserializeObject<List<Owner>>(content);

            return tourClients.Max(o => o.OwnerID) + 1;
        }

        public async Task DeleteOwner(Owner pOwnerToDelete)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            string clientToDeleteJSON = JsonConvert.SerializeObject(pOwnerToDelete, Formatting.None);

            var content = new StringContent(clientToDeleteJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.DeleteAsync("owners/" + pOwnerToDelete.OwnerID);

        }
        public async Task UpdateOwner(Owner pOwnerToUpdate)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://vetserviceapi.azurewebsites.net/API/");

            string clientToUpdateJSON = JsonConvert.SerializeObject(pOwnerToUpdate, Formatting.None);

            var content = new StringContent(clientToUpdateJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("owners/" + pOwnerToUpdate.OwnerID, content);

        }
    }
}
