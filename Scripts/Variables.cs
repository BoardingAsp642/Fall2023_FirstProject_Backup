using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{

    //Name
    public string playerName = "Rose";
    //Assigned team
    public string team = "Red";
    //Walking speed
    public float speed = 5.0f;
    //Running speed multiplier
    public float speedMultiplier = 1.0f;
    //Pieces of armor(take a guess!)
    public int armorPieces = 5;
    //Does the player currently have a weapon(take a guess!)
    public bool hasWeapon = false;
    //Maximum pieces of armor allowed by game(take a guess!)
    public bool armorMax = true;
    //Level of player(take a guess!)
    public int playerLV = 5;
    //Coins(take a guess!)
    public int money = 0;
    //Magic slots allowed(take a guess!)
    public int magicMax = 3;
    //Health(take a guess!)
    public float health = 100.0f;
    //Experience Points(aka XP) (take a guess!)
    public float exp = 0.0f;
    //Has a powerup or not(take a guess!)
    public bool hasPowerup = true;
    //Is the player alive(take a guess!)
    public bool isAlive = true;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintInfo());
    }

    IEnumerator PrintInfo()
    {
        print("Player Username is Rose");
        print("She has been assigned to Red Team");
        print("Current speed is set to 5");
        print("Their class Speed Multiplier is set to 1");
        print("Total Armor slots allowed is 5");
        print("Current weapon is: Pistol(Unequiped)" + "    Please remember to equip all gear before adventuring!");
        print("Curently Rose has the maximum number of armor pieces allowed!");
        print("Player Rose is Level 5!");
        print("Starting money is set to 0!");
        print("Current Magic equiped: 0/3");
        print("Current Health is 100");
        print("Current EXP is: 0/100!");
        print("Player Rose starts with a temporary Speed Boost!");
        print("Player Rose is now being Resurrected into 'The Endless War'!");
        print("Please try to do better with this new life.");



        yield return null;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
