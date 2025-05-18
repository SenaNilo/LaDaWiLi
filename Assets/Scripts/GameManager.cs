using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int score = 0;
    public TMP_Text scoreTexto;

    // NOVO – Referências da tela de Game Over
    public GameObject gameOverPainel;
    // public TMP_Text gameOverTexto;
    public TMP_Text scoreFinalTexto;
    public Button botaoTentarNovamente;
    public Button botaoMenu;

    public AudioSource musicaFundo;
    public AudioSource somGameOver;
    public AudioSource barulhoRato;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        AtualizarScoreUI();
        gameOverPainel.SetActive(false); // Garante que a tela começa oculta

        // Atribui ações aos botões
        botaoTentarNovamente.onClick.AddListener(RecarregarCena);
        botaoMenu.onClick.AddListener(VoltarParaMenu);
    }

    public void AdicionarScore()
    {
        score++;
        AtualizarScoreUI();
    }

    void AtualizarScoreUI()
    {
        if (scoreTexto != null)
            scoreTexto.text = "Queijos: " + score;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER!");

        // Para a música e toca som de morte
        if (musicaFundo != null) musicaFundo.Stop();
        if (somGameOver != null) somGameOver.Play();
        if (barulhoRato != null) barulhoRato.Play();

        // Mostra tela de Game Over
        gameOverPainel.SetActive(true);
        scoreFinalTexto.text = "Pontuação final: " + score;
    }

    void RecarregarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void VoltarParaMenu()
    {
        SceneManager.LoadScene("Menu"); // Substitua "Menu" pelo nome real da cena do menu
    }
}
