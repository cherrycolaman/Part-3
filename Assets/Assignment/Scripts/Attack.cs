using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public float time;
    public float charges;
    bool evade = false;
    // a list of coroutines will be made to complete the attack coroutines in the order the player pressed them
    public List<IEnumerator> attackOrder = new List<IEnumerator>();
    // this is the slider for the time bar
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // slider value is constantly updated
        slider.value = time;
    }
    public void meleebutton()
    {
        // when pressed, adds 30 time and adds melee attack to coroutine list (only if there is enough time)
        if (time<71)
        {
            time += 30;
            attackOrder.Add(MeleeAttack());
        }
    }
    public void firebutton()
    {
        // adds fireball to coroutine list
        if (time<81)
        {
            time += 20;
            attackOrder.Add(Fireball());
        }
    }
    public void icebutton()
    {
        // adds ice to coroutine list
        if (time<56)
        {
            time += 45;
            attackOrder.Add(Ice());
        }
    }
    public void chargebutton()
    {
        // adds charge to coroutine list
        if (time < 93)
        {
            time += 8;
            attackOrder.Add(Charge());
        }
    }
    public void evadebutton()
    {
        // adds evade to coroutine list
        if (time < 41)
        {
            time += 60;
            attackOrder.Add(Evade());
        }
    }
    public void EndTurn()
    {
        // does every coroutine in the list in order
        foreach (IEnumerator coroutine in attackOrder)
        {
            StartCoroutine(coroutine);
        }
        // if the player evaded, there is a 60% chance to avoid the enemy attack. Otherwise, their HP is reduced by enemy's damage
        if (evade == false || Random.Range(0, 99) > 60)
        {
            if (Health.enemyHealth > 0)
            {
                Health.playerHealth -= Health.enemyDamage;
            }
        }
        // charges, evade and time are reset for the next turn
        charges = 0;
        evade = false;
        time = 0;
        // coroutine list is cleared for the next turn
        attackOrder.Clear();
    }
    IEnumerator MeleeAttack()
    {
        // all attacks that do damage will reset the number of charges
        // they will do damage if the hit chance succeeds (affected by charges)
        // +1 damage if the enemy is weak to that type
        if (70 + charges*10 > Random.Range(0, 99))
        {
            Health.enemyHealth -= 4;
            if (Health.enemyType == 0)
            {
                Health.enemyHealth -= 1;
            }
        }
        charges = 0;
        yield return new WaitForSeconds(1);
    }
    IEnumerator Fireball()
    {
        if (60 + charges*10 > Random.Range(0, 99))
        {
            Health.enemyHealth -= 3;
            if (Health.enemyType == 1)
            {
                Health.enemyHealth -= 1;
            }
        }
        charges = 0;
        yield return new WaitForSeconds(1);
    }
    IEnumerator Ice()
    {
        if (80 + charges * 10 > Random.Range(0, 99))
        {
            Health.enemyHealth -= 5;
            if (Health.enemyType == 2)
            {
                Health.enemyHealth -= 1;
            }
        }
        charges = 0;
        yield return new WaitForSeconds(1);
    }
    IEnumerator Charge()
    {
        // increases charges by 1 (+10% hit chance)
        charges += 1;
        yield return new WaitForSeconds(1);
    }

    IEnumerator Evade()
    {
        // player may evade enemy's next attack
        evade = true;
        yield return new WaitForSeconds(1);
    }
}
