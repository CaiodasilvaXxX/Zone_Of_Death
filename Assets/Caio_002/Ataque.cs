using UnityEngine;

public class Ataque : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform maoDireita;
    [SerializeField] private float socoDireitaAlcance = 0.5f;
    [SerializeField] private LayerMask playerMask;

    public void SocoDireita()
    {
        Collider[] acertos = Physics.OverlapSphere(
            maoDireita.position, socoDireitaAlcance, playerMask);

        foreach (Collider c in acertos)
        {
            if (c.transform != this.transform)
            {
                c.transform.GetComponent<Hp>().TomarDano(10f);
            }
        }

    }
}

