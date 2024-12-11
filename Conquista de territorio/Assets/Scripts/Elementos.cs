using UnityEngine;

public class Elemento : MonoBehaviour
{
    // M�todo virtual que pode ser sobrescrito pelas subclasses
    public virtual void Interagir(GameObject jogador)
    {
        Debug.Log("Intera��o padr�o com o jogador");
    }
}
