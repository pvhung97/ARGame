using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour
{
    Text text;
    PlayerShooting playerShooting;
    GameObject player;

    void Awake()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
    }

    void Update()
    {
        text.text = playerShooting.ammoInClip.ToString() + "/" + playerShooting.maxAmmo.ToString();
    }
}
