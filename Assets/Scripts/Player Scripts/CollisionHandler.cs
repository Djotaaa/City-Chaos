using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashAudio;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] PoliceChaseTrigger policeTrigger;
    [SerializeField] ScreenHandlerScript screenHandler;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            StartCrashSequence(crashAudio, crashParticle);

            screenHandler.EndGame();
            policeTrigger.TriggerChase();
        }
    }

    void StartCrashSequence(AudioClip audio, ParticleSystem particle)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audio);
        particle.Play();
    }
}
