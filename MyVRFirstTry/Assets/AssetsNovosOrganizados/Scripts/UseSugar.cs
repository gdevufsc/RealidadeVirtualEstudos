using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseSugar :TemSliderEContaTempo {

    public GameObject[] acucaresParaUsar;

    private void Start () {
        myDelegate += Acao; //MyDelegate definido na superclasse TemSliderEContaTempo
    }

    public void Acao () {
        StartCoroutine(UsarAcucar());
    }

    IEnumerator UsarAcucar () {
        foreach (GameObject sugar in acucaresParaUsar) {
            sugar.SetActive(false);
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("prototipo001");
    }
}
