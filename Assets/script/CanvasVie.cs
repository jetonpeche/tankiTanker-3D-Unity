using UnityEngine;

public class CanvasVie : MonoBehaviour
{
    public Camera cam;
    private GameObject joueur;
    
    private void Start()
    {
        // ennemi spawn en cours de partie
        if (cam == null)
        {
            joueur = GameObject.FindGameObjectWithTag("Player");
            cam = joueur.transform.GetChild(0).GetComponentInChildren<Camera>();
        }
    }

    void Update()
    {
        // permet a la bar de vie de toujours faire face a la camera (joueur)
        transform.LookAt(cam.transform);
    }
}
