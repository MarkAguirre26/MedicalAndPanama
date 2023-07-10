using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MedicalManagementSoftware.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManagementSoftware.Report
{
    public partial class FrmPanamaReport : Form
    {

        DataTable data;
        int pageIndex = 1;
        public string physicianName, NameOfWitness1;
        string Bdate, BMonth, BYear, expirationDay, expirationMonth, expirationYear, issuedDay, issuedMonth, issuedYear;


        public FrmPanamaReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPanamaReport_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();


            PageSelection();
        }


        private void btn_page1_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            PageSelection();
        }



        private void btn_page2_Click(object sender, EventArgs e)
        {
            pageIndex = 2;
            PageSelection();

        }



        private void btn_page3_Click(object sender, EventArgs e)
        {

            pageIndex = 3;
            PageSelection();
        }



        private void btn_page4_Click(object sender, EventArgs e)
        {

            pageIndex = 4;
            PageSelection();

        }





        private void btn_page5_Click(object sender, EventArgs e)
        {
            pageIndex = 5;
            PageSelection();


        }


        private void btn_page6_Click(object sender, EventArgs e)
        {

            pageIndex = 6;
            PageSelection();

        }

        //DataTable getData()
        //{
        //            DataClasses1DataContext db = new DataClasses1DataContext(RJCodeUI_M1.Server.Database.connectionString);
        //            var l = db.PANAMA_SELECT(this.Tag.ToString()).ToList();

        //            DataTable dt = new DataSet1.PANAMA_SELECTDataTable();
        //            foreach (var i in l)
        //            {
        //                DateTime d = DateTime.Parse(i.birthdate);

        //                Bdate = d.Day.ToString();
        //                BMonth = Convert.ToDateTime(i.birthdate).ToString("MMM");
        //                BYear = d.Year.ToString();

        //                if (i.valid_until == null || i.valid_until.Equals("00-00-0000"))
        //                {

        //                    expirationDay = "N/A";
        //                    expirationMonth = "N/A";
        //                    expirationYear = "N/A";
        //                }
        //                else
        //                {





        //                    string[] ddd = i.valid_until.Split('/');
        //                    expirationDay = ddd[0];
        //                    expirationMonth = Convert.ToDateTime(i.valid_until).ToString("MMM");
        //                    expirationYear = ddd[2];
        //                }





        //                if (i.fitness_date == null || i.fitness_date.Equals("00-00-0000"))
        //                {

        //                    issuedDay = "N/A";
        //                    issuedMonth = "N/A";
        //                    issuedYear = "N/A";
        //                }
        //                else
        //                {


        //                    string[] ddd = i.fitness_date.Split('/');
        //                    issuedDay = ddd[0];
        //                    issuedMonth = Convert.ToDateTime(i.fitness_date).ToString("MMM");
        //                    issuedYear = ddd[2];


        //                }



        //                dt.Rows.Add(i.papin,
        //    i.Fullname,
        //    i.HomeAddress,
        //    i.Department,
        //    i.position,
        //    i.gender,
        //    i.birthdate,
        //    i.PassportSeamanBookNo,
        //    null,
        //    i.RhTypingProfile,
        //    i.LookOutDuties,
        //    i.EmergencyDuties,
        //    i.TypeOfShip,
        //    i.TradeArea,
        //    i.Papin1,
        //    i.FitForLookOut,
        //    i.NonFitForLookOut,
        //    i.DeckServiceFit,
        //    i.EngineFit,
        //    i.CateringFit,
        //    i.OtherServiceFit,
        //    i.DeckServiceUnFit,
        //    i.EngineUnFit,
        //    i.CateringUnFit,
        //    i.OtherUnFit,
        //    i.WithOutRestrictions,
        //    i.cbVisualAidRequiredYes,
        //    i.cbVisualAidRequiredNo,
        //    i.assessmentComment1,
        //i.assessmentComment2,
        //i.assessmentComment3,
        //i.assessmentComment4,
        //i.assessmentComment5,
        //    i.MedicalCertificateExpiration,
        //    i.MedicalCertificateIssued,
        //    i.NumberOfMedicalCertificate,
        //    i.PhysicianName,
        //    i.WithRestrictions,
        //    i.UID,
        //    i.HighBloodPressure,
        //i.Eyeproblem,
        //i.EarNoseThroat,
        //i.HeartSurgery,
        //i.Varicoseveins,
        //i.AsthmaBronchitis,
        //i.BloodDisorder,
        //i.Diabetes,
        //i.ThyroidProblem,
        //i.DigestiveDisorders,
        //i.KidneyDisorders,
        //i.SkinProblem,
        //i.Allergies,
        //i.Epilipsy,
        //i.SickleCell,
        //i.Herinas,
        //i.GenitalDisorders,
        //i.Pregnancy,
        //i.Sleepproblem,
        //i.DoyouSmoke,
        //i.Surgeries,
        //i.Infectious,
        //i.DizzinessFainting,
        //i.Lossofconsciousness,
        //i.PsychiatricProblem,
        //i.Depression,
        //i.Attemptedsuicide,
        //i.Lossofmemory,
        //i.BalanceProblems,
        //i.SevereHeadAches,
        //i.Vasculardisease,
        //i.RestrictedMobility,
        //i.BackJointProblem,
        //i.Amputation,
        //i.FracturesDislocation,
        //i.Covid19,
        //i.Repatriated,
        //i.Hospitalized,
        //i.SeaDuty,
        //i.Revoke,
        //i.ConsiderDisease,
        //i.FitToPerformDuries,
        //i.AllergicToAnyMedication,
        //i.AlternativeSupliment,
        //i.AlternativeSuplimentComment1,
        //i.TakenMedications,
        //i.TakenMedicationsComment1,
        //i.Comment1,
        //i.ResultMainUID,
        //i.Comment2,
        //i.Comment3,
        //i.Comment4,
        //i.Comment5,
        //i.AlternativeSuplimentComment2,
        //i.AlternativeSuplimentComment3,
        //i.AlternativeSuplimentComment4,
        //i.AlternativeSuplimentComment5,
        //i.TakenMedicationsComment2,
        //i.TakenMedicationsComment3,
        //i.TakenMedicationsComment4,
        //i.TakenMedicationsComment5,
        //i.AlternativeSuplimentComment6,
        //    i.PersonundergoingExamination,
        //    i.UndergoingExaminationDate,
        //    i.NameOfWitness,
        //    i.DoctorName,
        //    i.UndergoingExamination,
        //    i.UndergoingExaminationDate2,
        //    i.NameOfWitness2,
        //    i.PreviousMedical,
        //    i.UnaidedRightEyeDistant,
        //    i.UnAidedLeftEyeDistant,
        //    i.UnAidedBonocularDistant,
        //    i.AidedRightEyeDistant,
        //    i.AidedLeftEyeDistant,
        //    i.AidedBinocularDistant,
        //    i.UnaidedRightEyeShort,
        //    i.UnAidedLeftEyeShort,
        //    i.UnAidedBonocularShort,
        //    i.AidedRightEyeShort,
        //    i.AidedLeftEyeShort,
        //    i.AidedBinocularShort,
        //    i.NonTestedColorVision,
        //    i.NormalColorVision,
        //    i.DoubtfulColorVision,
        //    i.DefectiveColorVision,
        //    i.NormalRightEye,
        //    i.NormalLeftEye,
        //    i.DefectiveRightEye,
        //    i.DefectiveLeftEye,
        //    i.SightsComment,
        //    i._500HzRightEar,
        //    i._1kRightEar,
        //    i._2kRightEar,
        //    i._3kRightEar,
        //    i._500HzLeftEar,
        //    i._1kLeftEar,
        //    i._2kLeftEar,
        //    i._3kLeftEar,
        //    i.Hemogram,
        //    i.HemogramNormal,
        //    i.HemogramAbNormal,
        //    i.HemogramOservation,
        //    i.Lipid,
        //    i.LipidNormal,
        //    i.LipidAbNormal,
        //    i.LipidObservation,
        //    i.Creatinine,
        //    i.CreatinineNormal,
        //    i.CreatinineAbnormal,
        //    i.CreatinineObservation,
        //    i.Cholesterol,
        //    i.CholesterolNormal,
        //    i.CholesterolAbnormal,
        //    i.CholesterolObservation,
        //    i.Triglycerides,
        //    i.TriglyceridesNormal,
        //    i.TriglyceridesAbnormal,
        //    i.TriglyceridesObservation,
        //    i.Glucose,
        //    i.GlucoseNormal,
        //    i.GlucoseAbNormal,
        //    i.GlucoseObservation,
        //    i.Nitrogen,
        //    i.NitrogenNormal,
        //    i.NitrogenAbnormal,
        //    i.NitrogenObservation,
        //    i.RhTyping,
        //    i.RhTypingNormal,
        //    i.RhTypingAbnormal,
        //    i.RhTypingObservation,
        //    i.Hiv,
        //    i.HivNormal,
        //    i.HivAbnormal,
        //    i.HivObservation,
        //    i.Vdrl,
        //    i.VdrlNormal,
        //    i.VdrlAbnormal,
        //    i.VdrlObservation,
        //    i.Gch,
        //    i.GchNormal,
        //    i.GchAbnormal,
        //    i.GchObservation,
        //    i.GeneralUrien,
        //    i.GeneralUrineNormal,
        //    i.GeneralUrineAbNormal,
        //    i.GeneralUrineObservation,
        //    i.Stool,
        //    i.StoolNormal,
        //    i.StoolAbNormal,
        //    i.StoolObservation,
        //    i.Drugtest,
        //    i.DrugTestNormal,
        //    i.DrugTestAbNormal,
        //    i.DrugTestObservation,
        //    i.Alcohol,
        //    i.AlcoholNormal,
        //    i.AlcoholAbNormal,
        //    i.AlcoholObservation,
        //    i.Breast,
        //    i.BreastExaminationNormal,
        //    i.BreastExaminationAbNormal,
        //    i.BreastExaminationObservation,
        //    i.PapTest,
        //    i.PaptestJNormal,
        //    i.PapAbnormal,
        //    i.PapObservation,
        //    i.Psa,
        //    i.PsaNormal,
        //    i.PsaAbNormal,
        //    i.PsaObservation,
        //    i.Xray,
        //    i.XrayDate,
        //    i.XrayObservation,
        //    i.Ekg,
        //    i.EkgDate,
        //    i.EkgObservation,
        //    i.SarsCovidByPcr,
        //    i.SarsCovidByAntigens,
        //    i.OtherTest,
        //    i.OtherTestResult,
        //    i.DiagnosticComment1,
        //    i.DiagnosticComment2,
        //    i.DiagnosticComment3,
        //    i.DiagnosticComment4,
        //    i.Head,
        //    i.Mouth,
        //    i.Dental,
        //    i.Ears,
        //    i.Tympanic,
        //    i.Eyes,
        //    i.Pupils,
        //    i.OfThalmoscopy,
        //    i.EyeMovement,
        //    i.Lungs,
        //    i.Breast,
        //    i.Heart,
        //    i.Skin,
        //    i.VaricoseVenis,
        //    i.Vascular,
        //    i.Abdomen,
        //    i.Hernias,
        //    i.Anus,
        //    i.Gu,
        //    i.Upper,
        //    i.Spine,
        //    i.Neurologic,
        //    i.Psychiatric,
        //    i.GeneralAppearance,
        //    i.PhysicalExplorationComment1,
        //    i.PhysicalExplorationComment2,
        //    i.PhysicalExplorationComment3,
        //    i.PhysicalExplorationComment4,
        //    i.ContactInCovidPositive,
        //    i.CovidTest,
        //    i.CovidDateTest,
        //    i.HadFeverLast30Days,
        //    i.VaccinationCovid,
        //    i.VaccineType,
        //    i.NumberofDoses,
        //    i.Booster,
        //    i.Height,
        //    i.Weight,
        //    i.BMI,
        //    i.BloodPressure,
        //    i.HeartRate,
        //    i.Respiratory,
        //    i.Diatolic,
        //    i.Oxygen,
        //    i.recommendation,
        //    i.engine_srvc_flag,
        //    i.deck_srvc_flag,
        //    i.catering_srvc_flag,
        //    i.other_srvc_flag,
        //    i.fitness_date,
        //    i.valid_until,
        //    i.specimen_no,
        //    i.countvalidator);
        //            }


        //            return dt;
        //        }

        //        void RemoveTab(CrystalReportViewer rpt)
        //        {

        //            foreach (Control control in rpt.Controls)
        //            {
        //                if (control is PageView)
        //                {
        //                    TabControl tab = (TabControl)((PageView)control).Controls[0];
        //                    tab.ItemSize = new Size(0, 1);
        //                    tab.SizeMode = TabSizeMode.Fixed;
        //                    tab.Appearance = TabAppearance.Buttons;
        //                }
        //            }




        //}


        private void PageSelection()
        {
            if (pageIndex == 1)
            {

                PanamaPage1 page1 = new PanamaPage1();


                Viewer1.ReportSource = page1;

                btn_page1.BackColor = SystemColors.ActiveCaption;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.Control;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.Control;



                page1.SetDataSource(data);

                TextObject txtBDay = (TextObject)page1.ReportDefinition.ReportObjects["txtBDay"];
                TextObject txtBMonth = (TextObject)page1.ReportDefinition.ReportObjects["txtBMonth"];
                TextObject txtBYear = (TextObject)page1.ReportDefinition.ReportObjects["txtBYear"];
                txtBDay.Text = Bdate;
                txtBMonth.Text = BMonth;
                txtBYear.Text = BYear;



                Viewer1.ReportSource = page1;



            }
            else if (pageIndex == 2)
            {

                PanamaPage2 page2 = new PanamaPage2();
                Viewer1.ReportSource = page2;
                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.ActiveCaption;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.Control;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.Control;

                page2.SetDataSource(data);
                Viewer1.ReportSource = page2;


            }
            else if (pageIndex == 3)
            {

                PanamaPage3 page3 = new PanamaPage3();
                Viewer1.ReportSource = page3;
                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.ActiveCaption;
                btn_page4.BackColor = SystemColors.Control;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.Control;

                page3.SetDataSource(data);
                Viewer1.ReportSource = page3;


            }
            else if (pageIndex == 4)
            {
                PanamaPage4 page = new PanamaPage4();
                Viewer1.ReportSource = page;
                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.ActiveCaption;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.Control;

                TextObject txtNameOfWitness1 = (TextObject)page.ReportDefinition.ReportObjects["txtNameOfWitness1"];
                TextObject txtNameOfWitness21 = (TextObject)page.ReportDefinition.ReportObjects["txtNameOfWitness2"];

                txtNameOfWitness1.Text = NameOfWitness1;
                txtNameOfWitness21.Text = NameOfWitness1;




                page.SetDataSource(data);
                Viewer1.ReportSource = page;




            }
            else if (pageIndex == 5)
            {
                PanamaPage5 page5 = new PanamaPage5();
                Viewer1.ReportSource = page5;
                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.Control;
                btn_page5.BackColor = SystemColors.ActiveCaption;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.Control;

                page5.SetDataSource(data);
                Viewer1.ReportSource = page5;



            }
            else if (pageIndex == 6)
            {
                PanamaPage6 page6 = new PanamaPage6();
                Viewer1.ReportSource = page6;

                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.Control;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.ActiveCaption;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.Control;

                page6.SetDataSource(data);


                Viewer1.ReportSource = page6;



            }
            else if (pageIndex == 7)
            {
                PanamaPage7 page = new PanamaPage7();
                Viewer1.ReportSource = page;

                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.Control;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.ActiveCaption;
                btn_page8.BackColor = SystemColors.Control;

                page.SetDataSource(data);


                Viewer1.ReportSource = page;



            }
            else if (pageIndex == 8)
            {
                PanamaPage8 page = new PanamaPage8();
                Viewer1.ReportSource = page;

                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.Control;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.ActiveCaption;

                page.SetDataSource(data);


                TextObject txtexpirationDay = (TextObject)page.ReportDefinition.ReportObjects["txtexpirationDay"];
                TextObject txtexpirationMonth = (TextObject)page.ReportDefinition.ReportObjects["txtexpirationMonth"];
                TextObject txtexpirationYear = (TextObject)page.ReportDefinition.ReportObjects["txtexpirationYear"];
                txtexpirationDay.Text = "Day: " + expirationDay;
                txtexpirationMonth.Text = "Month: " + expirationMonth;
                txtexpirationYear.Text = "Year: " + expirationYear;

                TextObject txtissuedDay = (TextObject)page.ReportDefinition.ReportObjects["txtissuedDay"];
                TextObject txtissuedMonth = (TextObject)page.ReportDefinition.ReportObjects["txtissuedMonth"];
                TextObject txtissuedYear = (TextObject)page.ReportDefinition.ReportObjects["txtissuedYear"];
                txtissuedDay.Text = "Day: " + issuedDay;
                txtissuedMonth.Text = "Month: " + issuedMonth;
                txtissuedYear.Text = "Year: " + issuedYear;

                TextObject txtPhysicianName = (TextObject)page.ReportDefinition.ReportObjects["txtPhysicianName"];
                txtPhysicianName.Text = physicianName;
                Viewer1.ReportSource = page;



            }

            RemoveTab(Viewer1);
        }


        void RemoveTab(CrystalReportViewer rpt)
        {

            foreach (Control control in rpt.Controls)
            {
                if (control is PageView)
                {
                    TabControl tab = (TabControl)((PageView)control).Controls[0];
                    tab.ItemSize = new Size(0, 1);
                    tab.SizeMode = TabSizeMode.Fixed;
                    tab.Appearance = TabAppearance.Buttons;
                }
            }




        }

        private void FormPrintReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (pageIndex == 1)
                {
                    pageIndex = 8;

                }
                else
                {
                    pageIndex -= 1;
                }

                PageSelection();
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (pageIndex == 8)
                {
                    pageIndex = 1;

                }
                else
                {
                    pageIndex += 1;
                }
                PageSelection();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                Viewer1.PrintReport();
            }


        }

        private void btn7_Click(object sender, EventArgs e)
        {
            pageIndex = 7;
            PageSelection();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            pageIndex = 8;
            PageSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Viewer1.PrintReport();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //data = getData();
        }
    }
}
