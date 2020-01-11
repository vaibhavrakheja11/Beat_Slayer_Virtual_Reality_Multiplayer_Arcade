using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreCalculater : MonoBehaviour
{

    private int score;
    public TMPro.TextMeshPro text;
    public TMPro.TextMeshPro text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int enemies_killed, int headshots)
    {
        score = (enemies_killed * 5) * ((headshots * 5) + 1);
        text.text = score.ToString();
    }
    public void setHealth(int health)
    {
        text2.text = (Math.Abs(health /10)).ToString();
    }
}
