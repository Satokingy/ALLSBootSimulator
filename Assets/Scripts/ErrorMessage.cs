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
        string filePath = Path.Combine(Application.streamingAssetsPath, "config.txt"); // �t�@�C������K�؂Ȃ��̂ɒu��������

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
                    // �����̒l�����������烋�[�v���I��
                    break;
                }
            }

            if (errorValue != null)
            {
                errorText.text = errorValue.Replace("\\n", Environment.NewLine);
            }
            else
            {
                Debug.LogError("errorno ��������܂���B");
            }

            if (messageValue != null)
            {
                messageText.text = messageValue.Replace("\\n", Environment.NewLine);
            }
            else
            {
                Debug.LogError("errormessage ��������܂���B");
            }
        }
        else
        {
            Debug.LogError("�w�肳�ꂽ�t�@�C����������܂���B");
        }
    }
}
