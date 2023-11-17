using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ErrorCheck : MonoBehaviour
{
    // �`�F�b�N����e�L�X�g�t�@�C���̖��O
    public string fileName = "config.txt";

    // �G���[��true�̏ꍇ�ɑJ�ڂ���V�[����
    public string errorSceneName = "error";

    void Start()
    {
        // StreamingAssets�t�H���_���̃t�@�C���p�X���擾
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        // �t�@�C�������݂��邩�m�F
        if (File.Exists(filePath))
        {
            // �e�L�X�g�t�@�C�����當�����ǂݍ���
            string[] lines = File.ReadAllLines(filePath);

            // �e�L�X�g�t�@�C���̊e�s�𒲂ׂ�
            foreach (string line in lines)
            {
                // �G���[����������̕����񂪊܂܂�Ă��邩�`�F�b�N
                if (line.Contains("error=true"))
                {
                    // �G���[�����������ꍇ�AErrorScene�ɑJ�ڂ���
                    LoadErrorScene();
                    return; // �G���[�����������珈�����I��
                }
            }
        }
        else
        {
            Debug.LogError("�w�肳�ꂽ�t�@�C����������܂���: " + fileName);
        }
    }

    // �G���[�V�[���ɑJ�ڂ��郁�\�b�h
    void LoadErrorScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(errorSceneName);
    }
}
