namespace Blackjack
{
    partial class InitializeGameForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAmountOfDecks = new System.Windows.Forms.Label();
            this.lblAmountOfPlayers = new System.Windows.Forms.Label();
            this.tbxDecks = new System.Windows.Forms.TextBox();
            this.tbxPlayers = new System.Windows.Forms.TextBox();
            this.btnLetsGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAmountOfDecks
            // 
            this.lblAmountOfDecks.AutoSize = true;
            this.lblAmountOfDecks.Font = new System.Drawing.Font("Rockwell Condensed", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblAmountOfDecks.Location = new System.Drawing.Point(49, 107);
            this.lblAmountOfDecks.Name = "lblAmountOfDecks";
            this.lblAmountOfDecks.Size = new System.Drawing.Size(210, 33);
            this.lblAmountOfDecks.TabIndex = 9;
            this.lblAmountOfDecks.Text = "Amount of decks:";
            // 
            // lblAmountOfPlayers
            // 
            this.lblAmountOfPlayers.AutoSize = true;
            this.lblAmountOfPlayers.Font = new System.Drawing.Font("Rockwell Condensed", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblAmountOfPlayers.Location = new System.Drawing.Point(49, 191);
            this.lblAmountOfPlayers.Name = "lblAmountOfPlayers";
            this.lblAmountOfPlayers.Size = new System.Drawing.Size(239, 33);
            this.lblAmountOfPlayers.TabIndex = 10;
            this.lblAmountOfPlayers.Text = "Amount of players: ";
            // 
            // tbxDecks
            // 
            this.tbxDecks.Location = new System.Drawing.Point(308, 109);
            this.tbxDecks.Name = "tbxDecks";
            this.tbxDecks.Size = new System.Drawing.Size(150, 31);
            this.tbxDecks.TabIndex = 11;
            // 
            // tbxPlayers
            // 
            this.tbxPlayers.Location = new System.Drawing.Point(308, 191);
            this.tbxPlayers.Name = "tbxPlayers";
            this.tbxPlayers.Size = new System.Drawing.Size(150, 31);
            this.tbxPlayers.TabIndex = 12;
            // 
            // btnLetsGo
            // 
            this.btnLetsGo.Font = new System.Drawing.Font("Rockwell Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLetsGo.Location = new System.Drawing.Point(214, 256);
            this.btnLetsGo.Name = "btnLetsGo";
            this.btnLetsGo.Size = new System.Drawing.Size(145, 45);
            this.btnLetsGo.TabIndex = 13;
            this.btnLetsGo.Text = "Let\'s go!";
            this.btnLetsGo.UseVisualStyleBackColor = true;
            this.btnLetsGo.Click += new System.EventHandler(this.btnLetsGo_Click);
            // 
            // InitializeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 335);
            this.Controls.Add(this.btnLetsGo);
            this.Controls.Add(this.tbxPlayers);
            this.Controls.Add(this.tbxDecks);
            this.Controls.Add(this.lblAmountOfPlayers);
            this.Controls.Add(this.lblAmountOfDecks);
            this.Name = "InitializeGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A New Game of Blackjack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblAmountOfDecks;
        private Label lblAmountOfPlayers;
        private TextBox tbxDecks;
        private TextBox tbxPlayers;
        private Button btnLetsGo;
    }
}