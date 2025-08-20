namespace Exam_System.Helper
{
    public static class ValidationHelper
    {
        public static int GetValidateNumber(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                bool isValid = int.TryParse(Console.ReadLine(), out int result);

                if (isValid && result >= min && result <= max)
                    return result;
                else
                {
                    ConsoleHelper.PrintMessage($"\ninvalid input ,input must be number and  between {min} and {max}", false);
                    ConsoleHelper.PressEnterToContinue();
                }
            }
        }

        public static string GetValidString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string result = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(result))
                    return result;


                ConsoleHelper.PrintMessage("Invalid Input.String Can't be null or empty,try again", false);
            }
        }
    }
}

