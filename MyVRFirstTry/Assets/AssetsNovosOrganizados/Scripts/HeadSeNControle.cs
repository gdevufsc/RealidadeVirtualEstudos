﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//quem ativa esse objeto atualmente eh o Investigador (25/05/2018)

///Esse script estah sendo usado na cena intitulada SimENaoComACabeca, no objeto HeadSeN
///A ideia eh verificar se o jogador fez que Sim ou que Nao com a cabeca, e executar algo em resposta.
///ele controla os 4 Quads que sao seus filhos na hierarquia, gerenciando o tempo e concatenando
///devidamente s e n de acordo com o movimento da cabeca do player nas direcoes vertical e horizontal.
///Ele eh baseado no evento do GoogleVR PointerEnter, e no tempo.
public class HeadSeNControle : MonoBehaviour {

    string sequencia = ""; //eh onde vai ser concatenado s e n
    public double tempoParaResetar=2; // tempo para fazer sequencia=""
    public int quantasVezesEncaraQuads=3; //vezes que tu precisa olhar para um quad X para concatenar X
    double cont = 0; // contador para o tempo
    string sequenciaS = "", sequenciaN =""; //variaveis auxiliares para guardar a sequencia de s ou n
    //a serem atingidas.
    public Investigador investigador;

    //public Memoria Memoria; //referencias a essa classe que controla os videos nesse app
    //public GameObject SUp, SDown, SLeft, SRight; //sao os objetos Quads, isto eh, os S e N

    public bool segueACabeca; //ativar no editor para que esse objeto fique centralizando na camera
    
    //aqui estah sendo setado a sequencia alvo, de acordo com o tamanho "quantasVezesEncaraQuad"
    private void Start () {

        for (int i=0 ; i<quantasVezesEncaraQuads ; i++) {
            sequenciaS += 's'; sequenciaN += 'n';
        }
        if (segueACabeca)
            CentralizaComACamera();
    }

    void Update () {
        //incrementa por alguns segundos e então zera, resetando a sequencia da cabeça
        if (cont < tempoParaResetar) {
            cont += Time.deltaTime;
        } else {
            cont = 0;
            sequencia = "";
            if (segueACabeca)
            CentralizaComACamera();
        }
        
	}

    //faz o que tem que fazer quando olharam para o S
    public void DizQueSim () {
        sequencia = sequencia + "s";
        VerificaSequencia();
        ControlaRitmo();
    }

    //faz o que tem que fazer quando olharam para o N
    public void DizQueNao () {
        sequencia += "n";
        VerificaSequencia();
        ControlaRitmo();
    }

    //soh confere se foi atingida a sequencia alvo de S ou N, tipo SS ou NNN e chama a acao desejada
    void VerificaSequencia () {
        if(sequencia == sequenciaS) {
            AcaoParaSim();
        } else if (sequencia == sequenciaN) {
            AcaoParaNao();
        }
    }

    //controla aspectos do ritmo de dizer S ou N..
    void ControlaRitmo () {
        cont = 0; //zera o contador
        if (sequencia.Length>quantasVezesEncaraQuads) {
            sequencia = ""; //reinicia a sequencia caso esteja sendo concatenada uma coisa gigante
        }// soh pra qd nao pegou no comeco e o player estah tentando sem parar dizer S ou N
    }

    //nas acoes atualmente estah sendo chamada a interacao do investigador
    void AcaoParaSim () {
        Memoria.enderecoAtualMemoria += 's';
        //Memoria.PlayVideo();
        investigador.Interagir(); //essa eh a linha que ele chama a interacao-----------------------------------
        this.gameObject.SetActive(false);
    }

    void AcaoParaNao () {
        Memoria.enderecoAtualMemoria += 'n';
        //Memoria.PlayVideo();
        investigador.Interagir(); //essa eh a linha que ele chama a interacao-----------------------------------
        gameObject.SetActive(false);
    }

    //esse metodo faz o sistema de HeadSeN (S e N) aparecer na frente da camera
    void CentralizaComACamera () {
        transform.SetParent(Camera.main.transform);
        transform.localPosition = new Vector3(0, 0, 1);
        transform.localEulerAngles = new Vector3(0 , -90 , 0);
        transform.SetParent(null);
    }
}
