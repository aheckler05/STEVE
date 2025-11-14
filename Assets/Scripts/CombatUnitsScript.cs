using UnityEngine;
using UnityEngine.Events;

public class UnitTemplate : MonoBehaviour
{
    int Health;
    int Speed;
    public int Turnmeter;
    int PAttack;
    int MAttack;
    int PResist;
    int MResist;
    string ability1;
    string ability2;

    List<(string d, int i, int t)> debuff = new List<(string d, int i, int t)>();

    UnityEvent<bool, int, bool, int, int, int, string> AttackReceive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (AttackReceive == null)
            AttackReceive = new UnityEvent<bool, int, bool, int, int, int, string>();
        AttackReceive.AddListener(AttackEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnBegin()
    {
        //for poisoned and hindered, decreases health/turn meter respectively at beginning of the turn (if speed is higher than hindrance strength, it is practically identical to an equivalent slow, this debuff is more meant to decrease turn meter into negatives, delaying turn in one effect, rather than an over time slow, which would be more appropriate for the slowed effect)
        //for all other debuffs handled here, it is just a matter of undoing the stat decrease if the debuff duration expires
        foreach ((string, int, int) i in this.debuff)
        {
                switch (i.Item1)
                {
                case "Poisoned":
                    if (i.Item3 > 0) { this.Health -= i.Item2; i.item3--;}
                    else { this.debuff.Remove(i); }
                    break;
                case "Slowed":
                    if (i.Item3 > 0) {i.item3--;}
                    else {this.Speed += i.Item2;this.debuff.Remove(i);}
                    break;
                case "Hindered":
                    if (i.Item3 > 0) { this.Turnmeter -= i.Item2; i.item3--;}
                    else {this.debuff.Remove(i);}
                    break;
                case "Weakened":
                    if (i.Item3 > 0) {i.item3--;}
                    else {this.PAttack += i.Item2;this.debuff.Remove(i);}
                    break;
                case "Distracted":
                    if (i.Item3 > 0) {i.item3--;}
                    else {this.MAttack += i.Item2;this.debuff.Remove(i);}
                    break;
                case "Exposed":
                    if (i.Item3 > 0) {i.item3--;}
                    else {this.PResist += i.Item2;this.debuff.Remove(i);}
                    break;
                case "Hexed":
                    if (i.Item3 > 0) {i.item3--;}
                    else {this.MResist += i.Item2;this.debuff.Remove(i);}
                    break;
                case "Ability 1 Nullified":
                    if (i.Item3 > 0) {i.item3--;}
                    else {this.ability1=string.Join("",this.ability1.Split('~'));this.debuff.Remove(i);}
                    break;
                case "Ability 2 Nullified":
                    if (i.Item3 > 0) {i.item3--;}
                    else {this.ability1=string.Join("",this.ability1.Split('~'));this.debuff.Remove(i);}
                    break;
                default:
                    break;
                }
        }
    
    }
    public void AttackEvent(bool damagetype, int incomingdamage, bool isdebuff, int debufftarget, int debuffamount, int debuffduration, string extraeffects)
    {
        //Damagetype=1 indicates Magical, else it is physical
        //debuffduration is a measure of how many turns a statistical debuff will last (or poisoning/other DoTs)
        //extraeffects will largely be for debuffs not affecting character statistics (i.e. confusion or blindness)
        //extraeffects will use debuffduration if applicable, statistical debuffs and special debuffs should not be applied on the same attack, for balance and simplicity
        if (damagetype)
        {
            this.Health -= (incomingdamage - this.MResist);
        }
        else
        {
            this.Health -= (incomingdamage - this.PResist);
        }

        if (isdebuff)
        {
            switch (debufftarget)
            {
                case 1:
                    this.debuff.Add(("Poisoned", debuffamount, debuffduration));
                    break;
                case 2:
                    this.debuff.Add(("Slowed", debuffamount, debuffduration));
                    this.Speed -= debuffamount;
                    break;
                case 3:
                    this.debuff.Add(("Hindered", debuffamount, debuffduration));
                    this.Turnmeter -= debuffamount;
                    break;
                case 4:
                    this.debuff.Add(("Weakened", debuffamount, debuffduration));
                    this.PAttack -= debuffamount;
                    break;
                case 5:
                    this.debuff.Add(("Distracted", debuffamount, debuffduration));
                    this.MAttack -= debuffamount;
                    break;
                case 6:
                    this.debuff.Add(("Exposed", debuffamount, debuffduration));
                    this.PResist -= debuffamount;
                    break;
                case 7:
                    this.debuff.Add(("Hexed", debuffamount, debuffduration));
                    this.MResist -= debuffamount;
                    break;
                case 8:
                    this.debuff.Add(("Ability 1 Nullified", debuffamount, debuffduration));
                    this.ability1 += "~";
                    break;
                case 9:
                    this.debuff.Add(("Ability 2 Nullified", debuffamount, debuffduration));
                    this.ability1 += "~";
                    break;
                default:
                    break;
            }
        }

        switch (extraeffects)
        {
            case "Confused": //do something that isn't a statistical debuff or damage //i.e. confusion would give a percentage chance to damage yourself on attacking, etc.
                break;
            case "Blinded": //crab sand in eyes effect, chance to have attack do less or 0 damage, evaluated when attack is declared, debuffamount would determine the percent accuracy decrease and/or the damage reduction
                break;
            case "Baited": //would force player to only attack a specific target, debufftarget would hold a numerical ID for which enemy this effect should target
            default: break;
        }

        if (this.Health <= 0)
        {
            this.Death();

        }

    }



}
