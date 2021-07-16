using System;

namespace Interfaces
{
    class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal depositAmount, int depositPeriod)
        : base(depositAmount, depositPeriod)
        {

        }
        override public decimal Income()
        {
            const int YearPercent = 60;
            if (Period == 0)
            {
                return 0;
            }
            return Math.Floor((Amount * (decimal)System.Math.Pow((1 + (double)YearPercent / 1200), Period) - Amount) * 100) / 100;
        }

    }
}