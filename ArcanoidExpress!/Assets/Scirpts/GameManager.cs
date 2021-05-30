using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public enum GameState
    {
        Win,
        Lose,
        InGame,
        InMenu
    }
    [SerializeField] public GameState state;
    [SerializeField] public int scorePlayer;
    [SerializeField] public int bestScore;

    public void SetStateGame(GameState actualState)
    {
        switch (actualState)
        {
            case GameState.Win:
                if (SceneLoader.Get() != null)
                    SceneLoader.Get().LoadScene("EndScene");
                break;
            case GameState.Lose:
                if (SceneLoader.Get() != null)
                    SceneLoader.Get().LoadScene("EndScene");
                break;
            case GameState.InGame:
                if (SceneLoader.Get() != null)
                    SceneLoader.Get().LoadScene("InGame");
                break;
            case GameState.InMenu:
                if (SceneLoader.Get() != null)
                    SceneLoader.Get().LoadScene("MainMenu");
                break;
        }
        state = actualState;
    }
    public void SetScore(int score)
    {
        scorePlayer = score;
    }
    public void SetHighScore(int score)
    {
        if(score > bestScore)
            bestScore = score;
    }
}
