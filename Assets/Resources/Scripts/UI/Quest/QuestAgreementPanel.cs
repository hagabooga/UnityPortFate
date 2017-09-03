﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestAgreementPanel : MonoBehaviour {
    public GameObject questAgreementPanel;
    public Text questName, questDetails, questRewards;
    public Quest CurrentQuest { get; set; }

    public void Accept()
    {
        SoundDatabase.PlaySound(9);
        Destroy(gameObject);
        DialogueSystem.Instance.MakeDialouge(DialogueSystem.Instance.CurrentNPC.questAcceptText);
        DialogueSystem.Instance.ShowQuest = false;
        UIEventHandler.QuestAccepted(CurrentQuest);
        print("GG");
    }

    public void Decline()
    {
        SoundDatabase.PlaySound(21);
        Destroy(gameObject);
        DialogueSystem.Instance.ShowQuest = false;
        DialogueSystem.Instance.MakeDialouge(DialogueSystem.Instance.CurrentNPC.questDeclineText);
    }



}