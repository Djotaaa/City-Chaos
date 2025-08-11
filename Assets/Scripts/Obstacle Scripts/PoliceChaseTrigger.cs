using System.Collections;
using UnityEngine;

public class PoliceChaseTrigger : MonoBehaviour
{
    [SerializeField] GameObject policeObject;
    [SerializeField] Transform player;
    [SerializeField] float spawnPosition = 10f;
    [SerializeField] float speed = 5f;
    [SerializeField] float distance = 4f;

    public void TriggerChase()
    {
        policeObject.transform.position = player.position - new Vector3(0f, 0f, spawnPosition);
        policeObject.SetActive(true);

        StartCoroutine(MoveToPlayer());
    }

    IEnumerator MoveToPlayer()
    {
        while (Vector3.Distance(policeObject.transform.position, player.position) > distance)
        {
            policeObject.transform.position = Vector3.MoveTowards(
            policeObject.transform.position,
            player.position,
            speed * Time.deltaTime
            );
            yield return null;
        }
    }

}
