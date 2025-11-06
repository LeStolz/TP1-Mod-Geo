using UnityEngine;

public class DoorTriggerDangerZone : MonoBehaviour
{
    public bool IsPlayerInZone { get; private set; } = false;

    BoxCollider triggerZone;

    void Start()
    {
        triggerZone = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInZone = false;
        }
    }
}
