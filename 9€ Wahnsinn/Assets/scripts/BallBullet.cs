using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Enemy")
      {
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        ScoreManager.instance.AddPoint(100);
      }
    }
}
