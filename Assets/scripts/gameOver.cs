using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public float limiteY = -12f; // altura em que considera que caiu

    void Update()
    {
        if (transform.position.y < limiteY)
        {
            SceneManager.LoadScene("gameover");
        }
    }
}