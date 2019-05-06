using System.Collections;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float startspawnTime;
    public float repeatTime;
    public float reduceStart;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", startspawnTime, repeatTime);
        StartCoroutine(CutOff());
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    IEnumerator CutOff()
    {
        yield return new WaitForSeconds(reduceStart);
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 0f, 2.5f);
    }
}
