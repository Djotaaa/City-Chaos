using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float maxTime;
    [SerializeField] GameObject player;
    [SerializeField] ScreenHandlerScript screenHandler;
    [SerializeField] PoliceChaseTrigger policeTrigger;

    void Update()
    {
        maxTime -= Time.deltaTime;
        timerText.text = ((int)maxTime).ToString();

        if (maxTime < 1)
        {
            player.GetComponent<AudioSource>().enabled = false;
            screenHandler.EndGame();
            policeTrigger.TriggerChase();
            Destroy(gameObject);
        }
    }
}
