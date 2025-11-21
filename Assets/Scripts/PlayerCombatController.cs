using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : UnitTemplate
{
    public EnemyController eTarget;
    private bool attackchosen=false;
    private bool magicintent;
    private bool targetchosen=false;
    private debuff nulldebuff=new debuff(0);

    
        void Awake()
    {
        this.Health = 300;
        this.Speed = 30;
        this.Turnmeter = 0;
        this.PAttack = 20;
        this.MAttack = 20;
        this.PResist = 10;
        this.MResist = 10;
        this.ability1="none";
        this.ability2="none";
        attackpackage Basic_Physical_Attack=new attackpackage(false,10,false,nulldebuff,"Basic Physical Attack");
        attackpackage Basic_Magical_Attack=new attackpackage(true,10,false,nulldebuff,"Basic Magical Attack");

        this.UsableAttacks.Insert(0,Basic_Physical_Attack);
        this.UsableAttacks.Insert(1,Basic_Magical_Attack);

    }


    override protected void Turninprogress()
    {
        this.attackchosen=false;
        this.targetchosen=false;
        CSC.CMC.PlayerMenus();
        
        StartCoroutine(waitingforturninputs());
    }
    public void setAttackChoice(string attackname)
    {
        Debug.Log("Attack Chosen!");
        if(attackname=="Basic Physical Attack"){this.attackchosen=true;this.magicintent=false;}
        else{this.attackchosen=true;this.magicintent=true;}
        

    }
    IEnumerator AttackWait()
    {
        Debug.Log("Choosing Action...");
        yield return new WaitUntil(()=> this.attackchosen);
        Debug.Log("Action Chosen Successfully");
    }

    public void TargetEnemy(EnemyController e)
    {   
        if(e.gameObject.activeSelf)
        {
        Debug.Log("Targetting Enemy");
        this.eTarget=e;
        this.targetchosen=true;
        }
        else
        {
            Debug.Log("Inactive Enemy Chosen");
        }
    }
    IEnumerator waitingforturninputs()
    {
        Debug.Log("Awaiting Player Inputs");
        yield return new WaitUntil(()=> this.attackchosen&&this.targetchosen);
        if(magicintent){this.AttackTarget(eTarget,this.UsableAttacks[1]);}
        else {this.AttackTarget(eTarget,this.UsableAttacks[0]);}
        
        CSC.CMC.PlayerMenuHide();
        this.EndTurn();
        Debug.Log("Player Turn Complete");
    }
    public void Death()
    {
        CSC.CombatOver=true;
        CSC.StopAllCoroutines();
        SceneManager.LoadScene("Combat Loss");
    }

}
