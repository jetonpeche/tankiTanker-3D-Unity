using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class DeplacementEnnemi : MonoBehaviour
{
    [SerializeField] private Transform[] listPosition = null;
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private DetectionJoueur detectionJoueur = null;

    private int index = 0;
    private bool modePoursuiteJoueur;
    private Transform joueur;

    private void Start()
    { 
        // se rendre a la position
        if (agent != null)
            agent.SetDestination(listPosition[index].position);
    }

    private void Update()
    {
        Deplacement();
    }

    private void Deplacement()
    {
        if (!modePoursuiteJoueur)
        {
            if (Vector3.Distance(transform.position, listPosition[index].position) < 0.3f)
            {
                index = (index + 1) % listPosition.Length;
                if (agent != null)
                    agent.SetDestination(listPosition[index].position);
            }
        }
        else
        {
            if (agent != null)
                agent.SetDestination(joueur.position);
        }
    }

    public void PoursuivreJoueur(Transform _joueur, int _tpsPoursuite)
    {
        if(agent != null)
        {
            // le go stop a une distance de 5 unitées entre lui et le go
            agent.stoppingDistance = 5;
            modePoursuiteJoueur = true;
            joueur = _joueur;

            Invoke("StopperPoursuiteJoueur", _tpsPoursuite);
        }       
    }

    public void StopperPoursuiteJoueur()
    {
        if(agent != null)
        {
            CancelInvoke("StopperPoursuiteJoueur");

            detectionJoueur.estAttaquer = false;
            agent.stoppingDistance = 0;
            modePoursuiteJoueur = false;
            joueur = null;
            agent.SetDestination(listPosition[index].position);

            // permet de tirer 2 obus de plus
            Invoke("StopperTirer", 4);
        }      
    }

    private void StopperTirer()
    {
        detectionJoueur.cible = null;    
    }
}
