using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab do bloco
    public GameObject player; // Prefab do jogador
    public int rows = 5; // N�mero de linhas da matriz
    public int cols = 5; // N�mero de colunas da matriz
    public float spacing = 1.1f; // Espa�amento entre os blocos

    private Block[,] grid; // Matriz 2D para armazenar os blocos
    private int conqueredTerritories = 0;

    void Start()
    {
        grid = new Block[rows, cols];
        CreateGrid();
    }

    // M�todo para criar a matriz de blocos
    void CreateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector2 position = new Vector2(col * spacing, row * spacing);
                GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity);
                grid[row, col] = newBlock.GetComponent<Block>();
                grid[row, col].Initialize(row, col, this);
            }
        }

        // Posicionar o jogador no centro do tabuleiro
        Vector2 playerStartPosition = new Vector2((cols / 2) * spacing, (rows / 2) * spacing);
        Instantiate(player, playerStartPosition, Quaternion.identity);
    }

    // M�todo que � chamado quando um territ�rio � conquistado
    public void ConquerTerritory(int row, int col)
    {
        if (!grid[row, col].IsConquered())
        {
            grid[row, col].SetConquered(true);
            conqueredTerritories++;
            Debug.Log("Territ�rios conquistados: " + conqueredTerritories);
        }
    }

    // M�todo que retorna a quantidade de territ�rios conquistados
    public int GetConqueredTerritories()
    {
        return conqueredTerritories;
    }

    // M�todo que retorna a quantidade de territ�rios restantes
    public int GetRemainingTerritories()
    {
        return (rows * cols) - conqueredTerritories;
    }
}
