﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    // Inventory Equipment
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemEquipped;
    public static event ItemEventHandler OnItemUnequipped;


    public delegate void ItemNoneEventHandler();
    public static event ItemNoneEventHandler OnItemRemovedFromInventory;

    // Player
    public delegate void PlayerHealhEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealhEventHandler OnPlayerHealthChanged;

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChanged;

    // Skill
    public delegate void SkillEventHandler(Skill skill);
    public static event SkillEventHandler OnSkillLearn;

    public delegate void SkillNoneEventHandler();
    public static event SkillNoneEventHandler OnSkillUse;

    // Quest
    public delegate void QuestEventHandler(Quest quest);
    public static event QuestEventHandler OnQuestAccepted;

    public static void QuestAccepted(Quest quest)
    {
        OnQuestAccepted(quest);
    }

    public static void SkillUsed() { OnSkillUse(); }

    public static void SkillLearned(Skill skill)
    {
        OnSkillLearn(skill);
    }

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemEquipped(Item item)
    {
        OnItemEquipped(item);
    }

    public static void ItemUnequipped(Item item)
    {
        OnItemUnequipped(item);
    }

    public static void ItemRemovedFromInventory()
    {
        OnItemRemovedFromInventory();
    }

    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        OnPlayerHealthChanged(currentHealth, maxHealth);
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
    }

    public static void PlayerLevelChanged()
    {
        OnPlayerLevelChanged();
    }
}
