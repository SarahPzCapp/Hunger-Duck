using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaDoPulo = 8f;

    private Rigidbody2D rb;
    private bool estaNoChao;
    private bool viradoParaDireita = true; // começa olhando pra direita
    public int pontos = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * velocidade, rb.linearVelocity.y);

        // Flip: vira o personagem conforme a direção
        if (horizontal > 0 && !viradoParaDireita)
        {
            Virar();
        }
        else if (horizontal < 0 && viradoParaDireita)
        {
            Virar();
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaDoPulo);
        }
    }

    void Virar()
    {
        viradoParaDireita = !viradoParaDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1; // inverte o eixo X
        transform.localScale = escala;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        estaNoChao = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        estaNoChao = false;
    }

     
    public void SomarPonto()
    {
        GetComponent<Pontuacao>().GanharPonto();
    }

}