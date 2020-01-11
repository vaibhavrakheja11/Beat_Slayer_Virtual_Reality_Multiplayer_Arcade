using UnityEngine;

public class Target : MonoBehaviour
{
	public float health = 100f;


    // Start is called before the first frame update
   public void TakeDamage(float amount)
	{
		health -= amount;

        if(health >=0f)
		{
			Die();
		}
	}

    // Update is called once per frame
    void Die()
    {
		Destroy(gameObject);
    }
}
