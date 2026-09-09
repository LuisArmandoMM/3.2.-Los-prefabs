using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaController : MonoBehaviour
{
    [Header("Referencia al panel de pausa")]
    [SerializeField] private GameObject panelPausa;

    [Header("Escena del menú principal (para Salir)")]
    [SerializeField] private string nombreEscenaMenu = "SampleScene";

    private bool juegoPausado = false;

    // Botón de Pausa (el que ya tienes en el HUD)
    public void OnBotonPausaClick()
    {
        if (juegoPausado)
        {
            Continuar();
        }
        else
        {
            Pausar();
        }
    }

    private void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f; // congela el juego
        juegoPausado = true;
    }

    // Botón "Continuar" dentro del panel de pausa
    public void Continuar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f; // reanuda el juego
        juegoPausado = false;
    }

    // Botón "Salir" dentro del panel de pausa
    public void Salir()
    {
        Time.timeScale = 1f; // importante: restaurar antes de cambiar de escena
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}