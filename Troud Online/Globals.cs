namespace Troud_Online
{
    public static class Globals
    {
        public static bool connected = false;
        public static bool online = false;
        public static byte state = 0;
        public static string username = "";

        public static Database db = new Database();
        public static Display display = new Display();
    }
}
