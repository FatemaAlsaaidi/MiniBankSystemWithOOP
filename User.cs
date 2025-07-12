using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemWithOOP
{
    class User
    {
        
        // Fields with encapsulation
        public int AccountNumber { get; private set; }
        public string Name { get; private set; }
        public string NationalID { get; private set; }
        public double Balance { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public bool HasActiveLoan { get; private set; }
        public double LoanAmount { get; private set; }
        public double LoanInterestRate { get; private set; }
    }
}
