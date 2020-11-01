using UnityEngine;
using System.Collections;
using System;


    public class JsonReader
    {

        public static T Read<T>(string filePath)
        {
            string fullPath = Application.dataPath + "/" + filePath + ".json";
            string fileData = System.IO.File.ReadAllText(fullPath);
            T jsonData = JsonUtility.FromJson<T>(fileData);
            return (T)Convert.ChangeType(jsonData, typeof(T));

        }
    }
