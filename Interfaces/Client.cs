using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
    class Client : IEnumerable<Deposit> 
    {
        private Deposit[] deposits;
        public Client()
        {
            deposits = new Deposit[10];
        }
        public bool AddDeposit(Deposit depositToAdd)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if(deposits[i] == null)
                {
                    deposits[i] = depositToAdd;
                    return true;
                }
            }
            return false;
        }
        public decimal TotalIncome()
        {
            decimal sum = 0;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null)
                {
                    sum += deposits[i].Income();
                }
            }
            return sum;
        }
        public decimal MaxIncome()
        {
            decimal max = 0;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null && deposits[i].Income() > max)
                {
                    max = deposits[i].Income();
                }
            }
            return max;
        }
        public decimal GetIncomeByNumber(int number)
        {
            if (deposits[number] != null)
            {
                return deposits[number -1].Income();
            }
            else return 0;
        }
        public void SortDeposits()
        {
            System.Array.Sort(deposits);
            System.Array.Reverse(deposits);
        }
        public int CountPossibleToProlongDeposit()
        { 
            int result = 0;
            foreach (var item in deposits)
            {
                if (item is IProlongable p && p.CanToProlong()) result++;
            }
            /*for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null && (deposits[i] as IProlongable).CanToProlong() == true)
                result++;
            }*/
            return result;
        }
        public IEnumerator<Deposit> GetEnumerator()
        {
            return (IEnumerator<Deposit>)deposits.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return deposits.GetEnumerator();
        }
    }
} 