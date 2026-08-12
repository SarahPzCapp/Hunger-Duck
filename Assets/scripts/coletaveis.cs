using UnityEngine;

public class Coletavel : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController  pato = other.GetComponent<PlayerController>();
            if (pato != null)
            {
                pato.SomarPonto();
            }
            Destroy(gameObject);
        }
    }

}
