using InterviewTask_20230617.Models;
using System.Text;
using System;

namespace InterviewTask_20230617.Services
{
    public class Task2Service : ITask2Service
    {
        public Task2BasicDTO GetReferenceNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("Please enter input.");

            string specialValue = GetSpecialDigit(input);
            return new Task2BasicDTO(specialValue, input + specialValue);
        }

        public List<Task2AdvanceDTO> FindDistribution(int stringSize, int sampleSize)
        {
            List<string> outputList = new List<string>();
            for (int i = 0; i <= sampleSize; i++)
            {
                var rngString = RandomString(stringSize);
                outputList.Add(GetSpecialDigit(rngString));
            }

            return outputList.GroupBy(x => x).Select(g => new Task2AdvanceDTO { Key = g.Key, Count = g.Count() }).OrderByDescending(x => x.Count).ToList();
        }

        private string GetSpecialDigit(string input)
        {
            var tupleList = new List<Tuple<string, int>>();
            IDictionary<string, int> numberNames = new Dictionary<string, int>();
            var inputArray = input.ToCharArray();
            for (int i = 0; i < inputArray.Length; i++)
            {
                if ((i + 1) % 5 == 0)
                {
                    tupleList.Add(new Tuple<string, int>("E", Int32.Parse(inputArray[i].ToString()) * 2));
                }
                else if ((i + 1) % 4 == 0)
                {
                    tupleList.Add(new Tuple<string, int>("D", Int32.Parse(inputArray[i].ToString()) * 4));
                }
                else if ((i + 1) % 3 == 0)
                {
                    tupleList.Add(new Tuple<string, int>("C", Int32.Parse(inputArray[i].ToString()) * 6));
                }
                else if ((i + 1) % 2 == 0)
                {
                    tupleList.Add(new Tuple<string, int>("B", Int32.Parse(inputArray[i].ToString()) * 8));
                }
                else if ((i + 1) % 1 == 0)
                {
                    tupleList.Add(new Tuple<string, int>("A", Int32.Parse(inputArray[i].ToString()) * 10));
                }
            }

            int sumOfGeneratedValues = 0;
            foreach (var tupleKey in tupleList.Select(x => x.Item1).Distinct().ToList())
            {
                if (tupleList.Any(x => x.Item1 == tupleKey))
                    sumOfGeneratedValues += tupleList.Where(x => x.Item1 == tupleKey).Sum(x => x.Item2);
            }

            var sumOfGeneratedValuesString = sumOfGeneratedValues.ToString();
            int specialValue = 0;
            foreach (var value in sumOfGeneratedValuesString.ToCharArray())
            {
                specialValue += Int32.Parse(value.ToString());
            }
            return specialValue.ToString();
        }

        private string RandomString(int size)
        {
            var builder = new StringBuilder(size);

            Random rng = new Random();
            for (var i = 0; i < size; i++)
            {
                builder.Append(rng.Next(1, 10).ToString());
            }

            return builder.ToString();
        }
    }
}
