using System;
using System.Collections.Generic;
using System.Text;

namespace DeFabriek
{
    class ACME
    {
        private List<IContract> employees = new List<IContract>();

        public void Hire(IContract emp)
        {
            employees.Add(emp);
        }

        public void StoomFluit()
        {
            Console.WriteLine("ACME gaat produceren");
            foreach (IContract employee in employees)
            {
                employee?.VoerUit();
            }
        }
    }
}
