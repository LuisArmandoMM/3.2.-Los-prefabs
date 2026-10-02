using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento = 6f;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto = 12f;
    [SerializeField] private float gravedadExtra = 2.5f; // hace el salto menos "flotante"

    [Header("Detección de suelo")]
    [SerializeField] private Transform puntoChequeoSuelo;
    [SerializeField] private float radioChequeoSuelo = 0.15f;
    [SerializeField] private LayerMask capaSuelo;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float inputHorizontal;
    private bool enSuelo;
    private bool quiereSaltar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Leer input cada frame
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            quiereSaltar = true;
        }

        // Voltear el sprite según la dirección
        if (inputHorizontal > 0f) sr.flipX = false;
        else if (inputHorizontal < 0f) sr.flipX = true;

        // Chequear si está tocando el suelo
        enSuelo = Physics2D.OverlapCircle(puntoChequeoSuelo.position, radioChequeoSuelo, capaSuelo);
    }

    private void FixedUpdate()
    {
        // Movimiento horizontal
        rb.linearVelocity = new Vector2(inputHorizontal * velocidadMovimiento, rb.linearVelocity.y);

        // Salto
        if (quiereSaltar && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
        quiereSaltar = false;

        // Gravedad extra para que la caída se sienta mejor
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * gravedadExtra * Time.fixedDeltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoChequeoSuelo == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoChequeoSuelo.position, radioChequeoSuelo);
    }
}
