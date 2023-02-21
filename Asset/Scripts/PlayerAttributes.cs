using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttributes : MonoBehaviour
{

    //variable to keeo track of currency
    public static int currency;
    public int initialMoney = 500;

    //variables to keep track of lives
    public static int health;
    public int initialHealth = 20;




    // Start is called before the first frame update
    void Start()
    {
        currency = initialMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
