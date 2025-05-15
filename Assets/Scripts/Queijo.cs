using UnityEngine;

public class Queijo : MonoBehaviour
{
    private float minX = -15.09f;
    private float maxX = 15.13f;
    private float minY = -8.87f;
    private float maxY = 8.82f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Certifique-se que o rato tem a tag "Player"
        {
            MoverParaNovaPosicao();
        }
    }

    void MoverParaNovaPosicao()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        transform.position = new Vector2(x, y);
    }
}
