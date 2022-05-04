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
    public partial class KVGM100mazut : Form
    {
        public KVGM100mazut()
        {
            InitializeComponent();
        }

    

        private void calcAll_Click(object sender, EventArgs e)
        {
            if (valueItem1.Text != "" && valueItem2.Text != "" && valueItem3.Text != "" && valueItem4.Text != "" &&
                valueItem5.Text != "" && valueItem6.Text != "" && valueItem7.Text != "" && valueItem8.Text != "" &&
                valueItem9.Text != "" && valueItem10.Text != "" && valueItem11.Text != "" && valueItem12.Text != "")
            {
                valueItem1.BackColor = Color.White;
                valueItem2.BackColor = Color.White;
                valueItem3.BackColor = Color.White;
                valueItem4.BackColor = Color.White;
                valueItem5.BackColor = Color.White;
                valueItem6.BackColor = Color.White;
                valueItem7.BackColor = Color.White;
                valueItem8.BackColor = Color.White;
                valueItem9.BackColor = Color.White;
                valueItem10.BackColor = Color.White;
                valueItem11.BackColor = Color.White;
                valueItem12.BackColor = Color.White;

                calcAll.BackColor = Color.DarkSeaGreen;
                addInDB.BackColor = Color.DarkSeaGreen;

                double param1 = double.Parse(valueItem1.Text);
                double param2 = double.Parse(valueItem2.Text);
                double param3 = double.Parse(valueItem3.Text);
                double param4 = double.Parse(valueItem4.Text);
                double param5 = double.Parse(valueItem5.Text);
                double param6 = double.Parse(valueItem6.Text);
                double param7 = double.Parse(valueItem7.Text);
                double param8 = double.Parse(valueItem8.Text);
                double param9 = double.Parse(valueItem9.Text);
                double param10 = double.Parse(valueItem10.Text);
                double param11 = double.Parse(valueItem11.Text);
                double param12 = double.Parse(valueItem12.Text);


                double mNO2 = calcMNO2(param6);
                double mNO = calcMNO(mNO2);
                double mCO = calcMCO(param6);
                double mSO2 = calcMSO2(param6);
                double mC = calcMC(param4, param7);
                double mMZ = calcMZ(param6);
                double mBenzP = calcBenzP(param4);

                double mMazut = calcHardMetal(param6, 0.02, 0, 0.02);
                double mKadm = calcHardMetal(param6, 0.05, 0.01, 0.05);
                double mHrom = calcHardMetal(param6, 0.48, 0.05, 0.48);
                double mMed = calcHardMetal(param6, 0.36, 0.3, 0.36);
                double mRtut = calcHardMetal(param6, 0.05, 0, 0.05);
                double mNikel = calcHardMetal(param6, 44.65, 0.5, 44.65);
                double mSvinets = calcHardMetal(param6, 1.26, 1, 1.26);
                double mZink = calcHardMetal(param6, 1.62, 0.1, 1.62);

                double dyOxy = calcDyOxyPhbGxbMt(param6, param11, param12, param4, param5, 100000);
                double PHB = calcDyOxyPhbGxbMt(param6, param11, param12, param4, param5, 1000);
                double GHB = calcDyOxyPhbGxbMt(param6, param11, param12, param4, param5, 1000);

                double MtB = calcDyOxyPhbGxbMt(param6, param11, param12, param4, param5, 1000000000) * 0.2;
                double MtK = calcDyOxyPhbGxbMt(param6, param11, param12, param4, param5, 1000000000) * 0.1;
                double MtBenz = calcDyOxyPhbGxbMt(param6, param11, param12, param4, param5, 1000000000) * 0.1;
                double MtPiren = calcDyOxyPhbGxbMt(param6, param11, param12, param4, param5, 1000000000) * 0.2;


                double[] valueList = { mNO2, mNO, mCO, mSO2, mC,mMZ, mBenzP,
                mMazut, mKadm, mHrom, mMed, mRtut, mNikel, mSvinets, mZink, dyOxy, PHB, GHB, MtB, MtK, MtBenz, MtPiren};

                double sum = 0;
                for (int i = 0; i < valueList.Length; i++)
                {
                    sum += valueList[i];
                }

                double[] resultValueList = { mNO2, mNO, mCO, mSO2, mC, mMZ, mBenzP,
                    mMazut, mKadm, mHrom, mMed, mRtut, mNikel, mSvinets, mZink, dyOxy, PHB, GHB, MtB, MtK, MtBenz, MtPiren, sum };


                string[] resultTextList = {
                    "Количество азота диоксида NO2 (т/год)",
                    "Количество азота оксидов NO (т/год)",
                    "Количество выбросов углерода оксида (т/год)",
                    "Количество выбросов деоксида серы (т/год)",
                    "Количество выбросов сажи (т/год)",
                    "Количество мазутной золы (т/год)",
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
            } else
            {
                valueItem1.BackColor = Color.RosyBrown;
                valueItem2.BackColor = Color.RosyBrown;
                valueItem3.BackColor = Color.RosyBrown;
                valueItem4.BackColor = Color.RosyBrown;
                valueItem5.BackColor = Color.RosyBrown;
                valueItem6.BackColor = Color.RosyBrown;
                valueItem7.BackColor = Color.RosyBrown;
                valueItem8.BackColor = Color.RosyBrown;
                valueItem9.BackColor = Color.RosyBrown;
                valueItem10.BackColor = Color.RosyBrown;
                valueItem11.BackColor = Color.RosyBrown;
                valueItem12.BackColor = Color.RosyBrown;
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


        private double calcDyOxyPhbGxbMt(double Bp, double Qptb, double Qpjt, double PBT, double PJT, int d)
        {
            return Math.Round((0.005 * 40.61 *  Bp * Qptb) * (Qptb + Qpjt) * (PJT + PBT) / d, 6);
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
            return Math.Round(mNO2 * k1 , 3, MidpointRounding.ToEven);
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

        private void KVGM100_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            this.Close();
            mainForm.ShowDialog();
        }
    }
}
