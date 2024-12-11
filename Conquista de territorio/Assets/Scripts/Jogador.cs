using UnityEngine;

public class Jogador : JogadorBase
{
    [SerializeField] bool jogador1;
    [SerializeField] public Color corDoJogador;

    void Update()
    {
        // Movimenta��o personalizada para o jogador
        if (jogador1)
        {
            if (Input.GetKey(KeyCode.A)) { direcao.x = -1; }
            else if (Input.GetKey(KeyCode.D)) { direcao.x = 1; }
            else { direcao.x = 0; }

            if (Input.GetKey(KeyCode.S)) { direcao.y = -1; }
            else if (Input.GetKey(KeyCode.W)) { direcao.y = 1; }
            else { direcao.y = 0; }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow)) { direcao.x = -1; }
            else if (Input.GetKey(KeyCode.RightArrow)) { direcao.x = 1; }
            else { direcao.x = 0; }

            if (Input.GetKey(KeyCode.DownArrow)) { direcao.y = -1; }
            else if (Input.GetKey(KeyCode.UpArrow)) { direcao.y = 1; }
            else { direcao.y = 0; }
        }

        // Chama o m�todo Mover da classe base
        Mover();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se o jogador colidir com um bloco, ele conquista o territ�rio
        if (other.CompareTag("Block"))
        {
            Bloco bloco = other.GetComponent<Bloco>();
            if (!bloco.PegarConquistado())
            {
                bloco.Interagir(gameObject); // Usa a intera��o do bloco
            }
        }
    }

    public bool IsJogador1() => jogador1;
}
