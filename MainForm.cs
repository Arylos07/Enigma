using System.Diagnostics;
using System.Text.Json;

namespace Enigma
{
    public partial class MainForm : Form
    {
        public RotorAssembly rotorAssembly;
        private List<TextBox> rotorPositionBoxes = new();

        public MainForm()
        {
            InitializeComponent();

            // Read JSON from file
            string json = File.ReadAllText("rotors.json");
            List<Rotor> rotors = JsonSerializer.Deserialize<List<Rotor>>(json);

            // Example: Load from JSON
            string reflectorJson = File.ReadAllText("reflectors.json");
            List<Reflector> reflectors = JsonSerializer.Deserialize<List<Reflector>>(reflectorJson);
            Reflector reflector = reflectors?.FirstOrDefault();

            if (rotors != null)
            {
                rotorAssembly = new RotorAssembly(rotors, reflector);
                InitializeRotorPositionControls();
            }
        }

        private void InitializeRotorPositionControls()
        {
            panelRotorPositions.Controls.Clear();
            rotorPositionBoxes.Clear();

            if (rotorAssembly == null) return;

            for (int i = 0; i < rotorAssembly.Rotors.Count; i++)
            {
                var rotor = rotorAssembly.Rotors[i];

                var label = new Label
                {
                    Text = rotor.Name,
                    Width = 70,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(3, 6, 3, 3)
                };
                panelRotorPositions.Controls.Add(label);

                var posBox = new TextBox
                {
                    Width = 40,
                    Text = rotor.Position.ToString(),
                    Tag = i,
                    Margin = new Padding(3, 3, 10, 3)
                };
                posBox.TextChanged += RotorPositionBox_TextChanged;
                panelRotorPositions.Controls.Add(posBox);
                rotorPositionBoxes.Add(posBox);
            }
        }

        private void ButtonTranslate_Click(object sender, EventArgs e)
        {
            if (rotorAssembly == null) return;

            string input = textBoxInput.Text.ToUpperInvariant();
            string output = "";

            foreach (char c in input)
            {
                if (Rotor.PublicKey.Contains(c))
                {
                    output += rotorAssembly.Encode(c);
                    rotorAssembly.Step();
                }
                else
                {
                    output += c; // Non-alphabetic chars pass through
                }
            }

            textBoxOutput.Text = output;
            UpdateRotorPositionBoxes();
        }

        private void RotorPositionBox_TextChanged(object sender, EventArgs e)
        {
            if (rotorAssembly == null) return;
            var box = sender as TextBox;
            if (box == null) return;
            if (int.TryParse(box.Text, out int pos))
            {
                int idx = (int)box.Tag;
                if (idx >= 0 && idx < rotorAssembly.Rotors.Count)
                {
                    rotorAssembly.Rotors[idx].Position = pos;
                }
            }
        }

        private void UpdateRotorPositionBoxes()
        {
            if (rotorAssembly == null) return;
            for (int i = 0; i < rotorPositionBoxes.Count; i++)
            {
                rotorPositionBoxes[i].Text = rotorAssembly.Rotors[i].Position.ToString();
            }
        }
    }
}
