namespace Exam_System.Service
{
    public class ExamService
    {
        public string GetGrade(double percentage)
        {
            return percentage switch
            {
                >= 85 => "Excellent",
                >= 75 => "Very Good",
                >= 65 => "Good",
                >= 50 => "Acceptable",
                _ => "Failed"
            };
        }
        public double GetPercentage(double totalMark, double degree) => (degree / totalMark) * 100;
        public bool IsPassed(double percentage) => percentage >= 50;
    }
}
