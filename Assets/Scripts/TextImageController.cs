using UnityEngine;
using UnityEngine.UI;

public class TextImageController : MonoBehaviour
{
    public Text textField; // UI�e�L�X�g
    public RawImage imageField; // UI�C���[�W
    public float imageOffset = 20f; // �摜�̃e�L�X�g����̃I�t�Z�b�g

    void Update()
    {
        // �e�L�X�g�̓��e�ɍ��킹�ĉ摜�𓮂���
        float textWidth = textField.preferredWidth;
        float imagePosition = textWidth / 2 + imageOffset;
        imageField.rectTransform.localPosition = new Vector3(-imagePosition, -288, 0);
    }

    // �e�L�X�g��ύX���郁�\�b�h
    public void ChangeText(string newText)
    {
        textField.text = newText;
    }
}
