using UnityEngine;

public class DoubleDoorHandler : MonoBehaviour
{
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;
    [SerializeField] DoorTriggerZoneHandler openCloseTrigger;
    [SerializeField] DoorTriggerZoneHandler dangerTrigger;

    [SerializeField] float openCloseTranslation = 2f;
    [SerializeField] float openCloseSpeed = 2f;

    AudioSource leftDoorAudio;
    AudioSource rightDoorAudio;
    Vector3 leftDoorClosePosition;
    Vector3 rightDoorClosePosition;
    Vector3 leftDoorOpenPosition;
    Vector3 rightDoorOpenPosition;
    bool isOpen = false;
    float closeProgress = 1f;

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
        if (openCloseTrigger.IsPlayerInZone && Input.GetKeyUp(KeyCode.E))
        {
            isOpen = isOpen && dangerTrigger.IsPlayerInZone ? true : !isOpen;

            leftDoorAudio.Play();
            rightDoorAudio.Play();
        }

        if (isOpen && closeProgress > 0f)
        {
            closeProgress -= Time.deltaTime * openCloseSpeed;
        }
        else if (!isOpen && closeProgress < 1f)
        {
            closeProgress += Time.deltaTime * openCloseSpeed;
        }

        leftDoor.position = Vector3.Lerp(leftDoorOpenPosition, leftDoorClosePosition, closeProgress);
        rightDoor.position = Vector3.Lerp(rightDoorOpenPosition, rightDoorClosePosition, closeProgress);
    }
}
