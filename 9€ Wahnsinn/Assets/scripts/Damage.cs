using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public Healthbar healthBar;

	public GameObject GameOverScreen;
	public GameObject youDiedScreen;


  void Start()
  {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
  }

   
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if(currentHealth <= 0){
			Time.timeScale = 0f;
			youDiedScreen.SetActive(true);
      GameOverScreen.SetActive(true);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
	if (collision.gameObject.tag == "Enemy")
		{
			TakeDamage(10);
		}
	}


}

