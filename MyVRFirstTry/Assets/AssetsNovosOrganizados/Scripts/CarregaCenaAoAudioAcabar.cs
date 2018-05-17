using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregaCenaAoAudioAcabar : MonoBehaviour {
    public AudioSource olhosDoInvestigador;
    // Use this for initialization
    void Start () {
        StartCoroutine(carregaCenaAoAudioAcabar());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator carregaCenaAoAudioAcabar () {
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
        SceneManager.LoadScene("prototipo001");
    }
}
