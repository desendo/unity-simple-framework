using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    [SerializeField] string startScene="menu";
    void Awake()
    {
        if(!string.IsNullOrEmpty(startScene))
            StartCoroutine(LoadYourAsyncScene(startScene));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));

    }
    IEnumerator LoadYourAsyncScene(string sceneName)
    {


        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
