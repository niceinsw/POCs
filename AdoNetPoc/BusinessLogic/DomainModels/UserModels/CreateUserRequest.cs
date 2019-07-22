using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DomainModels.UserModels
{
    public class CreateUserRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }        
    }
}
