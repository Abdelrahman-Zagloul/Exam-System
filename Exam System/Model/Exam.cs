namespace Exam_System.Model
{
    public abstract class Exam : IComparable<Exam>
    {
        public abstract TimeSpan TimeOfExam { get; set; }
        public abstract int NumberOFQuestion { get; set; }
        public List<Question> Questions { get; set; }

        protected Exam() { }


        public abstract void ShowExam();
        public int CompareTo(Exam? other)
        {
            if (other == null)
                return 1;
            return this.NumberOFQuestion.CompareTo(other.NumberOFQuestion);
        }
        public override string ToString()
        {
            return $"Exam Has '{NumberOFQuestion}' Question and Take '{TimeOfExam}'";
        }
    }
}
