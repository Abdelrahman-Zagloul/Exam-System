using Exam_System.Helper;

namespace Exam_System.Model
{
    public class MCQQuestion : Question
    {
        public override string Header { get; set; }
        public override string Body { get; set; }
        public override double Mark { get; set; }

        public override void ShowQuestion()
        {
            ConsoleHelper.PrintMessage(ToString());
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].AnswerText}");
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()} [MCQ Question] ";
        }
    }
}
