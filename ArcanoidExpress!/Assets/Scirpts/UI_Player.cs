using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    [SerializeField] public Text lifesPlayer;
    [SerializeField] public Text actualScore;
    [SerializeField] public Text highScorePlayer;

    private Player playerRef;
    void Start()
    {
        playerRef = FindObjectOfType<Player>();

        Player.updateUIData += UpdateUI;
    }
    private void OnDisable()
    {
        Player.updateUIData -= UpdateUI;
    }
    void UpdateUI()
    {
        if(playerRef != null)
            lifesPlayer.text = playerRef.GetPlayerLifes().ToString();
        if(GameManager.Get() != null)
        {
            actualScore.text = GameManager.Get().scorePlayer.ToString();
            highScorePlayer.text = GameManager.Get().bestScore.ToString();
        }
    }
}
