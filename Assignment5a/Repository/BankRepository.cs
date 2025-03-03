using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5a.Exception;
using Assignment5a.Model;

namespace Assignment5a.Repository
{
    internal class BankRepository : IbankRepo
    {
        List<Bank> banks;

        public BankRepository()
        {
            banks = new List<Bank>(){
                new Bank()
            {AccountNumber = 12345698765,AccountName="raju"},
                new Bank()
            {AccountNumber = 98765432179,AccountName="Shaam"},

             };
        }



        public bool AddAccount(Bank bankAcc)
        {
            try
            {


                Bank searchRes = GetBankAccountNumber(bankAcc.AccountNumber);

                if (searchRes == null)
                {
                    
                    banks.Add(bankAcc);
                    return true;
                }
                else
                {
                    throw new BankAccExists($"Account:{bankAcc.AccountNumber} already exists!!!");
                }
            }
            catch (BankAccExists ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<Bank> GetAllAccounts()
        {
            return banks;
        }

        public Bank GetBankAccountNumber(long bankAccountNumber)
        {
            return banks.Find(p => p.AccountNumber == bankAccountNumber);
        }


    }
}
