using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    public static PlayerInfomation instance;
    public PlayerAttributes playerAttributes; //Thông tin thuộc tính hiện tại của nhân vật
    public PlayerAttributes saveAttributes; //Lưu lại thông tin thuộc tính nhân vật

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        playerAttributes.Basic();        
    }
}

[System.Serializable]
public class PlayerAttributes
{
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

    public void Basic()
    {
        level = 1;
        requimentEXP = Mathf.Pow(level, 3) * 60;
        currentEXP = 0;
        maxHP = 200;
        currentHP = maxHP;
        maxMP = 100;
        currentMP = maxMP;
        str = 10;
        agi = 12;
        intel = 20;
        physicDmg = 20;
        magicDmg = 50;
        defPhysicDmg = 10;
        defMagicDmg = 20;
        avoid = 5;
        critical = 5;
        speedMove = 3;
    }

    public void IncrementEXP(int exp)
    {
        currentEXP += exp;
        if (currentEXP >= requimentEXP)
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
}