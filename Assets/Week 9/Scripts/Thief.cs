using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
    protected override void Attack()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Attack();
        Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
}
