using UnityEngine;

public class IdleTimeHandler : MonoBehaviour
{
    [SerializeField] float maxIdleTime = 1.8f;
    [SerializeField] PoliceChaseTrigger policeTrigger;
    [SerializeField] ScreenHandlerScript screenHandler;

    float idleTime;
    float currentZ;
    float maxZReached;

    void Start()
    {
        maxZReached = transform.position.z;
    }

    void Update()
    {
        CheckIdleTime();
    }

    void CheckIdleTime()
    {
        currentZ = transform.position.z;

        if (currentZ > maxZReached)
        {
            maxZReached = currentZ;
            idleTime = 0f;
        }
        else
        {
            idleTime += Time.deltaTime;

            if (idleTime >= maxIdleTime)
            {
                EndLevel();
            }
        }
    }

    void EndLevel()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;
        screenHandler.EndGame();
        policeTrigger.TriggerChase();
    }
}
