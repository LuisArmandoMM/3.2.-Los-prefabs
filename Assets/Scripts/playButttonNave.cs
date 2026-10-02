using UnityEngine;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour
{
    [SerializeField] private GameObject Play;
    [SerializeField] private NaveController nave;

    public void OnPlayPressed()
    {
        Play.SetActive(false); // desaparece el botón
        nave.IniciarJuego();        // arranca la animación/movimiento
    }
}