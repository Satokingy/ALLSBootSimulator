using UnityEngine;
using UnityEngine.UI;

public class loadlogo : MonoBehaviour
{
    public Image imageComponent;

    void Start()
    {
        StartCoroutine(LoadImage());
    }

    System.Collections.IEnumerator LoadImage()
    {
        string imagePath = System.IO.Path.Combine(Application.streamingAssetsPath, "logo.png");

        // Check if the path is a file:// URL or a real file system path
        if (imagePath.Contains("://") || imagePath.Contains(":///"))
        {
            // For Android or WebGL, use UnityWebRequest to get the file
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequestTexture.GetTexture(imagePath);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture2D texture = ((UnityEngine.Networking.DownloadHandlerTexture)www.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                imageComponent.sprite = sprite;
            }
        }
        else
        {
            // For other platforms, use the file system directly
            byte[] fileData = System.IO.File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            imageComponent.sprite = sprite;
        }
    }
}
