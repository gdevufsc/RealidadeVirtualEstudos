using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Esse script estah sendo usado na cena intitulada SimENaoComACabeca, no objeto HeadSeN
///A ideia eh verificar se o jogador fez que Sim ou que Nao com a cabeca, e executar algo em resposta.
///ele controla os 4 Quads que sao seus filhos na hierarquia, gerenciando o tempo e concatenando
///devidamente s e n de acordo com o movimento da cabeca do player nas direcoes vertical e horizontal.
///Ele eh baseado no evento do GoogleVR PointerEnter, e no tempo.
public class HeadSeNControle : MonoBehaviour {

    string sequencia = ""; //eh onde vai ser concatenado s e n
    public double tempoParaResetar=2; // tempo para fazer sequencia=""
    public int quantasVezesEncaraQuads=2; //vezes que tu precisa olhar para um quad X para concatenar X
    double cont = 0; // contador para o tempo
    string sequenciaS = "", sequenciaN =""; //variaveis auxiliares para guardar a sequencia de s ou n
    //a serem atingidas.

    public MemoriaParaVideos memoriaParaVideos; //referencias a essa classe que controla os videos nesse app
    public GameObject SUp, SDown, SLeft, SRight; //sao os objetos Quads, isto eh, os S e N
    
    //aqui estah sendo setado a sequencia alvo, de acordo com o tamanho "quantasVezesEncaraQuad"
    private void Start () {
        for (int i=0 ; i<quantasVezesEncaraQuads ; i++) {
            sequenciaS += 's'; sequenciaN += 'n';
        }
    }

    void Update () {
        //incrementa por alguns segundos e então zera, resetando a sequencia da cabeça
        if (cont < tempoParaResetar) {
            cont += Time.deltaTime;
        } else {
            cont = 0;
            sequencia = "";
        }
        
	}

    //faz o que tem que fazer quando olharam para o S
    public void DizQueSim () {
        sequencia = sequencia + "s";
        VerificaSequencia();
        ControlaRitmo();
    }

    //faz o que tem que fazer quando olharam para o S
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
        }// soh pq nao pegou no comeco e o player estah tentando sem parar dizer S ou N
    }

    //nas acoes atualmente estao sendo chamadas essas classes que startam videos 360
    void AcaoParaSim () {
        MemoriaParaVideos.enderecoAtualMemoria += 's';
        memoriaParaVideos.PlayVideo();
    }

    void AcaoParaNao () {
        MemoriaParaVideos.enderecoAtualMemoria += 'n';
        memoriaParaVideos.PlayVideo();
    }
}
