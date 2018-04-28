using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nao : TemSliderEContaTempo
{

    public MemoriaParaVideos memoriaParaVideos;

    private void Start()
    {
        myDelegate += ApertouNao;
    }

    public void ApertouNao()
    {
        MemoriaParaVideos.enderecoAtualMemoria += '0';
        memoriaParaVideos.PlayVideo();
    }



}
