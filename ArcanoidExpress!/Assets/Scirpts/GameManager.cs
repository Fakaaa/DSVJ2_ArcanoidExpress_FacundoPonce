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

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("score", 0);
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
    [SerializeField] public int amountBricksRemaining;
    [SerializeField] public int actualBricks;
    [SerializeField] public int bricksDestroyed;

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
    public void SetActualBricks(int amount)
    {
        actualBricks = amount;

        CalcBricksRemaining();
    }
    public void BrickDestroyed()
    {
        bricksDestroyed++;
        CalcBricksRemaining();
    }
    public void CalcBricksRemaining()
    {
        amountBricksRemaining = actualBricks - bricksDestroyed;

        if(amountBricksRemaining <= 0)
            SetStateGame(GameState.Win);
    }
    public void ResetScore()
    {
        scorePlayer = 0;
    }
    public void SetScore(int score)
    {
        scorePlayer += score;

        Player.updateUIData?.Invoke();
    }
    public void SetHighScore(int score)
    {
        if(score > bestScore)
            bestScore = score;

        PlayerPrefs.SetInt("score", bestScore);
        PlayerPrefs.Save();
    }
}
