using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using TMPro;

public class VionOutputService : MonoBehaviour
{
    [SerializeField]
    private int MaxEntries = 10;

    [SerializeField]
    private Transform OutputTextContainer;

    [SerializeField]
    private TextMeshProUGUI TextLinePrefab;

    [SerializeField]
    private Image NewLinePrefab;

    public VionOutputService() => mEntries = new List<GameObject>();

    public void Clear() => mEntries.ForEach(entry => Destroy(entry));

    public void Write(string value) => ParseAndWriteLine(value);

    public void WriteLine(string value) => ParseAndWriteLine(value);

    private void ParseAndWriteLine(string value)
    {
        string[] delimeters = { "\n" };

        var lines = value.Split(delimeters, StringSplitOptions.None);
        foreach (var line in lines)
        {
            if (mEntries.Count >= MaxEntries)
            {
                var entry = mEntries.First();
                Destroy(entry);
                mEntries.Remove(entry);
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                WriteNewLine();
            }
            else
            {
                WriteTextLine(line);
            }
        }
    }

    private void WriteNewLine()
    {
        var newLine = GameObject.Instantiate(NewLinePrefab);
        newLine.transform.SetParent(OutputTextContainer, false);
        mEntries.Add(newLine.gameObject);
    }

    private void WriteTextLine(string value)
    {
        var textLine = Instantiate(TextLinePrefab);
        textLine.transform.SetParent(OutputTextContainer, false);
        textLine.text = "> " + value;
        mEntries.Add(textLine.gameObject);
    }

    private readonly List<GameObject> mEntries;
}
