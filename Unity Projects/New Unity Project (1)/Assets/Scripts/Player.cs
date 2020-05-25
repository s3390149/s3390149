using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar barHealth;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float playerPadding = 1;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float needleSpeed = 5f;
    float firingTime = 0.1f;
    [SerializeField] float health = 1000;
    [SerializeField] AudioClip PlayerSFX;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = .7f;
    [SerializeField] AudioClip PlayerShootSFX;
    [SerializeField] [Range(0, 1)] float shootVolume = .7f;

    //coroutine
    Coroutine firing;
    

    float xMin;
    float xMax;
    float yMin;
    float yMax;
  


    private void Start()
    {
        SetUpPlayerBoundaries();
        barHealth.setMax(health);
    }

    void Update()
    {

        playerMove();
        Attack();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Damage damage = other.gameObject.GetComponent<Damage>();
        //below is how the hit from projectile is processed
        if (!damage) { return; }
        health -= damage.getDamage();
        barHealth.changeHealth(health);
        //if there is a collision on the projectile destroy it *damage script
        damage.hit();
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(PlayerSFX, Camera.main.transform.position, deathSoundVolume);
            Destroy(gameObject);
            FindObjectOfType<Load>().loadGameOver();
        }

    }
    public float getPlayerLives()
    {
        return health;
    }
    private void Attack()
        //Starting and stopping coroutines based on the player input
        //e.g. button pressed will start the coroutine and releasing 
        //button up will stop the coroutine
    {
        if (Input.GetButtonDown("Fire1"))
        {

          firing = StartCoroutine(repeatFire());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firing);
        }
    }
    IEnumerator repeatFire()
        //coroutine 
        {
        // while true is true which will always be true ...... LOL 
        while (true)
        {
            // Object, position and rotation Quaternion.identity (current rotation)
            //declaring new game object as a game object with the above
            GameObject needle = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(PlayerShootSFX, Camera.main.transform.position, shootVolume);
            //Adding a rigidbody component to allow the needle to move by setting the horizontal axis to 0
            // Verticle axis to needle speed.
            needle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, needleSpeed);
            //coroutines must have a yield return and this particular return will wait for the firingTime to execute again
            // and spawn more objects
            yield return new WaitForSeconds(firingTime);
        }
        }
   

    private void SetUpPlayerBoundaries()
    {
        //using camera object specifically the main camera
        Camera mainCamera = Camera.main;
        //setting the minimum and maximum viewport of the camera to x and y values
        //bottom left (0,0) bottom right (1,0), top left (0, 1) top right (1,1) are the x and y coordinates
        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerPadding;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerPadding;

        yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerPadding;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerPadding;
        // plus or minus padding is minimum plus padding and maximum minus padding to make the game area
        //limited so player does not move off the screen.
    }

    // Update is called once per frame


    private void playerMove()
    {
        //Setting the horizontal axis in Edit> Input > Axis > horizontal to times 
        //delta time (rate in which each frame is processed) multiplied by a move speed.
        var deltX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPOS = Mathf.Clamp(transform.position.x + deltX, xMin, xMax);
        
        var deltY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPOS = Mathf.Clamp(transform.position.y + deltY, yMin, yMax);

        //mathf.clamp limiting the range of a value with a minimum and maximum
        // Mathf.clamp(value, min, max)

        //position of the current game object "player" to the new positions
        transform.position = new Vector2(newXPOS, newYPOS);
    }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].