namespace InterviewTask_20230617.Services
{
    public interface ITask1Service
    {
        public double CalculateMonthlyRepayment(double principalAmount, int loanPeriodInYear, bool isAdvance = false);
    }
}
