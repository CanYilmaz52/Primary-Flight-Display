using System.Drawing;
using System.Windows.Forms;

namespace deneme
{
    public partial class AttitudeSlipSkidIndicator : UserControl
    {
        private float pitchValue = 0;
        private float rollValue = 0;
        private float slipSkidValue = 0;

        public AttitudeSlipSkidIndicator()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void UpdateAttitudeSlipSkidControlValues(float newPitch, float newRoll, float newSlipSkid)
        {
            pitchValue = newPitch;
            rollValue = newRoll;
            slipSkidValue = newSlipSkid;

            // Trigger repaint
            Invalidate();
        }

        private void DrawAttitudeIndicator(Graphics g)
        {
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            // Draw the attitude indicator background (horizon line)
            int horizonWidth = pictureBox1.Width;
            int horizonHeight = pictureBox1.Height / 2;
            g.FillRectangle(Brushes.LightBlue, 0, centerY - horizonHeight, horizonWidth, 2 * horizonHeight);

            // Draw the aircraft symbol (simple rectangle)
            int symbolWidth = 20;
            int symbolHeight = 40;
            int symbolX = centerX - symbolWidth / 2;
            int symbolY = centerY - symbolHeight / 2;
            g.FillRectangle(Brushes.White, symbolX, symbolY, symbolWidth, symbolHeight);

            // Rotate the aircraft symbol based on the roll angle
            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(rollValue); // Using the class-level rollValue
            g.FillRectangle(Brushes.White, -symbolWidth / 2, -symbolHeight / 2, symbolWidth, symbolHeight);
            g.ResetTransform();

            // Draw the pitch lines (reference lines)
            for (int i = -90; i <= 90; i += 10)
            {
                int pitchY = centerY + i * horizonHeight / 90;
                g.DrawLine(Pens.Black, centerX - 10, pitchY, centerX + 10, pitchY);
            }

            // Draw the pitch indicator line
            int pitchIndicatorY = centerY - (int)(pitchValue * horizonHeight / 90);
            g.DrawLine(Pens.Red, centerX - 20, pitchIndicatorY, centerX + 20, pitchIndicatorY);

            // Draw numerical pitch and roll values
            string pitchText = $"Pitch: {pitchValue:F1}°";
            string rollText = $"Roll: {rollValue:F1}°";
            Font font = new Font("Arial", 10, FontStyle.Bold);
            Brush textBrush = Brushes.White;
            int textX = centerX + symbolWidth / 2 + 10;
            int textY = centerY - symbolHeight / 2;
            g.DrawString(pitchText, font, textBrush, textX, textY);
            g.DrawString(rollText, font, textBrush, textX, textY + 20);
        }

        private void DrawSlipSkidIndicator(Graphics g)
        {
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;
            int ballSize = 10;

            // Calculate the position of the slip/skid indicator ball
            int ballX = centerX + (int)(slipSkidValue * 50);
            int ballY = centerY + 100; // Adjust the vertical position of the ball

            // Clear the area
            g.Clear(Color.Black);

            // Draw the slip/skid ball
            g.FillEllipse(Brushes.Blue, ballX - ballSize / 2, ballY - ballSize / 2, ballSize, ballSize);

            // Draw the pitch lines (reference lines)
            int horizonHeight = pictureBox1.Height / 2;
            for (int i = -90; i <= 90; i += 10)
            {
                int pitchY = centerY + i * horizonHeight / 90;
                g.DrawLine(Pens.Black, centerX - 10, pitchY, centerX + 10, pitchY);
            }

            // Draw the pitch indicator line using class-level pitchY
            int pitchIndicatorY = centerY - (int)(pitchValue * horizonHeight / 90);
            g.DrawLine(Pens.Red, centerX - 20, pitchIndicatorY, centerX + 20, pitchIndicatorY);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawSlipSkidIndicator(g); // Call your drawing method here
            DrawAttitudeIndicator(g);
        }
    }
}