public class Rotor
{
    // Guid is used to uniquely identify each rotor as direct references. Just in case we can't use index
    public Guid Id { get; set; } = Guid.NewGuid(); // Unique identifier for each rotor
    public string Name { get; set; }
    public string SetId { get; set; }

    public const string PublicKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Standard alphabet for rotor wiring
    public string Wiring { get; set; }
    // public string Metadata { get; set; } // expand on this later

    // Notch position used for shifting letters. Use as offset when translating letters
    private int _position = 0;
    public int Position
    {
        get => _position;
        set
        {
            if (!string.IsNullOrEmpty(Wiring) && Wiring.Length > 0)
            {
                // Modulo operation to wrap position, handles negative values as well
                _position = ((value % Wiring.Length) + Wiring.Length) % Wiring.Length;
            }
            else
            {
                _position = 0;
            }
        }
    }

    public Rotor(string name, string setId, string wiring)
    {
        Name = name;
        SetId = setId;
        Wiring = wiring;
    }

    // Parameterless constructor for deserialization
    public Rotor() { }

    // Forward: input index -> output index
    public int EncodeForward(int inputIndex)
    {
        int shiftedIndex = (inputIndex + Position) % Wiring.Length;
        char outputChar = Wiring[shiftedIndex];
        int outputIndex = RotorAssembly.PublicKey.IndexOf(outputChar);
        return outputIndex;
    }

    // Backward: input index -> output index
    public int EncodeBackward(int inputIndex)
    {
        char inputChar = RotorAssembly.PublicKey[inputIndex];
        int wiringIndex = Wiring.IndexOf(inputChar);
        int shiftedIndex = (wiringIndex - Position + Wiring.Length) % Wiring.Length;
        return shiftedIndex;
    }
}