using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    private Animator animator;
    private BoxCollider2D hitbox;
    [SerializeField] public AudioSource auSrc;
    [SerializeField] public AudioClip auAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        hitbox = transform.Find("HitBox").GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && EquipManager.instance.currentEquip != null) // Attack on Space key press.
        {
            animator.SetTrigger("Attack");
            auSrc.PlayOneShot(auAttack);
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.
        }
    }

    void ActivateHitbox()
    {
        hitbox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitbox.gameObject.SetActive(false);
    }
}
