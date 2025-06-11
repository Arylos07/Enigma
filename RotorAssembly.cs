using System;
using System.Collections.Generic;
using System.Linq;

public class RotorAssembly
{
    public static readonly string PublicKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private readonly List<Rotor> _rotors;
    public Reflector Reflector { get; set; }

    public RotorAssembly(IEnumerable<Rotor> rotors, Reflector reflector = null)
    {
        _rotors = rotors.ToList();
        Reflector = reflector;
    }

    /// <summary>
    /// Exposes the rotors for configuration or inspection.
    /// </summary>
    public IReadOnlyList<Rotor> Rotors => _rotors;

    /// <summary>
    /// Steps the rotors, cascading as needed (rightmost rotor steps every time).
    /// </summary>
    public void Step()
    {
        for (int i = 0; i < _rotors.Count; i++)
        {
            _rotors[i].Position++;
            // If this rotor did not wrap, stop cascading
            if (_rotors[i].Position != 0)
                break;
        }
    }

    /// <summary>
    /// Encodes a character through all rotors (right to left).
    /// </summary>
    public char Encode(char input)
    {
        int index = PublicKey.IndexOf(char.ToUpper(input));
        if (index < 0) throw new ArgumentException("Input character not in PublicKey.");

        // Forward through rotors
        foreach (var rotor in _rotors)
            index = rotor.EncodeForward(index);

        // Reflect
        if (Reflector != null)
            index = Reflector.Reflect(index);

        // Backward through rotors (reverse order)
        for (int i = _rotors.Count - 1; i >= 0; i--)
            index = _rotors[i].EncodeBackward(index);

        return PublicKey[index];
    }
}