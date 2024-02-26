using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lesson02
{
    class Settings
    {
        public static SizeF WindowSize { set; get; }
        public static float Interval { get; set; }

        public static void InitSettings(SizeF size, float interval)
        {
            WindowSize = size;
            Interval = interval / 1000;
        }
    }

    class Utils
    {
        public static Dictionary<string, bool> KeysState { set; get; } = new Dictionary<string, bool>()
        {
            {"Up", false },
            {"Down", false },
            {"Left", false },
            {"Right", false }
        };

        public static void SetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                KeysState["Up"] = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                KeysState["Down"] = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                KeysState["Left"] = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                KeysState["Right"] = true;
            }
        }

        public static void SetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                KeysState["Up"] = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                KeysState["Down"] = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                KeysState["Left"] = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                KeysState["Right"] = false;
            }
        }

        public static bool IsCollide(Character first, Character second)
        {
            if (first.Position.X <= second.Position.X + second.Size.Width &&
                first.Position.Y <= second.Position.Y + second.Size.Height &&
                second.Position.Y <= first.Position.Y + first.Size.Height &&
                second.Position.X <= first.Position.X + first.Size.Width)
            {
                return true;
            }
            return false;
        }
    }


}
