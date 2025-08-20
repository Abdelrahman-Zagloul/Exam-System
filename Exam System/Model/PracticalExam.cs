using Exam_System.Helper;

namespace Exam_System.Model
{
    public class PracticalExam : Exam
    {
        public override TimeSpan TimeOfExam { get; set; }
        public override int NumberOFQuestion { get; set; }

        public override void ShowExam()
        {
            Console.WriteLine("=============================== Practical Exam ===============================\n");
            foreach (var question in Questions)
            {
                question.ShowQuestion();
                Console.WriteLine("\n---------------------------------------\n");
            }
        }

        public void ShowCorrectAnswers()
        {
            ConsoleHelper.PrintHeader("Correct Answers");
            foreach (var question in Questions)
            {
                Console.WriteLine($"{question.ToString()}");
                ConsoleHelper.PrintMessage($"Correct Answer: {question.CorrectAnswer.ToString()}\n");
            }
        }

    }
}
