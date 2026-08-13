using UnityEngine;
using TMPro; // necessário para TextMeshPro

public class Pontuacao : MonoBehaviour
{
    public int pontos = 0;
    public TMP_Text textoPontos; // arraste o TextMeshPro aqui no Inspector
    public void GanharPonto()
    {
        pontos++;
        Debug.Log("Ponto ganho! Total: " + pontos);
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        if (textoPontos != null)
        {
            textoPontos.text = "Pontos: " + pontos;
        }
    }

     
}