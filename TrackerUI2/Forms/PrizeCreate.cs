using System;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI2;

namespace TrackerUI
{
    public partial class PrizeCreate : BaseSets // REFACTORED
    {
        #region Readonly

        readonly IPrizeRequestor _caller;

        #endregion

        #region Constructor

        public PrizeCreate(IPrizeRequestor caller)
        {
            InitializeComponent();
            _caller = caller;
        }

        #endregion

        #region PrivateFunc

        private bool ValidateForm()
        {
            bool result = true,
                 placeNumberValid = int.TryParse(tbPlaceNumber.Text, out int placeNumber),
                 prizeAmountValid = int.TryParse(tbPrizeAmount.Text, out int prizeAmount),
                 prizePercentageValid = float.TryParse(tbPrizePercentage.Text, out float prizePercentage);

            if (!placeNumberValid)
            {
                result = false;
            }
            if (placeNumber < 1)
            {
                result = false;
            }
            if (tbPlaceName.Text.Length == 0)
            {
                result = false;
            }
            if ((!prizeAmountValid) || (!prizePercentageValid))
            {
                result = false;
            }
            if ((prizeAmount <= 0) && (prizePercentage <= 0))
            {
                result = false;
            }
            if (prizePercentage > 100)
            {
                result = false;
            }

            return result;
        }

        private void BcreatePrize_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ModelPrize model = new ModelPrize(
                    tbPlaceNumber.Text,
                    tbPlaceName.Text,
                    tbPrizeAmount.Text,
                    tbPrizePercentage.Text);

                GlobalConfig.Connection.CreatePrize(model);

                _caller.PrizeComplete(model);
                this.Close();

                tbPlaceNumber.Text = tbPlaceName.Text = "";
                tbPrizeAmount.Text = tbPrizePercentage.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has some invalid information. Please check and try again");
            }
        }

        #endregion

    }
}
