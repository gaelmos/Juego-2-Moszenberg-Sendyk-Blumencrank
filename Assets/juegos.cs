using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class juegos : MonoBehaviour
{
    int sumatotal;


    public int cantidaddinero;

    public GameObject[] objetos;

    public Transform lugar1;
    public Transform lugar2;

    public Text precios1;
    public Text precios2;
    public Text dineroactual;
    public Text resultado;

    public GameObject panel;
   

    
    private GameObject ponerob1;
    private GameObject ponerob2;
    // Start is called before the first frame update
    void Start()
    {
        ponerob1 = Instantiate(objetos[Random.Range(0, objetos.Length)], lugar1.position, Quaternion.identity);
        ponerob2 = Instantiate(objetos[Random.Range(0, objetos.Length)], lugar2.position, Quaternion.identity);

        Producto producto1 = ponerob1.GetComponent<Producto>();
        Producto producto2 = ponerob2.GetComponent<Producto>();

        sumatotal = producto1.precio + producto2.precio;

        precios1.text = producto1.precio.ToString();
        precios2.text = producto2.precio.ToString();

        

        cantidaddinero = Random.Range(1000, 10000);
        dineroactual.text = "Dinero: $" + cantidaddinero.ToString();

        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
        
    
    
    public void VerificarAlcanzaYSobra()
    {

        bool bien = cantidaddinero > sumatotal;
        MostrarResultado(bien);
    }

    public void VerificarAlcanzaJusto()
    {
        
        bool bien = cantidaddinero == sumatotal;
        MostrarResultado(bien);
    }

    public void VerificarNoAlcanza()
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
        }
        else
        {
            resultado.text = "Incorrecto.";
            
        }
    }

    public void JugarOtraVez()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        // Aquí cargas la escena de selección de juegos
        UnityEngine.SceneManagement.SceneManager.LoadScene("SeleccionarJuegos");
    }
}

