﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
    public static Transform equipment;
    public static List<Texture2D> defaultImage = new List<Texture2D>();

    void Start()
    {
        equipment = gameObject.transform;
    }

    public static bool CheckEquip(Transform parent) // check the slots
    {
        bool ableToEquip = false;
        if (parent.name == "Weapon" && InvEq.holdingItem.itemType == Item.ItemType.Weapon ||
            parent.name == "Head" && InvEq.holdingItem.armorType == Item.ArmorType.Head ||
            (parent.name == "Weapon&Shield" && (InvEq.holdingItem.itemType == Item.ItemType.Weapon || InvEq.holdingItem.armorType == Item.ArmorType.Shield)) ||
            parent.name == "Neck" && InvEq.holdingItem.armorType == Item.ArmorType.Neck ||
            parent.name == "Hands" && InvEq.holdingItem.armorType == Item.ArmorType.Hands ||
            parent.name == "Body" && InvEq.holdingItem.armorType == Item.ArmorType.Body ||
            parent.name == "Boots" && InvEq.holdingItem.armorType == Item.ArmorType.Boots ||
            parent.name == "Bottom" && InvEq.holdingItem.armorType == Item.ArmorType.Bottom ||
            parent.name == "Accessory" && InvEq.holdingItem.armorType == Item.ArmorType.Accessory)
        {
            ableToEquip = true;
        }
        return ableToEquip;
    }

    public static void AddItemStats(Item item)
    {
        GameManager.player.strength.buffedAmount += item.itemBonusStr;
        GameManager.player.intelligence.buffedAmount += item.itemBonusInt;
        GameManager.player.agility.buffedAmount += item.itemBonusAgi;
        GameManager.player.luck.buffedAmount += item.itemBonusLuk;
        GameManager.player.health += item.itemBonusHP;
        GameManager.player.maxHealth.buffedAmount += item.itemBonusHP;
        GameManager.player.maxMana.buffedAmount += item.itemBonusMP;
        GameManager.player.mana += item.itemBonusMP;
        GameManager.player.physAtk.buffedAmount += item.itemBonusAtk;
        GameManager.player.magicAtk.buffedAmount += item.itemBonusMAtk;
        GameManager.player.armor.buffedAmount += item.itemBonusArmor;
        GameManager.player.resist.buffedAmount += item.itemBonusResist;
        GameManager.player.hitChance.buffedAmount += item.itemBonusHit;
        GameManager.player.dodgeChance.buffedAmount += item.itemBonusDodge;
        GameManager.player.critChance.buffedAmount += item.itemBonusCrit;
        GameManager.player.critMulti.buffedAmount += item.itemBonusCritMulti;
        GameManager.player.FullUpdate();
        StatusBar.UpdateSliders();
    }

    public static void RemoveItemStats(Item item)
    {
        GameManager.player.strength.buffedAmount -= item.itemBonusStr;
        GameManager.player.intelligence.buffedAmount -= item.itemBonusInt;
        GameManager.player.agility.buffedAmount -= item.itemBonusAgi;
        GameManager.player.luck.buffedAmount -= item.itemBonusLuk;
        GameManager.player.maxHealth.buffedAmount -= item.itemBonusHP;
        if (GameManager.player.health > GameManager.player.maxHealth.totalAmount + GameManager.player.maxHealth.baseAmount)
        {
            GameManager.player.health = GameManager.player.maxHealth.totalAmount + GameManager.player.maxHealth.baseAmount;
        }
        GameManager.player.maxMana.buffedAmount -= item.itemBonusMP;
        if (GameManager.player.mana > GameManager.player.maxMana.buffedAmount + GameManager.player.maxMana.baseAmount)
        {
            GameManager.player.mana = GameManager.player.maxMana.buffedAmount + GameManager.player.maxMana.baseAmount;
        }
        GameManager.player.physAtk.buffedAmount -= item.itemBonusAtk;
        GameManager.player.magicAtk.buffedAmount -= item.itemBonusMAtk;
        GameManager.player.manaComs.buffedAmount -= item.itemBonusMAtk;
        GameManager.player.dmgOutput.buffedAmount -= item.itemBonusMAtk;
        GameManager.player.dmgTaken.buffedAmount -= item.itemBonusMAtk;
        GameManager.player.armor.buffedAmount -= item.itemBonusArmor;
        GameManager.player.resist.buffedAmount -= item.itemBonusResist;
        GameManager.player.hitChance.buffedAmount -= item.itemBonusHit;
        GameManager.player.dodgeChance.buffedAmount -= item.itemBonusDodge;
        GameManager.player.critChance.buffedAmount -= item.itemBonusCrit;
        GameManager.player.critMulti.buffedAmount -= item.itemBonusCritMulti;
        GameManager.player.FullUpdate();
        StatusBar.UpdateSliders();

    }
    //private Page page = new Page(1, 460, 100, 400, 450, 50);
    //public float equipSlotX, equipSlotY, statButtonW, statButtonH,
    //    statBoxW, statBoxH;
    //public GUISkin skin;
    //public List<Item> equipment = new List<Item>();
    ////
    //public PlayerStats playerStats;
    //public SlotButton slotButton;
    //public Tooltip tooltip;
    //public Shop shop;
    //public GameManager manager;
    ////private ItemDatabase database;
    //public Inventory inventory;
    //// 
    //private bool showStats;

    //void Start () {
    //    for (int i = 0; i < (equipSlotX * equipSlotY); i += 1)
    //    {
    //        equipment.Add(new Item());
    //    }
    //    // show the picture that shows where to equip

    //    //
    //    shop = shop.GetComponent<Shop>();
    //    manager = manager.GetComponent<GameManager>();
    //    playerStats = playerStats.GetComponent<PlayerStats>();
    //    slotButton = slotButton.GetComponent<SlotButton>();
    //    tooltip = tooltip.GetComponent<Tooltip>();
    //    //database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
    //    inventory = inventory.GetComponent<Inventory>();
    //}
    //void Update()
    //{
    //    if (Input.GetButtonDown("Equipment")) 
    //    {
    //        page.showPage = !page.showPage;
    //        slotButton.showTooltip = false;
    //    }
    //    // PLAYER CLOTHES INGAME
    //    int i;
    //    for (i = 0; i < equipment.Count; i += 1)
    //    {
    //        SpriteRenderer spriteRenderer = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
    //        if (equipment[i].itemID != -1)
    //        {
    //            gameObject.transform.GetChild(i).transform.position = new Vector2(gameObject.transform.parent.transform.position.x, gameObject.transform.parent.transform.position.y);
    //            // if weapon in shield slot
    //            if (i == 1 && equipment[i].itemType == Item.ItemType.Weapon)
    //            {
    //                spriteRenderer.sprite = Resources.Load<Sprite>("Player/" + equipment[i].itemName + "2");

    //            }
    //            else
    //            {
    //                spriteRenderer.sprite = Resources.Load<Sprite>("Player/" + equipment[i].itemName);
    //            }
    //            if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") > 0)
    //            {
    //                spriteRenderer.flipX = false;
    //            }
    //            else if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") < 0)
    //            {
    //                spriteRenderer.flipX = true;
    //            }

    //        }
    //        else
    //        {
    //            if (i == 3)
    //            {
    //                gameObject.transform.GetChild(i).transform.position = new Vector2(gameObject.transform.parent.transform.position.x, gameObject.transform.parent.transform.position.y);
    //                spriteRenderer.sprite = Resources.Load<Sprite>("Player/Mage Arm");
    //                if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") > 0)
    //                {
    //                    spriteRenderer.flipX = false;
    //                }
    //                else if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") < 0)
    //                {
    //                    spriteRenderer.flipX = true;
    //                }
    //            }
    //            else
    //            {
    //                spriteRenderer.sprite = Resources.Load<Sprite>("None");
    //            }
    //        }

    //    }

    //}

    //void OnGUI()
    //{
    //    if (page.showPage)
    //    {
    //        slotButton.hoveringCurrentItem = new Item();
    //        DrawEquipment();
    //        if (tooltip.DrawTooltip(slotButton.hoveringCurrentItem) && (manager.showingPageTooltipID == -1 || manager.showingPageTooltipID == page.id))
    //        {
    //            manager.showingPageTooltipID = page.id;
    //        }
    //        else
    //        {
    //            manager.showingPageTooltipID = -1;
    //        }
    //        if (slotButton.draggingItem)
    //        {
    //            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
    //        }
    //    }

    //}
    //void DrawEquipment()
    //{
    //    Event e = Event.current;
    //    // title drag
    //    if ((manager.draggingPageID == -1 || manager.draggingPageID == page.id) &&
    //        !slotButton.draggingItem && new Rect(page.x, page.y, page.w, page.titleh).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
    //    {
    //        manager.draggingPageID = page.id;
    //        page.x = Event.current.mousePosition.x - page.w / 2;
    //        page.y = Event.current.mousePosition.y - page.titleh / 2;
    //    }
    //    if (e.type == EventType.mouseUp)
    //    {
    //        manager.draggingPageID = -1;
    //    }
    //    // Background
    //    GUI.Box(new Rect(page.x, page.y, page.w, page.h), "", skin.GetStyle("Panel Brown"));
    //    // Title
    //    GUI.Box(new Rect(page.x, page.y, page.w, page.titleh), "Equipment", skin.GetStyle("Button Long Brown"));
    //    // Character 
    //    float characterX = page.x + 22;
    //    float characterY = page.y + 45;
    //    Rect charRect = new Rect(characterX, characterY, 200, 400);
    //    //if (playerStats.job.jobID == 0)
    //    //{
    //    //    GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Body"));
    //    //    GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Hair"));
    //    //}
    //    for (int i = 0; i < equipment.Count; i += 1)
    //    {
    //        if (equipment[i].itemID != -1)
    //        {
    //            if (i != 3 && i != 0 && i != 1 && i != 7 && i != 4 && i != 9)
    //            {
    //                GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[i].itemName));
    //            }
    //        }
    //    }
    //    if (equipment[1].itemID != -1)
    //    {
    //        if (equipment[1].itemType == Item.ItemType.Weapon)
    //        {
    //            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[1].itemName + "2")); // weapon 2
    //        }
    //        else
    //        {
    //            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[1].itemName)); // shield goes under weapon
    //        }
    //    }
    //    if (equipment[7].itemID != -1)
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[7].itemName)); // bottom over shield but under weapon
    //    }
    //    if (equipment[0].itemID != -1)
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[0].itemName)); // weapon under hands but over bottom
    //    }
    //    if (equipment[3].itemID != -1)
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[3].itemName)); // hands are covered if go by index
    //    }
    //    else
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Arm"));
    //    }
    //    // show stats
    //    if (showStats == false)
    //    {
    //        if (GUI.Button(new Rect(page.x + page.w - statButtonW - 20, page.y + page.h - statButtonH - 20, statButtonW, statButtonH), 
    //        Resources.Load<Texture2D>("GUI/Arrow Right")))
    //        {
    //            showStats = true;
    //        }
    //    }
    //    else
    //    {
    //        if (GUI.Button(new Rect(page.x + page.w - statButtonW - 20, page.y + page.h - statButtonH - 20, statButtonW, statButtonH),
    //        Resources.Load<Texture2D>("GUI/Arrow Left")))
    //        {
    //            showStats = false;
    //        }
    //    }
    //    // Close button
    //    if (GUI.Button(new Rect(page.x + page.w - 45, page.y + 5, 35, 35), Resources.Load<Texture2D>("GUI/Cross Brown")))
    //    {
    //        page.showPage = false;
    //    }
    //    // Slot
    //    slotButton.MatrixSlot(equipSlotX, equipSlotY, equipment, page.x + 235, page.y + 65, 67, 67);
    //    if (showStats)
    //    {
    //        GUI.Box(new Rect(page.x + page.w, page.y, statBoxW, statBoxH), "", skin.GetStyle("Panel Brown"));
    //        //GUI.Box(new Rect(page.x + page.w, page.y, statBoxW, statBoxH), playerStats.makeStatsPage(), skin.GetStyle("Stats Page"));
    //    }




    //}

}
