﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("chạm enemy");
            //int dmg = PlayerAttributes.Instance.basePlayer.mAtk;
            collision.GetComponent<Enemy>().GetDmg(5);
        }
    }
}
