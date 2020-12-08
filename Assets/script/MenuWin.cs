using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWin : MonoBehaviour
{
    [SerializeField] private GameObject menuWin = null;

    public void Rejouer()
    {
        MenuOption.Rejouer(menuWin, "jeu");
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
