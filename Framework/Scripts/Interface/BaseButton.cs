using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	public class BaseButton : MonoBehaviour {

		public Button button;

		void Start () {
        button = GetComponent<Button>();


        if (button != null) {
				button.onClick.AddListener (delegate () {
                    Manager.ui.PlayClick();
				});
			}
		}

	}
