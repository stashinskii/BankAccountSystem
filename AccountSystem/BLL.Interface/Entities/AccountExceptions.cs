using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Base exception for common troubles with Account
    /// </summary>
    public class AccountException : Exception
    {
        public AccountException(string message)
            : base(String.Format("Some troubles while working with Account: {0}", message)) { }
    }

    /// <summary>
    /// Exception for troubles while working with Account's operations
    /// </summary>
    public class InvalidAccountOperationException : AccountException
    {
        public InvalidAccountOperationException(string message)
            : base(String.Format("Invalid operation with account: {0}", message)) { }
    }
}
