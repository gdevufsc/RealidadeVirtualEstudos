using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatoGuiche : FazAlgoAoAcabarAudio {

    public AudioSource bocaPlayer;
    public Animator dinheiro;//, fichas;
    public Animation fichas2;

    void Start () {
        myDelegate += FacaAoAcabarOAudio;
	}
	
    public void FacaAoAcabarOAudio () {
        dinheiro.SetTrigger("comecaAnim");
        //fichas.SetTrigger("comecaAnim");
        fichas2.Play();
    }

}
