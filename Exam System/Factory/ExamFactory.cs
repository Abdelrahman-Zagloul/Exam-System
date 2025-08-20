using Exam_System.Helper;
using Exam_System.Model;

namespace Exam_System.Factory
{
    public class ExamFactory
    {
        private readonly QuestionFactory _questionFactory;
        public ExamFactory(QuestionFactory questionFactory)
        {
            _questionFactory = questionFactory;
        }
        public PracticalExam CreatePracticalExam()
        {
            Console.Clear();
            ConsoleHelper.PrintMessage("\n\t ================== Practical Exam ==================\n\n");

            PracticalExam practicalExam = new PracticalExam();
            practicalExam.NumberOFQuestion = ValidationHelper.GetValidateNumber("Enter Number Of Question: ", 0, 100);
            int timeInMinutes = ValidationHelper.GetValidateNumber("Enter Time Of Exam in Minutes : ", 0, 1000);
            practicalExam.TimeOfExam = TimeSpan.FromMinutes(timeInMinutes);
            List<Question> questionList = new List<Question>();

            for (int i = 0; i < practicalExam.NumberOFQuestion; i++)
            {
                ConsoleHelper.PrintHeader("Practical Exam");
                questionList.Add(_questionFactory.CreateMCQQuestion(i + 1));
            }
            practicalExam.Questions = questionList;


            return practicalExam;
        }
        public FinalExam CreateFinalExam()
        {
            ConsoleHelper.PrintHeader("Final Exam");

            FinalExam exam = new FinalExam();
            exam.NumberOFQuestion = ValidationHelper.GetValidateNumber("Enter Number Of Question: ", 0, 100);
            int timeInMinutes = ValidationHelper.GetValidateNumber("Enter Time Of Exam in Minutes : ", 0, 1000);
            exam.TimeOfExam = TimeSpan.FromMinutes(timeInMinutes);
            List<Question> questionList = new List<Question>();

            for (int i = 0; i < exam.NumberOFQuestion; i++)
            {
                ConsoleHelper.PrintHeader("Final Exam");
                Console.WriteLine("1: True Of False Question \t 2: MCQ Question");
                int choose = ValidationHelper.GetValidateNumber("Choose Type of question: ", 1, 2);
                if (choose == 1)
                    questionList.Add(_questionFactory.CreateTrueFalseQuestion(i + 1));
                else
                    questionList.Add(_questionFactory.CreateMCQQuestion(i + 1));
            }
            exam.Questions = questionList;

            return exam;
        }
    }
}
