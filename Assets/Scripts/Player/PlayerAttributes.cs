using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static PlayerAttributes Instance; //null
    public PlayerInfo basePlayer; //thuộc tính cơ bản ban đầu (fix)
    public PlayerInfo playerInfo; //tính toán thuộc tính

    private void Awake()
    {
        if(Instance != null & Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        basePlayer.level = 1;
        basePlayer.requireEXP = 100 * Mathf.Pow(basePlayer.level, 3);
        basePlayer.currentEXP = 0;
        basePlayer.HP = 200;
        basePlayer.currentHP = basePlayer.HP;
        basePlayer.MP = 100;
        basePlayer.currentMP = basePlayer.MP;
        basePlayer.str = 10;
        basePlayer.agi = 12;
        basePlayer.intel = 20;
        basePlayer.pAtk = 20;
        basePlayer.mAtk = 50;
        basePlayer.pDef = 10;
        basePlayer.mDef = 20;
        basePlayer.avoid = 5;
        basePlayer.critical = 5;
        basePlayer.speedMove = 3;

        playerInfo = basePlayer;
    }
}

[System.Serializable] 
public class PlayerInfo
{
    public int level;
    public float requireEXP; //số điểm kinh nghiệm cần đạt được để lên cấp tiếp theo
    public float currentEXP; //số điểm kinh nghiệm hiện tại có
    public int currentHP;
    public int currentMP;
    public int str; //Tăng máu, tăng công vật lý, tăng thủ vật lý
    public int agi; //né tránh, chí mạng, tốc độ
    public int intel; //tăng mana, tăng công phép, tăng thủ phép
    public int HP; //máu
    public int MP; //mana
    public int pAtk; //physic attack
    public int mAtk; //magic attack
    public int pDef; //physic defence
    public int mDef; //magic defence
    public int avoid; //né tránh, tính bằng %
    public int critical; //chí mạng, tính bằng %
    public int speedMove; //tốc độ di chuyển
}
