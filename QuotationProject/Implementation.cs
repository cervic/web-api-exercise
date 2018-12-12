using DataAccess.Dto;
namespace QuotationProject
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Models;
    using DataAccess.Querys;

    public class Implementation
    {
        private readonly IDictionary<string, Func<Task<string>>> currencyStrategy;
        private readonly UserDataAccess userDataAccess;

        public Implementation()
        {
            userDataAccess = new UserDataAccess();
            currencyStrategy = new Dictionary<string, Func<Task<string>>>
            {
                { CurrencyType.Peso, GetQuotationPesos },
                { CurrencyType.Real, GetQuotationReales },
                { CurrencyType.Dollar, GetQuotationDollars }
            };
        }

        private async Task<string> GetQuotationPesos()
        {
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private async Task<string> GetQuotationDollars()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(new Uri("http://www.bancoprovincia.com.ar/Principal/Dolar"));
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetQuotationReales()
        {
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public async Task<string> GetQuotation(string currencyType)
        {
            return await currencyStrategy[currencyType]();
        }

        public async Task<string> InsertUser(UserDto userDto)
        {
            return userDataAccess.Insert(userDto);
        }

        public async Task<string> UpdataUser(UserDto userDto)
        {
            return userDataAccess.Update(userDto);
        }

        public async Task<string> DeleteUser(int id)
        {
            return userDataAccess.Delete(id);
        }

        public async Task<IList<UserDto>> GetUsers()
        {
            return userDataAccess.GetAllUsers();
        }
    }
}