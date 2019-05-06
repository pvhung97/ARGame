using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public void ScoreCheat()
    {
        ScoreManager.score = ScoreManager.score + 1000;
    }
}
