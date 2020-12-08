using UnityEngine;

[RequireComponent(typeof(DetectionJoueur))]
public class Vie : MonoBehaviour
{
    [SerializeField] private BarVie barVie = null;
    [SerializeField] private int vieMax = 100;
    [SerializeField] private bool estJoueur = false;
    [SerializeField] private Son son = null;
    [SerializeField] private GameObject cadavre = null;

    private DetectionJoueur detectionJoueur;
    private int VieActuelle;

    private void Start()
    {
        VieActuelle = vieMax;
        barVie.SetVieMax(vieMax);
        detectionJoueur = gameObject.transform.GetComponentInChildren<DetectionJoueur>();
    }

    public void SubirDegat(int _degat)
    {
        VieActuelle -= _degat;
        barVie.SetVie(VieActuelle);

        if (VieActuelle <= 0)
            Mourir();
        else
            EnVie();    
    }

    public void EnVie()
    {
        // attaque le joueur si l'enemi est hors de porter et se fait attaquer
        if (!estJoueur && detectionJoueur.cible == null)
            detectionJoueur.estAttaquer = true;

        son.JouerSonToucher();

        if (estJoueur && VieActuelle <= 30)
            son.JouerSonAlertVie();
    }

    public void Mourir()
    {
        if (estJoueur)
        {
            son.StoperSon();
            MenuGameOver.instance.GameOver();
        }
            
        else
        {
            Instantiate(cadavre, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);

            // compteur d'ennemi restant
            if (GameManger.instance != null)
                GameManger.instance.EnnemiMort();

            Destroy(gameObject);
        }    
    }
}
