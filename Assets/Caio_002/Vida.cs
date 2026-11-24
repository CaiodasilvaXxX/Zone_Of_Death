using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public float vidaMaxima = 100f;
    public float vidaAtual;

    [Header("Interface (UI)")]
    public Image barraDeVida;

    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarBarra();
    }

    void Update()
    {
        // Controles de teste
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TomarDano(20f); // Pressione Espaço para tomar 20 de dano
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Curar(15f); // Pressione H para curar 15 de vida
        }
    }

    public void TomarDano(float quantidade)
    {
        vidaAtual -= quantidade;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima); // Garante que a vida fique entre 0 e a vida máxima
        AtualizarBarra();

        if (vidaAtual <= 0)
        {
            Die();
        }
    }

    public void Curar(float quantidade)
    {
        vidaAtual += quantidade;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);
        AtualizarBarra();
    }

    void AtualizarBarra()
    {
        if (barraDeVida != null)
        {
            // O fillAmount da Image aceita valores de 0.0 (vazio) a 1.0 (cheio)
            barraDeVida.fillAmount = vidaAtual / vidaMaxima;
        }
    }

    void Die()
    {
        Debug.Log("O personagem morreu!");
        // Adicione aqui o código de morte (ex: tocar animação, desativar o jogador, etc.)
    }
}