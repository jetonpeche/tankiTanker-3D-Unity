using UnityEngine;

public class BarChargementCanonManager : MonoBehaviour
{
    [SerializeField] private BarChargementCanon[] listBarCanon = null;

    [HideInInspector]
    public delegate void D_canonDecharger();
    public D_canonDecharger d_canonDecharger;

    private void Start()
    {
        foreach (BarChargementCanon element in listBarCanon)
        {
            d_canonDecharger += element.CanonDecharger;
        }
    }
}
