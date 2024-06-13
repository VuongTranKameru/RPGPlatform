using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsInfo : MonoBehaviour
{
    public GameObject statsWindow;
    public float checkRate = 0.05f;
    private float lastcheckTime;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI damge;
    
    public int checkDamge;
   
    
    // Start is called before the first frame update
    void Start()
    {
        statsWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastcheckTime >checkRate && statsWindow.activeInHierarchy)
        {
            lastcheckTime = Time.time;
            hp.text = ("" + HealthManager.instance.currentHealth.ToString("F0") + "/" + "" + HealthManager.instance.maxHealth).ToString();
            
            if(EquipManager.instance.currentEquip != null)
            {
                damge.text = ("" + EquipWeapond.instance.damgeStats.ToString()).ToString();
            }
            else
            {
                damge.text = "0";
            }
        }
    }

   

    public void OpenStatsInfoPanel()
    {
        statsWindow.SetActive(true);

    }

    public void CloseStatsInfoPanel()
    {
        statsWindow.SetActive(false);

    }
}
