using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections.Generic;

public class wasdShow : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference actionReference;

    public enum MoveDirection { Up, Down, Left, Right }

    [Header("Which movement to display")]
    public MoveDirection direction = MoveDirection.Up;

    [Header("UI")]
    public TextMeshProUGUI text;
    public string textFormat = "{key}";

    void OnEnable()
    {
        if (actionReference != null)
            actionReference.action.Enable();

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
            // Only parts of a composite (WASD / Arrow keys)
            if (!binding.isPartOfComposite)
                continue;

            // Match direction (case-insensitive!)
            if (!string.Equals(
                    binding.name,
                    direction.ToString(),
                    System.StringComparison.OrdinalIgnoreCase))
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

        text.text = keys.Count > 0
            ? textFormat.Replace("{key}", string.Join(" / ", keys))
            : "Unbound";
    }
}
