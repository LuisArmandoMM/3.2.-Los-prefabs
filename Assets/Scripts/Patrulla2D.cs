using UnityEngine;

public class Patrulla2D : MonoBehaviour
{
    [Header("Límites de movimiento")]
    [SerializeField] private Transform limiteIzquierdo;
    [SerializeField] private Transform limiteDerecho;

    [Header("Movimiento")]
    [SerializeField] private float velocidad = 3f;

    private Vector2 objetivoActual;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Empieza yendo hacia la derecha
        objetivoActual = limiteDerecho.position;
    }

    private void Update()
    {
        // Mover hacia el objetivo actual
        transform.position = Vector2.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        // Voltear el sprite según la dirección de movimiento
        if (sr != null)
        {
            sr.flipX = objetivoActual.x < transform.position.x;
        }

        // Si llegó al objetivo, cambia hacia el otro extremo
        if (Vector2.Distance(transform.position, objetivoActual) < 0.05f)
        {
            objetivoActual = (objetivoActual == (Vector2)limiteDerecho.position)
                ? (Vector2)limiteIzquierdo.position
                : (Vector2)limiteDerecho.position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (limiteIzquierdo == null || limiteDerecho == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(limiteIzquierdo.position, limiteDerecho.position);
        Gizmos.DrawWireSphere(limiteIzquierdo.position, 0.1f);
        Gizmos.DrawWireSphere(limiteDerecho.position, 0.1f);
    }
}
