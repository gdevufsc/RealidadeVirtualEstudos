using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim : TemSliderEContaTempo {

    public MemoriaParaVideos memoriaParaVideos;

    private void Start()
    {
        myDelegate += ApertouSim; //MyDelegate definido na superclasse TemSliderEContaTempo
    }

    public void ApertouSim()
    {
        MemoriaParaVideos.enderecoAtualMemoria += 's';
        memoriaParaVideos.PlayVideo();
    }

}
