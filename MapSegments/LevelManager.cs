using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using Microsoft.Xna.Framework;

using MahJong.GameObject;
using MahJong.Factory;

namespace MahJong.LevelMap
{
    internal class LevelManager
    {
        private LevelManager() { }
        public static Level LoadFromFile(string fileName)
        {
            Level level = null;
            fileName = Directory.GetCurrentDirectory() + "\\" + fileName;
            Debug.WriteLine($"Loading level from {fileName}");
            if (File.Exists(fileName))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Level));
                level = (Level)serializer.ReadObject(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read));
            }

            return level;
        }
    }
}
