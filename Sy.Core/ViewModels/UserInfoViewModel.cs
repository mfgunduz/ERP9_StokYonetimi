using Sy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sy.Core.ViewModels
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
        public string Display => $"{Name} {SurName} - {ApplicationRole}";
        
    }
}
