using UnityEngine;
using TMPro;

public class Ninho : MonoBehaviour
{
    public TMP_Text mensagem; // texto que mostra avisos na tela

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Pontuacao pontos = outro.GetComponent<Pontuacao>();

            if (pontos != null && pontos.pontos >= 3)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("vitoria");
            }
            else if (mensagem != null)
            {
                // Mostra aviso na tela quando não tem pontos suficientes
                mensagem.text = "Você precisa de 3 pontos!";
            }
        }
    }
}