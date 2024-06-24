using UnityEngine;

public class ResourceAmount : MonoBehaviour
{
    internal static ResourceAmount instance;

    public ItemData[] itemResource;

    void Awake()
    {
        instance = this;
    }
}
