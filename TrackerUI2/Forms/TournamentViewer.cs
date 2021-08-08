using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewer : BaseSets // REFACTORED
    {
        #region Readonly

        readonly ModelTournament tournament;
        readonly BindingList<int> rounds = new BindingList<int>();
        readonly BindingList<ModelMatchup> selectedMatchups = new BindingList<ModelMatchup>();

        #endregion

        #region Constructor

        public TournamentViewer(ModelTournament _tournament)
        {
            InitializeComponent();

            tournament = _tournament;

            tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

            WireUpLists();

            LoadFormData();

            LoadRounds();
        }

        #endregion

        #region PrivateFunc

        private void Tournament_OnTournamentComplete(object sender, DateTime e)
        {
            this.Close();
        }
        private void LoadFormData()
        {
            lTournamentName.Text = tournament.TournamentName;
        }
        private void WireUpLists()
        {
            CbRounds.DataSource = rounds;
            LbRounds.DataSource = selectedMatchups;
            LbRounds.DisplayMember = "DisplayName";
        }
        private void LoadRounds()
        {
            rounds.Clear();

            rounds.Add(1);
            int currRound = 1;

            foreach (List<ModelMatchup> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                }
            }
            LoadMatchupList(1);
        }
        private void LoadMatchupList(int round)
        {
            foreach (List<ModelMatchup> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (ModelMatchup model in matchups)
                    {
                        if (model.Winner == null || !CbUnplayedOnly.Checked)
                        {
                            selectedMatchups.Add(model);
                        }
                    }
                }
            }
            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }
            DisplayMatchupInfo();
        }
        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            lteamOne.Visible = tbTeamOne.Visible = isVisible;
            lTeamTwo.Visible = tbTeamTwo.Visible = isVisible;
            lNoneSelected.Visible = !isVisible;

        }
        private void CbRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchupList((int)CbRounds.SelectedItem);
        }
        private void LoadMatchup(ModelMatchup model)
        {
            if (model != null)
            {
                for (int i = 0; i < model.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (model.Entries[0].TeamCompeting != null)
                        {
                            lteamOne.Text = model.Entries[0].TeamCompeting.TeamName;
                            tbTeamOne.Text = model.Entries[0].Score.ToString();

                            lTeamTwo.Text = "<bot>";
                            tbTeamTwo.ReadOnly = true;
                            tbTeamTwo.Text = "0";
                        }
                        else
                        {
                            lteamOne.Text = "Not Yet Set";
                            tbTeamOne.Text = "";
                        }
                    }
                    if (i == 1)
                    {
                        if (model.Entries[1].TeamCompeting != null)
                        {
                            lTeamTwo.Text = model.Entries[1].TeamCompeting.TeamName; ;
                            tbTeamTwo.ReadOnly = false;
                            tbTeamTwo.Text = model.Entries[1].Score.ToString();
                        }
                        else
                        {
                            lTeamTwo.Text = "Not Yet Set";
                            tbTeamTwo.Text = "";
                        }
                    }
                }
            }
        }
        private void CbUnplayedOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchupList((int)CbRounds.SelectedItem);
        }
        private string ValidateData()
        {
            string output = "";

            bool scoreOneValid = double.TryParse(tbTeamOne.Text, out double teamOneScore);
            bool scoreTwoValid = double.TryParse(tbTeamTwo.Text, out double teamTwoScore);

            if (!scoreOneValid)
            {
                output = "The score one is not valid number";
            }
            else if (!scoreTwoValid)
            {
                output = "The score two is not valid number";
            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "You didnt enter a score for either teams";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "Ties are't allowed in this App";
            }

            return output;
        }
        private void Bscore_Click(object sender, EventArgs e)
        {
            string errorMsg = ValidateData();
            if (errorMsg.Length > 0)
            {
                MessageBox.Show($"Input error : {errorMsg}");
                return;
            }

            ModelMatchup model = (ModelMatchup)LbRounds.SelectedItem;

            for (int i = 0; i < model.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (model.Entries[0].TeamCompeting != null)
                    {
                        model.Entries[0].Score = Convert.ToInt32(tbTeamOne.Text);
                    }
                }
                if (i == 1)
                {
                    if (model.Entries[1].TeamCompeting != null)
                    {
                        model.Entries[1].Score = Convert.ToInt32(tbTeamTwo.Text);
                    }
                }
            }
            try
            {
                Logic.AppLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The App Encounter An Error : {ex.Message}");
                return;
            }
            LoadMatchupList((int)CbRounds.SelectedItem);
        }
        private void LbRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((ModelMatchup)LbRounds.SelectedItem);
        }

        #endregion
    }
}
