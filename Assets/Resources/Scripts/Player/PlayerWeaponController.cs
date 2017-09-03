﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    Item currentlyEquippedItem;
    IWeapon equippedWeapon;
    CharacterStats characterStats;
    InventoryController inventoryController;
    public PlayerSkillController playerSkillController;

    void Start()
    {
        spawnProjectile = transform.FindChild("ProjectileSpawn");
        characterStats = GetComponent<Player>().characterStats;
        inventoryController = GetComponent<InventoryController>();
        UIEventHandler.OnSkillUse += UpdatePanelCooldowns;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) ActivateHotKeySkill(0);
        if (Input.GetKeyDown(KeyCode.W)) ActivateHotKeySkill(1);
        if (Input.GetKeyDown(KeyCode.E)) ActivateHotKeySkill(2);
        if (Input.GetKeyDown(KeyCode.R)) ActivateHotKeySkill(3);
        if (Input.GetKeyDown(KeyCode.A)) ActivateHotKeySkill(4);
        if (Input.GetKeyDown(KeyCode.S)) ActivateHotKeySkill(5);
        if (Input.GetKeyDown(KeyCode.D)) ActivateHotKeySkill(6);
        if (Input.GetKeyDown(KeyCode.F)) ActivateHotKeySkill(7);

        if (Input.GetKeyDown(KeyCode.X) && EquippedWeapon != null)
        {
            PerformWeaponAttack();
        }
    }

    public void ActivateHotKeySkill(int index)
    {
        PanelSkill panel = playerSkillController.skillPanel.transform.GetChild(index).GetComponent<PanelSkill>();
        if (EquippedWeapon != null && panel.skill != null && !EquippedWeapon.GetComponent<Animator>().GetBool("IsLastAnimation"))
        {
            if (!(panel.cooldownRemain > 0))
            {
                playerSkillController.UsingSkill = panel.skill;
                PerformSkill();
            }
        }
    }


    public void UpdatePanelCooldowns()
    {
        foreach (Transform skill in playerSkillController.skillPanel.transform)
        {
            if (skill.GetComponent<PanelSkill>().skill != null)
            {
                if (skill.GetComponent<PanelSkill>().skill.skillID == playerSkillController.UsingSkill.skillID)
                {
                    skill.GetComponent<PanelSkill>().SkillUsed();
                }
            }
        }
    }


    public void EquipWeapon(Item itemToEquip)
    {
        UnequipWeapon(itemToEquip);
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Items/Weapons/" + itemToEquip.ItemName), playerHand.transform);
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        characterStats.AddStatBonus(itemToEquip.Stats);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.playerSkillController = playerSkillController;
        SoundDatabase.PlaySound(0);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon(Item item)
    {
        if (EquippedWeapon != null)
        {
            SoundDatabase.PlaySound(0);
            characterStats.RemoveStatBonus(equippedWeapon.Stats);
            inventoryController.GiveItem(currentlyEquippedItem.ItemName);
            Destroy(playerHand.transform.GetChild(0).gameObject);
            UIEventHandler.ItemUnequipped(item);
            UIEventHandler.StatsChanged();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculateDamage());
    }
    
    public void PerformSkill()
    {
        equippedWeapon.PerformSkillAnimation();
    }

    private Damage CalculateDamage()
    {
        Damage dmg = new Damage();
        //if (Random.Range(0f, 1f) < 0.5f)
        //    dmg.DidHit = false;
        //else
            dmg.DidHit = true;
        dmg.Amount = ((characterStats.GetStat(BaseStat.BaseStatType.Physical).GetCalcStatValue() * 2) +
            Random.Range(2,8));
        // Calculate Crit
        if (Random.value <= .1f)
        {
            dmg.Amount += CalculateCrit(dmg.Amount);
            dmg.DidCrit = true;
       }
        return dmg;
    }

    private int CalculateCrit(int damage)
    {
        int critDamage = (int)(damage * Random.Range(.5f, .75f));
        return critDamage;
    }
}