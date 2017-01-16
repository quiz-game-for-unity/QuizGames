using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // usar componente de texto
using UnityEngine;

public class Responder : MonoBehaviour {

	public int idTema;

	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text infoResposta;

	//pequeno "banco" pras perguntas
	public string[] perguntas;

	//banco de alternativas
	public string[] A;
	public string[] B;
	public string[] C;

	//respostas corretas
	public string[] corretas;

	private int idPergunta;
	private float acertos;
	private float questoes;
	private float media;

	private int notaFinal;
	private int acertosTemp;
	private int notaFinalTemp;

	// Use this for initialization
	void Start () {
		
		idTema = PlayerPrefs.GetInt ("idTema");
		idPergunta = 0;
		questoes = perguntas.Length;//quantas perguntas eu tenho

		//para mostras as perguntas e respostas na tela
		pergunta.text = perguntas[idPergunta]; 
		respostaA.text = A[idPergunta];
		respostaB.text = B[idPergunta];
		respostaC.text = C[idPergunta];

		infoResposta.text = (idPergunta+1).ToString()+ " - " + questoes.ToString();

	}
	
	public void Resposta(string alternativa)
	{
		if (alternativa == "A") {
			if (A [idPergunta] == corretas [idPergunta]) {
				acertos++;
			}
		} else if (alternativa == "B") {
			if (B [idPergunta] == corretas [idPergunta]) {
				acertos++;
			}
		} else {
			if (C [idPergunta] == corretas [idPergunta]) {
				acertos++;
			}
		}

		Prox ();
	}

	void Prox(){
		idPergunta++;

		if (idPergunta <= (questoes - 1)) {
			//para mostras as perguntas e respostas na tela
			pergunta.text = perguntas [idPergunta]; 
			respostaA.text = A [idPergunta];
			respostaB.text = B [idPergunta];
			respostaC.text = C [idPergunta];

			infoResposta.text = (idPergunta + 1).ToString () + " - " + questoes.ToString ();
		} else {
			media = 10 * (acertos / questoes);//percentual de acerto
			notaFinal = Mathf.RoundToInt (media);// arredonda

			if (notaFinal > PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ())) {
				PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString (), (int) acertos);
			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int) acertos);

			//acabou e vai pra outra tela
			Application.LoadLevel ("NotaFinal");
		}
	}
}
