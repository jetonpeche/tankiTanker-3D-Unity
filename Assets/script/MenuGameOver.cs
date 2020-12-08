using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public static MenuGameOver instance;
    public bool perdu;

    [SerializeField] private GameObject menuGameOver = null;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("Il y a plus d'une instance de MenuGameOver");

        instance = this;
    }

    public void GameOver()
    {
        perdu = true;
        Time.timeScale = 0;
        menuGameOver.SetActive(true);
    }

    public void Rejouer()
    {
        MenuOption.Rejouer(menuGameOver, SceneManager.GetActiveScene().name);
    }

    public void MenuPrincipal()
    {
        MenuOption.MenuPrincipal();
    }

    public void QuitterJeu()
    {
        MenuOption.Quitter();
    }
}
