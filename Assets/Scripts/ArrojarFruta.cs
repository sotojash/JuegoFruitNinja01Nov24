using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrojarFruta : MonoBehaviour
{
    public GameObject frutaArrojada;
    public float esperaMinima = 0.3f;
    public float esperaMaxima = 1f;
    public Transform[] lugaresLanzamiento;
    public float fuerzaMinima = 12;
    public float fuerzaMaxima = 17;

    void Start()
    {
        StartCoroutine(Arrojador());
    }

    private IEnumerator Arrojador()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(esperaMinima, esperaMaxima));
            Transform t = lugaresLanzamiento[Random.Range(0, lugaresLanzamiento.Length)];
            GameObject fruta = Instantiate(frutaArrojada, t.position, t.rotation);

            fruta.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(fuerzaMinima, fuerzaMaxima), ForceMode2D.Impulse);

            //para destruir los objetos frutas q se van creando

            Destroy(fruta, 5);
        }
    }
}
