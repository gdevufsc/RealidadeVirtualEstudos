using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Investigador : MonoBehaviour {

    //eu poderia chamar de boca, mas no modelo dele tem os olhos que eh bem perto
    public AudioSource olhosDoInvestigador; //coloquei a audiosource nos olhos

    //esses audioclips sao coisas que o investigador diz
    public AudioClip audioVcJahViu;
    public AudioClip vcUsouODinheiro;
    public AudioClip Passo2nVcLevouArmazem, Passo2sVcEsteveCabaret;

    public float tempoAtehFalar = 3; //em segundos

    public GameObject HeadSeN; //eh o objeto que segura S e N para informar isso com a cabeca
    //public Memoria Memoria;

	void Start () {
        //se o jogo acabou de comecar, chama a funcao VcJahViu, e logo que voltar, mostre o HeadSeN
        if (Memoria.enderecoAtualMemoria.Length == 0) { 
            if (!Memoria.jahViuFlashback) {
                StartCoroutine(SoltaAudioEChamaCena(audioVcJahViu , "FlashBack001Rodoviaria"));
                Invoke("VcJahViu" , tempoAtehFalar);
                Memoria.SetJahViuFlashback(true); //sinalizando que o flashback foi chamado
            } else { //se ele jah foi chamado, ative o HeadSeN
                HeadSeN.SetActive(true);
            }
        } else { //se o endereco nao eh zero, tambem tem que chamar o HeadSeN
            HeadSeN.SetActive(true);
            print("O endereco de memoria nao tem comprimento zero");
        }
    }

    //Interagir eh chamada pelo HeadSeNControle logo apos uma resposta de S ou N
    public void Interagir () { // a ideia eh fazer uma verificacao em duas etapas. Nessa etapa se ve
        print("Interagir chamado"); //quantas perguntas jah foram respondidas
        switch (Memoria.enderecoAtualMemoria.Length) { //depois disso, depende qual passo eh
            case 1:
                Passo1();
                break;
            case 2:
                Passo2();
                break;
            //... assim por diante
            default:
                break;
        }
    }

    //Passo 1 quer dizer que soh 1 pergunta foi respondida. Nesse caso:
    void Passo1 () {
        print("passo 1 chamado");
        StartCoroutine(SoltaAudioEChamaCena(vcUsouODinheiro , "FlashBack002ComprandoFichas"));
            //Invoke("VcUsouODinheiro" , tempoAtehFalar); //a pergunta eh "vc usou o dinheiro?"
    }

    //passo 2 quer dizer que 2 perguntas jah foram respondidas. E nesse caso:
    void Passo2 () {
        print("passo 2 chamado" + Memoria.enderecoAtualMemoria[1]);//como eh a primeira bifurcacao, soh importa o ultimo digito
        switch (Memoria.enderecoAtualMemoria[1]) {
            case 'n':
                //entao vc levou o dinheiro para o armazem?
                //flashback virando e olhando armazem
                StartCoroutine(SoltaAudioEChamaCena(Passo2nVcLevouArmazem, "placeholder"));
                break;
            case 's':
                //Você esteve no Cabaret. Porque o Frankie viu você lá. Você viu ele lá?
                StartCoroutine(SoltaAudioEChamaCena(Passo2sVcEsteveCabaret , "placeholder"));
                //Cabaret ouvindo conversa, bebendo algo, Frank está ao fundo
                break;
            default:
                break;
        }
    }

    //essa corrotina espera tempoAtehFalar, entao solta o audio e chama a corrotina q espera o audio acabar
    IEnumerator SoltaAudioEChamaCena (AudioClip audio, string cena) { //para soltar o flashback
        yield return new WaitForSeconds(tempoAtehFalar);
        olhosDoInvestigador.PlayOneShot(audio);
        StartCoroutine(ChamaFlashBack(cena));
    }

    //essa corrotina verifica se o audio terminou, e quando termina, carrega a cena "nomeDaCena"
    IEnumerator ChamaFlashBack (string nomeDaCena) {
        int k = 0;
        //verifica-se se jah comecou, pois tem um delay do metodo PlayOneShot ateh comecar
        while (!olhosDoInvestigador.isPlaying && k < 1200) { //se nao comecar em 20s, esquece
            k++;
            yield return null;
        }
        k = 0; //verifica se terminou. 3600 = 60*60 = 60 frames * 60 segundos = 3600 frames
        while (olhosDoInvestigador.isPlaying && k < 3600) { //se nao terminar em um minuto, aborta
            k++;
            yield return null;
        }
        SceneManager.LoadScene(nomeDaCena);
    }

}
