using System.Runtime.InteropServices;

internal class UsingAttributes
{
    [DllImport("user32.dll", EntryPoint = "MessageBox")]
    public static extern int ShowMessageBox(int hWnd, string text, string caption, int type);

    private static void Main()
    {
        ShowMessageBox(0, "Some text", "Some caption", 0);
    }
}