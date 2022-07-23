using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public Healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

   
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if(currentHealth == 0){
			UnityEditor.EditorApplication.isPlaying = false;
			Application.Quit();
		}
	}


	private void OnCollisionEnter2D(Collision2D collision){
	if (collision.gameObject.tag == "Enemy")
		{
			TakeDamage(10);
		}
	}


}

