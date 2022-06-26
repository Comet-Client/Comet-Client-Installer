using System;
using Raylib_CsLo;

namespace Comet_Client_Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            new Launcher().Render();
        }
    }

    class Launcher { 
        public void Render()
        {
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            Raylib.InitWindow(854,480,"Comet Client Launcher");
            Raylib.InitAudioDevice();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(new Color(17, 28, 46, 255));

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
            Raylib.CloseAudioDevice();
        }
    }
}
