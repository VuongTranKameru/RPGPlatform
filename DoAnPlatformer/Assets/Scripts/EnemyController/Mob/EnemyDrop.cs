using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    internal static EnemyDrop instance;
    [SerializeField] GameObject enemy;

    public ItemData[] dropGift;
    private int randoItem;
    public Transform dropPosition;

    [SerializeField] AudioClip auFallOut;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (!enemy.activeInHierarchy)
        { 
            DropFromEnemy();
            Destroy(gameObject);
        }
    }

    void RandomDrop()
    {
        randoItem = Random.Range(0, dropGift.Length);
    }

    public void DropFromEnemy()
    {
        RandomDrop();
        AudioSource.PlayClipAtPoint(auFallOut, Camera.main.transform.position);

        Debug.Log(dropGift[randoItem].name);
        Instantiate(dropGift[randoItem].dropPrefab, dropPosition.position, Quaternion.identity);
    }
}
