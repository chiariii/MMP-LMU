using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrain : MonoBehaviour
{
  public int maxCapacity = 10;
	public int currentCapacity;

	public Trainbar trainBar;
	public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
		currentCapacity = 0;
		trainBar.SetMaxCapacity(maxCapacity);
    }

   
	public void PassengerEntersTrain(int enter)
	{
		currentCapacity += enter;

		trainBar.SetCapacity(currentCapacity);

		if(currentCapacity == maxCapacity){
			Time.timeScale = 0f;
        	GameOverScreen.SetActive(true);
			//UnityEditor.EditorApplication.isPlaying = false;
			//Application.Quit();
		}
	}

private void OnCollisionEnter2D(Collision2D collision){
	if (collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			PassengerEntersTrain(1);
			ScoreManager.instance.AddPoint(50);
		}
	}		

}
