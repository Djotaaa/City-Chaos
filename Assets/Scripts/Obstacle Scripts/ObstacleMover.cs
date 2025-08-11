using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    Vector3 finalPosition;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        if (transform.position.x < 0)
        {
            ObstacleTransform(70f);
        }
        else
        {
            ObstacleTransform(-70f);
        }
    }

    void Update()
    {
        MoveObject();
        DestroyWhenReached();
    }

    void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
    }

    void DestroyWhenReached()
    {
        if (transform.position == finalPosition)
        {
            Destroy(gameObject);
        }
    }

    void ObstacleTransform(float xValue)
    {
        finalPosition = transform.position + new Vector3(xValue, 0f, 0f);
    }
}
