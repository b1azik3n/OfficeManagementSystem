﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public abstract class BaseActor:BaseDetailed        
    {
        [Required]
        public string Name { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }
}
