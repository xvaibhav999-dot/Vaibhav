using System;
using SapB1TradeFinanceAddon.Core;

namespace SapB1TradeFinanceAddon
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var app = new AddonApplication();
            app.Run(args);
        }
    }
}
