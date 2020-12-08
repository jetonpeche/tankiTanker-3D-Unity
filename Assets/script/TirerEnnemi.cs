using UnityEngine;

public class TirerEnnemi : MonoBehaviour
{
    [SerializeField] private bool doitSuivreJoueur = false;
    [SerializeField] private string tagCible = "Player";
    [SerializeField] private float tempoTir = 2f;
    [SerializeField] private int vitesseObus = 50;
    [SerializeField] private GameObject obus = null;
    [SerializeField] private Transform tourelle = null;
    [SerializeField] private DetectionJoueur detectionJoueur = null;
    [SerializeField] private Son son = null;

    private float couldown = 0;
    
    private void Start()
    {
        // change le comportement de tir
        if (GetComponent<SuivreJoueur>())
            doitSuivreJoueur = true;

        if(detectionJoueur == null)
            Debug.Log("detectionJoueur n'est pas assigner");
    }

    private void Update()
    {
        couldown -= Time.deltaTime;

        // l'ennemi suis le joueur
        if(doitSuivreJoueur)
        {
            RaycastHit _hit;

            // pour ne pas tirer dans le decor
            if (Physics.Raycast(tourelle.position, tourelle.forward, out _hit) && couldown <= 0)
            {
                if (_hit.transform.CompareTag(tagCible))
                {
                    Tirer();
                    couldown = tempoTir;
                }
            }
        }
        

        // l'ennemi se deplace normalement de pts en pts
        if(!doitSuivreJoueur)
        {
            RaycastHit _hit;

            // pour ne pas tirer dans le decor
            if (detectionJoueur.cible != null && Physics.Raycast(tourelle.position, tourelle.forward, out _hit) && couldown <= 0)
            {
                if (_hit.transform.CompareTag(tagCible))
                {
                    Tirer();
                    couldown = tempoTir;
                }
            }
        }  
    }

    private void Tirer()
    {
        son.JouerSonTirRecharge();
        GameObject obj = Instantiate(obus, tourelle.position, tourelle.rotation);
        obj.GetComponent<Rigidbody>().velocity = tourelle.forward * vitesseObus;
        obj.GetComponent<Obus>().tagCible = tagCible;
    }
}
