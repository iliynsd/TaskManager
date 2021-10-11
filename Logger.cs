#nullable enable
using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShitAssLogger
{
    public static class Logger
    {
        private static string _txtPath = @"..\..\..\..\ShitAssLogger\ShitAssLoggerDirectory\shitAssLogFile.txt";
        private static string _jsonPath = @"..\..\..\..\ShitAssLogger\ShitAssLoggerDirectory\shitAssLogFileJS.json";

        private static void LogToTxt(string? logType, string? msgType, string? msg)
        {
            var log = MsgToLogBuffer(msg, msgType, logType);
            File.WriteAllText(_txtPath, log);
        }

        private static void LogToJson(string? logType, string? msgType, string? msg)
        {
            var log = new JsonLog
            {
                Date = DateTime.Now.ToString(),
                Type = $"[{msgType}-{logType}]",
                Msg = msg
            };
            string json = JsonConvert.SerializeObject(log);
            File.WriteAllText(_jsonPath, json);
        }

        private static string MsgToLogBuffer(string? msg, string? msgType = "UNKNOWN", string? logType = "UNKNOWN")
        {
            return string.IsNullOrEmpty(msg) ? $"{DateTime.Now:u} [LOG-ERROR]: Пустое сообщение или какое-то такое дерьмо" : $"{DateTime.Now:u} [{msgType}-{logType}]: {msg}";
        }

        public static void InfoLog(string msgType, string msg)
        {
            LogToTxt("INFO", msgType, msg);
            LogToJson("INFO", msgType, msg);
        }

        public static void ErrorLog(string msgType, string msg)
        {
            LogToTxt("ERROR", msgType, msg);
            LogToJson("ERROR", msgType, msg);
        }

        public static void WarningLog(string msgType, string msg)
        {
            LogToTxt("WARNING", msgType, msg);
            LogToJson("WARNING", msgType, msg);
        }

        public static void ChangeLogDirectory(string? path)
        {
            if (string.IsNullOrEmpty(path))
            {
                LogToTxt(null, null, null);
                LogToJson(null, null, null);
                return;
            }
            _txtPath = $"{path}/shitAssLogFile.txt";
            _jsonPath = $"{path}/shitAssLogFile.json";
        }
    }
}