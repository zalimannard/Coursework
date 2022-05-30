public static class DataHolder
{
    private static int _loadedLevel;
    private static string _program = "";

    public static int getLoadedLevel()
    {
        return _loadedLevel;
    }

    public static void setLoadedLevel(int value)
    {
        _loadedLevel = value;
    }

    public static string getProgram()
    {
        return _program;
    }

    public static void setProgram(string value)
    {
        _program = value;
    }
}
