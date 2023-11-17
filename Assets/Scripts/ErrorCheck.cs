using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ErrorCheck : MonoBehaviour
{
    // チェックするテキストファイルの名前
    public string fileName = "config.txt";

    // エラーがtrueの場合に遷移するシーン名
    public string errorSceneName = "error";

    void Start()
    {
        // StreamingAssetsフォルダ内のファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        // ファイルが存在するか確認
        if (File.Exists(filePath))
        {
            // テキストファイルから文字列を読み込む
            string[] lines = File.ReadAllLines(filePath);

            // テキストファイルの各行を調べる
            foreach (string line in lines)
            {
                // エラーを示す特定の文字列が含まれているかチェック
                if (line.Contains("error=true"))
                {
                    // エラーが見つかった場合、ErrorSceneに遷移する
                    LoadErrorScene();
                    return; // エラーが見つかったら処理を終了
                }
            }
        }
        else
        {
            Debug.LogError("指定されたファイルが見つかりません: " + fileName);
        }
    }

    // エラーシーンに遷移するメソッド
    void LoadErrorScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(errorSceneName);
    }
}
