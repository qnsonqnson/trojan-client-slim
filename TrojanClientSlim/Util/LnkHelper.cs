﻿using System;
using System.IO;
using System.Reflection;

namespace TrojanClientSlim.Util
{
    public static class LnkHelper
    {
        public static void SetLnk()
        {
            var shellType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shellType);
            var shortcut = shell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "TCS.lnk"));
            shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
            shortcut.Arguments = "silence";
            shortcut.WorkingDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            shortcut.Save();
        }

        public static void RemoveLnk()
        {
            File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "TCS.lnk"));
        }
    }
}
