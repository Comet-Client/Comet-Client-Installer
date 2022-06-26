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
        // INTRO VARIABLES
        bool intro = true;
        float Y = 100;
        float X = 854;
        float inTime = 0;
        float flash = 1;
        float textnameSize = 0;
        float textdescSize = 0;

        public void Render()
        {
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            Raylib.InitWindow(854,480,"Comet Client Launcher");
            Raylib.InitAudioDevice();

            // ICON
            Image icon = Raylib.LoadImage("res/icon.png");
            Raylib.SetWindowIcon(icon);

            // ASSET LOADING
            Texture comet = Raylib.LoadTexture("res/logocomet.png");
            Font font = Raylib.LoadFont("res/FONT/Jost/Jost-VariableFont_wght.ttf");
            Font fontSB = Raylib.LoadFont("res/FONT/Jost/static/Jost-SemiBold.ttf");
            Font fontL = Raylib.LoadFont("res/FONT/Jost/static/Jost-Light.ttf");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(new Color(17, 28, 46, 255));

                // RENDER INTRO
                if (intro)
                {
                    inTime += Raylib.GetFrameTime();
                    X -= Raylib.GetFrameTime() * 1000;
                    Y += Raylib.GetFrameTime() * 100;
                    Raylib.DrawTextureEx(comet, new System.Numerics.Vector2(X, Y), 0, Raylib.GetScreenHeight() * 0.0003f, Raylib.WHITE);

                    // INTRO HERE
                    if (inTime > 1.5f)
                    {
                        if (inTime < 4)
                        {
                            flash -= Raylib.GetFrameTime();
                        }

                        textnameSize = Raylib.MeasureTextEx(fontSB, "Comet", (Raylib.GetScreenHeight() / 3), 5).X;
                        textdescSize = Raylib.MeasureTextEx(font, "Client", (Raylib.GetScreenHeight() / 4), 45).X;
                        Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), Raylib.Fade(Raylib.WHITE, flash));
                        Raylib.DrawTextEx(fontSB, "Comet", new System.Numerics.Vector2((Raylib.GetScreenWidth() - textnameSize) / 2, Raylib.GetScreenHeight() / 8f), (Raylib.GetScreenHeight() / 3), 5, Raylib.WHITE);
                        Raylib.DrawTextEx(font, "Client", new System.Numerics.Vector2((Raylib.GetScreenWidth() - textdescSize) / 2, Raylib.GetScreenHeight() / 3), (Raylib.GetScreenHeight() / 4), 45, Raylib.WHITE);
                        textdescSize = Raylib.MeasureTextEx(fontL, "Open-Source FTW!", (Raylib.GetScreenHeight() / 8), 5).X;
                        Raylib.DrawTextEx(fontL, "Open-Source FTW!", new System.Numerics.Vector2((Raylib.GetScreenWidth() - textdescSize) / 2, Raylib.GetScreenHeight() / 1.5f), (Raylib.GetScreenHeight() / 8), 5, Raylib.Fade(Raylib.WHITE, 0.25f));
                    }

                    if (inTime > 4)
                    {
                        // FADE TO BLACK
                        flash += Raylib.GetFrameTime() / 2;
                        Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), Raylib.Fade(Raylib.BLACK, flash));
                    }

                    if (inTime >= 10)
                    {
                        // GO TO THE LAUNCHER
                        intro = false;
                        flash = 1;
                    }
                }
                else
                {
                    // UNFADE FROM BLACK
                    flash -= Raylib.GetFrameTime()/2;
                    Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), Raylib.Fade(Raylib.BLACK, flash));
                }

                Raylib.EndDrawing();
            }

            // UNLOADING ASSETS AND CLOSING WINDOW
            Raylib.UnloadImage(icon);
            Raylib.UnloadTexture(comet);
            Raylib.UnloadFont(font);
            Raylib.UnloadFont(fontSB);
            Raylib.UnloadFont(fontL);

            Raylib.CloseWindow();
            Raylib.CloseAudioDevice();
        }
    }
}
