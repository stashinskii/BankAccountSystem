using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class InvalidAccountOperationException: Exception
    {
        public InvalidAccountOperationException(string message)
            : base(String.Format("Invalid operation with account: {0}", message)){}
    }
}
