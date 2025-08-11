using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputAction xMove;
    [SerializeField] InputAction gas;
    [SerializeField] InputAction brake;
    [SerializeField] AudioClip gasAudio;
    [SerializeField] AudioClip idleAudio;
    [SerializeField] float moveSpeed = 800f;
    [SerializeField] float rotationSpeed = 5f;

    AudioSource audioSource;
    Rigidbody rb;
    float xDirection;
    float gasValue;
    float brakeValue;
    float rotationAngle = 60f;
    bool engineReady = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        xMove.Enable();
        gas.Enable();
        brake.Enable();
    }

    void Start()
    {
        Invoke(nameof(StartEngineAudio), 1.2f);
    }

    void Update()
    {
        xDirection = xMove.ReadValue<float>();
        gasValue = gas.ReadValue<float>();
        brakeValue = brake.ReadValue<float>();
        if (engineReady)
        {
            AudioPlayer();
        }
    }

    void FixedUpdate()
    {
        if (engineReady)
        {
            RotatePlayer();
            ApplyGas();
            ApplyBrake();

        }
    }

    void ApplyGas()
    {
        if (gasValue > 0f)
        {
            AddForce(moveSpeed);
        }
    }

    void ApplyBrake()
    {
        if (brakeValue > 0f)
        {
            AddForce(-moveSpeed);
        }
    }

    void RotatePlayer()
    {
        if (xDirection > 0)
        {
            AddRotation(rotationAngle);
        }
        else if (xDirection < 0)
        {
            AddRotation(-rotationAngle);
        }
    }

    void AudioPlayer()
    {
        if (Mathf.Approximately(gasValue, 0f))
        {
            if (audioSource.clip != idleAudio)
            {
                audioSource.Stop();
                audioSource.clip = idleAudio;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else if (gasValue > 0f)
        {
            if (audioSource.clip != gasAudio)
            {
                audioSource.Stop();
                audioSource.clip = gasAudio;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    void StartEngineAudio()
    {
        engineReady = true;
    }

    void AddForce(float speed)
    {
        rb.AddRelativeForce(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    void AddRotation(float angle)
    {
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(0f, angle, 0f), Time.fixedDeltaTime * rotationSpeed));
    }

}
