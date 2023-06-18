namespace InterviewTask_20230617.Services
{
    public class Task3Service : ITask3Service
    {
        public string Task3Basic(char[] input, int ordering)
        {
            var output = OrderByAlgorithm(input, ordering);
            return new string(output);
        }

        private char[] OrderByAlgorithm(char[] input, int ordering)
        {
            List<char> initialCharList = input.ToList();
            List<char> outputCharList = new List<char>();
            ordering -= 1;
            int counter = 0;
            int startFromIndex = 0;

            while (initialCharList.Count > 0)
            {
                int selectedCharIndex = startFromIndex + ordering;
                while (selectedCharIndex >= initialCharList.Count)
                {
                    selectedCharIndex -= initialCharList.Count;
                }

                char selectedChar = initialCharList.ElementAt(selectedCharIndex);
                outputCharList.Add(selectedChar);
                initialCharList.RemoveAt(selectedCharIndex);
                startFromIndex = selectedCharIndex;

                counter++;
                if (counter == 3)
                {
                    outputCharList.Add('-');
                    counter = 0;
                }
            }
            return outputCharList.ToArray();
        }
    }
}
