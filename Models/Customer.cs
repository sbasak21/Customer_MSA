using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerMicroservice.Models2
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Dob { get; set; }
        public string PanNo { get; set; }
    }
}
