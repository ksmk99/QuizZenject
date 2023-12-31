using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class InputView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Text messageText;

        public event Action<string> OnTextSubmit;

        private void OnEnable()
        {
            inputField.onSubmit.AddListener(Submit);
            inputField.ActivateInputField();
        }

        private void OnDisable()
        {
            inputField.onSubmit.RemoveListener(Submit);
        }

        public void SetMessageValue(string text)
        {
            messageText.text = text;
        }

        private void Submit(string key)
        {
            OnTextSubmit?.Invoke(key);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inputField.ActivateInputField();
            }
        }
    }
}