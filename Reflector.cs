public class Reflector
{
    public string Name { get; set; }
    public string Wiring { get; set; }

    public Reflector() { }

    public char Reflect(char input)
    {
        int index = Rotor.PublicKey.IndexOf(char.ToUpper(input));
        if (index < 0 || index >= Wiring.Length)
            throw new ArgumentException("Invalid character for reflector.");
        return Wiring[index];
    }

    public int Reflect(int inputIndex)
    {
        char reflectedChar = Wiring[inputIndex];
        return RotorAssembly.PublicKey.IndexOf(reflectedChar);
    }
}