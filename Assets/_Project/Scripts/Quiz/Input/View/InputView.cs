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
        [SerializeField] private AudioClip audioClip;
        

        public event Action<string> OnTextSubmit;
        public event Action OnStart;

        private bool isActive;
        private bool isSubmitted = false;

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
            key = key.ToLower();
            OnTextSubmit?.Invoke(key);
        }

        public void Update()
        {
            if(isSubmitted)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!isActive)
                {
                    isSubmitted = true;

                    inputField.ActivateInputField();
                    isActive = true;
                    OnStart?.Invoke();
                }
            }
        }


        private void CheckSpace(string text)
        {
            if(text == String.Empty)
            {
                return;
            }

            if(text.Last().Equals(' '))
            {
                Submit(inputField.text.TrimEnd(' '));
                inputField.DeactivateInputField();
                inputField.enabled = false;
            }
            else
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
}