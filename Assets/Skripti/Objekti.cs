using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Objekti : MonoBehaviour {
	//Uzglabā ainā esošo kanvu
	public Canvas kanva;
	//GameObject, kas uzglabās velkamos objektus
	public GameObject atkritumuMasina;
	public GameObject atraPalidziba;
	public GameObject autobuss;
	public GameObject policija;
	public GameObject traktors1;
	public GameObject traktors5;
	public GameObject ugunsdzeseji;
	public GameObject b2;
	public GameObject cementaMasina;
	public GameObject e46;
	public GameObject eskavators;


	//Uzglabā velakmo objektu sākotnējās atrašanās vietas koordinātas
	[HideInInspector]
	public Vector2 atkrKoord;
	[HideInInspector]
	public Vector2 atroKoord;
	[HideInInspector]
	public Vector2 bussKoord;
	[HideInInspector]
	public Vector2 polKoord;
	[HideInInspector]
	public Vector2 trakt1Koord;
	[HideInInspector]
	public Vector2 trakt5Koord;
	[HideInInspector]
	public Vector2 ugunsKoord;
	[HideInInspector]
	public Vector2 b2Koord;
	[HideInInspector]
	public Vector2 cemKoord;
	[HideInInspector]
	public Vector2 e46Koord;
	[HideInInspector]
	public Vector2 eskaKoord;

	//Uzglabās audio avotu, kurā atskaņot attēlu skaņas efektus
	public AudioSource skanasAvots;
	//Masīvs, kas uzglabā visas iespējamās skaņas
	public AudioClip[] skanaKoAtskanot;
	//Mainīgais piefiksē vai objekts nolikts īstajāvietā (true/false)
	[HideInInspector]
	public bool vaiIstajaVieta = false;
	//Uzglabās pēdējo objektu, kurš pakustināts
	public GameObject pedejaisVIlktais = null;

	// Use this for initialization
	void Start () {
		atkrKoord = atkritumuMasina.GetComponent<RectTransform> ().localPosition;
		atroKoord = atraPalidziba.GetComponent<RectTransform> ().localPosition;
		bussKoord = autobuss.GetComponent<RectTransform> ().localPosition;
		polKoord = policija.GetComponent<RectTransform> ().localPosition;
		trakt1Koord = traktors1.GetComponent<RectTransform> ().localPosition;
		trakt5Koord = traktors5.GetComponent<RectTransform> ().localPosition;
		ugunsKoord = ugunsdzeseji.GetComponent<RectTransform> ().localPosition;
		b2Koord = b2.GetComponent<RectTransform> ().localPosition;
		cemKoord = cementaMasina.GetComponent<RectTransform> ().localPosition;
		e46Koord = e46.GetComponent<RectTransform> ().localPosition;
		eskaKoord = eskavators.GetComponent<RectTransform> ().localPosition;

	}
}
