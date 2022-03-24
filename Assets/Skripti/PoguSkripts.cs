using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoguSkripts : MonoBehaviour {
	//Nodrosina ainu parslegsanu, uzkliksinot uz pogu Sakt parsledzas uz ainu Pilseta
	public void uzkliksinot (){
		SceneManager.LoadScene("Pilseta");
	}
	//Nodrošina spēles atsākšanu aizejot atpakaļ uz ainu Izvelne
	public void atskakt (){
		SceneManager.LoadScene("Izvelne");
	}
}
