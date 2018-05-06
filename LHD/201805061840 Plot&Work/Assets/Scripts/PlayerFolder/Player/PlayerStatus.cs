using UnityEngine;
using UnityEditor;

public class PlayerStatus
{
    public int INITHP = 0;
    public int INITSPEED = 0;
    public int INITATTACK = 0;
    public int speed = 0;
    public int HP = 0;
    public int attack = 0;

    public PlayerStatus(PlayerStatus stauts)
    {
        this.INITHP = stauts.INITHP;
        this.INITSPEED = stauts.INITSPEED;
        this.INITATTACK = stauts.INITATTACK;
        this.speed = stauts.speed;
        this.HP = stauts.HP;
        this.attack = stauts.attack;
    }
    public PlayerStatus()
    {
        this.INITHP = 0;
        this.INITSPEED = 0;
        this.INITATTACK = 0;
        this.speed = 0;
        this.HP = 0;
        this.attack = 0;
    }
}