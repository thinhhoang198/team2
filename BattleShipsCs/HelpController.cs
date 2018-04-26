using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    class HelpController
    {
        private const int BACK_BUTTON_TOP = 5;
        private const int BACK_BUTTON_HEIGHT = 46;
        private const int BACK_BUTTON_LEFT = 5;
        private const int BACK_BUTTON_WIDTH = 25;

        private const int INSTRUCTION_TOP = 40;
        private const int INSTRUCTION_LEFT = 50;

        public static void DrawHelp()
        {
            SwinGame.DrawBitmap(GameResources.GameImage("Menu"), 0, 0);
            SwinGame.DrawBitmap(GameResources.GameImage("HelpDeploy"), INSTRUCTION_LEFT, INSTRUCTION_TOP);
        }

        private static void DrawHelpPlay()
        {
            SwinGame.DrawBitmap(GameResources.GameImage("HelpPlay"), INSTRUCTION_LEFT, INSTRUCTION_TOP);
        }

        public static void HandleHelpInput()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton) ||
                SwinGame.KeyDown(KeyCode.EscapeKey) ||
                SwinGame.KeyDown(KeyCode.ReturnKey))
            {
                GameController.SwitchState(GameState.ViewingMainMenu);
            }
        }
    }
}
