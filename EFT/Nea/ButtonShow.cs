using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections.Generic;

public class ButtonShow : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference actionReference;
    public string controlScheme = "Keyboard";

    [Header("UI")]
    public TextMeshProUGUI text;
    public string textFormat = "{key}";

    void OnEnable()
    {
        UpdateText();
        InputSystem.onActionChange += OnActionChange;
    }

    void OnDisable()
    {
        InputSystem.onActionChange -= OnActionChange;
    }

    void OnActionChange(object obj, InputActionChange change)
    {
        if (change == InputActionChange.BoundControlsChanged)
            UpdateText();
    }

    void UpdateText()
    {
        if (actionReference == null || text == null)
            return;

        var action = actionReference.action;
        var keys = new List<string>();

        foreach (var binding in action.bindings)
        {
            // Skip composites (like WASD vectors)
            if (binding.isComposite || binding.isPartOfComposite)
                continue;

            // Filter by control scheme (Keyboard)
            if (!string.IsNullOrEmpty(controlScheme) &&
                !binding.groups.Contains(controlScheme))
                continue;

            if (string.IsNullOrEmpty(binding.effectivePath))
                continue;

            string readable = InputControlPath.ToHumanReadableString(
                binding.effectivePath,
                InputControlPath.HumanReadableStringOptions.OmitDevice
            );

            if (!keys.Contains(readable))
                keys.Add(readable);
        }

        string keyText = keys.Count > 0
            ? string.Join(" / ", keys)
            : action.GetBindingDisplayString();

        text.text = textFormat.Replace("{key}", keyText);
    }
}
