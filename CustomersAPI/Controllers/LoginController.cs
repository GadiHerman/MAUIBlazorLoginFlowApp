using Microsoft.AspNetCore.Mvc;
using DataClassLibrary;
using System.Collections.Generic;
using System.Reflection;

namespace CustomersAPI.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class LoginController : ControllerBase
    {
        private static List<Customer> CustomerList = new List<Customer>
        {
            new Customer { Name = "gadi", Id = 1, Age = 17, Password="1234" },
            new Customer { Name = "tal", Id = 2, Age = 17, Password="1234" },
            new Customer { Name = "ran", Id = 3, Age = 17, Password="1234" }
        };
        private static int masterID = 4;

        [HttpGet]
        [ActionName("GetAllCustomer")]
        public List<Customer> Get()
        {
            return CustomerList;
        }

        // POST api/<ToDoListController>
        [HttpPost]
        [ActionName("AddNewCustomer")]
        public void Post1([FromBody] Customer item)
        {
            item.Id = masterID;
            masterID++;
            CustomerList.Add(item);
        }

        // POST api/<ToDoListController>
        [HttpPost]
        [ActionName("Login")]
        public async Task<ActionResult<Customer>> Post2([FromBody] Customer item)
        {
            if (item is null) return BadRequest();
            Customer getCustomer = CustomerList.Find(x => x.Name == item.Name);
            if (getCustomer == null)
            {
                return BadRequest("User not found");
            }
            if (getCustomer.Password == item.Password)
            {
                return Ok(getCustomer);
            }
            return BadRequest("Invalid password");
        }
    }
}
