﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    public class GameResources
    {
        /// <summary> *
        /// Loads font resources for the game. 
        /// <summary> 
        
        private static void LoadFonts()
        {
            NewFont("ArialLarge", "arial.ttf", 80);
            NewFont("Courier", "cour.ttf", 14);
            NewFont("CourierSmall", "cour.ttf", 8);
            NewFont("Menu", "ffaccess.ttf", 8);
        }
        
        /// <summary> *
        /// Loads images for the game,
        /// includes buttons, ships and effects.
        /// <summary>
        
        private static void LoadImages()
        {
            //Backgrounds
            NewImage("Menu", "main_page.jpg");
            NewImage("Discovery", "discover.jpg");
            NewImage("Deploy", "deploy.jpg");

            //Deployment
            NewImage("LeftRightButton", "deploy_dir_button_horiz.png");
            NewImage("UpDownButton", "deploy_dir_button_vert.png");
            NewImage("SelectedShip", "deploy_button_hl.png");
            NewImage("PlayButton", "deploy_play_button.png");
            NewImage("RandomButton", "deploy_randomize_button.png");

            //Ships
            int i = 0;
            for (i = 1; i <= 5; i++)
            {
                NewImage("ShipLR" + System.Convert.ToString(i), "ship_deploy_horiz_" + System.Convert.ToString(i) + ".png");
                NewImage("ShipUD" + System.Convert.ToString(i), "ship_deploy_vert_" + System.Convert.ToString(i) + ".png");
            }

            //Explosions
            NewImage("Explosion", "explosion.png");
            NewImage("Splash", "splash.png");

            //Instructions
            NewImage("HelpDeploy", "help_deploy.png");

            //Back button
            NewImage("BackButton", "back_button.png");

        }

        /// <summary> *
        /// Load audio resources for the game.
        /// <summary>
        
        private static void LoadSounds()
        {
            NewSound("Error", "error.wav");
            NewSound("Hit", "hit.wav");
            NewSound("Sink", "sink.wav");
            NewSound("Siren", "siren.wav");
            NewSound("Miss", "watershot.wav");
            NewSound("Winner", "winner.wav");
            NewSound("Lose", "lose.wav");
        }
        
        /// <summary> *
        /// Loads background music for menu screen.
        /// <summary>

        private static void LoadMusic()
        {
            NewMusic("Background", "horrordrone.wav");
        }

        /// <summary>
        /// Gets a Font Loaded in the Resources
        /// </summary>
        /// <param name="font">Name of Font</param>
        /// <returns>The Font Loaded with this Name</returns>

        public static Font GameFont(string font)
        {
            return _Fonts[font];
        }

        /// <summary>
        /// Gets an Image loaded in the Resources
        /// </summary>
        /// <param name="image">Name of image</param>
        /// <returns>The image loaded with this name</returns>

        public static Bitmap GameImage(string image)
        {
            return _Images[image];
        }

        /// <summary>
        /// Gets an sound loaded in the Resources
        /// </summary>
        /// <param name="sound">Name of sound</param>
        /// <returns>The sound with this name</returns>

        public static SoundEffect GameSound(string sound)
        {
            return _Sounds[sound];
        }

        /// <summary>
        /// Gets the music loaded in the Resources
        /// </summary>
        /// <param name="music">Name of music</param>
        /// <returns>The music with this name</returns>

        public static Music GameMusic(string music)
        {
            return _Music[music];
        }

        private static Dictionary<string, Bitmap> _Images = new Dictionary<string, Bitmap>();
        private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font>();
        private static Dictionary<string, SoundEffect> _Sounds = new Dictionary<string, SoundEffect>();
        private static Dictionary<string, Music> _Music = new Dictionary<string, Music>();

        private static Bitmap _Background;
        private static Bitmap _Animation;
        private static Bitmap _LoaderFull;
        private static Bitmap _LoaderEmpty;
        private static Font _LoadingFont;
        private static SoundEffect _StartSound;

        /// <summary>
        /// The Resources Class stores all of the Games Media Resources, such as Images, Fonts
        /// Sounds, Music.
        /// </summary>

        public static void LoadResources()
        {
            int width = 0;
            int height = 0;

            width = System.Convert.ToInt32(SwinGame.ScreenWidth());
            height = System.Convert.ToInt32(SwinGame.ScreenHeight());

            SwinGame.ChangeScreenSize(800, 600);

            ShowLoadingScreen();

            ShowMessage("Loading fonts...", 0);
            LoadFonts();
            SwinGame.Delay(100);

            ShowMessage("Loading images...", 1);
            LoadImages();
            SwinGame.Delay(100);

            ShowMessage("Loading sounds...", 2);
            LoadSounds();
            SwinGame.Delay(100);

            ShowMessage("Loading music...", 3);
            LoadMusic();
            SwinGame.Delay(100);

            SwinGame.Delay(100);
            ShowMessage("Game loaded...", 5);
            SwinGame.Delay(100);
            EndLoadingScreen(width, height);
        }
        
        /// <summary> *
        /// Runs the loading screen with all game resources,
        /// such as images, sounds, animations,...
        /// <summary>
        
        private static void ShowLoadingScreen()
        {
            _Background = SwinGame.LoadBitmap(SwinGame.PathToResource("SplashBack.png",ResourceKind.BitmapResource));
            SwinGame.DrawBitmap(_Background, 0, 0);
            SwinGame.RefreshScreen();
            SwinGame.ProcessEvents();

            _Animation = SwinGame.LoadBitmap(SwinGame.PathToResource("SwinGameAni.jpg", ResourceKind.BitmapResource));
            _LoadingFont = SwinGame.LoadFont(SwinGame.PathToResource("arial.ttf",ResourceKind.FontResource), 12);
            _StartSound = Audio.LoadSoundEffect(SwinGame.PathToResource("SwinGameStart.wav",ResourceKind.SoundResource));

            _LoaderFull = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_full.png",ResourceKind.BitmapResource));
            _LoaderEmpty = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_empty.png", ResourceKind.BitmapResource));

            PlaySwinGameIntro();
        }
        
        /// <summary> *
        /// Runs the intro of SwinGame with sound effects.
        /// <summary>

        private static void PlaySwinGameIntro()
        {
            const int ANI_CELL_COUNT = 11;

            Audio.PlaySoundEffect(_StartSound);
            SwinGame.Delay(200);

            int i = 0;
            for (i = 0; i <= ANI_CELL_COUNT - 1; i++)
            {
                SwinGame.DrawBitmap(_Background, 0, 0);
                SwinGame.Delay(20);
                SwinGame.RefreshScreen();
                SwinGame.ProcessEvents();
            }

            SwinGame.Delay(1500);

        }
        
        /// <summary> *
        /// Prints out the messages.
        /// <summary> 
        /// <param name ="message">the message that will be printed out</param>
        /// <param name ="number"></param>
        private static void ShowMessage(string message, int number)
        {
            const int TX = 310;
            const int TY = 493;
            const int TW = 200;
            const int TH = 25;
            const int STEPS = 5;
            const int BG_X = 279;
            const int BG_Y = 453;

            int fullW;
            Rectangle toDraw = default(Rectangle);

            fullW = System.Convert.ToInt32(260 * number / STEPS);
            SwinGame.DrawBitmap(_LoaderEmpty, BG_X, BG_Y);
            SwinGame.DrawCell(_LoaderFull, 0, BG_X, BG_Y);
            // SwinGame.DrawBitmapPart(_LoaderFull, 0, 0, fullW, 66, BG_X, BG_Y)

            toDraw.X = TX;
            toDraw.Y = TY;
            toDraw.Width = TW;
            toDraw.Height = TH;
            SwinGame.DrawText(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, toDraw);
            // SwinGame.DrawTextLines(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, TX, TY, TW, TH)

            SwinGame.RefreshScreen();
            SwinGame.ProcessEvents();
        }

        /// <summary> *
        /// Stops the loading screen and frees all game resources.
        /// <summary> 
        /// <param name="width">width of screen</param>
        /// <param name="height">height of screen</param>
        
        private static void EndLoadingScreen(int width, int height)
        {
            SwinGame.ProcessEvents();
            SwinGame.Delay(500);
            SwinGame.ClearScreen();
            SwinGame.RefreshScreen();
            SwinGame.FreeFont(_LoadingFont);
            SwinGame.FreeBitmap(_Background);
            SwinGame.FreeBitmap(_Animation);
            SwinGame.FreeBitmap(_LoaderEmpty);
            SwinGame.FreeBitmap(_LoaderFull);
            //SwinGame.FreeSoundEffect(_StartSound);
            SwinGame.ChangeScreenSize(width, height);
        }
        
        /// <summary> *
        /// Adds new font.
        /// <summary> 
        /// <param name="fontName">name of new font</param>
        /// <param name="filename">name of file contains new font</param>
        /// <param name="size">size of new font</param>

        private static void NewFont(string fontName, string filename, int size)
        {
            _Fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size));
        }
        
        /// <summary> *
        /// Adds new image
        /// <summary> 
        /// <param name="imageName">name of new image</param>
        /// <param name="filename">name of file contains new image</param> 

        private static void NewImage(string imageName, string filename)
        {
            _Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource)));
        }
        
        /// <summary> *
        /// Adds new Transparen color image
        /// <summary> 
        /// <param name="imageName">name of image</param>
        /// <param name="fileName">name of file contains new trans color</param>
        /// <param name="transColor">new trans color</param>
        
        private static void NewTransparentColorImage(string imageName, string fileName, Color transColor)
        {
            _Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(fileName, ResourceKind.BitmapResource)));
        }
        
        /// <summary> *
        /// Adds new Transparen color image
        /// <summary> 
        /// <param name="imageName">name of image</param>
        /// <param name="fileName">name of file contains new trans color</param>
        /// <param name="transColor">new trans color</param>

        private static void NewTransparentColourImage(string imageName, string fileName, Color transColor)
        {
            NewTransparentColorImage(imageName, fileName, transColor);
        }
        
        /// <summary> *
        /// Adds new sound
        /// <summary> 
        /// <param name="soundName">name of new sound</param>
        /// <param name="fileName">name of file contains new sound</param>

        private static void NewSound(string soundName, string filename)
        {
            _Sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }
        
        /// <summary> *
        /// Adds new music
        /// <summary> 
        /// <param name="musicName">name of new music</param>
        /// <param name="fileName">name of file contains new music</param>

        private static void NewMusic(string musicName, string filename)
        {
            _Music.Add(musicName, SwinGame.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.MusicResource)));
        }

        /// <summary> *
        /// Frees the fonts
        /// <summary>

        private static void FreeFonts()
        {
            Font obj = default(Font);
            foreach (Font tempLoopVar_obj in _Fonts.Values)
            {
                obj = tempLoopVar_obj;
                SwinGame.FreeFont(obj);
            }
        }
        
        /// <summary> *
        /// Frees the images
        /// <summary>

        private static void FreeImages()
        {
            Bitmap obj = default(Bitmap);
            foreach (Bitmap tempLoopVar_obj in _Images.Values)
            {
                obj = tempLoopVar_obj;
                SwinGame.FreeBitmap(obj);
            }
        }
        
        /// <summary> *
        /// Frees the sounds
        /// <summary>

        private static void FreeSounds()
        {
            SoundEffect obj = default(SoundEffect);
            foreach (SoundEffect tempLoopVar_obj in _Sounds.Values)
            {
                obj = tempLoopVar_obj;
                Audio.FreeSoundEffect(obj);
            }
        }
        
        /// <summary> *
        /// Frees the music
        /// <summary>

        private static void FreeMusic()
        {
            Music obj = default(Music);
            foreach (Music tempLoopVar_obj in _Music.Values)
            {
                obj = tempLoopVar_obj;
                SwinGame.FreeMusic(obj);
            }
        }
        
        /// <summary> *
        /// Frees all the game resources
        /// <summary>

        public static void FreeResources()
        {
            FreeFonts();
            FreeImages();
            FreeMusic();
            FreeSounds();
            SwinGame.ProcessEvents();
        }
    }
}
