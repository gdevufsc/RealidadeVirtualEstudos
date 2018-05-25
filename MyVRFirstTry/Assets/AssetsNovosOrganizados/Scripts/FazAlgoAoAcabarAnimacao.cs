﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//nao estou usando esse script
public class FazAlgoAoAcabarAnimacao : MonoBehaviour {

    public Animation anim;
    protected delegate void MyDelegate ();
    protected MyDelegate myDelegate;

    void Start () {
        StartCoroutine(AoAudioAcabar());
    }

    IEnumerator AoAudioAcabar () {
        int k = 0;
        //verifica-se se jah comecou, pois tem um delay do metodo PlayOneShot ateh comecar
        while (!anim.IsPlaying("VenhamFichas") && k < 1200) { //se nao comecar em 20s, esquece
            k++;
            yield return null;
        }
        k = 0; //verifica se terminou. 3600 = 60*60 = 60 frames * 60 segundos = 3600 frames
        while (anim.IsPlaying("VenhamFichas") && k < 3600) { //se nao terminar em um minuto, aborta
            k++;
            yield return null;
        }

        myDelegate();
        //exemplos de coisas pra colocar numa funcao que seria adicionada ( += ) ao delegate
        /*blocoInteracao.podeInteragir = true;
        animatorBloco.SetTrigger("comecaAnim");
        gameObject.GetComponent<Animator>().SetTrigger("comecaAnim");*/
        //SceneManager.LoadScene("prototipo001");
    }
}
