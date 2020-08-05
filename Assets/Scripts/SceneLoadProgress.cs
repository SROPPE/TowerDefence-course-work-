using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadProgress : MonoBehaviour
{
    public int sceneID;
    public Slider slider;
    public Text progressText;

    void Start()
    {
        slider.value = 0;
        StartCoroutine(AsyncLoad());
    }
 
    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
