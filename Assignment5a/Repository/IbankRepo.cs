using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5a.Model;

namespace Assignment5a.Repository
{
    internal interface IbankRepo
    {
        Bank GetBankAccountNumber(long bankAccountNumber);
        bool AddAccount(Bank account);
        List<Bank> GetAllAccounts();
    }
}
