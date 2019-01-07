using Poseidon.Domain.Models.Base;
using ShirtAPI.DB.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtAPI.DB.DTOModels;

namespace ShirtAPI.DB.Models
{
    public class Order : EntityBase<int>, IEntity<int>
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Message { get; set; }
    }
}
