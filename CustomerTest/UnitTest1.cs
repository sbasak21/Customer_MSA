using CustomerMicroservice.Controllers;
using CustomerMicroservice.Models2;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace CustomerTest
{
    public class Tests
    {
        CustomerController customer;
        [SetUp]
        public void Setup()
        {
            customer = new CustomerController();
        }



        [TestCase(2)]
        public void GetCustomerDetails_When_ValidIdIsGiven(int id)
        {
            var result = customer.getCustomerDetails(id);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.OkObjectResult", result.ToString());
        }



        [TestCase(1)]
        public void GetCustomerDetails_When_InvalidIdIsGiven(int id)
        {
            var result = customer.getCustomerDetails(id);
            Assert.IsInstanceOf<BadRequestResult>(result);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.BadRequestResult", result.ToString());
        }
        [Test]
        public void CreateCustomer_When_ValidDataIsGiven()
        {
            var result = customer.createCustomer(new Customer()
            {
                Id = 4,
                Name = "New User",
                Address = "Tehatta",
                Dob = "26/08/1999",
                PanNo = "WXYZ1234"
            });
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.OkObjectResult", result.ToString());
        }
        [Test]
        public void CreateCustomer_When_InvalidDataIsGiven()
        {
            var result = customer.createCustomer(new Customer()
            {
                Id = 3,
                Name = "New User",
                Address = "Tehatta",
                Dob = "26/08/1999",
                PanNo = "WXYZ1234"
            });
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.BadRequestObjectResult", result.ToString());
        }
    }
}