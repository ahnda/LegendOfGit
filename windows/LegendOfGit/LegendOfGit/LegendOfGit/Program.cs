using System;

namespace LegendOfGit
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (LoG game = new LoG())
            {
                game.Run();
            }
        }
    }
#endif
}

