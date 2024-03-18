using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public Villager.ChestType type;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Villager villager = collision.gameObject.GetComponent<Villager>();
        if (villager != null)
        {
            if (villager.CanOpen() == type || type == Villager.ChestType.Villager)
            {
                animator.SetBool("IsOpened", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsOpened", false);
    }
}
