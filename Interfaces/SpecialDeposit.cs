namespace Interfaces
{
    class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal depositAmount, int depositPeriod)
        : base(depositAmount, depositPeriod)
        {

        }
        override public decimal Income()
        {
            decimal sum = 0;
            decimal PreviosMonthSum = 0;
            for (int i = 1; i <= Period; i++)
            {
                if (i == 1)
                {
                    sum += Amount * i / 100;
                    PreviosMonthSum = sum;
                }
                else if (i > 1)
                {
                    sum += (PreviosMonthSum + Amount) * i / 100;
                    PreviosMonthSum = sum;
                }
            }
            return System.Math.Floor(sum * 100) / 100;
        }
        public bool CanToProlong()
        {
            if (Amount > 1000)
            {
                return true;
            }
            else return false;
        }
    }
}