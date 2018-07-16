namespace BankAccount
{
    /// <summary>
    /// Represents basic operations for implementation for account classes 
    /// </summary>
    interface IAccount
    {
        /// <summary>
        /// Represents income operation
        /// </summary>
        /// <param name="amount">Amount of money</param>
        void Income(int amount);

        /// <summary>
        /// Represents outcome operation
        /// </summary>
        /// <param name="amount">Amount of money</param>
        void Outcome(int amount);

        /// <summary>
        /// Represents operation of closing an account
        /// </summary>
        void CloseAccount();
    }
}
