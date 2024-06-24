using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.TextCore.Text;

public class BossSkill : MonoBehaviour
{
    //Shotting Skills
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float timer;

    //TeleSkill
    public Transform telePos;
    private float healthBossCanTele;
    public int teleCount = 1 ;


    void Update()
    {  
        ShootSkill();
        TeleSkill();   
    }


    public void ShootSkill()
    {
        
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }
    public void TeleSkill()
    {
        healthBossCanTele = Mathf.Round(EnemyHealth.instance.startingHealth / 2);
        if (EnemyHealth.instance.currentHealth <= healthBossCanTele)
        {
            if (teleCount >= 1)
            {
                transform.position = TelePosSkill().position;
                teleCount--;
            }

        }
    }

    public void Shoot()
    {
         Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
    }

    public Transform TelePosSkill()
    {
        
        return telePos;
    }
}
