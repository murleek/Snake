using System.Collections;
using System.Windows.Forms;

namespace Snake
{
    class Input
    {
        private static Hashtable keyTable = new Hashtable();

        // thx to @r4v3c4t
        public static bool KeyPress(Keys key) => keyTable[key] != null && (bool)keyTable[key];

        public static void changeState(Keys key, bool state) => keyTable[key] = state;
    }
}
