﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool invisibleWallOn = false;
    static string showingPage;
    public static bool inBattle;
    public bool setupBattle;

    void Start()
    {
        OpenClosePage("Skill Page");
        OpenClosePage("Battle UI");
        OpenClosePage("InventoryEquipment");
    }

    void Update()
    {
        if (!invisibleWallOn)
        {
            if (Input.GetButtonDown("Skill"))
            {
                CheckSkillPage();
            }
            if (!inBattle)
            {
                if (Input.GetButtonDown("Inventory"))
                {
                    SoundDatabase.PlaySound(34);
                    if (!OpenClosePage("InventoryEquipment"))
                    {
                        InvEq.ShowStats(false);
                        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(false);
                        Inventory.AddItem(InvEq.holdingItem.itemID);
                        InvEq.UpdateHoldingItem(new Item(), false);
                    }
                }
            }
        }
    }

    public static void CheckSkillPage()
    {
        SoundDatabase.PlaySound(34);
        //playerSkills.SkillUpdate();
        if (OpenClosePage("Skill Page"))
        {
            if (SkillPage.quickSkillsPressed)
            {
                SkillPage.AfterQuickSkillButonPress();
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
        }

    }

    public static void InvisibleWallOn(bool yes)
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Invisible Wall").gameObject.SetActive(yes);
        invisibleWallOn = yes;
    }

    public static bool OpenClosePage(string name)
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.SetActive(
            !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.activeInHierarchy));
        return !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.activeInHierarchy);
    }

}
