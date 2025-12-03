using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class whaleScript : MonoBehaviour
{
    public GameObject krillPrefab;
    public GameObject harpoonPrefab;
    public float spawnInterval = 2f;
    private float timeSinceLastSpawn;
    public float movementSpeed = 2f;
    public Vector2 pointA;
    public Vector2 pointB;

    public int HealthBar=156;
    public int ComboCount=1;

    public Queue<int> ColorPattern=new Queue<int>();

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeSinceLastSpawn = spawnInterval;
        this.HealthBar=156;
        StartCoroutine(KrillSpit());
    }

    IEnumerator KrillSpit()
    {
        int tempcount;
        int tempcolorindex;
        GameObject krilltemp;
        GameObject harpoontemp;
        while(this.HealthBar>0)
        {
            krilltemp = Instantiate(krillPrefab,this.transform.position,Quaternion.identity,this.transform);
            krilltemp.GetComponent<KrillScript>().Coloring(9);
        if(ColorPattern.Count>0)
        {
            switch (this.HealthBar)
            {
            case (<=52):
                tempcount=6;
                break;
            case (<=78):
                tempcount=5;
                break; 
            case (<=104):
                tempcount=4;
                break;
            case (<=130):
                tempcount=3; 
                break;           
            default:
                tempcount=2;
                break;
            }
            for(int i=0;i<tempcount;i++)
            {
                tempcolorindex=Random.Range(0,8);
                krilltemp = Instantiate(krillPrefab,this.transform.position,Quaternion.identity,this.transform);
                krilltemp.GetComponent<KrillScript>().Coloring(tempcolorindex);
                if(i!=(tempcount-1)){ColorPattern.Enqueue(tempcolorindex);}
                yield return new WaitForSeconds(0.5f);
            }
            if(ColorPattern.TryPeek(out tempcount))
            {
                foreach (int i in ColorPattern)
                {
                    harpoontemp=Instantiate(harpoonPrefab,this.transform.position,Quaternion.identity,this.transform);
                    harpoontemp.GetComponent<HarpoonScript>().Coloring(i);
                }
            }
            tempcolorindex=Random.Range(0,8);
            harpoontemp=Instantiate(harpoonPrefab,this.transform.position,Quaternion.identity,this.transform);
            harpoontemp.GetComponent<HarpoonScript>().Coloring(tempcolorindex);
        }
            yield return new WaitForSeconds(2f);
            
        }
    }


    public void Damage(int dmg)
    {
        this.HealthBar=this.HealthBar-(dmg*this.ComboCount);
        if(dmg>0){this.ComboCount=this.ComboCount+1;}
        else{this.ComboCount=0;}
        if(this.HealthBar<=0)
        {
            SceneManager.LoadScene("Combat Victory");
        }
    }
}
