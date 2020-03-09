namespace B16_Ex05
{
	public partial class GameForm
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
			this.m_PlayerOneLbl = new System.Windows.Forms.Label();
			this.m_PlayerTwoLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_PlayerOneLbl
			// 
			this.m_PlayerOneLbl.AutoSize = true;
			this.m_PlayerOneLbl.Location = new System.Drawing.Point(100, 352);
			this.m_PlayerOneLbl.Name = "m_PlayerOneLbl";
			this.m_PlayerOneLbl.Size = new System.Drawing.Size(70, 13);
			this.m_PlayerOneLbl.TabIndex = 0;
			this.m_PlayerOneLbl.Text = "PlayerOneLbl";
			// 
			// m_PlayerTwoLbl
			// 
			this.m_PlayerTwoLbl.AutoSize = true;
			this.m_PlayerTwoLbl.Location = new System.Drawing.Point(296, 352);
			this.m_PlayerTwoLbl.Name = "m_PlayerTwoLbl";
			this.m_PlayerTwoLbl.Size = new System.Drawing.Size(71, 13);
			this.m_PlayerTwoLbl.TabIndex = 1;
			this.m_PlayerTwoLbl.Text = "PlayerTwoLbl";
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 374);
			this.Controls.Add(this.m_PlayerTwoLbl);
			this.Controls.Add(this.m_PlayerOneLbl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "GameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Tag = string.Empty;
			this.Text = "Connect Four";
			this.Load += new System.EventHandler(this.GameForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label m_PlayerOneLbl;
		private System.Windows.Forms.Label m_PlayerTwoLbl;
	}
}