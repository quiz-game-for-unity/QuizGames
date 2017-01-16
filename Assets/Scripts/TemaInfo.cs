using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaInfo : MonoBehaviour {

	public int idTema;

	//estrelas
	public GameObject estrela1;
	public GameObject estrela2;
	public GameObject estrela3;


	public int notaFinal;

	// Use this for initialization
	void Start () {
		//apagando estrelas
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);


		int notaF = PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ());



		if (notaF == 10) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);
		} else if (notaF >= 6) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);
		} else if (notaF >= 4) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);
		}

	}

}
