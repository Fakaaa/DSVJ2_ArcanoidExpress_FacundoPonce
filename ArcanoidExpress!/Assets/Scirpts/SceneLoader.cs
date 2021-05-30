using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    public static SceneLoader Get()
    {
        return instance;
    }
    public void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
