using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public Image loadingimg;

    // Start is called before the first frame update
    public void LoadScene(int index)
    {
        StartCoroutine(LoadingScene(index));

    }


    IEnumerator LoadingScene(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            try
            {
                loadingimg.color = new Color(loadingimg.color.r, loadingimg.color.g, loadingimg.color.b, progress);
            }
            catch (System.Exception)
            {

                Debug.Log(progress);
            }

            yield return null;
        }
    }
}
