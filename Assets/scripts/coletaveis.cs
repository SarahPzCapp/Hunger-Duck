using UnityEngine;

public class Coletavel : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController  Player = other.GetComponent<PlayerController>();
            if (Player != null)
            {
                Player.SomarPonto();
            }
            Destroy(gameObject);
        }
    }

}
