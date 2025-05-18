using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
        Debug.Log("JOGAR FOI CLICADO!");
        SceneManager.LoadScene("CheeseChase"); 
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}