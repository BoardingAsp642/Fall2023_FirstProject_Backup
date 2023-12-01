using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AfterMe : MonoBehaviour
{
    [SerializeField] GameObject followobject;
    [SerializeField] GameObject spearPrefab;
    [SerializeField] GameObject firstPosition;

    [SerializeField] GameObject secondPosition;

    [SerializeField] GameObject thirdPosition;
    private GameObject nextPosition;

    [SerializeField] float speed;

    private Renderer sphereRenderer;
    private Renderer cubeRenderer;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] float shootDistance;
    [SerializeField] float bulletSpeed;
    [SerializeField] float firerate;
    [SerializeField] float nextTimeFire;

    [SerializeField] GameObject Player;

    private Material ourMaterial;

    [SerializeField] int health = 100;
    [SerializeField] int ammo = 20;

    [SerializeField] Text HealthText;
    [SerializeField] Text AmmoText;
    [SerializeField] Color HealthColor;
    [SerializeField] Color AmmoColor;

    void Start()
    {
        //nextPosition = firstPosition;

        ourMaterial = GetComponent<Material>();

        sphereRenderer = firstPosition.GetComponent<Renderer>();
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = new Color (139f, 0f, 211f);


        // assign the first position as the next position
        nextPosition = firstPosition;
    }

    // Update is called once per frame
    void Update()
    {


        //Health Text
        HealthText.text = health.ToString();


        //Ammo Text
        AmmoText.text = ammo.ToString();


        float distance = Vector3.Distance(Player.transform.position , transform.position);



        if(distance < shootDistance)
        {
            FIRE();

        }
        else
        {
            Patrol();
        }


    }

    public void TakeHealth(int amount)
    {
        health -= amount;
        if(health <= 20 && health >0)
        {
            ourMaterial.color = Color.red;
        }
        else if(health <= 0)
        {
            Destroy(gameObject);
        }
    }



    public void FIRE()
    {


        transform.LookAt(followobject.transform);


        if (Time.time <= nextTimeFire)
        {

            nextTimeFire = Time.time + 1f / firerate;
            //Create Projectile
            GameObject theProjectile = Instantiate(spearPrefab, projectileSpawn.position, projectileSpawn.rotation);
            print("I Shoot You");

            //get the rb
            Rigidbody rb = theProjectile.GetComponent<Rigidbody>();
            //launch it
            rb.velocity = theProjectile.transform.forward * bulletSpeed;

            Destroy(theProjectile, 3f);
        }




    }



    void Patrol()
    {
        transform.LookAt(nextPosition.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, nextPosition.transform.position, speed);
        //when the object arrives at the first position change the color
        if (transform.position == firstPosition.transform.position)
        {
            //cubeRenderer.material.color = sphereRenderer.material.color;
            nextPosition = secondPosition;
        }
        else if (transform.position == secondPosition.transform.position)
        {
            nextPosition = thirdPosition;
            // cubeRenderer.material.color = Color.red;
        }
        else if (transform.position == thirdPosition.transform.position)
        {
            nextPosition = firstPosition;
            // cubeRenderer.material.color = Color.yellow;
        }
    }






}
