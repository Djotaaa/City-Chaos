using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenHandlerScript : MonoBehaviour
{
    [SerializeField] TMP_Text endText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TimerScript timer;
    [SerializeField] AudioSource musicPlayer;
    [SerializeField] GameObject player;

    bool gameEnded = false;

    void Start()
    {
        endText.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
    }

    void Update()
    {
        if (gameEnded)
        {
            EndGameInputReader();
        }
    }

    public void EndGame()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;
        endText.gameObject.SetActive(true);
        timer.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        musicPlayer.gameObject.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<IdleTimeHandler>().enabled = false;
    }

    void EndGameInputReader()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
