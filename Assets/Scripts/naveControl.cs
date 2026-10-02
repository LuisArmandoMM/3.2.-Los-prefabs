using UnityEngine;

public class NaveController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool juegoIniciado = false;

    public void IniciarJuego()
    {
        if (juegoIniciado) return; // evita disparar dos veces
        juegoIniciado = true;
        animator.SetTrigger("Iniciar");
    }
}