using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class PrizeCreate : BaseSets
    {
        public PrizeCreate()
        {
            InitializeComponent();
        }

        private void bCreatePrize_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ModelPrize model = new ModelPrize(
                    tbPlaceNumber.Text,
                    tbPlaceName.Text,
                    tbPrizeAmount.Text,
                    tbPrizePercentage.Text);

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
                tbPlaceNumber.Text = "";
                tbPlaceName.Text = "";
                tbPrizeAmount.Text = "0";
                tbPrizePercentage.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has some invalid information. Please check and try again");
            }
        }
        private bool ValidateForm()
        {
            float prizePercentage = 0;
            int placeNumber = 0,
                prizeAmount = 0;
            bool result = true, 
                 placeNumberValid = int.TryParse(tbPlaceNumber.Text, out placeNumber),
                 prizeAmountValid = int.TryParse(tbPrizeAmount.Text, out prizeAmount),
                 prizePercentageValid = float.TryParse(tbPrizePercentage.Text, out prizePercentage);

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
            if ((!prizeAmountValid)||(!prizePercentageValid))
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
    }
}
