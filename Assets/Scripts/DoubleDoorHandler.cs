using UnityEngine;

public class DoubleDoorHandler : MonoBehaviour
{
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;
    [SerializeField] DoorTriggerZoneHandler triggerZone;

    [SerializeField] float openCloseTranslation = 2f;
    [SerializeField] float openCloseSpeed = 2f;

    AudioSource leftDoorAudio;
    AudioSource rightDoorAudio;
    Vector3 leftDoorClosePosition;
    Vector3 rightDoorClosePosition;
    Vector3 leftDoorOpenPosition;
    Vector3 rightDoorOpenPosition;
    bool isOpen = false;
    float openCloseProgress = 0f;

    void Start()
    {
        leftDoorClosePosition = leftDoor.position;
        rightDoorClosePosition = rightDoor.position;
        leftDoorOpenPosition = leftDoor.position + leftDoor.right * openCloseTranslation;
        rightDoorOpenPosition = rightDoor.position + rightDoor.right * openCloseTranslation;

        leftDoorAudio = leftDoor.GetComponent<AudioSource>();
        rightDoorAudio = rightDoor.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (triggerZone.IsPlayerInZone && Input.GetKey(KeyCode.E))
        {
            isOpen = !isOpen;

            leftDoorAudio.Play();
            rightDoorAudio.Play();
        }

        if (isOpen && openCloseProgress < 1f)
        {
            openCloseProgress += Time.deltaTime * openCloseSpeed;
        }
        else if (!isOpen && openCloseProgress > 0f)
        {
            openCloseProgress -= Time.deltaTime * openCloseSpeed;
        }

        leftDoor.position = Vector3.Lerp(leftDoorOpenPosition, leftDoorClosePosition, openCloseProgress);
        rightDoor.position = Vector3.Lerp(rightDoorOpenPosition, rightDoorClosePosition, openCloseProgress);
    }
}
