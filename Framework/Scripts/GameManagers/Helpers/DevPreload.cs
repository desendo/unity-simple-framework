using UnityEngine;

public class DevPreload : MonoBehaviour
{
    [SerializeField]  string SceneName = "preload";

    void Awake()
    {

#if UNITY_EDITOR
        GameObject check = GameObject.Find("_app");
        if (check == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
        }

#endif
    }
}