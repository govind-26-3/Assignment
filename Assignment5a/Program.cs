using Assignment5a.Model;
using Assignment5a.Repository;

namespace Assignment5a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IbankRepo bankRepo = new BankRepository();

            List<Bank> allAccounts = bankRepo.GetAllAccounts();

            foreach (Bank bank in allAccounts)
            {
                Console.WriteLine($"Bank Account Number::{bank.AccountNumber}        Account Holder Name::{bank.AccountName}");

            }

            Bank account3 = new Bank()
            {
                AccountNumber = 12345698765,
                AccountName = "Babu Rao"
            };
            bool result = bankRepo.AddAccount(account3);
            if (result)
            {
                Console.WriteLine("Account Details Added Succesfully!!");
            }


        }
    }
}
