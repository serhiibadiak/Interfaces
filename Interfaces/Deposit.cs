namespace Interfaces
{
    abstract class Deposit : System.IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }
        public Deposit(decimal depositAmount, int depositPeriod)
        {
            this.Amount = depositAmount;
            this.Period = depositPeriod;
        }
        abstract public decimal Income();
        public int CompareTo(Deposit other)
        {
            if (other != null)
            {
                return (Amount + Income()).CompareTo(other.Amount + other.Income());
            }
            else
                throw new System.Exception("Unable to compare");
        }
    }
}