using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public float time;
    public float charges;
    bool evade = false;
    public List<IEnumerator> attackOrder = new List<IEnumerator>();
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = time;
    }
    public void meleebutton()
    {
        if (time<71)
        {
            time += 30;
            attackOrder.Add(MeleeAttack());
        }
    }
    public void firebutton()
    {
        if (time<81)
        {
            time += 20;
            attackOrder.Add(Fireball());
        }
    }
    public void icebutton()
    {
        if (time<56)
        {
            time += 45;
            attackOrder.Add(Ice());
        }
    }
    public void chargebutton()
    {
        if (time < 93)
        {
            time += 8;
            attackOrder.Add(Charge());
        }
    }
    public void evadebutton()
    {
        if (time < 41)
        {
            time += 60;
            attackOrder.Add(Evade());
        }
    }
    public void EndTurn()
    {
        foreach (IEnumerator coroutine in attackOrder)
        {
            StartCoroutine(coroutine);
        }
        if (evade == false || Random.Range(0, 99) > 60)
        {
            if (Health.enemyHealth > 0)
            {
                Health.playerHealth -= Health.enemyDamage;
            }
        }
        charges = 0;
        evade = false;
        time = 0;
        attackOrder.Clear();
    }
    IEnumerator MeleeAttack()
    {
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
        charges += 1;
        yield return new WaitForSeconds(1);
    }

    IEnumerator Evade()
    {
        evade = true;
        yield return new WaitForSeconds(1);
    }
}
