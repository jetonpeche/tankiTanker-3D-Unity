using UnityEngine;

public class TirerJoueur : MonoBehaviour
{
    [SerializeField] private string tagCible = "ennemi";
    [SerializeField] private GameObject projectil = null;
    [SerializeField] private int vitesseObus = 20;
    [SerializeField] private Transform tourelle = null;
    [SerializeField] private Son son = null;
    [SerializeField] private BarChargementCanonManager loadUI = null;

    // const a cause du rendu son / durée rechargement
    private const int tempoTir = 2;
    private float couldown = 0;

    private void Update()
    {
        couldown -= Time.deltaTime;

        // tirer
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && (couldown <= 0) && !MenuPause.instance.jeuEnPause)
        {
            Tirer();
            couldown = tempoTir;
        }
    }

    private void Tirer()
    {
        son.JouerSonTirRecharge();

        if(loadUI != null)
            loadUI.d_canonDecharger();

        GameObject obj = Instantiate(projectil, tourelle.position, tourelle.rotation);

        obj.GetComponent<Obus>().degat = 40;
        obj.GetComponent<Rigidbody>().velocity = tourelle.forward * vitesseObus;
        obj.GetComponent<Obus>().tagCible = tagCible;
    }
}
