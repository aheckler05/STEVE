using UnityEngine;
using System.Collections.Generic;

public class SkillTreeController : MonoBehaviour
{
    public static SkillTreeController SkillTree;
    public List<int> StatModifiers;
    public List<string> AbilityModifiers;
    private void Awake()
    {
        if(SkillTree != null)
        {
            Destroy(gameObject);
            return;
        }

        SkillTree = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
