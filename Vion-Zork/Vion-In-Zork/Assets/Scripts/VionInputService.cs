using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using Zork;

public class VionInputService : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField InputField = null;

    public event EventHandler<string> InputReceived;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (string.IsNullOrWhiteSpace(InputField.text) == false)
            {
                string inputString = InputField.text.Trim().ToUpper();
                InputReceived?.Invoke(this, inputString);
            }

            InputField.text = string.Empty;
            SelectInputField();
        }
    }

    public void SelectInputField() => InputField.ActivateInputField();
}
