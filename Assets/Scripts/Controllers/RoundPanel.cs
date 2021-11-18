using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class RoundPanel : MonoBehaviour
    {
        [SerializeField]
        private Text CounterText;

        void Start()
        {
            DisableRoundFightImage();
        }

        private void Update()
        {
            StartCoroutine(TransformImageVisibility());
        }

        IEnumerator TransformImageVisibility()
        {
            if (int.Parse(CounterText.text) > 85)
            {
                EnableRoundFightImage();
                DisableCharactersInput();
                ChangeCharactersInputStatus(false, false);
            }
            else
            {
                DisableRoundFightImage();
                ChangeCharactersInputStatus(true, true);
            }

            yield return new WaitForSeconds(1);
        }

        void EnableRoundFightImage()
        {
            gameObject.GetComponent<Image>().enabled = true;
        }

        void DisableRoundFightImage()
        {
            gameObject.GetComponent<Image>().enabled = false;
        }

        void ChangeCharactersInputStatus(bool characterOneEnable, bool characterTwoEnable)
        {
            CallFighters.Instance.CharacterPlayerOne.CharacterInput.Enabled = characterOneEnable;
            CallFighters.Instance.CharacterPlayerTwo.CharacterInput.Enabled = characterTwoEnable;
        }

        void DisableCharactersInput()
        {
            CallFighters.Instance.CharacterPlayerOne.CharacterInput.input = new Vector2(0, 0);
            CallFighters.Instance.CharacterPlayerTwo.CharacterInput.input = new Vector2(0, 0);
        }
    }
}