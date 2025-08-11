using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField] GameObject[] obstacleObjects;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject obstacleObject in obstacleObjects)
            {
                obstacleObject.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}
