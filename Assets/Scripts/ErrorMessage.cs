using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ErrorMassage : MonoBehaviour
{
    public Text errorText;
    public Text messageText;

    void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "config.txt"); // ファイル名を適切なものに置き換える

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            string errorValue = null;
            string messageValue = null;

            foreach (string line in lines)
            {
                if (line.Contains("errorno="))
                {
                    errorValue = line.Split('=')[1];
                }
                else if (line.Contains("errormessage="))
                {
                    messageValue = line.Split('=')[1];
                }

                if (errorValue != null && messageValue != null)
                {
                    // 両方の値が見つかったらループを終了
                    break;
                }
            }

            if (errorValue != null)
            {
                errorText.text = errorValue.Replace("\\n", Environment.NewLine);
            }
            else
            {
                Debug.LogError("errorno が見つかりません。");
            }

            if (messageValue != null)
            {
                messageText.text = messageValue.Replace("\\n", Environment.NewLine);
            }
            else
            {
                Debug.LogError("errormessage が見つかりません。");
            }
        }
        else
        {
            Debug.LogError("指定されたファイルが見つかりません。");
        }
    }
}
