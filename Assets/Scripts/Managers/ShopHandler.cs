using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    PlayerShooting playerShooting;
    PlayerMovement playerMovement;

    ScoreManager scoreManager;


    void Awake()
    {
        transform.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
    }

    public void showShop()
    {
        Time.timeScale = 0;
        transform.gameObject.SetActive(true);
    }

    public void closeShop()
    {
        Time.timeScale = 1;
        transform.gameObject.SetActive(false);
    }

    public void SemiRifleUpgrade()
    {
        if (ScoreManager.score < 250)
        {
            return;
        }
        playerShooting.SemiRifleUpgrade();
        Button damageButton = GameObject.Find("DamageUpgrade").GetComponent<Button>();
        damageButton.interactable = true;
        ScoreManager.score = ScoreManager.score - 250;
    }

    public void SMGUpgrade()
    {
        if(ScoreManager.score < 800)
        {
            return;
        }
        playerShooting.SMGUpgrade();
        Button damageButton = GameObject.Find("DamageUpgrade").GetComponent<Button>();
        damageButton.interactable = true;
        ScoreManager.score = ScoreManager.score - 800;
    }

    public void RifleUpgrade()
    {
        if (ScoreManager.score < 3000)
        {
            return;
        }
        playerShooting.RifleUpgrade();
        Button damageButton = GameObject.Find("DamageUpgrade").GetComponent<Button>();
        damageButton.interactable = true;
        ScoreManager.score = ScoreManager.score - 3000;
    }

    public void speedUpgrade()
    {
        if (ScoreManager.score < 2500)
        {
            return;
        }
        playerMovement.SpeedUpgrade();
        Button speedButton = GameObject.Find("SpeedUpgrade").GetComponent<Button>();
        speedButton.interactable = false;
        ScoreManager.score = ScoreManager.score - 2500;
    }

    public void healthUpgrade()
    {
        if (ScoreManager.score < 10000)
        {
            return;
        }
        playerHealth.HealthUpgrade();
        Button healthButton = GameObject.Find("HealthUpgrade").GetComponent<Button>();
        healthButton.interactable = false;
        ScoreManager.score = ScoreManager.score - 10000;
    }

    public void reloadUpgrade()
    {
        if (ScoreManager.score < 2500)
        {
            return;
        }
        playerShooting.ReloadUpgrade();
        Button reloadButton = GameObject.Find("ReloadUpgrade").GetComponent<Button>();
        reloadButton.interactable = false;
        ScoreManager.score = ScoreManager.score - 2500;
    }

    public void damageUpgrade()
    {
        if (ScoreManager.score < 5000)
        {
            return;
        }
        playerShooting.DamageUpgrade();
        Button damageButton = GameObject.Find("DamageUpgrade").GetComponent<Button>();
        damageButton.interactable = false;
        ScoreManager.score = ScoreManager.score - 5000;
    }

    public void refillAmmo()
    {
        if (ScoreManager.score < 1000)
        {
            return;
        }
        playerShooting.RefillAmmo();
        ScoreManager.score = ScoreManager.score - 1000;
    }

}
