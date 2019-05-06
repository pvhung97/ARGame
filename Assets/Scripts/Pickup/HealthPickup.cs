using System.Collections;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    GameObject player;
    PlayerHealth playerHealth;
    int healthValue = 100;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        StartCoroutine(SelfDestruct());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Destroy(gameObject);
            playerHealth.Heal(healthValue);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }

}
