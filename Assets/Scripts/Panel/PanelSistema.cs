using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSistema : MonoBehaviour
{
    [Header("Enlaces - Costado Izquierdo (3)")]
    [SerializeField] private string linkIzq1 = "https://www.udgvirtual.udg.mx/";
    [SerializeField] private string linkIzq2 = "https://www.udg.mx/";
    [SerializeField] private string linkIzq3 = "https://unity.com/";

    [Header("Enlaces - Costado Derecho (3)")]
    [SerializeField] private string linkDer1 = "https://www.febucci.com/2018/10/unity-ui-tutorial/";
    [SerializeField] private string linkDer2 = "https://docs.unity3d.com/";
    [SerializeField] private string linkDer3 = "https://github.com/";

    [Header("Escena del escenario de juego")]
    [SerializeField] private string nombreEscenaJuego = "level1";

    // ---------- Enlaces lado izquierdo ----------
    public void AbrirLinkIzq1() => Application.OpenURL(linkIzq1);
    public void AbrirLinkIzq2() => Application.OpenURL(linkIzq2);
    public void AbrirLinkIzq3() => Application.OpenURL(linkIzq3);

    // ---------- Enlaces lado derecho ----------
    public void AbrirLinkDer1() => Application.OpenURL(linkDer1);
    public void AbrirLinkDer2() => Application.OpenURL(linkDer2);
    public void AbrirLinkDer3() => Application.OpenURL(linkDer3);

    // ---------- Los 3 botones principales ----------
    public void OnBoton1Click()
    {
        Debug.Log("Botón 1 presionado");
    }

    public void OnBoton2Click()
    {
        Debug.Log("Botón 2 presionado");
    }

    // Botón "Jugar" — carga la escena level1
    public void OnBoton3Click()
    {
        SceneManager.LoadScene(nombreEscenaJuego);
    }
}