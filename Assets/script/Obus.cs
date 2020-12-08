using UnityEngine;

public class Obus : MonoBehaviour
{
    public int degat;

    [HideInInspector] public string tagCible;
    [SerializeField] private GameObject[] explosionEffect = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagCible))
        {
            other.GetComponent<Vie>().SubirDegat(degat);
            Instantiate(explosionEffect[0], transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        else if(other.CompareTag("decor"))
        {
            Instantiate(explosionEffect[1], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
