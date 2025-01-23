using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace deneme
{
    public partial class RadarForm : UserControl
    {

        private List<Threat> threats = new List<Threat>();
        private Random random = new Random();


        public RadarForm()
        {
            InitializeComponent();
        }


        private void AddThreat(Threat threat)
        {
            threats.Add(threat);
        }


        public void Draw(Graphics g)
        {
            int centerX = 100;
            int centerY = 100;
            int radius = 80;

            // Radar çizgisini çiz
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            }

            // Radar çizgisinin içindeki tehditleri çiz
            foreach (var threat in threats)
            {
                int x = centerX + (int)(radius * Math.Sin(threat.Angle));
                int y = centerY - (int)(radius * Math.Cos(threat.Angle));

                threat.X = x - 10;
                threat.Y = y - 10;

                threat.Draw(g);
            }

            int aircraftX = centerX - 5;
            int aircraftY = centerY - 5;
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                g.FillEllipse(brush, aircraftX, aircraftY, 10, 10);
            }
        }

        public void ClearThreats()
        {
            threats.Clear();
        }

        private void pictureBoxRadar_Paint_1(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private int remainingFlare = 100;

        private void BtnAddMissile_Click_1(object sender, EventArgs e)
        {
            double angle = random.NextDouble() * 2 * Math.PI; // Rastgele bir açı seçin
            Threat missile = new Threat(angle, ThreatType.Missile);


            string deffence = $"MISSILE INCOMING!! Do you want to use flare for deflect? Remaining Flare: {remainingFlare}";
            DialogResult dialogResult = MessageBox.Show(deffence, "Received Emergency Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                remainingFlare --;
                MessageBox.Show("Missile deflected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else 
            {
                MessageBox.Show("Missile location writing on list. INCOMING MISSILE!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddThreat(missile); // Radar sınıfının AddThreat metodu ile tehdit ekleyin
                pictureBoxRadar.Refresh();
                dataGridView.Rows.Add("Missile", angle, GetRandomCoordinate(), GetRandomCoordinate());
            }

        }

        private void BtnAddEnemy_Click_1(object sender, EventArgs e)
        {
            double angle = random.NextDouble() * 2 * Math.PI; // Rastgele bir açı seçin
            Threat enemy = new Threat(angle, ThreatType.Enemy);
            AddThreat(enemy); // Radar sınıfının AddThreat metodu ile tehdit ekleyin
            pictureBoxRadar.Refresh();

            dataGridView.Rows.Add("Enemy", angle, GetRandomCoordinate(), GetRandomCoordinate());
        }

        private void BtnAddFriend_Click_1(object sender, EventArgs e)
        {
            double angle = random.NextDouble() * 2 * Math.PI; // Rastgele bir açı seçin
            Threat friend = new Threat(angle, ThreatType.Friend);
            AddThreat(friend); // Radar sınıfının AddThreat metodu ile tehdit ekleyin
            pictureBoxRadar.Refresh();

            dataGridView.Rows.Add("Friend", angle, GetRandomCoordinate(), GetRandomCoordinate());
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearThreats();
            pictureBoxRadar.Refresh();
            dataGridView.Rows.Clear();
        }

        private double GetRandomCoordinate()
        {
            return random.Next(-100, 100);
        }

        private void RadarForm_Load(object sender, EventArgs e)
        {
            // DataGridView'a sütunları tanımlayın
            dataGridView.Columns.Add("ThreatType", "Threat Type");
            dataGridView.Columns.Add("Angle", "Angle");
            dataGridView.Columns.Add("XCoordinate", "X Coordinate");
            dataGridView.Columns.Add("YCoordinate", "Y Coordinate");

        }
    }

    public enum ThreatType
    {
        Missile,
        Enemy,
        Friend
    }

    public class Threat
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Angle { get; private set; }
        public ThreatType Type { get; private set; }

        public Threat(double angle, ThreatType type)
        {
            Angle = angle;
            Type = type;
        }

        public void Draw(Graphics g)
        {
            Color color = Type == ThreatType.Missile ? Color.Red :
                          Type == ThreatType.Enemy ? Color.Red :
                          Type == ThreatType.Friend ? Color.Green :
                          Color.Black;

            if (Type == ThreatType.Missile)
            {
                Point[] points = new Point[]
                {
                    new Point(X, Y + 20),
                    new Point(X + 10, Y),
                    new Point(X + 20, Y + 20)
                };

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillPolygon(brush, points);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, X, Y, 20, 20);
                }
            }
        }
    }
}
