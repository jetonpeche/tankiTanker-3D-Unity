using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuOption
{
    public static void MenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menuPrincipal");
    }

    public static void Jouer()
    {
        SceneManager.LoadScene("jeu");
    }

    public static void JouerTuto()
    {
        SceneManager.LoadScene("tuto");
    }

    public static void Rejouer(GameObject _menu, string _nomScene)
    {
        SceneManager.LoadScene(_nomScene);
        _menu.SetActive(false);
        Time.timeScale = 1;
    }

    public static void Quitter()
    {
        Application.Quit();
    }
}
