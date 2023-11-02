using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class LogoView : MonoBehaviour
    {
        [SerializeField] private Button button;

        public event Action OnClick;

        private void OnEnable()
        {
            if(button == null)
            {
                throw new ArgumentException();
            }

            button.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        private void Click()
        {
            OnClick?.Invoke();  
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.Return))
            {
                Click();
            }
        }
    }
}
