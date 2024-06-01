using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradePanel : MonoBehaviour
{
    public GameObject UpgradePanel;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void openUpgradePanel()
    {
        if (UpgradePanel != null)
        {
            bool isActive = UpgradePanel.activeSelf;

            UpgradePanel.SetActive(!isActive);
        }
    }

}
