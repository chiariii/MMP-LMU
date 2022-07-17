using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private float shootCooldown;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private ScriptSchaffner Schaffner;
    private float cooldownTimer = Mathf.Infinity;

    public float bulletForce = 20f;

    private void Start() {
        Schaffner = GetComponent<ScriptSchaffner>();
    }

    void Update()
    {
        if(Input.GetKeyDown("space") && Schaffner.canShoot() && cooldownTimer > shootCooldown) {
            Shoot();

        }
        cooldownTimer += Time.deltaTime;
    }

    void Shoot() 
    {
        cooldownTimer = 0;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
