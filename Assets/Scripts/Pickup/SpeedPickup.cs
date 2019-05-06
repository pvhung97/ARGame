using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{

    GameObject player;
    PlayerMovement playerMovement;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        StartCoroutine(SelfDestruct());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Destroy(gameObject);
            playerMovement.Boost();
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
