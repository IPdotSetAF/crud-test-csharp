﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Customer
{
    public class CustomerCreateDTO : CustomerUpdateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="First name is required.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage ="Email is not valid.")]
        public string Email { get; set; }
    }
}
