using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;


public class CombatMenuController : MonoBehaviour
{
    public GameObject attacksMenu;
    public GameObject actionTarget;
    public GameObject magicalactions;
    public GameObject physicalactions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }
    void Start()
    {

    }

    public void PlayerMenus()
    {
        attacksMenu.SetActive(true);
        actionTarget.SetActive(false);
        magicalactions.SetActive(true);
        physicalactions.SetActive(true);
    }
    public void PlayerMenuHide()
    {
        attacksMenu.SetActive(false);
        actionTarget.SetActive(false);
        magicalactions.SetActive(false);
        physicalactions.SetActive(false);
    }
    public void TargettingEnemy()
    {
        attacksMenu.SetActive(true);
        actionTarget.SetActive(true);
        magicalactions.SetActive(false);
        physicalactions.SetActive(false);
    }

}
