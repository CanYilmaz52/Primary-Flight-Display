namespace deneme
{
    partial class RadarForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxRadar = new System.Windows.Forms.PictureBox();
            this.BtnAddMissile = new System.Windows.Forms.Button();
            this.BtnAddEnemy = new System.Windows.Forms.Button();
            this.BtnAddFriend = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRadar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRadar
            // 
            this.pictureBoxRadar.Location = new System.Drawing.Point(0, 224);
            this.pictureBoxRadar.Name = "pictureBoxRadar";
            this.pictureBoxRadar.Size = new System.Drawing.Size(345, 217);
            this.pictureBoxRadar.TabIndex = 0;
            this.pictureBoxRadar.TabStop = false;
            this.pictureBoxRadar.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxRadar_Paint_1);
            // 
            // BtnAddMissile
            // 
            this.BtnAddMissile.Location = new System.Drawing.Point(351, 227);
            this.BtnAddMissile.Name = "BtnAddMissile";
            this.BtnAddMissile.Size = new System.Drawing.Size(98, 49);
            this.BtnAddMissile.TabIndex = 1;
            this.BtnAddMissile.Text = "Missile";
            this.BtnAddMissile.UseVisualStyleBackColor = true;
            this.BtnAddMissile.Click += new System.EventHandler(this.BtnAddMissile_Click_1);
            // 
            // BtnAddEnemy
            // 
            this.BtnAddEnemy.Location = new System.Drawing.Point(351, 282);
            this.BtnAddEnemy.Name = "BtnAddEnemy";
            this.BtnAddEnemy.Size = new System.Drawing.Size(98, 49);
            this.BtnAddEnemy.TabIndex = 2;
            this.BtnAddEnemy.Text = "Enemy";
            this.BtnAddEnemy.UseVisualStyleBackColor = true;
            this.BtnAddEnemy.Click += new System.EventHandler(this.BtnAddEnemy_Click_1);
            // 
            // BtnAddFriend
            // 
            this.BtnAddFriend.Location = new System.Drawing.Point(351, 337);
            this.BtnAddFriend.Name = "BtnAddFriend";
            this.BtnAddFriend.Size = new System.Drawing.Size(98, 49);
            this.BtnAddFriend.TabIndex = 3;
            this.BtnAddFriend.Text = "Friend";
            this.BtnAddFriend.UseVisualStyleBackColor = true;
            this.BtnAddFriend.Click += new System.EventHandler(this.BtnAddFriend_Click_1);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(351, 392);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(98, 49);
            this.BtnClear.TabIndex = 4;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(452, 215);
            this.dataGridView.TabIndex = 5;
            // 
            // RadarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnAddFriend);
            this.Controls.Add(this.BtnAddEnemy);
            this.Controls.Add(this.BtnAddMissile);
            this.Controls.Add(this.pictureBoxRadar);
            this.Name = "RadarForm";
            this.Size = new System.Drawing.Size(452, 443);
            this.Load += new System.EventHandler(this.RadarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRadar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRadar;
        private System.Windows.Forms.Button BtnAddMissile;
        private System.Windows.Forms.Button BtnAddEnemy;
        private System.Windows.Forms.Button BtnAddFriend;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}
