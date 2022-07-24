using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrain : MonoBehaviour
{
  public int maxCapacity = 10;
	public int currentPassengers = 0;

	public Trainbar trainBar;
	public GameObject GameOverScreen;
	public GameObject full;

    // Start is called before the first frame update
    void Start()
    {
		trainBar.SetMaxCapacity(maxCapacity);
		trainBar.SetCurrentInTrain(currentPassengers);
    }

   
	public void PassengerEntersTrain(int enter)
	{
		currentPassengers += enter;

		trainBar.SetCurrentInTrain(currentPassengers);

		if(currentPassengers == maxCapacity){
			Time.timeScale = 0f;
			full.SetActive(true);
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
			//ScoreManager.instance.AddPoint(50);
		}
	}		

}
