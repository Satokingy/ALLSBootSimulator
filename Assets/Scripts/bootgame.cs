using UnityEngine;
using System.Diagnostics;

public class bootgame : MonoBehaviour
{
    public string batchFileName = "game.bat";

    void Start()
    {
        string path = Application.streamingAssetsPath + "/" + batchFileName;

        ProcessStartInfo processInfo = new ProcessStartInfo(path)
        {
            UseShellExecute = true,
            CreateNoWindow = false
        };

        Process process = new Process { StartInfo = processInfo };
        process.Start();
        Invoke(nameof(Quit), 5);
        
    }
    void Quit()
    {
        Application.Quit();
    }
}
