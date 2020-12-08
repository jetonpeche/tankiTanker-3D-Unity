using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static MenuPause instance;

    [SerializeField] private GameObject menuPause = null;

    public bool jeuEnPause;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("plus d'une instance de menuPause");

        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !jeuEnPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            jeuEnPause = true;    
            menuPause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continuer()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        jeuEnPause = false;
        menuPause.SetActive(false);
    }

    public void MenuPrincipal()
    {
        MenuOption.MenuPrincipal();
    }
}
