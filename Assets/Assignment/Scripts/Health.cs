using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static float playerHealth = 15;
    public static float enemyHealth;
    public static int enemyType;
    public float enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        enemyType = Random.Range(0, 2);
        if (enemyType == 0)
        {
            enemyHealth = 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
