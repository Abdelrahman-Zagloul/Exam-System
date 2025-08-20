namespace Exam_System.Model
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Answer() { }
        public Answer(int answerId, string answer)
        {
            AnswerId = answerId;
            AnswerText = answer;
        }

        public override string ToString()
        {
            return $"[{AnswerId}]. {AnswerText}";
        }
    }
}
