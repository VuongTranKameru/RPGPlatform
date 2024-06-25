using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    BossHP hp;

    //Shotting Skills
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float timer;

    //TeleSkill
    public Transform telePos, teleRestartPos;
    private int healthBossCanTele;
    public int teleCount;

    Animator anim;
    SpriteRenderer sprite;

    private void Awake()
    {
        hp = FindAnyObjectByType<BossHP>();

        anim = gameObject.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (hp.currentHealth > 0)
        {
            ShootSkill();
            TeleSkill();
        }
    }

    public void ShootSkill()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            anim.SetTrigger("Fire");
            timer = 0;
            Invoke(nameof(Shoot), .63f);
        }
    }

    public void TeleSkill()
    {
        healthBossCanTele = (int)hp.currentHealth;
        if (healthBossCanTele % 100 == 0 && healthBossCanTele > 0)
        {
            teleCount = healthBossCanTele / 100;

            if (teleCount % 2 == 1)
            {
                transform.position = TeleRestartPos().position;
                sprite.flipX = false;
            }
            else if (teleCount % 2 == 0)
            {
                transform.position = TelePosSkill().position;
                sprite.flipX = true;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
    }

    Transform TelePosSkill()
    {
        return telePos;
    }

    Transform TeleRestartPos()
    {
        return teleRestartPos;
    }
}
