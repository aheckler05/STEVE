using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    int Health = 400;
    int Speed = 30;
    public int Turnmeter = 0;
    int PAttack = 20;
    int MAttack = 20;
    int PResist = 10;
    int MResist = 10;
    string ability1;
    string ability2;

    UnityEvent<bool, int, int, int> AttackEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (AttackEvent == null)
            AttackEvent = new UnityEvent<bool, int, int, int>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackEvent(bool damagetype, int incomingdamage, bool isdebuff, int debufftarget, int debuffamount, string extraeffects)
    {
        



    }
}
