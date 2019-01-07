using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShirtAPI.DB.DTOModels;

namespace ShirtAPI.DB.Models
{
    public class OrderDTO
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public string Email { get; set; }
        public string Message { get; set; }
        public List<SelectedClothesDTO> ClothesList { get; set; }
    }
}
