using UnityEngine;

public class NoodleGenderator : MonoBehaviour
{
    [SerializeField]
    GameObject noodlePrefab;

    void Start()
    {
        var initialTransform = noodlePrefab.transform;

        for (int i = 0; i < 360 / 15; i++)
        {
            Instantiate(
                noodlePrefab,
                initialTransform.position + Vector3.up * i * 0.01f,
                initialTransform.rotation * Quaternion.Euler(0, 0, i * 15f)
            );
        }
    }
}
