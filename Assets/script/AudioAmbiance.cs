using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioAmbiance : MonoBehaviour
{
    [SerializeField] private AudioClip[] listSon = null;

    public bool menuPrincipal;

    private AudioSource audioSource;
    private int index = 0;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if(menuPrincipal)
            JouerMusicAmbiance();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && menuPrincipal)
        {
            JouerMusicAmbiance();
        }
        else if(!audioSource.isPlaying && MenuGameOver.instance.perdu)
        {            
            JouerMusicAmbiance();
        }
    }

    private void JouerMusicAmbiance()
    {
        index = (index + 1) % listSon.Length;
        audioSource.clip = listSon[index];
        audioSource.Play();
    }
}
