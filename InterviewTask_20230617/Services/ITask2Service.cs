using InterviewTask_20230617.Models;

namespace InterviewTask_20230617.Services
{
    public interface ITask2Service
    {
        public Task2BasicDTO GetReferenceNumber(string input);
        public List<Task2AdvanceDTO> FindDistribution(int stringSize, int sampleSize);
    }
}
