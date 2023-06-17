using System.Net;
using System.Web.Http;

namespace InterviewTask_20230617.Services
{
    public class Task1Service : ITask1Service
    {
        public double CalculateMonthlyRepayment(double principalAmount, int loanPeriodInYear, bool isAdvance = false)
        {
            if (principalAmount < 5000)
            {
                throw new Exception("The minimum amount for loan is RM 5000");
            }

            double interestRate = GetInterestRate(principalAmount, isAdvance);
            double monthlyInterstRate = GetMonthlyInterestRate(interestRate);
            int noOfPayments = GetNoOfPayments(loanPeriodInYear);
            double output = principalAmount * monthlyInterstRate * Math.Pow(1 + monthlyInterstRate, noOfPayments) / 
                (Math.Pow(1 + monthlyInterstRate, noOfPayments) - 1);
            return Math.Round(output, 2, MidpointRounding.AwayFromZero);
        }

        private double GetInterestRate(double principalAmount, bool isAdvance = false)
        {
            double interestRate = 0;
            if (principalAmount >= 5000 && principalAmount <= 20000)
                interestRate = 8;
            else if (principalAmount > 20000 && principalAmount <= 50000)
                interestRate = 7;
            else if (principalAmount > 50000 && principalAmount <= 100000)
                interestRate = 6.50;
            else if (principalAmount > 50000 && isAdvance)                  //for advance questions
                interestRate = 6.50;
            return interestRate;
        }

        private int GetNoOfPayments(int loanPeriodInYear)
        {
            //12 payments per year
            return loanPeriodInYear * 12;
        }

        private double GetMonthlyInterestRate(double interestRate)
        {
            return interestRate / 100 / 12;
        }
    }
}
