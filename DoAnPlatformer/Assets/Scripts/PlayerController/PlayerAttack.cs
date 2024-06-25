using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    internal static PlayerAttack instance;
    
    private Animator animator;
    private BoxCollider2D hitbox;
    [SerializeField] AudioClip auAttack;

    private void Start()
    {
        instance = this;

        animator = GetComponent<Animator>();
        hitbox = transform.Find("HitBox").GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && EquipManager.instance.currentEquip != null) // Attack on Space key press.
        {
            animator.SetTrigger("Attack");
            AudioSource.PlayClipAtPoint(auAttack, Camera.main.transform.position);
            Invoke(nameof(ActivateHitbox), 0.2f); // Activate hitbox after 0.2 seconds.
            Invoke(nameof(DeactivateHitbox), 0.4f); // Deactivate hitbox after 0.4 seconds.
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
