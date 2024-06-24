using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerAttack.instance.enabled = false;
        PlayerController.instance.enabled = false;
    }

    private void OnDisable()
    {
        PlayerAttack.instance.enabled = true;
        PlayerController.instance.enabled = true;
    }
}
