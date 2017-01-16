using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TemaJogo : MonoBehaviour {

    public Button btnPlay;
    public Text txtNomeTema;

    public GameObject infoTema;
    public Text txtInfoTema;

    //estrelas
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    //temas
    public string[] nomeTema;
	public int numQuestoes;
    private int idTema;

	// Use this for initialization
	void Start () {
		idTema = 0;
		txtNomeTema.text = nomeTema[idTema];//escolhendo o tema
		txtInfoTema.text = "Você acertou X de X questões!";

		//desativando
		infoTema.SetActive(false);
		estrela1.SetActive(false);
		estrela2.SetActive(false);
		estrela3.SetActive(false);
		btnPlay.interactable = false;
		
	}
	
	public void SelecioneTem(int i)
	{
		idTema = i;
		PlayerPrefs.SetInt ("idTema", idTema);
		txtNomeTema.text = nomeTema[i]; //aparecendo o texto do tema

		int notaFinal = PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ());
		int acertos = PlayerPrefs.GetInt ("acertos" + idTema.ToString ());

		if (notaFinal == 10) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);
		} else if (notaFinal >= 6) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);
		} else if (notaFinal >= 3) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);
		}

		txtInfoTema.text = "Você acertou "+ acertos.ToString()+" de "+numQuestoes.ToString()+" questões!";
		infoTema.SetActive(true); //ativando estrelas
		btnPlay.interactable = true; //ativando botao
	}

	public void Jogar()
	{
		Application.LoadLevel("T" + idTema.ToString());
	}
}
