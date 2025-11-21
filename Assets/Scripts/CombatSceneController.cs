using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class CombatSceneController : MonoBehaviour
{
    
    public UnityEvent e_turncompleted;
    public int EnemyCount;
    public string[] EnemyVariants={"Shark","Pufferfish","Dolphin","Crab","Octopus","Starfish","Fisherman","Whale","Krill"};
    public int BossCount;

    public float difficulty;
    
    protected static Queue<UnitTemplate> turnqueue=new Queue<UnitTemplate>();
    public PlayerController p1;
    public EnemyController e1;
    public EnemyController e2;
    public EnemyController e3;
    public EnemyController e4;
    public EnemyController e5;
    public EnemyController e6;
    public EnemyController e7;
    public EnemyController e8;

    public List<EnemyController> units=new List<EnemyController>();
    public CombatMenuController CMC;
    public bool turncomplete=false;
    public bool inprogress=true;
    public bool CombatOver=false;
    System.Random rand=new System.Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (e_turncompleted == null)
        {
            e_turncompleted = new UnityEvent();
            e_turncompleted.AddListener(TurnHelper);
        }

        for(int i=0;i<EnemyCount;i++)
        {
            units[i].variant=EnemyVariants[rand.Next(6)];
        }
        for(int i=EnemyCount;i<8&&BossCount>0;i++)
        {   
            int coinflip=rand.Next(2);
            if(coinflip==1){units[i].variant=EnemyVariants[6];}
            else if(coinflip==0){units[i].variant=EnemyVariants[7];}
        }
        for(int i=EnemyCount+BossCount;i<8;i++)
        {
            units[i].gameObject.SetActive(false);
        }
        this.inprogress=true;
        this.turncomplete=false;

    }
    void Start()
    {
        p1.Turnmeter=p1.Turnmeter+100;
        this.inprogress=true;
        this.turncomplete=false;
        StartCoroutine(TurnHeartbeat());
    }

    //Constrained Update Loop, waits until turn completion event before initiating another round of turnmeter ticks and checks if they are ready for a turn
    IEnumerator TurnHeartbeat()
    {
        while(!this.CombatOver)
        {
        this.inprogress=true;
        this.turncomplete=false;
        if(p1.Turnmeter>=100){this.turncomplete=false;p1.TurnBegin();Debug.Log("Waiting for playable unit to finish turn...");yield return new WaitUntil(()=>this.turncomplete);Debug.Log("Finished");}
        
        for(int i=0;i<units.Count;i++)
        {
            if(units[i].gameObject.activeSelf)
            {
                if(units[i].Turnmeter>=100){this.turncomplete=false;units[i].TurnBegin();Debug.Log("Waiting for npcunit to finish turn...");yield return new WaitUntil(()=>this.turncomplete);Debug.Log("Finished");}
            }   
        }
        
        for(int i=0;i<units.Count;i++){units[i].Tick();}
        p1.Tick();
        }
    }

    public void TurnHelper()
    {
        this.turncomplete=true;
        this.inprogress=true;
    }
    private void FixedUpdate() {
        if(!this.inprogress){if(!this.inprogress){TurnHeartbeat();}}
    }
}
