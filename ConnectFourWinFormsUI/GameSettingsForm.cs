using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectFourLogic;

namespace B16_Ex05
{
	public partial class GameSettingsForm : Form
	{
		private GameModel m_GameModel;
		private eGameMode m_GameMode;

		public GameSettingsForm()
		{
			InitializeComponent();
			setFormSettings();
		}

		private void setFormSettings()
		{
			m_GameModel = new GameModel();
			
			m_RowsNUD.Minimum = m_GameModel.MinBoardLength;
			m_RowsNUD.Maximum = m_GameModel.MaxBoardLength;
			m_ColsNUD.Minimum = m_GameModel.MinBoardLength;
			m_ColsNUD.Maximum = m_GameModel.MaxBoardLength;

			m_PlayerTwoComboBox.SelectedIndex = m_PlayerTwoComboBox.Items.IndexOf("AI");
			this.m_PlayerOneTB.Select();
		}

		private void m_PlayerOneTB_MouseDown(object sender, MouseEventArgs e)
		{
			if (m_PlayerOneTB.BackColor == Color.Pink)
			{
				m_PlayerOneTB.BackColor = Color.White;
			}

			m_PlayerOneTB.Text = string.Empty;
		}

		private void m_PlayerTwoTB_MouseDown(object sender, MouseEventArgs e)
		{
			if (m_PlayerTwoTB.BackColor == Color.Pink)
			{
				m_PlayerTwoTB.BackColor = Color.White;
			}

            m_PlayerTwoTB.Text = string.Empty;
		}

		private void m_PlayerTwoCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_PlayerTwoCheckBox.Checked)
			{
				m_PlayerTwoComboBox.Visible = false;

				if (m_PlayerTwoTB == null)
				{
					m_PlayerTwoTB = new TextBox();
					m_PlayerTwoTB.Size = m_PlayerTwoComboBox.Size;
					m_PlayerTwoTB.Location = m_PlayerTwoComboBox.Location;
					m_PlayerTwoTB.MouseDown += new MouseEventHandler(this.m_PlayerTwoTB_MouseDown);
					Controls.Add(m_PlayerTwoTB);
				}

				m_PlayerTwoTB.Visible = true;
			}
			else
			{
				m_PlayerTwoTB.Visible = false;
				m_PlayerTwoComboBox.Visible = true;
			}
		}

		private void m_StartGameBtn_Click(object sender, EventArgs e)
		{
			bool playerOneEmptyNameFlag = m_PlayerOneTB.Text.Equals(string.Empty);
			bool playerTwoEmptyNameFlag = m_PlayerTwoCheckBox.Checked && m_PlayerTwoTB.Text.Equals(string.Empty);
			if (playerOneEmptyNameFlag)
			{
				m_PlayerOneTB.BackColor = Color.Pink;
				m_PlayerOneTB.Update();
			}

			if (playerTwoEmptyNameFlag)
			{
				m_PlayerTwoTB.BackColor = Color.Pink;
				m_PlayerTwoTB.Update();
			}

			if (!playerOneEmptyNameFlag && !playerTwoEmptyNameFlag)
			{
                // $G$ DSN-001 (-5) Board initialization should not be the responsibility of the UI. 
				m_GameModel.GameBoard = new Board((int)m_RowsNUD.Value, (int)m_ColsNUD.Value);
				setGameMode();
				initPlayers();
                // $G$ DSN-999 (-5) The game settings form should not be tightly coupled to the game form.
				GameForm gameForm = new GameForm(m_GameModel, m_GameMode);
				this.Hide();
				gameForm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Please fill all the details.", "Attention");
			}
		}

		private void setGameMode()
		{
			if (m_PlayerTwoCheckBox.Checked)
			{
				m_GameMode = eGameMode.PlayerVsPlayer;
			}
			else
			{
				m_GameMode = m_PlayerTwoComboBox.SelectedIndex == m_PlayerTwoComboBox.Items.IndexOf("AI") ? eGameMode.PlayerVsAi : eGameMode.PlayerVsDumbComputer;
			}
		}

		private void initPlayers()
		{
			const bool v_InitTwoPlayers = true;
			switch (m_GameMode)
			{
				case eGameMode.PlayerVsPlayer:
					initPlayer(v_InitTwoPlayers);
					break;
				case eGameMode.PlayerVsDumbComputer:
					initPlayer(!v_InitTwoPlayers);
					initDumbComputer();
					break;
				case eGameMode.PlayerVsAi:
					initPlayer(!v_InitTwoPlayers);
					initAi();
					break;
				default:
					break;
			}
		}

		private void initAi()
		{
			m_GameModel.InitializePlayer("AI", ePlayer.Ai);
		}

		private void initDumbComputer()
		{
			m_GameModel.InitializePlayer("Dumb Computer", ePlayer.DumbComputer);
		}

		private void initPlayer(bool i_InitTwoPlayers)
		{
			m_GameModel.InitializePlayer(m_PlayerOneTB.Text, ePlayer.Human);

			if (i_InitTwoPlayers)
			{
				m_GameModel.InitializePlayer(m_PlayerTwoTB.Text, ePlayer.Human);
			}
		}
	}
}
