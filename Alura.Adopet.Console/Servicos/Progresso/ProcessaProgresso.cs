namespace Alura.Adopet.Console.Servicos.Progresso
{
    public static class ProcessaProgresso
    {
        public static void ProgressChanged(int progresso, int total)
        {
            System.Console.CursorLeft = 0;
            System.Console.Write("[");

            int progressBarWidth = System.Console.WindowWidth - 2;
            int completedWidth = (int)((double)progresso / total * progressBarWidth);

            System.Console.BackgroundColor = ConsoleColor.Green;
            System.Console.Write(new string(' ', completedWidth));
            System.Console.ResetColor();

            System.Console.Write(new string(' ', progressBarWidth - completedWidth));
            System.Console.Write("]");

            System.Console.WriteLine($" {((double)progresso / (double)total) * 100}%");
        }
    }
}
