using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : UnitTemplate
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public string variant;
    public int eID;
    System.Random rand=new System.Random();
    debuff nulldebuff=new debuff(0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (this.variant)
        {
        case "Shark":
            this.Health=100;
            this.Speed=20;
            this.PAttack=25;
            this.MAttack=5;
            this.PResist=100;
            this.MResist=5;
            this.ability1="Physical Resistance";
            this.UsableAttacks.Add(new attackpackage(false,15,false,nulldebuff,"Bite"));
            this.UsableAttacks.Add(new attackpackage(true,0,true,genericdebuffs[3],"Growl"));
            break;
        case "Pufferfish":
            this.Health=100;
            this.Speed=10;
            this.PAttack=5;
            this.MAttack=5;
            this.PResist=10;
            this.MResist=10;
            this.ability1="Poisonous";
            this.UsableAttacks.Add(new attackpackage(false,5,false,nulldebuff,"Nibble"));
            this.UsableAttacks.Add(new attackpackage(false,0,false,nulldebuff,"Puff Up"));
            break;
        case "Dolphin":
            this.Health=100;
            this.Speed=20;
            this.PAttack=5;
            this.MAttack=25;
            this.PResist=5;
            this.MResist=100;
            this.ability1="Magic Resistance";
            this.UsableAttacks.Add(new attackpackage(true,0,false,genericdebuffs[6],"Echolocation"));
            this.UsableAttacks.Add(new attackpackage(true,15,false,nulldebuff,"Targeted Sonar"));
            break;
        case "Crab":
            this.Health=100;
            this.Speed=10;
            this.PAttack=20;
            this.MAttack=15;
            this.PResist=15;
            this.MResist=10;
            this.ability1="Sand Toss";
            this.UsableAttacks.Add(new attackpackage(true,0,true,genericdebuffs[4],"Crab Dance"));
            this.UsableAttacks.Add(new attackpackage(false,10,true,genericdebuffs[5]," Firm Pinch"));
            break;
        case "Octopus":
            this.Health=100;
            this.Speed=15;
            this.PAttack=10;
            this.MAttack=20;
            this.PResist=5;
            this.MResist=15;
            this.ability1="Multi Attack";
            this.UsableAttacks.Add(new attackpackage(false,10,true,genericdebuffs[1],"Fish Punch"));
            this.UsableAttacks.Add(new attackpackage(true,10,false,nulldebuff,"Tentawhip"));
            break;
        case "Starfish":
            this.Health=100;
            this.Speed=10;
            this.PAttack=10;
            this.MAttack=10;
            this.PResist=15;
            this.MResist=15;
            this.ability1="Regeneration";
            this.UsableAttacks.Add(new attackpackage(false,5,false,nulldebuff,"Slap"));
            this.UsableAttacks.Add(new attackpackage(true,5,false,nulldebuff,"Spin"));
            break;
        case "Fisherman":
            this.Health=400;
            this.Speed=20;
            this.PAttack=50;
            this.MAttack=30;
            this.PResist=15;
            this.MResist=35;
            this.ability1="Catch of the Day";
            this.ability2="Baited Hook";   
            this.UsableAttacks.Add(new attackpackage(false,10,false,nulldebuff,"Spearfishing"));
            this.UsableAttacks.Add(new attackpackage(true,0,true,new debuff("Baited", 10,2),"Hook Line and Sinker"));    
            this.UsableAttacks.Add(new attackpackage(false,5,true,genericdebuffs[4],"Surface Slap"));
            break;
        case "Whale":
            this.Health=300;
            this.Speed=20;
            this.PAttack=30;
            this.MAttack=50;
            this.PResist=35;
            this.MResist=15;
            this.ability1="Krill Swarm";
            this.ability2="Filter Feeder";
            this.UsableAttacks.Add(new attackpackage(true,15,true,genericdebuffs[3],"Giant Echolocation"));
            this.UsableAttacks.Add(new attackpackage(false,5,true,genericdebuffs[1],"Tail Slap"));
            this.UsableAttacks.Add(new attackpackage(true,10,false,nulldebuff,"Water Spout"));
            this.UsableAttacks.Add(new attackpackage(true,20,true,genericdebuffs[7],"Vacuous Maw"));
            this.UsableAttacks.Add(new attackpackage(true,20,true,genericdebuffs[8],"Vacuous Maw"));
            break;
        case "Krill":
            this.Health=10;
            this.Speed=15;
            this.PAttack=5;
            this.MAttack=5;
            this.PResist=5;
            this.MResist=5;
            this.ability1="Schooling";
            this.UsableAttacks.Add(new attackpackage(false,5,false,nulldebuff,"Nibble"));
            this.UsableAttacks.Add(new attackpackage(true,5,false,nulldebuff,"Nibble"));
            break;
            
        }
        
    }

    //TurnBegin inherited from template, implementation of virtual Turninprogress
    override protected void Turninprogress()
    {
        Debug.Log("Enemy ID:" + this.eID + " turn in progress");
        int atemp=this.UsableAttacks.Count;
        int randattack=rand.Next(atemp);
        attackpackage tempattack=new attackpackage(false,0,false,nulldebuff,"none");
        tempattack=this.UsableAttacks[randattack];
        this.AttackTarget(CSC.p1,tempattack.pom,tempattack.att,tempattack.isd,tempattack.dbf,tempattack.name);
        this.EndTurn();
        Debug.Log("Enemy ID:" + this.eID + " Turn Completed");
    }
    
    public void DeliverTargettoPlayer()
    {
        CSC.p1.TargetEnemy(this);
    }

    public void Death()
    {
        int alliesstillfighting=0;
        this.gameObject.SetActive(false);
        for(int i=0;i<8;i++)
        {
            if(CSC.units[i].gameObject.activeSelf){alliesstillfighting++;}
        }
        if(alliesstillfighting<=0)
        {
            CSC.CombatOver=true;
            CSC.StopAllCoroutines();
            SceneManager.LoadScene("Combat Victory");
            audioManager.PlaySFX(audioManager.win);
        }
    }
}
