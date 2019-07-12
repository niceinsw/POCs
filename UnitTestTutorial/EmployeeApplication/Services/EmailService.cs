using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Constraints;

namespace EmployeeApplication.Services
{
    public interface IEmailService
    {
        bool SendEmail(string email);
    }
    public class EmailService : IEmailService
    {
        public bool SendEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
