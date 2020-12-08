using UnityEngine;

public class DetectionJoueur : MonoBehaviour
{
    public bool estAttaquer = false;

    [SerializeField] private string tagJoueur = "Player";
    [SerializeField] private Transform tourelle = null;
    [SerializeField] private Transform chassis = null;
    [SerializeField] private int tpsPoursuite = 5;

    [HideInInspector]
    public Transform cible;

    [SerializeField] private DeplacementEnnemi deplacement = null;

    // pour avoir une IA qui attaque le joueur en cas d'attaque
    private Transform joueur;

    private void Awake()
    {
        joueur = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // l'ennemi est attaquer en dehors de sa zone de detection
        if(estAttaquer)
        {
            Attaquer();
        }

        // remettre la tourelle a 0 sur la rotation
        if (cible == null && tourelle.rotation != Quaternion.Euler(Vector3.zero))
        {
            tourelle.rotation = chassis.rotation;
        }
        else if(cible != null)
        {
            tourelle.LookAt(cible);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagJoueur))
        {
            Attaquer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagJoueur))
        {
            cible = null;
            deplacement.StopperPoursuiteJoueur();
        }
    }

    private void Attaquer()
    {
        cible = joueur;
        deplacement.PoursuivreJoueur(cible, tpsPoursuite);
    }
}
