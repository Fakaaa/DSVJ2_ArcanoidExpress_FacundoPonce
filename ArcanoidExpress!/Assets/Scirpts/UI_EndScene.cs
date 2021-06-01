using UnityEngine;
using UnityEngine.UI;

public class UI_EndScene : MonoBehaviour
{
    [SerializeField] public GameObject win;
    [SerializeField] public GameObject lose;
    void Start()
    {
        if(GameManager.Get() != null)
        {
            switch (GameManager.Get().state)
            {
                case GameManager.GameState.Win:
                    win.SetActive(true);
                    lose.SetActive(false);
                    break;
                case GameManager.GameState.Lose:
                    lose.SetActive(true);
                    win.SetActive(false);
                    break;
            }
        }
    }

    void Update()
    {
        
    }
}
