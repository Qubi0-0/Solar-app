using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlanetInfoReader : MonoBehaviour
{
    public static bool ReadPlanetData(string planetName, out Dictionary<string, string>data)
    {
        data = new Dictionary<string, string>();
        string fileText = File.ReadAllText(Application.streamingAssetsPath + "/" + planetName + ".txt");

        string[] lines = fileText.Split(new char[] { '\n' });
        foreach (string line in lines) 
        {
            if (line == "")
                continue;
            string tmpLine =  line.Trim();
            string[] lineText = tmpLine.Split(new char[] { ':' });
            data.Add(lineText[0], lineText[1]);
        }

        return true;
    }
}
