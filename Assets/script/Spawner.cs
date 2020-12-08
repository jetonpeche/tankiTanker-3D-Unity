using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ennemi = null;

    public void Spawn()
    {
        Instantiate(ennemi, transform.position, Quaternion.identity);
    }
}
