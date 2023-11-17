using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class load : MonoBehaviour
{
    public Text displayText;
    public Text stepText;
    public Text modelText;
    string filePath; // ファイルパス
    public GameObject boot;

    void Start()
    {
        // StreamingAssets内のファイルパスを作成
        filePath = Path.Combine(Application.streamingAssetsPath, "config.txt");
        StartCoroutine(DisplayTextWithDelay());
    }

    IEnumerator DisplayTextWithDelay()
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            // Model= の行の場合
            if (line.StartsWith("Model"))
            {
                string[] parts = line.Split('=');
                string model = parts[0];
                string text = parts[1];

                modelText.text = text;
            }
            // STEP= の行の場合
            if (line.StartsWith("STEP "))
            {
                string[] parts = line.Split('=');
                string step = parts[0];
                string text = parts[1];

                displayText.text = text;
                stepText.text = step;

                // 遅延時間の読み込み
                float delay = 0f;
                if (parts.Length > 2 && float.TryParse(parts[2], out delay))
                {
                    yield return new WaitForSeconds(delay);
                }
                else
                {
                    boot.SetActive(true);
                }
            }
        }
    }
}
