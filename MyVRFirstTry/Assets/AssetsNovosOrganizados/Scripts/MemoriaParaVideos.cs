using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

///esse script implementa um sistema para instanciar esferas para exibir videos 360.
///alem disso, controla qual video sera exibido atraves de uma variavel String aa qual
///deve ser concatenado s ou n.
///Esse script (09/05/2018) estah sendo chamado pelos script "Sim" e "Nao" que estao
///em dois botoes configurados para interacao em realidade virtual, usando o plugin GoogleVR

public class MemoriaParaVideos : MonoBehaviour {

    public static string enderecoAtualMemoria = "";
    public GameObject GameObjectVideoClip0;
 //   public GameObject GameObjectVideoClip1; ...
    VideoPlayer sphereVideoPlayer;

    public void PlayVideo()
    {
        switch (enderecoAtualMemoria)
        {
            case "n":
                print("casoZeroChamado");
            break;
            case "s":
                print("Caso 1 escolhido");
                GameObjectVideoClip0.SetActive(true);
                VideoPlayer videoPlayer = GameObjectVideoClip0.GetComponent<VideoPlayer>();
                StartCoroutine(GetRidOfSphere(videoPlayer));
            break;
            default:
                print("defalut");
            break;
        }
    }

    IEnumerator GetRidOfSphere(VideoPlayer sphereVideoPlayer)
    {
        int k = 0;
        while (!sphereVideoPlayer.isPlaying && k<600)
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
