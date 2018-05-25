using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

//esse script estah em desuso agora (25/05/2018)

///esse script implementa um sistema para instanciar esferas para exibir videos 360.
///alem disso, controla qual video sera exibido atraves de uma variavel String aa qual
///deve ser concatenado s ou n.
///Esse script (09/05/2018) estah sendo chamado pelos script "Sim" e "Nao" que estao
///em dois botoes configurados para interacao em realidade virtual, usando o plugin GoogleVR

public class MemoriaParaVideos : MonoBehaviour {

    //objetos para serem desativados enquanto videos tao executando
    public GameObject[] desativarDuranteVideos; 
    public static string enderecoAtualMemoria = "";
    public GameObject GameObjectVideoClips;
    public GameObject GameObjectVideoClipn;

    public static bool jahViuFlashback=false;
    //   public GameObject GameObjectVideoClip1; ...

    public static void SetJahViuFlashback (bool jahViu) {
        jahViuFlashback = jahViu;
    }

    public void PlayVideo()
    {
        switch (enderecoAtualMemoria)
        {
            case "n":
                //SceneManager.LoadScene("FlashBack001Rodoviaria");
                //PlayVideoFromGO(GameObjectVideoClipn);
                //break;
            case "s":
                //PlayVideoFromGO(GameObjectVideoClips);
                print("disse Sim ou Nao");
                break;
            default:
                print("default atingido no switch");
            break;
        }
        //a proxima estah ae para testes. A logica de concatenar s e n nao vai funcionar com ela 
        enderecoAtualMemoria = ""; // tem que apagar quando crescer a arvore de s e n
        //******************************************************
    }

    //funcao para dar play no video a partir da esfera configurada
    public void PlayVideoFromGO (GameObject GO) {
        GO.SetActive(true);
        VideoPlayer videoPlayer = GO.GetComponent<VideoPlayer>();
        StartCoroutine(GetRidOfSphere(videoPlayer));
    }

    //no tempo certo ativa e desativa objetos e a esfera video player
    IEnumerator GetRidOfSphere(VideoPlayer sphereVideoPlayer)
    {
        DesativarObjetos();
        int k = 0;
        while (!sphereVideoPlayer.isPlaying && k<1200)
        {
            k++;
            yield return null;
        }
        k = 0;
        while (sphereVideoPlayer.isPlaying && k<3600)
        {
            k++;
            yield return null;
        }
        sphereVideoPlayer.gameObject.SetActive(false);
        AtivarObjetos();
    }

    public void DesativarObjetos () {
        foreach (GameObject go in desativarDuranteVideos) {
            go.SetActive(false);
        }
    }

    public void AtivarObjetos () {
        foreach (GameObject go in desativarDuranteVideos) {
            go.SetActive(true);
        }
    }

 /*   public void ConvertEnderecoToIndex()
    {
        //a cada bit a mais, são duas possibilidades a menos. Esse método pega
        enderecoInt = MemoriaParaVideos.enderecoAtualMemoria.Length - 1;
        if (MemoriaParaVideos.enderecoAtualMemoria[enderecoInt] == '1')
        {
            enderecoInt += 1;
        }
    }*/
 /*       for (int i = 0; i < MemoriaParaVideos.enderecoAtualMemoria.Length; i++)
        {
            if (MemoriaParaVideos.enderecoAtualMemoria[i] == '1')
            {
                enderecoInt += (int) Mathf.Pow(2, i);
            }
        }
    }
*/
}
