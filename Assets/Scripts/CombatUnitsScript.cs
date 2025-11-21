using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class UnitTemplate : MonoBehaviour
{
    public static AudioManager audioManager;
    public int Health;
    public int Speed;
    public int Turnmeter;
    public int PAttack;
    public int MAttack;
    public int PResist;
    public int MResist;
    public string ability1;
    public string ability2;
    public CombatSceneController CSC;

    public List<attackpackage> UsableAttacks=new List<attackpackage>();
    public List<debuff> debuffs = new List<debuff>();

    public List<debuff> genericdebuffs=new List<debuff>();

    public struct debuff{string name;int intensity;int duration;
            public debuff(string n, int i, int d){this.name=n;this.intensity=i;this.duration=d;}
            public debuff(int zero){this.name=null;this.intensity=0;this.duration=0;}
            public string getName(){return this.name;}
            public int getIntensity(){return this.intensity;}
            public int getDuration(){return this.duration;}
            public void setName(string input){if(input!=null){this.name=input;}}
            public void setIntensity(int input){this.intensity=input;}
            public void setDuration(int input){this.duration=input;}
                public void turntick(){this.duration-=1;}
        }

    public struct attackpackage{public bool pom;public int att;public bool isd;public debuff dbf;public string name;
        public attackpackage(bool a,int b,bool c,debuff d,string e){this.pom=a;this.att=b;this.isd=c;this.dbf=d;this.name=e;}
    }



// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    { 
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        debuff poison= new debuff("Poisoned",10,2);
        debuff slow= new debuff("Slowed",10,2);
        debuff hinder= new debuff("Hindered",10,2);
        debuff weaken= new debuff("Weakened",10,2);
        debuff distract= new debuff("Distracted",10,2);
        debuff expose= new debuff("Exposed",10,2);
        debuff hex= new debuff("Hexed",10,2);
        debuff null1= new debuff("Ability 1 Nullified",10,2);
        debuff null2= new debuff("Ability 2 Nullified",10,2);
        genericdebuffs.Add(poison);genericdebuffs.Add(slow);genericdebuffs.Add(hinder);
        genericdebuffs.Add(weaken);genericdebuffs.Add(distract);genericdebuffs.Add(expose);
        genericdebuffs.Add(hex);genericdebuffs.Add(null1);genericdebuffs.Add(null2);
        
        debuff nulldebuff=new debuff(0);
        attackpackage Basic_Physical_Attack=new attackpackage(false,10,false,nulldebuff,"Basic Physical Attack");
        attackpackage Basic_Magical_Attack=new attackpackage(true,10,false,nulldebuff,"Basic Magical Attack");
        UsableAttacks.Insert(0,Basic_Physical_Attack);
        UsableAttacks.Insert(1,Basic_Magical_Attack);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Health <= 0)
        {
            this.Death();
        }
    }
    public void TurnBegin()
    {
        this.Turnmeter=this.Turnmeter-100;
        string tempname="none";
        int tempintensity=0;
        int tempduration=0;
        //for poisoned and hindered, decreases health/turn meter respectively at beginning of the turn (if speed is higher than hindrance strength, it is practically identical to an equivalent slow, this debuff is more meant to decrease turn meter into negatives, delaying turn in one effect, rather than an over time slow, which would be more appropriate for the slowed effect)
        //for all other debuffs handled here, it is just a matter of undoing the stat decrease if the debuff duration expires
        foreach (debuff i in this.debuffs)
        {
            tempname=i.getName();
            tempintensity=i.getIntensity();
            tempduration=i.getDuration();
                switch (tempname)
                {
                case "Poisoned":
                    if (tempduration > 0) { this.Health=this.Health-tempintensity; i.turntick();}
                    else { this.debuffs.Remove(i); }
                    break;
                case "Slowed":
                    if (tempduration > 0) {i.turntick();}
                    else {this.Speed=this.Speed+tempintensity;this.debuffs.Remove(i);}
                    break;
                case "Hindered":
                    if (tempduration > 0) { this.Turnmeter -= tempintensity; i.turntick();}
                    else {this.debuffs.Remove(i);}
                    break;
                case "Weakened":
                    if (tempduration > 0) {i.turntick();}
                    else {this.PAttack += tempintensity;this.debuffs.Remove(i);}
                    break;
                case "Distracted":
                    if (tempduration > 0) {i.turntick();}
                    else {this.MAttack += tempintensity;this.debuffs.Remove(i);}
                    break;
                case "Exposed":
                    if (tempduration > 0) {i.turntick();}
                    else {this.PResist += tempintensity;this.debuffs.Remove(i);}
                    break;
                case "Hexed":
                    if (tempduration > 0) {i.turntick();}
                    else {this.MResist += tempintensity;this.debuffs.Remove(i);}
                    break;
                case "Ability 1 Nullified":
                    if (tempduration > 0) {i.turntick();}
                    else {this.ability1=string.Join("",this.ability1.Split('~'));this.debuffs.Remove(i);}
                    break;
                case "Ability 2 Nullified":
                    if (tempduration > 0) {i.turntick();}
                    else {this.ability1=string.Join("",this.ability1.Split('~'));this.debuffs.Remove(i);}
                    break;
                default:
                    break;
                }
        }
        this.Turninprogress();
    }
    protected virtual void Turninprogress()
    {
        
    }
    public void AttackTarget(EnemyController t, bool damagetype, int outgoingdamage, bool isdebuff, debuff outgoingdebuff, string attackname)  
    {
        //Damagetype=1 indicates Magical, else it is physical
        
        if (damagetype)
        {
            t.Health= t.Health-(outgoingdamage+this.MAttack-t.MResist);
            audioManager.PlaySFX(audioManager.hit);
        }
        else
        {
            t.Health= t.Health-(outgoingdamage+this.PAttack-t.PResist);
            audioManager.PlaySFX(audioManager.hit);
        }

        if (isdebuff)
        {
            t.debuffs.Add(outgoingdebuff);
        }

    }

        public void AttackTarget(PlayerController t, bool damagetype, int outgoingdamage, bool isdebuff, debuff outgoingdebuff, string attackname)  
    {
        //Damagetype=1 indicates Magical, else it is physical
        
        if (damagetype)
        {
            t.Health= t.Health-(outgoingdamage+this.MAttack-t.MResist);
            audioManager.PlaySFX(audioManager.hit);
        }
        else
        {
            t.Health= t.Health-(outgoingdamage+this.PAttack-t.PResist);
            audioManager.PlaySFX(audioManager.hit);
        }

        if (isdebuff)
        {
            t.debuffs.Add(outgoingdebuff);
        }

        if (t.Health <= 0)
        {
            t.Death();
        }

    }
            public void AttackTarget(PlayerController t, attackpackage p)  
    {
        //Damagetype=1 indicates Magical, else it is physical
        
        if (p.pom)
        {
            t.Health= t.Health-(p.att+this.MAttack-t.MResist);
            audioManager.PlaySFX(audioManager.hit);
        }
        else
        {
            t.Health= t.Health-(p.att+this.PAttack-t.PResist);
            audioManager.PlaySFX(audioManager.hit);
        }

        if (p.isd)
        {
            t.debuffs.Add(p.dbf);
        }

        if (t.Health <= 0)
        {
            t.Death();
            audioManager.PlaySFX(audioManager.death);
        }

    }
            public void AttackTarget(EnemyController t, attackpackage p)  
    {
        //Damagetype=1 indicates Magical, else it is physical
        
        if (p.pom)
        {
            t.Health= t.Health-(p.att+this.MAttack-t.MResist);
            audioManager.PlaySFX(audioManager.hit);
        }
        else
        {
            t.Health= t.Health-(p.att+this.PAttack-t.PResist);
            audioManager.PlaySFX(audioManager.hit);
        }

        if (p.isd)
        {
            t.debuffs.Add(p.dbf);
        }

        if (t.Health <= 0)
        {
            t.Death();
            audioManager.PlaySFX(audioManager.death);
        }
    }


    public void Tick()
    {
        this.Turnmeter=this.Turnmeter+this.Speed;
    }
    virtual public void Death()
    {
        
    }
    public void EndTurn()
    {
        CSC.TurnHelper();
    }

}
