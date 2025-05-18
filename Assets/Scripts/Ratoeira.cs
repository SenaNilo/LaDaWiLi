using UnityEngine;

public class Ratoeira : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SomController.instancia.TocarGameOver();
            SomController.instancia.TocarSomMorte();
            Debug.Log("Game Over!");
            Destroy(other.gameObject); // Destrói o rato
            // Aqui você pode chamar alguma lógica extra de game over se quiser
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
