using WinApi;
using System;
using System.Threading;

using static WinApi.User32.WindowLongFlags;
using static WinApi.User32.WindowStyles;
using static WinApi.User32.WindowStylesEx;

namespace RappelzBorderless
{
    class Program
    {
        const int delay = 1;
        static void Main(string[] args)
        {
            Console.Title = "Rappelz Borderless";

            Console.Write("Finding [SFRAME, Rappelz] window ... ");
            IntPtr hWnd;
            while ((hWnd = User32.FindWindow("SFRAME", "Rappelz")) == IntPtr.Zero)
                Thread.Sleep(delay);
            Console.WriteLine($"Found! (0x{{0:X{IntPtr.Size}}})", hWnd);

            Console.Write("Setting up styles ... ");
            var style = (uint)(WS_POPUP | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN);
            while (User32.SetWindowLong(hWnd, GWL_STYLE, style) == IntPtr.Zero)
                Thread.Sleep(delay);
            Console.WriteLine("Done!");

            Console.Write("Setting up styles ... ");
            var styleEx = (uint)(WS_EX_LEFT | WS_EX_LTRREADING | WS_EX_RIGHTSCROLLBAR | WS_EX_ACCEPTFILES);
            while (User32.SetWindowLong(hWnd, GWL_EXSTYLE, styleEx) == IntPtr.Zero)
                Thread.Sleep(delay);
            Console.WriteLine("Done!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
