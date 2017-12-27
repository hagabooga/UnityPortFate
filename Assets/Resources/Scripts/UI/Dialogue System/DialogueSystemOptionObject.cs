﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemOptionObject : MonoBehaviour
{
    public DialogueOption option;
    public Text optionText;
    public Button optionButton;
    
    public void UpdateText()
    {
        switch (option.optionType)
        {
            case DialogueOption.OptionType.Quest:
                {
                    optionText.text = QuestDatabase.Instance.GetQuest(option.optionID).Name;
                    optionButton.onClick.AddListener(QuestTalk);
                    break;
                }
        }
    }

    void QuestTalk()
    {
        NPCInfo npcInfo = DialogueSystem.Instance.CurrentNPC;
        Quest playerQuest = PlayerQuestController.Instance.inProgressQuests.Find(aQuest => aQuest.ID == option.optionID);
        if (PlayerQuestController.Instance.HasQuestInProgress(option.optionID))
        {
            if (playerQuest.Completed)
            {
                DialogueSystem.Instance.MakeDialouge(playerQuest.CompleteText);
                QuestDatabase.Instance.GiveQuestReward(option.optionID);
                PlayerQuestController.Instance.QuestCompleted(option.optionID);
            }
            else
                DialogueSystem.Instance.MakeDialouge(playerQuest.InProgressText);
        }
        else if (option.optionID != -1 && !PlayerQuestController.Instance.HasQuestCompleted(option.optionID))
        {
            print(DialogueSystem.Instance.CurrentDialogue.optionID);
            DialogueSystem.Instance.MakeDialouge(QuestDatabase.Instance.GetQuest(DialogueSystem.Instance.CurrentDialogue.optionID).AskText, true);
        }
    }

    public void SetAsTalkOption()
    {
        optionText.text = "Talk";
        optionButton.onClick.AddListener(() => DialogueSystem.Instance.MakeDialouge(DialogueSystem.Instance.CurrentNPC.defaultText));
    }

    public void SetAsExitOption()
    {
        optionText.text = "Close";
        optionButton.onClick.AddListener(() => DialogueSystem.Instance.dialoguePanel.SetActive(false));
        optionButton.onClick.AddListener(() => PlayerMovement.cantMove = false);
    }



    

    

}