using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class NomesanasVieta : MonoBehaviour, IDropHandler {
	//Uzglabās velkamā objekta un nomešanas lauka z rotāciju,
	// kāarī rotācijas un izmēru pieļaujamo starpību
	private float vietasZrot, velkObjZrot, rotacijasStarpiba, xIzmeruStarp, yIzmeruStarp;
	private Vector2 vietasIzm, velkObjIzm;
	//Norāde uz Objekti skriptu
	public Objekti objektuSkripts;
	//Int tipa mainigais, kas skaitis, cik automasinas ir novietotas pareizaja vieta
	static public int parViet=0;

	//Parbaude vai ir novietoti visi objekti savas vietas
	public GameObject fons, zvaigzne1, zvaigzne2, zvaigzne3, atsakt, uzvara, laiks;
	public void uzvareji(){
		if (parViet > 10) {
			Taimeris.beidzis = true;
			fons.SetActive(true);
			atsakt.SetActive(true);
			uzvara.SetActive(true);
			laiks.SetActive(true);
			if (Taimeris.zvaigznuMinutes < 2) {
				zvaigzne1.SetActive(true);
				zvaigzne2.SetActive(true);
				zvaigzne3.SetActive(true);
			}else if (Taimeris.zvaigznuMinutes >= 2 && Taimeris.zvaigznuMinutes < 3) {
				zvaigzne1.SetActive(true);
				zvaigzne3.SetActive(true);
			}else{
				zvaigzne2.SetActive(true);
			}
		}
	}

	void Start () {
		fons.SetActive(false);
		zvaigzne1.SetActive(false);
		zvaigzne2.SetActive(false);
		zvaigzne3.SetActive(false);
		atsakt.SetActive(false);
		uzvara.SetActive(false);
		laiks.SetActive(false);
		parViet = 0;
	}

	//Nostrādās, ja objektu cenšas nomest uz jebkuras nomešanas  vietas
	public void OnDrop(PointerEventData notikums){
		//Pārbauda vai tika vilkts un atlaists vispār kāds objekts
		if (notikums.pointerDrag != null) {
			//Ja nomešanas vietas tags sakrīt ar vilktā objekta tagu
			if (notikums.pointerDrag.tag.Equals (tag)) {
				//Iegūst objekta rotāciju grādos
				vietasZrot = notikums.pointerDrag.GetComponent<RectTransform> ().eulerAngles.z;
				velkObjZrot = GetComponent<RectTransform> ().eulerAngles.z;
				//Aprēkina abu objektu z rotācijas starpību
				rotacijasStarpiba = Mathf.Abs (vietasZrot - velkObjZrot);
				//Līdzīgi kā ar Z rotāciju, jāpiefiksē objektu izmēri pa x un y asīm, kā arī starpība
				vietasIzm = notikums.pointerDrag.GetComponent<RectTransform> ().localScale;
				velkObjIzm = GetComponent<RectTransform> ().localScale;
				xIzmeruStarp = Mathf.Abs (vietasIzm.x - velkObjIzm.x);
				yIzmeruStarp = Mathf.Abs (vietasIzm.y - velkObjIzm.y);


				//Pārbauda vai objektu rotācijas un izmēru starpība ir pieļaujamajās robēžās
				if ((rotacijasStarpiba <= 6 || (rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360))
				   && (xIzmeruStarp <= 0.1 && yIzmeruStarp <= 0.1)) {
					objektuSkripts.vaiIstajaVieta = true;
					//Noliktais objekts smuki iecentrējas nomešanas laukā
					notikums.pointerDrag.GetComponent<RectTransform> ().anchoredPosition 
								= GetComponent<RectTransform> ().anchoredPosition;
					//Rotācijai
					notikums.pointerDrag.GetComponent<RectTransform> ().localRotation
								= GetComponent<RectTransform> ().localRotation;
					//Izsmēram
					notikums.pointerDrag.GetComponent<RectTransform> ().localScale
					= GetComponent<RectTransform> ().localScale;

					//skaita pareizos noliktos objektus lidz uzvarai
					parViet = parViet + 1;
					uzvareji ();

					//Pārbauda tagu un atskaņo atbilstošo skaņas efektu
					switch (notikums.pointerDrag.tag) {
					case "Atkritumi":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [1]);
						break;

					case "Slimnica":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [2]);
						break;

					case "Skola":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [3]);
						break;

					case "Policija":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [4]);
						break;

					case "Traktors1":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [5]);
						break;

					case "Traktors5":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [6]);
						break;

					case "Ungunsdzeseji":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [7]);
						break;

					case "b2":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [8]);
						break;

					case "Cementa":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [9]);
						break;

					case "e46":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [10]);
						break;

					case "Eskavators":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [11]);
						break;


					default:
						Debug.Log ("Nedefinēts tags!");
						break;
					}

				}
			
				//Ja objekts nomests nepareizajā laukā
			} else {
				objektuSkripts.vaiIstajaVieta = false;
				objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [0]);

				//Objektu aizmet uz sākotnējo pozīciju
				switch (notikums.pointerDrag.tag) {
				case "Atkritumi":
					objektuSkripts.atkritumuMasina.GetComponent<RectTransform> ().localPosition 
							= objektuSkripts.atkrKoord;
					break; 

				case "Slimnica":
					objektuSkripts.atraPalidziba.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.atroKoord;
					break;

				case "Skola":
					objektuSkripts.autobuss.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.bussKoord;
					break;

				case "Policija":
					objektuSkripts.policija.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.polKoord;
					break;

				case "Traktors1":
					objektuSkripts.traktors1.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.trakt1Koord;
					break;

				case "Traktors5":
					objektuSkripts.traktors5.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.trakt5Koord;
					break;

				case "Ugunsdzeseji":
					objektuSkripts.ugunsdzeseji.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.ugunsKoord;
					break;

				case "b2":
					objektuSkripts.b2.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.b2Koord;
					break;

				case "Cementa":
					objektuSkripts.cementaMasina.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.cemKoord;
					break;

				case "e46":
					objektuSkripts.e46.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.e46Koord;
					break;

				case "Eskavators":
					objektuSkripts.eskavators.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.eskaKoord;
					break;
				default:
					Debug.Log ("Nedefinēts tags!");
					break;
				}

			}
		}
	}
}