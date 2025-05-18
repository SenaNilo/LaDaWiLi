using UnityEngine;

public class Queijo : MonoBehaviour
{
    private float minX = -15.09f;
    private float maxX = 15.13f;
    private float minY = -8.87f;
    private float maxY = 8.82f;

    public GameObject ratoeiraPrefab; 
    public LayerMask camadaObstaculos; // Atribua a Layer "Obstaculos" no Inspector
    private float distanciaSegura = 1.5f;
    private float raioVerificacao = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            SomController.instancia.TocarSomQueijo();
            GameManager.instancia.AdicionarScore();
            // Aumentar a velo do ratinho
            RatoMovimento rato = other.GetComponent<RatoMovimento>();
            if (rato != null)
            {
                rato.velocidade += 0.75f;
            }


            // Move o queijo para nova posição, longe de ratoeiras e dele mesmo
            MoverParaNovaPosicao();

            // Reposicionamento da ratoeira
            Vector2 posicaoRatoeira;
            int tentativas = 0;

            do
            { //Fazer com que nao spawne junto com o queijo
                float x = Random.Range(minX, maxX);
                float y = Random.Range(minY, maxY);
                posicaoRatoeira = new Vector2(x, y);
                tentativas++;
            }
            while ((Vector2.Distance(posicaoRatoeira, transform.position) < distanciaSegura 
                    || Physics2D.OverlapCircle(posicaoRatoeira, raioVerificacao, camadaObstaculos)) 
                    && tentativas < 20);

            // Define rotação aleatória
            float angulo = Random.value < 0.5f ? 0f : 90f;
            Quaternion rotacao = Quaternion.Euler(0f, 0f, angulo);

            // Instancia a ratoeira
            Instantiate(ratoeiraPrefab, posicaoRatoeira, rotacao);
        }
    }

    void MoverParaNovaPosicao()
    {
        Vector2 novaPosicao;
        int tentativas = 0;

        do
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            novaPosicao = new Vector2(x, y);
            tentativas++;
        }
        while ((Vector2.Distance(novaPosicao, transform.position) < 0.5f 
                || Physics2D.OverlapCircle(novaPosicao, raioVerificacao, camadaObstaculos)) 
                && tentativas < 20);

        transform.position = novaPosicao;
    }
}
