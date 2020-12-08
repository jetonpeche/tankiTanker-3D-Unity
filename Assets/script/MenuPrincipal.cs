using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public void Jouer()
    {
        MenuOption.Jouer();
    }

    public void Tuto()
    {
        MenuOption.JouerTuto();
    }

    public void QuitterJeu()
    {
        MenuOption.Quitter();
    }
}
