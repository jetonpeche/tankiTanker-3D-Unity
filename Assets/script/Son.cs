using UnityEngine;

public class Son : MonoBehaviour
{
    [Header("sons moteur")]
    [SerializeField] private AudioSource moteur = null;
    [SerializeField] private AudioClip[] listSonMoteur = null;

    [Header("son tir et recharge")]
    [SerializeField] private AudioSource tirEtRecharge = null;
    [SerializeField] private AudioClip son = null;

    [Header("Son alert plus bcp de vie")]
    [SerializeField] private AudioSource alert = null;
    [SerializeField] private AudioClip sonAlert = null;

    [Header("Son touche")]
    [SerializeField] private AudioSource touche = null;
    [SerializeField] private AudioClip sonTouche = null;

    private void Start()
    {      
        if(tirEtRecharge != null)
            tirEtRecharge.clip = son;        
    }

    public void JouerSonToucher()
    {
        if (touche != null)
            touche.clip = sonTouche;
        touche.Play();
    }

    public void JouerSonAlertVie()
    {
        if (alert != null)
            alert.clip = sonAlert;
        alert.Play();
    }

    public void JouerSonTirRecharge()
    {
        tirEtRecharge.Play();
    }
    
    public void JouerSonMoteurIdle()
    {
        if (moteur != null)
            moteur.clip = listSonMoteur[0];
        moteur.Play();
    }

    public void JouerSonDeplacement()
    {
        if (moteur != null)
            moteur.clip = listSonMoteur[1];
        moteur.Play();
    }

    public void StoperSon()
    {
        moteur.Stop();
        alert.Stop();
        tirEtRecharge.Stop();
        touche.Stop();
    }
}
