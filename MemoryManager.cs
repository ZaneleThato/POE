using System;
using System.Collections.Generic;
using System.IO;

namespace POE
{
    //Manages the chat history memory
    public class MemoryManager
    {
        private string GetFilePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string rootPath = baseDir.Replace("bin\\Debug\\", "");
            return Path.Combine(rootPath, "chat_history.txt");
        }

        public void EnsureFileExists()
        {
            string path = GetFilePath();
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void SaveConversation(List<string> entries)
        {
            string path = GetFilePath();
            EnsureFileExists();
            File.AppendAllLines(path, entries);
        }

        public List<string> GetHistory()
        {
            string path = GetFilePath();
            EnsureFileExists();
            return new List<string>(File.ReadAllLines(path));
        }
    }
}
