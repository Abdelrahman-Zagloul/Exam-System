using Exam_System.Helper;
using Exam_System.Model;
using System.Diagnostics;

namespace Exam_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintHeader("Exam System");

            Subject subject = new Subject();
            var exam = subject.CreateExam();

            string input = ValidationHelper.GetValidString("Start Exam Now ? (Y or N):");
            if (input.ToLower() == "y")
                StartExam(exam);
            else
            {
                Console.WriteLine("Exam Cancelled.");
                ConsoleHelper.PressEnterToContinue();
                return;
            }
        }

        private static void StartExam(Exam exam)
        {
            Console.WriteLine($"\nExam start now. You have {exam.TimeOfExam.TotalMinutes} minutes.\n");

            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] studentAnswer = GetAnswers(exam, stopwatch);
            stopwatch.Stop();


            if (exam is FinalExam finalExam)
                finalExam.ShowExamResult(studentAnswer);
            else if (exam is PracticalExam practicalExam)
                practicalExam.ShowCorrectAnswers();

            Console.WriteLine($"Exam finished. You take {stopwatch.Elapsed.Minutes} min {stopwatch.Elapsed.Seconds} sec\n");
        }
        private static int[] GetAnswers(Exam exam, Stopwatch stopwatch)
        {
            int[] studentAnswer = new int[exam.NumberOFQuestion];
            for (int i = 0; i < studentAnswer.Length; i++)
            {
                //check on the time of exam
                if (stopwatch.Elapsed > exam.TimeOfExam)
                {
                    Console.WriteLine("Exam Time is finished");
                    Environment.Exit(0);
                }

                int answer = ValidationHelper.GetValidateNumber($"Enter Answer of Question {i + 1}: ", int.MinValue, int.MaxValue);
                studentAnswer[i] = answer;

            }
            return studentAnswer;
        }
    }
}
