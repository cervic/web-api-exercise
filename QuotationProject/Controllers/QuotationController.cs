using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuotationProject.Controllers
{
    public class QuotationController : ApiController
    {
        private readonly Implementation implementation;
        public QuotationController()
        {
            implementation = new Implementation();
        }

        [HttpGet]
        [Route("api/quotation/{currency}")]
        public async Task<IHttpActionResult> Get(string currency)
        {
            return Ok(await implementation.GetQuotation(currency));
        }
    }
}
