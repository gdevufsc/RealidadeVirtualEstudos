using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//nao estou usando esse script
public class FichasGuiche : FazAlgoAoAcabarAnimacao {

    private void Start () {
        myDelegate += Acao; //MyDelegate definido na superclasse TemSliderEContaTempo
    }

    public void Acao () {
        SceneManager.LoadScene("prototipo001");
    }
}
