namespace Exam_System.Helper
{
    public class ConsoleHelper
    {
        public static void PrintHeader(string message)
        {
            Console.Clear();
            PrintMessage($"\n===============================================");
            PrintMessage($"\t\t{message} ");
            PrintMessage($"===============================================\n\n");
        }
        public static void PrintMessage(string message, bool flag = true)
        {
            if (flag)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PressEnterToContinue()
        {
            Console.Write($"\nPress Any Key To Continue . . . ");
            Console.ReadKey();
            Console.WriteLine();
        }
       
    }
}
