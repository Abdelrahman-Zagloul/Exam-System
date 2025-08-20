using Exam_System.Factory;
using Exam_System.Helper;

namespace Exam_System.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }
        public override string ToString()
        {
            return $"Subject name is {Name}";
        }

        public Exam CreateExam()
        {
            Name = ValidationHelper.GetValidString("Enter subject name: ");
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine("\n1: Final Exam \t 2:Practical Exam");
            int examType = ValidationHelper.GetValidateNumber("Choose Exam:", 1, 2);

            Exam exam;
            var examFactory = new ExamFactory(new QuestionFactory());
            if (examType == 1)
                exam = examFactory.CreateFinalExam();
            else
                exam = examFactory.CreatePracticalExam();

            Console.Clear();
            exam.ShowExam();

            return exam;
        }



    }
}
