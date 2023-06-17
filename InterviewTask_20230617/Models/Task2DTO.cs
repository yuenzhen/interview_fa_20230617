namespace InterviewTask_20230617.Models
{
    public class Task2BasicDTO
    {
        public string SpecialDigit { get; set; }
        public string GeneratedRefNo { get; set; }

        public Task2BasicDTO (string specialDigit, string generatedRefNo)
        {
            SpecialDigit = specialDigit;
            GeneratedRefNo = generatedRefNo;
        }
    }

    public class Task2AdvanceDTO
    {
        public string Key { get; set; }
        public int Count { get; set; }
    }
}
