using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;

    [Header("Enemy fire")]
    [SerializeField] float shotCounter;
    [SerializeField] float projectileSpeed;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [Header("Enemy Sounds")]
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip EnemySFX;
    [SerializeField] [Range(0,1)]float deathSoundVolume = .7f;
    [SerializeField] AudioClip EnemyShootSFX;
    [SerializeField] [Range(0, 1)] float Enemyshoot = .7f;
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        counterShoot();
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void counterShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    
    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(EnemyShootSFX, Camera.main.transform.position, Enemyshoot);
        GameObject projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Damage damage = other.gameObject.GetComponent<Damage>();
        if (!damage) { return; }
        //below is how the hit from projectile is processed
        health -= damage.getDamage();
        //if there is a collision on the projectile destroy it *damage script
        damage.hit();
        if (health >= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(EnemySFX, Camera.main.transform.position, deathSoundVolume);
        FindObjectOfType<GameSession>().addToScore(scoreValue);
    }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].