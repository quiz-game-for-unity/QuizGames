using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoScript : MonoBehaviour {
	float larguraImagem;
	float alturaImagem;
	float alturaTela;
	float larguraTela;

	void Start () {
		SpriteRenderer grafico = GetComponent<SpriteRenderer> ();
		//
		larguraImagem = grafico.sprite.bounds.size.x;
		alturaImagem = grafico.sprite.bounds.size.y;
		//
		alturaTela = Camera.main.orthographicSize * 2f;
		larguraTela = alturaTela / Screen.height * Screen.width;
		//
		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela / larguraImagem + 0.25f;
		novaEscala.y = alturaTela / alturaImagem + 0.25f;
		this.transform.localScale = novaEscala;
	}
}
