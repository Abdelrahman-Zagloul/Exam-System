using Exam_System.Helper;
using Exam_System.Model;

namespace Exam_System.Factory
{
    public class QuestionFactory
    {
        public MCQQuestion CreateMCQQuestion(int questionNumber)
        {
            ConsoleHelper.PrintHeader("MCQ Question");

            var mcq_Question = new MCQQuestion()
            {
                Header = $"Question {questionNumber}",
                Body = ValidationHelper.GetValidString($"Enter Body of Question {questionNumber} :"),
                Mark = ValidationHelper.GetValidateNumber($"Enter Mark of Question {questionNumber} :", 1, 100),
            };

            int numberOfAnswers = ValidationHelper.GetValidateNumber("Enter Number Of choices: ", 2, 20);
            mcq_Question.Answers = GetAnswers(questionNumber, numberOfAnswers);

            int correctAnswerId = ValidationHelper.GetValidateNumber("Enter Id For Correct Answer: ", 1, numberOfAnswers);
            mcq_Question.CorrectAnswer = mcq_Question.Answers.First(x => x.AnswerId == correctAnswerId);
            return mcq_Question;
        }
        public TFQuestion CreateTrueFalseQuestion(int questionNumber)
        {
            ConsoleHelper.PrintHeader("True || False  Question ");

            TFQuestion tf_Question = new TFQuestion()
            {
                Header = $"Question {questionNumber}",
                Body = ValidationHelper.GetValidString($"Enter Body of Question {questionNumber} :"),
                Mark = ValidationHelper.GetValidateNumber($"Enter Mark of Question {questionNumber} :", 0, 20),
                Answers = new List<Answer>()
                {
                    new Answer(1,"True"),
                    new Answer(2,"False")
                }
            };
            int correctAnswerId = ValidationHelper.GetValidateNumber("Enter Correct Answer :  1.True || 2.False: ", 1, 2);
            tf_Question.CorrectAnswer = tf_Question.Answers.First(x => x.AnswerId == correctAnswerId);

            return tf_Question;
        }
        private List<Answer> GetAnswers(int questionNumber, int answerNumber)
        {
            ConsoleHelper.PrintMessage($"\n\n----------------- Enter Choice Of Question {questionNumber} ----------------- ");
            List<Answer> answerList = new List<Answer>();
            for (int i = 0; i < answerNumber; i++)
            {
                string answer = ValidationHelper.GetValidString($"Enter Choice {i + 1}:");
                answerList.Add(new Answer() { AnswerId = i + 1, AnswerText = answer });
            }
            return answerList;
        }
    }
}
