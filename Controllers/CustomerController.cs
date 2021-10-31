using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models2;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CustomerController : ControllerBase
    {
        // static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerController));
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){
                Id = 2,
                Name = "Shobhon Basak",
                Address = "Mayapur",
                Dob = "15/08/1947",
                PanNo = "ABCD1234"
            },
            new Customer(){
                Id = 3,
                Name = "Subhradwip Ghosh",
                Address = "Tehatta",
                Dob = "26/08/1999",
                PanNo = "WXYZ1234"
            },
        };

        public static List<CustomerCreationStatus> customerStatus = new List<CustomerCreationStatus>()
        {
            new CustomerCreationStatus(){
                Id = 2,
                Message = "Profile of Customer with customer id: 2 is created"
            },
        };


        [HttpGet]
        [Route("getCustomerDetails/{Id}")]
        public IActionResult getCustomerDetails(int Id)
        {
           // _log4net.Info("Get Customer Details is called with id:" + id);
            try
            {
                 var obj = customers.FirstOrDefault<Customer>(c => c.Id == Id);
                 if(obj == null)
                 {
                    return BadRequest();
                 }
                 return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest("Exception Occured");
            }
        }
        [HttpPost]
        [Route("createCustomer")]
        public IActionResult createCustomer([FromBody] Customer customer)
        {
            //_log4net.Info("Creation of customer is initiated");
            try
            {
                    if((customers.FirstOrDefault<Customer>(c => c.Id == customer.Id)) != null)
                    {
                        return BadRequest("Customer ID already exist!");
                    }
                    CustomerCreationStatus status = new CustomerCreationStatus();
                    if(customer != null)
                    {
                        customers.Add(customer);
                        status.Id = customer.Id;
                        status.Message = "Profile of Customer with customer id: " + status.Id + " is created";
                        //using(var client = new HttpClient())
                        //{

                        //}
                        return Ok(customer);
                    }
                    return BadRequest("Customer data is empty!");
                    //_log4net.Info("New Customer account is created");
            }
            catch (Exception)
            {
                return BadRequest("Exception Occured");
            }
        }
    }
}
