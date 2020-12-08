using UnityEngine;

public class DetruireParticule : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 2);
    }
}
