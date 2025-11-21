using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class CombatVictoryorLoss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() { StartCoroutine(countdown());}

    public IEnumerator countdown()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Level Select");
    }

}
