using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MemoriaParaVideos : MonoBehaviour {

    public static string enderecoAtualMemoria = "";
    public GameObject GameObjectVideoClip0;
 //   public GameObject GameObjectVideoClip1; ...
    VideoPlayer sphereVideoPlayer;

    public void PlayVideo()
    {
        switch (enderecoAtualMemoria)
        {
            case "0":
                print("casoZeroChamado");
            break;
            case "1":
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
        while (!sphereVideoPlayer.isPlaying)
        {
            yield return null;
        }

        while (sphereVideoPlayer.isPlaying)
        {
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
