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
    public partial class DE6514GMgas : Form
    {
        public DE6514GMgas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            this.Close();
            mainForm.ShowDialog();
        }

        private void DE6514GM_Load(object sender, EventArgs e)
        {

        }

        private void calcAll_Click(object sender, EventArgs e)
        {
            if (valueItem1.Text != "" && valueItem2.Text != "" && valueItem3.Text != "" && valueItem4.Text != "" &&
                valueItem5.Text != "" && valueItem6.Text != "")
            {
                valueItem1.BackColor = Color.White;
                valueItem2.BackColor = Color.White;
                valueItem3.BackColor = Color.White;
                valueItem4.BackColor = Color.White;
                valueItem5.BackColor = Color.White;
                valueItem6.BackColor = Color.White;

                calcAll.BackColor = Color.DarkSeaGreen;
                addInDB.BackColor = Color.DarkSeaGreen;

                double param1 = double.Parse(valueItem1.Text);
                double param2 = double.Parse(valueItem2.Text);
                double param3 = double.Parse(valueItem3.Text);
                double param4 = double.Parse(valueItem4.Text);
                double param5 = double.Parse(valueItem5.Text);
                double param6 = double.Parse(valueItem6.Text);

                double mNO2 = calcMNO2(param6);
                double mNO = calcMNO(mNO2);
                double mCO = calcMCO(param6);
                double mSO2 = calcMSO2(param6);
                double mC = calcMC(param4, param4);
                double mMZ = calcMZ(param6);
                double mBenzP = calcBenzP(param4);

                double mRtut = calcHardMetal(param4, 0.05, 0, 0.05);

                double dyOxy = calcDyOxyPhbGxbMt(param4, param5 * 4.187 / 1000, 0.001, 100000);

                double MtB = calcDyOxyPhbGxbMt(param4, param5 * 4.187 / 1000, 0.0008, 1000000000) * 0.2;
                double MtK = calcDyOxyPhbGxbMt(param4, param5 * 4.187 / 1000, 0.0008, 1000000000) * 0.1;
                double MtBenz = calcDyOxyPhbGxbMt(param4, param5 * 4.187 / 1000, 0.0008, 1000000000) * 0.1;
                double MtPiren = calcDyOxyPhbGxbMt(param4, param5 * 4.187 / 1000, 0.0008, 1000000000) * 0.2;


                double[] valueList = { mNO2, mNO, mCO, mSO2, mC,mMZ, mBenzP,
                 mRtut,  dyOxy,  MtB, MtK, MtBenz, MtPiren};

                double sum = 0;
                for (int i = 0; i < valueList.Length; i++)
                {
                    sum += valueList[i];
                }

                double[] resultValueList = { mNO2, mNO, mCO, mSO2, mC, mMZ, mBenzP,
                    mRtut, dyOxy, MtB, MtK, MtBenz, MtPiren, sum };


                string[] resultTextList = {
                    "Количество азота диоксида NO2 (т/год)",
                    "Количество азота оксидов NO (т/год)",
                    "Количество выбросов углерода оксида (т/год)",
                    "Количество выбросов деоксида серы (т/год)",
                    "Количество выбросов сажи (т/год)",
                    "Количество мазутной золы (т/год)",
                    "Количество бенз(а)пирена (т/год)",
                    "Ртуть (т/год)",
                    "Валовый выброс диоксинов / фуранов Mt Ed (гЭТ/год)",
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
                valueItem1.BackColor = Color.RosyBrown;
                valueItem2.BackColor = Color.RosyBrown;
                valueItem3.BackColor = Color.RosyBrown;
                valueItem4.BackColor = Color.RosyBrown;
                valueItem5.BackColor = Color.RosyBrown;
                valueItem6.BackColor = Color.RosyBrown;
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


        private double calcDyOxyPhbGxbMt(double Bp, double Qn, double k, int d)
        {
            return Math.Round(Bp * Qn * k/ d, 8);
        }


        private double calcHardMetal(double Bp, double Mt, double PBT, double PJT)
        {
            return Math.Round((Bp * 0 + Mt * PBT + PJT * 0) / 1000000, 8);
        }

        private double calcMNO2(double Bp)
        {
            int CiNO = 0;
            return Math.Round(calcM(Bp, CiNO), 3, MidpointRounding.ToEven);
        }

        private double calcMNO(double mNO2)
        {
            double k1 = 0.8;
            return Math.Round(mNO2 * k1, 3, MidpointRounding.ToEven);
        }


        private double calcMCO(double Bp)
        {
            double k = 0.002;
            return Math.Round(Bp * k, 3, MidpointRounding.ToEven);
        }

        private double calcMSO2(double Bp)
        {
            double k = 0.9998;
            return Math.Round((k * Bp * 0.045), 5, MidpointRounding.ToEven);
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
        private double calcMZ(double Bp)
        {
            double k = 0.06;
            return Math.Round((k * Bp * 0), 4, MidpointRounding.ToEven);
        }

        private void addInDB_Click(object sender, EventArgs e)
        {
            addInDB.BackColor = Color.DarkGray;
            calcAll.BackColor = Color.RosyBrown;
        }
    }
}
