using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{

    //Variables
    [SerializeField] int damageAmount = 10;


    //private TakeDamage damageScript;
    private AfterMe theEnemyController;


    private void OnTriggerEnter(Collider other)
    {
        //damageScript = other.gameObject.GetComponent<TakeDamage>();

        ////its okay to have no curly brackets here if its only one line of code
        /////if(damageScript ==null)
        /////return;
        //damageScript.health -= damageAmaount;

        theEnemyController = other.GetComponent<AfterMe>();
        if (theEnemyController == null)
            return;


        theEnemyController.TakeHealth(damageAmount);
        
    }




}
