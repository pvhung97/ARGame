using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    GameObject player;
    PlayerShooting playerShooting;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
        StartCoroutine(SelfDestruct());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            GameObject parent = transform.parent.gameObject;
            Destroy(parent);
            playerShooting.RefillAmmo();
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(20f);
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }
}
