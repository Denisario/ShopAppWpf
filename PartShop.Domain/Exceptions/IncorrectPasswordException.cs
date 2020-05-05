using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Exceptions
{
    public class IncorrectPasswordException:Exception
    {
        public IncorrectPasswordException(string message):base(message)
        {
            
        }
    }
}
