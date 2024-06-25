using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class juegos : MonoBehaviour
{
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

    private producto objeto1;
    private producto objeto2;
    private GameObject ponerob1;
    private GameObject ponerob2;
    // Start is called before the first frame update
    void Start()
    {
        GenerarProductos();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerarProductos()
    {
        if (ponerob1 != null) Destroy(ponerob1);
        if (ponerob2 != null) Destroy(ponerob2);

        ponerob1 = Instantiate(objetos[Random.Range(0, objetos.Length)], lugar1.position, Quaternion.identity);
        ponerob2 = Instantiate(objetos[Random.Range(0, objetos.Length)], lugar2.position, Quaternion.identity);

        objeto1 = ponerob1.GetComponent<producto>();
        objeto2 = ponerob2.GetComponent<producto>();

        precios1.text = "$" + objeto1.ToString();
        precios2.text = "$" + objeto2.ToString();
        dineroactual.text = "Dinero: $" + dineroactual.ToString();
    }
}
