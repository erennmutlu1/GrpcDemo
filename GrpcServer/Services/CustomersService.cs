using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcServer.Protos;
using Microsoft.Extensions.Logging;

namespace GrpcServer.Services
{
    public class CustomersService: Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId==1)
            {
                output.FirstName = "Erry";
                output.LastName = "Carlmicheal";
            }
            else if (request.UserId==2)
            {
                output.FirstName = "Alisch";
                output.LastName = "Happy";
               
            }
            else  
            {
                output.FirstName = "Aghella";
                output.LastName = "Barmen";
            }


            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(
            NewCustomerRequest request, 
            IServerStreamWriter<CustomerModel> responseStream, 
            ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName ="Harry",
                    LastName="Kewell",
                    EmailAddress = "harry@kewell.net",
                    Age = 41,
                    IsAlive = false

                },


                new CustomerModel
                {
                    FirstName ="Alzace",
                    LastName="Nightwalker",
                    EmailAddress = "alzace@nightwalker.com",
                    Age = 48,
                    IsAlive = true

                },


                new CustomerModel
                {
                    FirstName ="David",
                    LastName="Isaac",
                    EmailAddress = "david@isaac.me",
                    Age = 22,
                    IsAlive = false

                },

            };

            foreach (var cust in customers)
            {
                await Task.Delay(1000); //If you want take data by one by you can use delay function in there
                await responseStream.WriteAsync(cust);

            }












        }
    }
}
