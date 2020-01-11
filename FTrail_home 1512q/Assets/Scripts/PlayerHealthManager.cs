using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Image damageImage;
    public float flashSpeed = 5f;
    private bool damaged = false;
    ScoreCalculater sc = new ScoreCalculater();

    void Start()
    {
        Debug.Log("Happy birthday");
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("collider");
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            //clickSource[0].Play();
            other.gameObject.SetActive(false);
            health -= 10;
            Debug.Log("Player Health -------------------->" + health);
            
            sc.setHealth(health);
            //count = count + 1;
            // SetCountText();
            damaged = true;
        }

    }

    public void increaseHealth()
    {
        health += 50;
        
        sc.setHealth(health);

    }
}
