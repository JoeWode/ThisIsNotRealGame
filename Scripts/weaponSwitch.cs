using UnityEngine;
using System.Collections;

public class weaponSwitch : MonoBehaviour {

	public GameObject Weapon01;
	public GameObject Weapon02;
	public GameObject Weapon03;
	
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			SwapWeaponUp();
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			SwapWeaponDown();
		}
	}

	void SwapWeaponUp() {
		if (Weapon01.activeSelf == true) {
			Weapon01.SetActive (false);
			Weapon02.SetActive (true);
			Weapon03.SetActive (false);
		} else if (Weapon02.activeSelf == true) {
			Weapon01.SetActive (false);
			Weapon02.SetActive (false);
			Weapon03.SetActive (true);
		} else {
			Weapon01.SetActive (true);
			Weapon02.SetActive (false);
			Weapon03.SetActive (false);
		}
	}

	void SwapWeaponDown() {
		if (Weapon01.activeSelf == true) {
			Weapon01.SetActive (false);
			Weapon02.SetActive (false);
			Weapon03.SetActive (true);
		} else if (Weapon02.activeSelf == true) {
			Weapon01.SetActive (true);
			Weapon02.SetActive (false);
			Weapon03.SetActive (false);
		} else {
			Weapon01.SetActive (false);
			Weapon02.SetActive (true);
			Weapon03.SetActive (false);
		}
	}
}
