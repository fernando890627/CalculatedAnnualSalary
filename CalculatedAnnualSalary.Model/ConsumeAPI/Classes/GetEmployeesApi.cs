using CalculatedAnnualSalary.Model.ConsumeAPI.Contracts;
using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CalculatedAnnualSalary.Model.ConsumeAPI.Classes
{
    public class GetEmployeesApi : IGetEmployeesApi
    {
        private const string apiUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";
        private IRestClient _client;
        public GetEmployeesApi(IRestClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client)); ;
        }
        public async Task<List<Employee>> GetEmployesList()
        {
            var request = new RestRequest(apiUrl, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            TaskCompletionSource<IRestResponse> completionSource = new TaskCompletionSource<IRestResponse>();

            _client.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    completionSource.TrySetException(response.ErrorException);
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    completionSource.TrySetResult(response);
                }

            });
            var ctResponse = await completionSource.Task;
            var empDto = JsonConvert.DeserializeObject<List<Employee>>(ctResponse.Content);
            return empDto;
        }

    }
}
