using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    public bool finNiveau;

    [SerializeField] private Text txtObjectif = null;
    [SerializeField] private Text txtNbEnnemi = null;

    private GameObject[] listSpawn;

    private int nbEnnemiRestant = 0;

    private delegate void SpawnEnnemi();
    private SpawnEnnemi spawnEnnemi;
    

    private void Awake()
    {
        if(instance != null)
            Debug.Log("Il y a plus d'une instance de GameManager");

        instance = this;

        // bloque la souris au milieu de l'ecran
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        listSpawn = GameObject.FindGameObjectsWithTag("spawn");

        foreach (var item in listSpawn)
        {
            spawnEnnemi += item.GetComponent<Spawner>().Spawn;
        }

        CompterEnnemi();

        txtNbEnnemi.text = "Ennemis restants: " + nbEnnemiRestant.ToString();
    }

    public void EnnemiMort()
    {
        nbEnnemiRestant -= 1;
        txtNbEnnemi.text = "Ennemis restants: " + nbEnnemiRestant.ToString();

        if (nbEnnemiRestant == 0)
            FinNiveau();
    }

    public void FinNiveau()
    {
        txtObjectif.text = "Repliez-vous sur l heliport !";
        finNiveau = true;
    }

    public void SpawnDerniereVague()
    {
        txtObjectif.text = "Tuez les jusqu'aux derniers !";

        finNiveau = false;
        spawnEnnemi();
        CompterEnnemi();

        txtNbEnnemi.text = "Ennemis restants: " + nbEnnemiRestant.ToString();

        if (nbEnnemiRestant == 0)
            FinNiveau();
    }

    private void CompterEnnemi()
    {
        GameObject[] _listEnnemi = GameObject.FindGameObjectsWithTag("ennemi");
        nbEnnemiRestant = _listEnnemi.Length;
    }
}
