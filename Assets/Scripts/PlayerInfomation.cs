using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    public static PlayerInfomation instance;

    public int level;
    public float requimentEXP;
    public float currentEXP;
    public int maxHP;
    public int currentHP;
    public int maxMP;
    public int currentMP;
    public int str; //tăng công & thủ vật lý
    public int agi; //tăng tốc độ di chuyển né tránh và critical
    public int intel; //tăng công & thủ phép
    public int physicDmg;
    public int magicDmg;
    public int defPhysicDmg;
    public int defMagicDmg;
    public int avoid; //%
    public int critical; //%
    public float speedMove;

    public void IncrementEXP(int exp)
    {
        currentEXP += exp;
        if(currentEXP >= requimentEXP)
        {
            level++;
            requimentEXP = Mathf.Pow(level, 3) * 60;
            currentEXP = 0;
            maxHP += Mathf.RoundToInt((maxHP * 2) / 100);
            currentHP = maxHP;
            maxMP += Mathf.RoundToInt((maxMP * 5) / 100);
            currentMP = maxMP;
            str += 3;
            agi += 5;
            intel += 7;
            physicDmg += 7;
            magicDmg += 7;
            defPhysicDmg += 7;
            defMagicDmg += 7;
            avoid += 1;
            critical += 1;
            speedMove += 0.1f;
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

}