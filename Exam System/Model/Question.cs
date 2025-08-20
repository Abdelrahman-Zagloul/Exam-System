namespace Exam_System.Model
{
    public abstract class Question
    {
        public abstract string Header { get; set; }
        public abstract string Body { get; set; }
        public abstract double Mark { get; set; }
        public List<Answer> Answers { get; set; }
        public Answer CorrectAnswer { get; set; }

        public abstract void ShowQuestion();

        public override string ToString()
        {
            return $"{Header}: {Body} \t[{Mark} marks]";
        }


    }
}
