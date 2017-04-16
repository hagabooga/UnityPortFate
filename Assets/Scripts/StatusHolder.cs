﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHolder : MonoBehaviour {

    public Status status;

    void Start()
    {
        status = new Status();
    }

    public void UpdateStatus()
    {
        Image image = gameObject.GetComponent<Image>();
        if (status.statusID != -1)
        {
            image.enabled = true;
            image.sprite = Resources.Load<Sprite>("Status Effects/" + status.statusName); ;
        }
        else
        {
            image.enabled = false;   
        }
    }

}
