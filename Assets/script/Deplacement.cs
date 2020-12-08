using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Deplacement : MonoBehaviour
{
    [SerializeField] private int vitesse = 0, vitesseRotationTourelle = 0, vitesseRotationChassis = 0;
    [SerializeField] private Transform tourelle = null, chassis = null;
    [SerializeField] private Transform[] listElementChassis = null;
    [SerializeField] private Son son = null;

    private Vector3 velocite = Vector3.zero, vRotation = Vector3.zero;
    private Rigidbody rb = null;

    private bool sonMoteurDeplacementJoue;
    private bool sonMoteurIdleJoue;

    private void Start()
    {
        velocite.Normalize();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // deplacement personnage
        float _deplacementZ = Input.GetAxisRaw("Vertical");

        // avancer reculer par rapport a la rotation du chassis
        Vector3 _vDeplacementZ = chassis.forward * _deplacementZ;
        velocite = _vDeplacementZ * vitesse;

        // rotation de la tourelle
        float _rotationY = Input.GetAxisRaw("Mouse X");
        vRotation = new Vector3(0, _rotationY, 0) * vitesseRotationTourelle;

        RotationTourelle();
        RotationChassis();
    }

    private void FixedUpdate()
    {
        DeplacementJ();       
    }

    private void DeplacementJ()
    {
        if (velocite != Vector3.zero)
        {
            // activer le son de deplacement une fois
            if (!sonMoteurDeplacementJoue)
            {
                son.JouerSonDeplacement();
                sonMoteurDeplacementJoue = true;
                sonMoteurIdleJoue = false;
            }

            rb.MovePosition(transform.position + velocite * Time.fixedDeltaTime);
        }
        // activer le son idle une fois
        else if (!sonMoteurIdleJoue)
        {
            son.JouerSonMoteurIdle();
            sonMoteurDeplacementJoue = false;
            sonMoteurIdleJoue = true;
        } 
    }

    private void RotationTourelle()
    {
        tourelle.Rotate(vRotation);
    }

    private void RotationChassis()
    {
        foreach (var element in listElementChassis)
        {
            element.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal") * vitesseRotationChassis, 0));
        }
    }
}
