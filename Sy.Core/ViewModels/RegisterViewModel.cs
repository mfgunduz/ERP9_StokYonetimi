﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sy.Core.ViewModels
{
    public class RegisterViewModel
    {
        private string _email;
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string SurName { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }
        [Required, StringLength(50)]
        public string Email
        {
            get { return _email; }
            set { _email = value.ToLower(); }
        }
    }
}
