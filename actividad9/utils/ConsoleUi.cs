namespace BreakLineEvents.Utils;

public static class ConsoleUi
{
    public static void ClearScreen()
    {
        try
        {
            Console.Clear();
            return;
        }
        catch
        {
            
        }

        try
        {
            int width = Math.Max(1, Console.BufferWidth);
            int height = Math.Max(1, Console.WindowHeight);
            string blank = new(' ', width);

            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < height; i++)
            {
                Console.Write(blank);
            }

            Console.SetCursorPosition(0, 0);
        }
        catch
        {
            Console.WriteLine(new string('\n', 40));
        }
    }
}
