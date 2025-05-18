using UnityEngine;

public class SomController : MonoBehaviour
{
    public static SomController instancia;

    public AudioSource efeitosAudio;
    public AudioSource musicaFundoAudio;

    public AudioClip somQueijo;
    public AudioClip somMorte;
    public AudioClip gameOver;
    public AudioClip somParede;
    public AudioClip musicaFundo;
    public AudioClip barulhoRato;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Mantém o som ao mudar de cena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicaFundoAudio.clip = musicaFundo;
        musicaFundoAudio.loop = true;
        musicaFundoAudio.Play();

        musicaFundoAudio.clip = barulhoRato;
        musicaFundoAudio.loop = true;
        musicaFundoAudio.Play();
    }

    public void TocarSomQueijo() => efeitosAudio.PlayOneShot(somQueijo);
    public void TocarSomMorte() => efeitosAudio.PlayOneShot(somMorte);
    public void TocarSomParede() => efeitosAudio.PlayOneShot(somParede);
    public void TocarGameOver() => efeitosAudio.PlayOneShot(gameOver);
}