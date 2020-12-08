using UnityEngine;

public class Cadavre : MonoBehaviour
{
    public int tpsVieCadavre = 20;

    private void Start()
    {
        Destroy(gameObject, tpsVieCadavre);
    }
}
