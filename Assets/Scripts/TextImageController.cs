using UnityEngine;
using UnityEngine.UI;

public class TextImageController : MonoBehaviour
{
    public Text textField; // UIテキスト
    public RawImage imageField; // UIイメージ
    public float imageOffset = 20f; // 画像のテキストからのオフセット

    void Update()
    {
        // テキストの内容に合わせて画像を動かす
        float textWidth = textField.preferredWidth;
        float imagePosition = textWidth / 2 + imageOffset;
        imageField.rectTransform.localPosition = new Vector3(-imagePosition, -288, 0);
    }

    // テキストを変更するメソッド
    public void ChangeText(string newText)
    {
        textField.text = newText;
    }
}
