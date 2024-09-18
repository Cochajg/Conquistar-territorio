using UnityEngine;

public class Block : MonoBehaviour
{
    private bool conquered = false; // O bloco foi conquistado?
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    private int row, col;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    // M�todo para inicializar o bloco com suas coordenadas e refer�ncia ao GameController
    public void Initialize(int row, int col, GameManager manager)
    {
        this.row = row;
        this.col = col;
        this.gameManager = manager;
    }

    // M�todo para alterar o estado de conquista do bloco
    public void SetConquered(bool conquered)
    {
        this.conquered = conquered;
        UpdateColor();
    }

    // M�todo para verificar se o bloco foi conquistado
    public bool IsConquered()
    {
        return conquered;
    }

    // M�todo que muda a cor do bloco dependendo se ele foi conquistado ou n�o
    private void UpdateColor()
    {
        if (conquered)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    // Detectar o clique no bloco
    void OnMouseDown()
    {
        gameManager.ConquerTerritory(row, col);
    }
}
