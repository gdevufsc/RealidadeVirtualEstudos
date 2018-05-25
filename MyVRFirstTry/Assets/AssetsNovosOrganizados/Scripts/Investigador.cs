using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Investigador : MonoBehaviour {

    //eu poderia chamar de boca, mas no modelo dele tem os olhos que eh bem perto
    public AudioSource olhosDoInvestigador; //coloquei a audiosource nos olhos
    public AudioClip audioVcJahViu;
    public AudioClip vcUsouODinheiro;
    public float tempoAtehFalar = 3; //em segundos
    public GameObject HeadSeN;
    //public MemoriaParaVideos memoriaParaVideos;

	void Start () {
        //se o jogo acabou de comecar, chama a funcao VcJahViu, e logo que voltar, mostre o HeadSeN
        if (MemoriaParaVideos.enderecoAtualMemoria.Length == 0) { 
            if (!MemoriaParaVideos.jahViuFlashback) {
                Invoke("VcJahViu" , tempoAtehFalar);
                MemoriaParaVideos.SetJahViuFlashback(true); //sinalizando que o flashback foi chamado
            } else { //se ele jah foi chamado, ative o HeadSeN
                HeadSeN.SetActive(true);
            }
        }
	}

    public void Interagir () {
        print("interagir chamado");
        switch (MemoriaParaVideos.enderecoAtualMemoria.Length) {
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

    void Passo1 () {
        print("passo 1 chamado");
   //     if (!MemoriaParaVideos.jahViuFlashback) {
            Invoke("VcUsouODinheiro" , tempoAtehFalar);
    //    } else {
    //        HeadSeN.SetActive(true);
    //    }
    }

    void Passo2 () {
        print("passo 2 chamado");
    }

    void VcUsouODinheiro () {
        print("Vc usou o dinheiro chamado");
        olhosDoInvestigador.PlayOneShot(vcUsouODinheiro);
        StartCoroutine(ChamaFlashBack("FlashBack002ComprandoFichas"));

    }

    void VcJahViu () {
        olhosDoInvestigador.PlayOneShot(audioVcJahViu);
        StartCoroutine(ChamaFlashBack("FlashBack001Rodoviaria"));
    }

    //essa corrotina verifica se o audio estah sendo executado, para no fim ativar o objet HeadSeN
    IEnumerator MostraHeadSeNAoFimDaPergunta () {
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
        HeadSeN.SetActive(true);
    }

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
