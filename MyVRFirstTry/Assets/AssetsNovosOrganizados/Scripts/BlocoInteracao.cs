using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoInteracao : TemSliderEContaTempo {

    public GameObject acucar, dinheiro;
    public bool podeInteragir=false;

    private void Start () {
        myDelegate += Acao; //MyDelegate definido na superclasse TemSliderEContaTempo
    }

    public void Acao () {
        if (podeInteragir) {
            acucar.SetActive(true);
            dinheiro.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
