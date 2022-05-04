using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsApp
{
    public partial class Rex200DataInputForm : Form
    {
        public Rex200DataInputForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void valueItem1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void valueItem2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void valueItem3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void valueItem4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void valueItem5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void valueItem6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void calcAll_Click(object sender, EventArgs e)
        {
            if (valueItem4.Text != "" && valueItem5.Text != "" && valueItem7.Text != "")
            {
                double param4 = double.Parse(valueItem4.Text);
                double param5 = double.Parse(valueItem5.Text);
                double param7 = double.Parse(valueItem7.Text);

                double mNO2 = calcMNO2(param4);
                double mNO = calcMNO(mNO2);
                double mCO = calcMCO(param4);
                double mSO2 = calcMSO2(param4, param5);
                double mC = calcMC(param4, param7);
                double mBenzP = calcBenzP(param4);

                double mMazut = calcHardMetal(param4, 0.02, 0, 0.02);
                double mKadm = calcHardMetal(param4, 0.05, 0.01, 0.05);
                double mHrom = calcHardMetal(param4, 0.48, 0.05, 0.48);
                double mMed = calcHardMetal(param4, 0.36, 0.3, 0.36);
                double mRtut = calcHardMetal(param4, 0.05, 0, 0.05);
                double mNikel = calcHardMetal(param4, 44.65, 0.5, 44.65);
                double mSvinets = calcHardMetal(param4, 1.26, 1, 1.26);
                double mZink = calcHardMetal(param4, 1.62, 0.1, 1.62);

                double dyOxy = calcDyOxyPhbGxbMt(0.01, param4, param7, 1000000);
                double PHB = calcDyOxyPhbGxbMt(0.005, param4, param7, 1000);
                double GHB = calcDyOxyPhbGxbMt(0.0005, param4, param7, 1000);

                double MtB = calcDyOxyPhbGxbMt(0.2, param4, param7, 1000000000);
                double MtK = calcDyOxyPhbGxbMt(0.1, param4, param7, 1000000000);
                double MtBenz = calcDyOxyPhbGxbMt(0.1, param4, param7, 1000000000);
                double MtPiren = calcDyOxyPhbGxbMt(0.2, param4, param7, 1000000000);


                double[] valueList = { mNO2, mNO, mCO, mSO2, mC, mBenzP,
                mMazut, mKadm, mHrom, mMed, mRtut, mNikel, mSvinets, mZink, dyOxy, PHB, GHB, MtB, MtK, MtBenz, MtPiren};

                double sum = 0;
                for (int i = 0; i < valueList.Length; i++)
                {
                    sum += valueList[i];
                }

                double[] resultValueList = { mNO2, mNO, mCO, mSO2, mC, mBenzP,
                mMazut, mKadm, mHrom, mMed, mRtut, mNikel, mSvinets, mZink, dyOxy, PHB, GHB, MtB, MtK, MtBenz, MtPiren, sum};


                string[] resultTextList = {
                    "Количество азота диоксида NO2 (т/год)",
                    "Количество азота оксидов NO (т/год)",
                    "Количество выбросов углерода оксида (т/год)",
                    "Количество выбросов деоксида серы (т/год)",
                    "Количество выбросов сажи (т/год)",
                    "Количество бенз(а)пирена (т/год)",
                    "Мышьяк (т/год)" ,
                    "Кадмий (т/год)",
                    "Хром (т/год)",
                    "Медь (т/год)",
                    "Ртуть (т/год)",
                    "Никель (т/год)",
                    "Свинец (т/год)",
                    "Цинк (т/год)",
                    "Валовый выброс диоксинов / фуранов Mt Ed (гЭТ/год)",
                    "Валовый выброс ПХБ (кг/год)",
                    "Валовый выброс ГХБ (кг/год)",
                    "Mt(b)флуорантен (т/год)",
                    "Mt(k)флуорантен (т/год)",
                    "MtБензо(а)пирен (кг/год)",
                    "Mt(1,2,3,с,d)пирен (т/год)",
                    "Всего"
                };
                initializeResultTable(resultTextList, resultValueList);


            }
            else
            {
                calcAll.BackColor = Color.RosyBrown;
                addInDB.BackColor = Color.RosyBrown;

                if (valueItem5.Text == "")
                {
                    valueItem5.BackColor = Color.RosyBrown;
                }
                if (valueItem4.Text == "")
                {
                    valueItem4.BackColor = Color.RosyBrown;
                }
                if (valueItem7.Text == "")
                {
                    valueItem7.BackColor = Color.RosyBrown;
                }
            }
        }

        private void Calc1_Click(object sender, EventArgs e)
        {
            if (valueItem4.Text != "")
            {
                Calc1.BackColor = Color.DarkSeaGreen;
                valueItem4.BackColor = Color.White;
                addInDB.BackColor = Color.DarkSeaGreen;

                double param1 = double.Parse(valueItem4.Text);
                double mNO2 = calcMNO2(param1);
                double mNO = calcMNO(mNO2);
                double[] resultValueList = { mNO2, mNO };
                string[] resultTextList = { "Количество азота диоксида NO2 (т/год)", "Количество азота оксидов NO (т/год)" };

                initializeResultTable(resultTextList, resultValueList);
            }
            else
            {
                Calc1.BackColor = Color.RosyBrown;
                addInDB.BackColor = Color.RosyBrown;

                if (valueItem4.Text == "")
                {
                    valueItem4.BackColor = Color.RosyBrown;
                }
            }
        }

        private void calc2_Click(object sender, EventArgs e)
        {
            if (valueItem4.Text != "")
            {
                calc2.BackColor = Color.DarkSeaGreen;
                addInDB.BackColor = Color.DarkSeaGreen;

                valueItem4.BackColor = Color.White;

                double param1 = double.Parse(valueItem4.Text);
                double mCO = calcMCO(param1);
                double[] resultValueList = { mCO };
                string[] resultTextList = { "Количество выбросов углерода оксида (т/год)" };

                initializeResultTable(resultTextList, resultValueList);
            }
            else
            {
                calc2.BackColor = Color.RosyBrown;
                addInDB.BackColor = Color.RosyBrown;

                if (valueItem4.Text == "")
                {
                    valueItem4.BackColor = Color.RosyBrown;
                }
            }
        }

        private void calc3_Click(object sender, EventArgs e)
        {
            if (valueItem4.Text != "" && valueItem5.Text != "")
            {
                calc3.BackColor = Color.DarkSeaGreen;
                addInDB.BackColor = Color.DarkSeaGreen;
                addInDB.Enabled = true;

                valueItem4.BackColor = Color.White;
                valueItem5.BackColor = Color.White;

                double param1 = double.Parse(valueItem4.Text);
                double param2 = double.Parse(valueItem5.Text);
                double mSO2 = calcMSO2(param1, param2);
                double[] resultValueList = { mSO2 };
                string[] resultTextList = { "Количество выбросов деоксида серы (т/год)" };

                initializeResultTable(resultTextList, resultValueList);
            }
            else
            {
                calc3.BackColor = Color.RosyBrown;
                addInDB.BackColor = Color.RosyBrown;

                if (valueItem5.Text == "")
                {
                    valueItem5.BackColor = Color.RosyBrown;
                }
                if (valueItem4.Text == "")
                {
                    valueItem4.BackColor = Color.RosyBrown;
                }
            }



        }

        private void calc4_Click(object sender, EventArgs e)
        {
            if (valueItem4.Text != "" && valueItem7.Text != "")
            {
                valueItem4.BackColor = Color.White;
                valueItem7.BackColor = Color.White;
                calc4.BackColor = Color.DarkSeaGreen;
                addInDB.BackColor = Color.DarkSeaGreen;


                double param1 = double.Parse(valueItem4.Text);
                double param2 = double.Parse(valueItem7.Text);
                double mC = calcMC(param1, param2);
                double[] resultValueList = { mC };
                string[] resultTextList = { "Количество выбросов сажи (т/год)" };

                initializeResultTable(resultTextList, resultValueList);
            }
            else
            {
                calc4.BackColor = Color.RosyBrown;
                addInDB.BackColor = Color.RosyBrown;

                if (valueItem4.Text == "")
                {
                    valueItem4.BackColor = Color.RosyBrown;
                }
                if (valueItem7.Text == "")
                {
                    valueItem7.BackColor = Color.RosyBrown;
                }
            }
        }

        private void calc5_Click(object sender, EventArgs e)
        {
            if (valueItem4.Text != "")
            {
                valueItem4.BackColor = Color.White;

                calc5.BackColor = Color.DarkSeaGreen;
                addInDB.BackColor = Color.DarkSeaGreen;


                double param1 = double.Parse(valueItem4.Text);
                double mBenzP = calcBenzP(param1);
                double[] resultValueList = { mBenzP };
                string[] resultTextList = { "Количество бенз(а)пирена (т/год)" };

                initializeResultTable(resultTextList, resultValueList);
            }
            else
            {
                calc5.BackColor = Color.RosyBrown;
                addInDB.BackColor = Color.RosyBrown;

                if (valueItem4.Text == "")
                {
                    valueItem4.BackColor = Color.RosyBrown;
                }
            }
        }

        private void calc6_Click(object sender, EventArgs e)
        {

            if (valueItem4.Text != "" && valueItem7.Text != "")
            {
                valueItem4.BackColor = Color.White;
                valueItem7.BackColor = Color.White;

                calc6.BackColor = Color.DarkSeaGreen;
                addInDB.BackColor = Color.DarkSeaGreen;


                double param1 = double.Parse(valueItem4.Text);
                double param2 = double.Parse(valueItem7.Text);

                double mMazut = calcHardMetal(param1, 0.02, 0, 0.02);
                double mKadm = calcHardMetal(param1, 0.05, 0.01, 0.05);
                double mHrom = calcHardMetal(param1, 0.48, 0.05, 0.48);
                double mMed = calcHardMetal(param1, 0.36, 0.3, 0.36);
                double mRtut = calcHardMetal(param1, 0.05, 0, 0.05);
                double mNikel = calcHardMetal(param1, 44.65, 0.5, 44.65);
                double mSvinets = calcHardMetal(param1, 1.26, 1, 1.26);
                double mZink = calcHardMetal(param1, 1.62, 0.1, 1.62);

                double dyOxy = calcDyOxyPhbGxbMt(0.01, param1, param2, 1000000);
                double PHB = calcDyOxyPhbGxbMt(0.005, param1, param2, 1000);
                double GHB = calcDyOxyPhbGxbMt(0.0005, param1, param2, 1000);

                double MtB = calcDyOxyPhbGxbMt(0.2, param1, param2, 1000000000);
                double MtK = calcDyOxyPhbGxbMt(0.1, param1, param2, 1000000000);
                double MtBenz = calcDyOxyPhbGxbMt(0.1, param1, param2, 1000000000);
                double MtPiren = calcDyOxyPhbGxbMt(0.2, param1, param2, 1000000000);


                double[] resultValueList = {
                    mMazut, mKadm, mHrom, mMed, mRtut, mNikel, mSvinets, mZink, dyOxy, PHB, GHB, MtB, MtK, MtBenz, MtPiren };
                string[] resultTextList = {
                    "Мышьяк (т/год)" ,
                    "Кадмий (т/год)",
                    "Хром (т/год)",
                    "Медь (т/год)",
                    "Ртуть (т/год)",
                    "Никель (т/год)",
                    "Свинец (т/год)",
                    "Цинк (т/год)",
                    "Валовый выброс диоксинов / фуранов Mt Ed (гЭТ/год)",
                    "Валовый выброс ПХБ (кг/год)",
                    "Валовый выброс ГХБ (кг/год)",
                    "Mt(b)флуорантен (т/год)",
                    "Mt(k)флуорантен (т/год)",
                    "MtБензо(а)пирен (кг/год)",
                    "Mt(1,2,3,с,d)пирен (т/год)"
                };

                initializeResultTable(resultTextList, resultValueList);
            }
            else
            {
                calc5.BackColor = Color.RosyBrown;
                addInDB.BackColor = Color.RosyBrown;

                if (valueItem4.Text == "")
                {
                    valueItem4.BackColor = Color.RosyBrown;
                }
                if (valueItem7.Text == "")
                {
                    valueItem7.BackColor = Color.RosyBrown;
                }
            }
        }


        private void initializeResultTable(string[] resultText, double[] resultValues)
        {
            resultTable.Controls.Clear();
            resultTable.RowStyles.Clear();

            resultTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            resultTable.RowCount = resultValues.Length + 1;

            for (int i = 0; i < resultValues.Length; i++)
            {

                Label resultLabelText = new Label();
                resultLabelText.Text = resultText[i];
                resultLabelText.Width = 1500;

                Label resultLabelValue = new Label();
                resultLabelValue.Text = Convert.ToString(resultValues[i]);

                resultTable.Controls.Add(resultLabelText, 0, i);
                resultTable.Controls.Add(resultLabelValue, 1, i);


            }

            resultTable.Visible = true;
        }


        private double calcDyOxyPhbGxbMt(double k, double Bp, double Q, double d)
        {
            return Math.Round((k * Bp * Q) / d, 7);
        }


        private double calcHardMetal(double Bp, double Mt, double PBT, double PJT)
        {
            return Math.Round((Bp * 0 + Mt * PBT + PJT * 0) / 1000000, 8);
        }

        private double calcMNO2(double Bp)
        {
            int CiNO = 250;
            return Math.Round(calcM(Bp, CiNO), 3, MidpointRounding.ToEven);
        }

        private double calcMNO(double mNO2)
        {
            double k1 = 0.8;
            double k2 = 0.13;
            return Math.Round(mNO2 / k1 * k2, 3, MidpointRounding.ToEven);
        }


        private double calcMCO(double Bp)
        {
            int CiCO = 150;
            return Math.Round(calcM(Bp, CiCO), 3, MidpointRounding.ToEven);
        }

        private double calcMSO2(double Bp, double Sr)
        {
            double k = 0.020;
            return Math.Round((k * Bp * Sr), 3, MidpointRounding.ToEven);
        }

        private double calcM(double Bp, double Ci)
        {
            double k = 0.00001532;
            return k * Bp * Ci;
        }

        private double calcMC(double Bp, double Q)
        {
            double k = Q / 32680;
            double k2 = 0.0002;
            return Math.Round((k * Bp * Q / 32680), 4, MidpointRounding.ToEven);
        }

        private double calcBenzP(double Bp)
        {
            double k = 0.0002;
            return Math.Round((k * Bp), 7, MidpointRounding.ToEven);
        }

        private void resultTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            this.Close();
            mainForm.ShowDialog();
        }

        private void addInDB_Click(object sender, EventArgs e)
        {

            addInDB.BackColor = Color.DarkGray;
            calcAll.BackColor = Color.RosyBrown;
        }
    }
}
