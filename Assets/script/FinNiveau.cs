using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
    private bool vagueFinAspawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !vagueFinAspawn && GameManger.instance.finNiveau)
        {
            GameManger.instance.SpawnDerniereVague();
            vagueFinAspawn = true;
        }
        else if(other.CompareTag("Player") && vagueFinAspawn && GameManger.instance.finNiveau)
        {
            SceneManager.LoadScene("menuGagne");
        }
    }
}
