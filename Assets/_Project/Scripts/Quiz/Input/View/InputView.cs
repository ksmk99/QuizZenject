using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class InputView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private AudioSource audioSource;   

        public event Action<string> OnTextSubmit;
        public event Action OnStart;

        private bool isActive;

        private void OnEnable()
        {
            inputField.onSubmit.AddListener(Submit);
            inputField.onValueChanged.AddListener(CheckSpace);
        }

        private void OnDisable()
        {
            inputField.onSubmit.RemoveListener(Submit);
        }

        public void SetMessageValue(string text, AudioClip audioClip)
        {
            messageText.text = text;
            if (audioClip != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }

        private void Submit(string key)
        {
            OnTextSubmit?.Invoke(key);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!isActive)
                {
                    inputField.ActivateInputField();
                    isActive = true;
                    OnStart?.Invoke();
                }
                else
                {
                    Submit(inputField.text);
                }
            }
        }


        private void CheckSpace(string text)
        {
            if(text.Last().Equals(' '))
            {
                Submit(inputField.text.TrimEnd(' '));
                inputField.DeactivateInputField();
            }
        }
    }
}