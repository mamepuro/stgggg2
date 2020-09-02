using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace SpaceBox2
{
    class Json
    {
        public static StageData[] ReadJsonToArarry(string filePath, string encodingName)
        {
            string json = ReadFileAllLine(filePath, encodingName);
            StageData[] stageDatas = JsonSerializer.Deserialize<StageData[]>(json);
            return stageDatas;
        }

        private static string ReadFileAllLine(string filePath, string encodingName)
        {
            StreamReader streamReader = new StreamReader(filePath, Encoding.GetEncoding(encodingName));
            string allLine = streamReader.ReadToEnd();
            return allLine;
        }
    }
}
