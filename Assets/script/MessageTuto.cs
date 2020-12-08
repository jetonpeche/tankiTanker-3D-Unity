using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageTuto : MonoBehaviour
{
    [TextArea]
    public string message;
    public int tempoRetourMenu = 3;

    [SerializeField] private Text textMessage = null;
    [SerializeField] private bool finTuto = false;

    private GameObject enemi;
    private bool coroutineStart = false;


    private void Start()
    {
        if (!finTuto)
            InvokeRepeating("VerifierEnnemiEnVie", 0, 0.5f);
    }

    private void VerifierEnnemiEnVie()
    {
        enemi = null;
        enemi = GameObject.FindGameObjectWithTag("ennemi");

        if (enemi == null)
            finTuto = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            textMessage.text = message;

            if (finTuto)
            {
                if (!coroutineStart)
                {
                    StartCoroutine(Tempo());
                    coroutineStart = true;
                }
            }
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textMessage.text = "";

            if (finTuto)
            {
                if (!coroutineStart)
                {
                    StartCoroutine(Tempo());
                    coroutineStart = true;
                }
                    
            }
        }
    }

    private void FinTuto()
    {
        SceneManager.LoadScene("menuPrincipal");
    }

    private IEnumerator Tempo()
    {
        yield return new WaitForSeconds(5);
        FinTuto();
    }

}
