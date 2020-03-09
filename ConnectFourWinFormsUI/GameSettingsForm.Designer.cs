using System.Windows.Forms;
using ConnectFourLogic;

namespace B16_Ex05
{
	public partial class GameSettingsForm
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
			this.m_StartGameBtn = new System.Windows.Forms.Button();
			this.m_PlayersLbl = new System.Windows.Forms.Label();
			this.m_PlayerOneLbl = new System.Windows.Forms.Label();
			this.m_PlayerTwoLbl = new System.Windows.Forms.Label();
			this.m_BoardSizeLbl = new System.Windows.Forms.Label();
			this.m_RowsLbl = new System.Windows.Forms.Label();
			this.m_ColsLbl = new System.Windows.Forms.Label();
			this.m_PlayerTwoCheckBox = new System.Windows.Forms.CheckBox();
			this.m_PlayerOneTB = new System.Windows.Forms.TextBox();
			this.m_PlayerTwoComboBox = new System.Windows.Forms.ComboBox();
			this.m_RowsNUD = new System.Windows.Forms.NumericUpDown();
			this.m_ColsNUD = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.m_RowsNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_ColsNUD)).BeginInit();
			this.SuspendLayout();
			// 
			// m_StartGameBtn
			// 
			this.m_StartGameBtn.Location = new System.Drawing.Point(43, 213);
			this.m_StartGameBtn.Name = "m_StartGameBtn";
			this.m_StartGameBtn.Size = new System.Drawing.Size(205, 23);
			this.m_StartGameBtn.TabIndex = 0;
			this.m_StartGameBtn.Text = "Start!";
			this.m_StartGameBtn.UseVisualStyleBackColor = true;
			this.m_StartGameBtn.Click += new System.EventHandler(this.m_StartGameBtn_Click);
			// 
			// m_PlayersLbl
			// 
			this.m_PlayersLbl.AutoSize = true;
			this.m_PlayersLbl.Location = new System.Drawing.Point(13, 13);
			this.m_PlayersLbl.Name = "m_PlayersLbl";
			this.m_PlayersLbl.Size = new System.Drawing.Size(44, 13);
			this.m_PlayersLbl.TabIndex = 1;
			this.m_PlayersLbl.Text = "Players:";
			// 
			// m_PlayerOneLbl
			// 
			this.m_PlayerOneLbl.AutoSize = true;
			this.m_PlayerOneLbl.Location = new System.Drawing.Point(84, 58);
			this.m_PlayerOneLbl.Name = "m_PlayerOneLbl";
			this.m_PlayerOneLbl.Size = new System.Drawing.Size(48, 13);
			this.m_PlayerOneLbl.TabIndex = 2;
			this.m_PlayerOneLbl.Text = "Player 1:";
			// 
			// m_PlayerTwoLbl
			// 
			this.m_PlayerTwoLbl.AutoSize = true;
			this.m_PlayerTwoLbl.Location = new System.Drawing.Point(84, 85);
			this.m_PlayerTwoLbl.Name = "m_PlayerTwoLbl";
			this.m_PlayerTwoLbl.Size = new System.Drawing.Size(48, 13);
			this.m_PlayerTwoLbl.TabIndex = 3;
			this.m_PlayerTwoLbl.Text = "Player 2:";
			// 
			// m_BoardSizeLbl
			// 
			this.m_BoardSizeLbl.AutoSize = true;
			this.m_BoardSizeLbl.Location = new System.Drawing.Point(13, 144);
			this.m_BoardSizeLbl.Name = "m_BoardSizeLbl";
			this.m_BoardSizeLbl.Size = new System.Drawing.Size(61, 13);
			this.m_BoardSizeLbl.TabIndex = 4;
			this.m_BoardSizeLbl.Text = "Board Size:";
			// 
			// m_RowsLbl
			// 
			this.m_RowsLbl.AutoSize = true;
			this.m_RowsLbl.Location = new System.Drawing.Point(40, 180);
			this.m_RowsLbl.Name = "m_RowsLbl";
			this.m_RowsLbl.Size = new System.Drawing.Size(37, 13);
			this.m_RowsLbl.TabIndex = 5;
			this.m_RowsLbl.Text = "Rows:";
			// 
			// m_ColsLbl
			// 
			this.m_ColsLbl.AutoSize = true;
			this.m_ColsLbl.Location = new System.Drawing.Point(168, 178);
			this.m_ColsLbl.Name = "m_ColsLbl";
			this.m_ColsLbl.Size = new System.Drawing.Size(30, 13);
			this.m_ColsLbl.TabIndex = 6;
			this.m_ColsLbl.Text = "Cols:";
			// 
			// m_PlayerTwoCheckBox
			// 
			this.m_PlayerTwoCheckBox.AutoSize = true;
			this.m_PlayerTwoCheckBox.Location = new System.Drawing.Point(69, 85);
			this.m_PlayerTwoCheckBox.Name = "m_PlayerTwoCheckBox";
			this.m_PlayerTwoCheckBox.Size = new System.Drawing.Size(15, 14);
			this.m_PlayerTwoCheckBox.TabIndex = 7;
			this.m_PlayerTwoCheckBox.UseVisualStyleBackColor = true;
			this.m_PlayerTwoCheckBox.CheckedChanged += new System.EventHandler(this.m_PlayerTwoCheckBox_CheckedChanged);
			// 
			// m_PlayerOneTB
			// 
			this.m_PlayerOneTB.Location = new System.Drawing.Point(138, 55);
			this.m_PlayerOneTB.Name = "m_PlayerOneTB";
			this.m_PlayerOneTB.Size = new System.Drawing.Size(100, 20);
			this.m_PlayerOneTB.TabIndex = 8;
			this.m_PlayerOneTB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_PlayerOneTB_MouseDown);
			// 
			// m_PlayerTwoComboBox
			// 
			this.m_PlayerTwoComboBox.FormattingEnabled = true;
			this.m_PlayerTwoComboBox.Items.AddRange(new object[] {
            "AI",
            "Dumb Computer"});
			this.m_PlayerTwoComboBox.Location = new System.Drawing.Point(138, 81);
			this.m_PlayerTwoComboBox.Name = "m_PlayerTwoComboBox";
			this.m_PlayerTwoComboBox.Size = new System.Drawing.Size(100, 21);
			this.m_PlayerTwoComboBox.TabIndex = 9;
			// 
			// m_RowsNUD
			// 
			this.m_RowsNUD.Location = new System.Drawing.Point(81, 177);
			this.m_RowsNUD.Name = "m_RowsNUD";
			this.m_RowsNUD.Size = new System.Drawing.Size(47, 20);
			this.m_RowsNUD.TabIndex = 10;
			// 
			// m_ColsNUD
			// 
			this.m_ColsNUD.Location = new System.Drawing.Point(201, 175);
			this.m_ColsNUD.Name = "m_ColsNUD";
			this.m_ColsNUD.Size = new System.Drawing.Size(47, 20);
			this.m_ColsNUD.TabIndex = 11;
			// 
			// GameSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.m_ColsNUD);
			this.Controls.Add(this.m_RowsNUD);
			this.Controls.Add(this.m_PlayerTwoComboBox);
			this.Controls.Add(this.m_PlayerOneTB);
			this.Controls.Add(this.m_PlayerTwoCheckBox);
			this.Controls.Add(this.m_ColsLbl);
			this.Controls.Add(this.m_RowsLbl);
			this.Controls.Add(this.m_BoardSizeLbl);
			this.Controls.Add(this.m_PlayerTwoLbl);
			this.Controls.Add(this.m_PlayerOneLbl);
			this.Controls.Add(this.m_PlayersLbl);
			this.Controls.Add(this.m_StartGameBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GameSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Settings";
			((System.ComponentModel.ISupportInitialize)(this.m_RowsNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_ColsNUD)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button m_StartGameBtn;
		private Label m_PlayersLbl;
		private Label m_PlayerOneLbl;
		private Label m_PlayerTwoLbl;
		private Label m_BoardSizeLbl;
		private Label m_RowsLbl;
		private Label m_ColsLbl;
		private CheckBox m_PlayerTwoCheckBox;
		private TextBox m_PlayerTwoTB;
		private TextBox m_PlayerOneTB;
		private ComboBox m_PlayerTwoComboBox;
		private NumericUpDown m_RowsNUD;
		private NumericUpDown m_ColsNUD;
	}
}