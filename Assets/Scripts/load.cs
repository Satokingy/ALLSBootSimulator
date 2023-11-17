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
    string filePath; // �t�@�C���p�X
    public GameObject boot;

    void Start()
    {
        // StreamingAssets���̃t�@�C���p�X���쐬
        filePath = Path.Combine(Application.streamingAssetsPath, "config.txt");
        StartCoroutine(DisplayTextWithDelay());
    }

    IEnumerator DisplayTextWithDelay()
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            // Model= �̍s�̏ꍇ
            if (line.StartsWith("Model"))
            {
                string[] parts = line.Split('=');
                string model = parts[0];
                string text = parts[1];

                modelText.text = text;
            }
            // STEP= �̍s�̏ꍇ
            if (line.StartsWith("STEP "))
            {
                string[] parts = line.Split('=');
                string step = parts[0];
                string text = parts[1];

                displayText.text = text;
                stepText.text = step;

                // �x�����Ԃ̓ǂݍ���
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
