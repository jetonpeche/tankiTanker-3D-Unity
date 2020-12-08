using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SuivreJoueur : MonoBehaviour
{
    private Transform joueur = null;
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform tourelle = null;

    private void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        tourelle.LookAt(joueur);
        agent.SetDestination(joueur.position);
    }
}
