using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float groundSpeed;

    [SerializeField] float rotateSensitivity;
    [SerializeField] float verticalSensitivity;

    [SerializeField] Transform ourCam;

    //Where we shoot from
    [SerializeField] Transform projectileSpawn;
    //What we shoot
    [SerializeField] GameObject spearPrefab;

    [SerializeField] float bulletSpeed;
    [SerializeField] float firerate;
    [SerializeField] float nextTimeFire;

    //Player Stats
    [SerializeField] Text HealthText;
    [SerializeField] int health = 100;
    [SerializeField] Text AmmoText;
    [SerializeField] int ammo = 100;

    //[SerializeField] Color HealthColor;
    //[SerializeField] Color AmmoColor;


    private Rigidbody rb;

    //The up and down angle of the mouse
    private float upDownAngle;




    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        AmmoText.text = "Ammo" + ammo.ToString();
        //AmmoText.color = AmmoColor;
        //HealthText.color = HealthColor;
    }





    // Update is called once per frame
    void Update()
    {
        Vector3 ourVelocity = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * groundSpeed;

        rb.velocity = ourVelocity;
        //Horizontal Rotation
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotateSensitivity);



        // Vertical Rotation
        upDownAngle = Mathf.Clamp(Input.GetAxis("Mouse Y") * verticalSensitivity + upDownAngle, -60, 60);



        //print(upDownAngle);
        ourCam.localRotation = Quaternion.Euler(new Vector3(upDownAngle, 0f, 0f));



        //Health Text
        HealthText.text = health.ToString();


        //Ammo Text
        AmmoText.text = ammo.ToString();



        //Shoot projectile

        if (Input.GetButton("Fire1") && Time.time >= nextTimeFire)
        {
            AmmoText.text = "Ammo " + ammo.ToString();
            /*if (ammo < 10)
            {
                AmmoColor = Color.red;

            }
            else if (ammo < 0)
                return;*/
            if (ammo < 0)
                return;
            ammo--;
            nextTimeFire = Time.time + 1f / firerate;
            //Create Projectile
            GameObject theProjectile = Instantiate(spearPrefab, projectileSpawn.position, projectileSpawn.rotation);

            //get the rb
            Rigidbody rb = theProjectile.GetComponent<Rigidbody>();
            //launch it
            rb.velocity = theProjectile.transform.forward * bulletSpeed;

            Destroy(theProjectile, 3f);
         
        }
        
        

    }




    public void TakeHealth(int amount)
    {
        health -= amount;
        if (health <= 20 && health > 0)
        {
            //ourMaterial.color = Color.red;
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


























}
