using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDinheiro : TemSliderEContaTempo {

    public Animator anim, fichasAnim;

    private void Start () {
        myDelegate += Acao; //MyDelegate definido na superclasse TemSliderEContaTempo
    }

    public void Acao () {
        anim.SetTrigger("comecaAnim");
        fichasAnim.SetTrigger("comecaAnim");
    }
}
