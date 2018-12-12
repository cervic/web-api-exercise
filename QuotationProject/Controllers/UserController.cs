using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace QuotationProject.Controllers
{
    public class UserController : ApiController
    {
        private readonly Implementation implementation;
        public UserController()
        {
            implementation = new Implementation();
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<IHttpActionResult> GetUsers()
        {
            return Ok(await implementation.GetUsers());
        }

        [HttpPost]
        [Route("api/users")]
        public async Task<IHttpActionResult> Insert([FromBody] UserDto user)
        {
            return Ok(await implementation.InsertUser(user));
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public async Task<IHttpActionResult> Update([FromBody]UserDto userDto, int id)
        {
            userDto.id = id;
            return Ok(await implementation.UpdataUser(userDto));
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Ok(await implementation.DeleteUser(id));
        }
    }
}