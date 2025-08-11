using UnityEngine;

public class SuccessEndGameHandler : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] GameObject player;
    [SerializeField] ScreenHandlerScript screenHandlerScript;

    void OnTriggerEnter(Collider other)
    {
        ShowCharacter();
        DisablePlayerAudio();
        screenHandlerScript.EndGame();      
    }

    void ShowCharacter()
    {
        character.SetActive(true);
    }

    void DisablePlayerAudio()
    {
        player.GetComponent<AudioSource>().enabled = false;

    }
}
