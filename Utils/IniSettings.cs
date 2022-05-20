using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Twitter_CSharp {
    class IniSettings {
        public string Category { get; set; }
        public string ApiKey { get; set; }
        public string ApiKeySecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        private string inifilepath = Directory.GetCurrentDirectory() + "\\Data\\configs.ini";

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        public IniSettings() {
            Category = "Keys";
            ApiKey = "";
            ApiKeySecret = "";
            AccessToken = "";
            AccessTokenSecret = "";
        }

        public IniSettings LoadSettings() {
            IniSettings iniSettings = new IniSettings();

            iniSettings.ApiKey = Readini(this.Category, nameof(ApiKey), inifilepath);
            iniSettings.ApiKeySecret = Readini(this.Category, nameof(ApiKeySecret), inifilepath);
            iniSettings.AccessToken = Readini(this.Category, nameof(AccessToken), inifilepath);
            iniSettings.AccessTokenSecret = Readini(this.Category, nameof(AccessTokenSecret), inifilepath);

            return iniSettings;
        }

        public void Save() {
            Writeini(this.Category, nameof(ApiKey), ApiKey, inifilepath);
            Writeini(this.Category, nameof(ApiKeySecret), ApiKeySecret, inifilepath);
            Writeini(this.Category, nameof(AccessToken), AccessToken, inifilepath);
            Writeini(this.Category, nameof(AccessTokenSecret), AccessTokenSecret, inifilepath);
        }

        private string Readini(string IpAppName, string IpKeyName, string Path) {
            int capacitySize = 256;

            StringBuilder sb = new StringBuilder(capacitySize);
            uint ret = GetPrivateProfileString(IpAppName, IpKeyName, "none", sb, Convert.ToUInt32(sb.Capacity), Path);
            if (0 < ret) {
                return $"{sb.ToString()}";
            }

            return null;
        }

        private bool Writeini(string IpAppName, string IpKeyName, string value, string Path) {
            bool ret = WritePrivateProfileString(IpAppName, IpKeyName, $"\"{value}\"", Path);
            return ret;
        }
    }
}
