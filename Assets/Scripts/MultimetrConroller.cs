using UnityEngine;
using TMPro;

public class MultimetrConroller : MonoBehaviour
{
    public TextMeshPro displayText;
    public TextMeshProUGUI uiText;

    private string[] modes = { "Neutral", "DC Voltage", "AC Voltage", "Current", "Resistance" };
    private int modeIndex = 0;

    private float resistance = 1000f;
    private float power = 400f;

    public void SwitchMode(int direction)
    {
        modeIndex = (modeIndex + direction + modes.Length) % modes.Length;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        float current = Mathf.Sqrt(power / resistance);
        float voltageDC = Mathf.Sqrt(power * resistance);
        float voltageAC = 0.01f;

        string activeValue = "0.00";

        switch (modes[modeIndex])
        {
            case "Resistance":
                activeValue = resistance.ToString("F2");
                break;
            case "Current":
                activeValue = current.ToString("F2");
                break;
            case "DC Voltage":
                activeValue = voltageDC.ToString("F2");
                break;
            case "AC Voltage":
                activeValue = voltageAC.ToString("F2");
                break;
        }
        OutputInformation(modes[modeIndex], activeValue);
    }

    void OutputInformation(string type, string value)
    {
        string zero = "0.00";
        string formattedText =
            "V   " + (type == "DC Voltage" ? value : zero) +
            "\nA   " + (type == "Current" ? value : zero) +
            "\n~  " + (type == "AC Voltage" ? value : zero) +
            "\nΩ   " + (type == "Resistance" ? value : zero);

        uiText.text = formattedText;
        displayText.text = value;
    }
}
