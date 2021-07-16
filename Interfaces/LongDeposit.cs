namespace Interfaces
{
    class LongDeposit : Deposit, IProlongable
    {
        public LongDeposit(decimal depositAmount, int depositPeriod)
        : base(depositAmount, depositPeriod)
        {

        }
        override public decimal Income()
        {
            decimal sum = 0;
            decimal PreviosMonthSum = 0;
            const decimal MonthPercent = 15;
            if (Period == 7)
            {
                PreviosMonthSum = Amount * (decimal)((double)MonthPercent / 100);
                sum += PreviosMonthSum;
            }
            else if (Period > 7)
            {
                for (int i = 7; i <= Period; i++)
                {
                    sum += (PreviosMonthSum + Amount) * (decimal)((double)MonthPercent / 100);
                    PreviosMonthSum = sum;
                }
            }
            else return 0;
            return System.Math.Floor(sum * 100) / 100;
        }
        public bool CanToProlong()
        {
            if(Period < 36)
            {
                return true;
            }
            else return false;
        }
    }
}