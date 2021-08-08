using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI2;

namespace TrackerUI
{
    public partial class TeamCreate : BaseSets // REFACTORED
    {
        #region Readonly

        private readonly List<ModelPerson> availTeamMembers = GlobalConfig.Connection.GetPersons();
        private readonly List<ModelPerson> selectedTeamMembers = new List<ModelPerson>();
        private readonly ITeamRequestor _caller;

        #endregion

        #region Constructor

        public TeamCreate(ITeamRequestor caller)
        {
            InitializeComponent();

            _caller = caller;

            WireUpLists();
        }

        #endregion

        #region PrivateFunc

        private void WireUpLists()
        {
            cbSelectTeamMember.DataSource = null;
            cbSelectTeamMember.DataSource = availTeamMembers;
            cbSelectTeamMember.DisplayMember = "FullName";

            lbTeamMembers.DataSource = null;
            lbTeamMembers.DataSource = selectedTeamMembers;
            lbTeamMembers.DisplayMember = "FullName";
        }
        private bool ValidateForm()
        {
            if (tbFirstName.Text.Length == 0)
            {
                return false;
            }
            if (tbLastName.Text.Length == 0)
            {
                return false;
            }
            if (tbEmailAddress.Text.Length == 0)
            {
                return false;
            }
            if (tbPhoneNumber.Text.Length == 0)
            {
                return false;
            }

            return true;
        }
        private void BcreateTeam_Click(object sender, EventArgs e)
        {
            ModelTeam team = new ModelTeam
            {
                TeamName = tbTeamName.Text,
                TeamMembers = selectedTeamMembers
            };

            GlobalConfig.Connection.CreateTeam(team);

            _caller.TeamComplete(team);

            this.Close();
        }
        private void BdeleteSelected_Click(object sender, EventArgs e)
        {
            ModelPerson m = (ModelPerson)lbTeamMembers.SelectedItem;

            if (m != null)
            {
                selectedTeamMembers.Remove(m);
                availTeamMembers.Add(m);

                WireUpLists();
            }
        }
        private void BaddMember_Click(object sender, EventArgs e)
        {
            ModelPerson m = (ModelPerson)cbSelectTeamMember.SelectedItem;

            if (m != null)
            {
                availTeamMembers.Remove(m);
                selectedTeamMembers.Add(m);

                WireUpLists();
            }
        }
        private void BcreateMember_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ModelPerson person = new ModelPerson
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    EmailAddress = tbEmailAddress.Text,
                    PhoneNumber = tbPhoneNumber.Text
                };

                GlobalConfig.Connection.CreatePerson(person);

                selectedTeamMembers.Add(person);
                WireUpLists();

                tbFirstName.Text = tbLastName.Text = tbEmailAddress.Text = tbPhoneNumber.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill in all of the fields!");
            }
        }

        #endregion
    }

}
