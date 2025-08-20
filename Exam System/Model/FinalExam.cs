using Exam_System.Helper;
using Exam_System.Service;

namespace Exam_System.Model
{
    public class FinalExam : Exam
    {
        public override TimeSpan TimeOfExam { get; set; }
        public override int NumberOFQuestion { get; set; }

        public override void ShowExam()
        {
            Console.WriteLine("=============================== Final Exam ===============================\n");
            foreach (var question in Questions)
            {
                question.ShowQuestion();
                Console.WriteLine();
            }
        }
        public void ShowExamResult(int[] StudentAnswers)
        {
            double degree = 0;
            double totalMarks = 0;
            ConsoleHelper.PrintHeader("Final Exam Result");
            for (int i = 0; i < Questions.Count; i++)
            {
                var question = Questions[i];
                totalMarks += question.Mark;

                ConsoleHelper.PrintMessage(question.ToString());
                foreach (var answer in question.Answers)
                    Console.WriteLine(answer.ToString());

                Console.WriteLine($"Correct Answer is :{question.CorrectAnswer}");
                Console.Write($"Your Answer id Is :{StudentAnswers[i]}");


                // check answer and calc degree
                if (question.CorrectAnswer.AnswerId == StudentAnswers[i])
                {
                    degree += question.Mark;
                    ConsoleHelper.PrintMessage("\t(Correct)");
                }
                else
                    ConsoleHelper.PrintMessage("\t(Incorrect)", false);

                Console.WriteLine("\n----------------------------------------------\n");
            }

            PrintExamSummary(totalMarks, degree);
        }
        private void PrintExamSummary(double totalMarks, double degree)
        {
            var examService = new ExamService();
            double percentage = examService.GetPercentage(totalMarks, degree);
            bool isPassed = examService.IsPassed(percentage);


            Console.WriteLine("\n=======================================================");
            Console.WriteLine(" ================ Exam Result ================\n");
            Console.WriteLine($"Your Degree: {degree} from {totalMarks}");
            Console.WriteLine($"Percentage: {percentage}%");
            ConsoleHelper.PrintMessage($"Grade: {examService.GetGrade(percentage)}", isPassed);
        }
    }
}
