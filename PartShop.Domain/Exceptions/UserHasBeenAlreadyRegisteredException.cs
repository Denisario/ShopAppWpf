using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Exceptions
{
    public class UserHasBeenAlreadyRegisteredException:Exception
    {
        public UserHasBeenAlreadyRegisteredException(string message) : base(message)
        {

        }
    }
}
