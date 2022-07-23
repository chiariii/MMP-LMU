using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private AudioClip shot;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    

    public void Fire() 
    {
    SoundManager.Instance.PlaySound(shot); 
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
