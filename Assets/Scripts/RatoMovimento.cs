using UnityEngine;

public class RatoMovimento : MonoBehaviour
{
    public float velocidade = 5f;
    private Vector3 direcao = Vector3.down; // começa indo pra baixo
    public LayerMask camadaParede; // defina no Inspector

    private SpriteRenderer spriteRenderer;
    private float tempoProximoFlip = 0f;
    public float intervaloFlip = 1f;

    //para musica
    private float tempoUltimoSomParede = 0f;
    private float intervaloSomParede = 0.2f; // mínimo de tempo entre os sons, em segundos


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Verifica se o jogador pressionou uma nova direção
        if (Input.GetKeyDown(KeyCode.W))
            direcao = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.S))
            direcao = Vector3.down;
        else if (Input.GetKeyDown(KeyCode.A))
            direcao = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D))
            direcao = Vector3.right;

        // Raycast: verifica se há camadaParede na direção
        float distanciaRaycast = 0.9f; // distância segura antes da parede
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direcao, distanciaRaycast, camadaParede);


        if (hit.collider == null)
        {
            // Só move se não tiver parede na frente
            transform.position += direcao * velocidade * Time.deltaTime;
        }else{
            // Só toca o som se já passou tempo suficiente
            if (Time.time - tempoUltimoSomParede > intervaloSomParede)
            {
                SomController.instancia.TocarSomParede();
                tempoUltimoSomParede = Time.time;
            }
        }

        // Rotaciona o rato para olhar na direção
        float angle = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 270f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Flip X a cada 1 segundo
        if (Time.time >= tempoProximoFlip)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            tempoProximoFlip = Time.time + intervaloFlip;
        }
    }

    void OnDrawGizmos()
    {
        // Desenha a linha do Raycast na cena para debug
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + direcao * 0.6f);
    }
}
