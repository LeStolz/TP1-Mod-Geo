using UnityEngine;

public class DoorTriggerZoneHandler : MonoBehaviour
{
    public bool IsPlayerInZone { get; private set; } = false;

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
