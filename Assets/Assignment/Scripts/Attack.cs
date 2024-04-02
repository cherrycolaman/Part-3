using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float time;
    public float hitChance;
    public float damage;
    public float charges;
    public int element;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Execute()
    {
        if ((hitChance + charges*10) > Random.Range(0, 100))
        {
            SendMessage("TakeDamage", damage);
            if (element = enemyType)
            {
                
            }
        }
    }
}
