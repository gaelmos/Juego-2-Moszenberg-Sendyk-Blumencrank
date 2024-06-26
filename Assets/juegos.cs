using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class juegos : MonoBehaviour
{
    int sumatotal;


    public int cantidaddinero;
    public GameObject[] objetos;
    public Transform lugar1;
    public Transform lugar2;
    public Text precios1;
    public Text  precios2;
    public Text dineroactual;
    public GameObject panel;
    public Text resultado;
    public Button alcanzaysobra;
    public Button alcanza;
    public Button falta;
    public Button jugarotravez;
    public Button salir;
    
    private int objeto1;
    private int objeto2;
    private GameObject ponerob1;
    private GameObject ponerob2;
    // Start is called before the first frame update
    void Start()
    {
     
        GenerarProductos();
        panel.SetActive(false);
        GenerarCantidadDinero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerarCantidadDinero()
    {
        
        cantidaddinero = Random.Range(50, 1000);
        dineroactual.text = "Dinero: $" + cantidaddinero.ToString();
    }
    void GenerarProductos()
    {
        if (ponerob1 != null) Destroy(ponerob1);
        if (ponerob2 != null) Destroy(ponerob2);

        ponerob1 = Instantiate(objetos[Random.Range(0, objetos.Length)], lugar1.position, Quaternion.identity);
        ponerob2 = Instantiate(objetos[Random.Range(0, objetos.Length)], lugar2.position, Quaternion.identity);

        Producto producto1 = ponerob1.GetComponent<Producto>();
        Producto producto2  = ponerob2.GetComponent<Producto>();
        sumatotal = producto1.precio + producto2.precio;
        precios1.text = objeto1.ToString();
        precios2.text =  objeto2.ToString();
    }
    void VerificarAlcanzaYSobra()
    {
        
        bool bien = cantidaddinero > sumatotal;
        MostrarResultado(bien);
    }

    void VerificarAlcanzaJusto()
    {
        ;
        bool bien = cantidaddinero == sumatotal;
        MostrarResultado(bien);
    }

    void VerificarNoAlcanza()
    {
        bool bien = cantidaddinero < sumatotal;
        MostrarResultado(bien);
    }

    void MostrarResultado(bool bien)
    {
        panel.SetActive(true);
        if (bien)
        {
            resultado.text = "¡Correcto!";
            jugarotravez.GetComponentInChildren<Text>().text = "Reiniciar el desafío";
        }
        else
        {
            resultado.text = "Incorrecto.";
            jugarotravez.GetComponentInChildren<Text>().text = "Volver a intentarlo";
        }
    }

    public void JugarOtraVez()
    {
        panel.SetActive(false);
        GenerarProductos();
    }

    public void Salir()
    {
        // Aquí cargas la escena de selección de juegos
        UnityEngine.SceneManagement.SceneManager.LoadScene("SeleccionarJuegos");
    }
}

