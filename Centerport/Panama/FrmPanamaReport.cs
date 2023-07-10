﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MedicalManagementSoftware.Model;
using MedicalManagementSoftware.Panama;
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
        public Page1Model page1Model;
        public Page2Model page2Model;
        public Page3Model page3Model;
        public Page4Model page4Model;
        public Page5Model page5Model;



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
            //backgroundWorker1.RunWorkerAsync();

            pageIndex = 1;
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



                page1.SetParameterValue("Fullname", page1Model.Fullname);
                page1.SetParameterValue("HomeAddress", page1Model.HomeAddress);
                page1.SetParameterValue("Department", page1Model.Department);
                page1.SetParameterValue("position", page1Model.Position);
                page1.SetParameterValue("gender", page1Model.Gender);
                page1.SetParameterValue("PassportSeamanBookNo", page1Model.PassportSeamanBookNo);
                page1.SetParameterValue("RhTyping", page1Model.RhTyping);
                page1.SetParameterValue("LookOutDuties", page1Model.LookOutDuties);
                page1.SetParameterValue("EmergencyDuties", page1Model.EmergencyDuties);
                page1.SetParameterValue("TypeOfShip", page1Model.TypeOfShip);
                page1.SetParameterValue("TradeArea", page1Model.TradeArea);
                page1.SetParameterValue("Day", page1Model.Day);
                page1.SetParameterValue("Month", page1Model.Month);
                page1.SetParameterValue("Year", page1Model.Year);
                page1.SetParameterValue("HighBloodPressure", page1Model.HighBloodPressure);
                page1.SetParameterValue("Eyeproblem", page1Model.EyeProblem);
                page1.SetParameterValue("EarNoseThroat", page1Model.EarNoseThroat);
                page1.SetParameterValue("HeartSurgery", page1Model.HeartSurgery);
                page1.SetParameterValue("Varicoseveins", page1Model.VaricoseVeins);
                page1.SetParameterValue("AsthmaBronchitis", page1Model.AsthmaBronchitis);
                page1.SetParameterValue("BloodDisorder", page1Model.BloodDisorder);
                page1.SetParameterValue("Diabetes", page1Model.Diabetes);
                page1.SetParameterValue("ThyroidProblem", page1Model.ThyroidProblem);
                page1.SetParameterValue("DigestiveDisorders", page1Model.DigestiveDisorders);
                page1.SetParameterValue("KidneyDisorders", page1Model.KidneyDisorders);
                page1.SetParameterValue("SkinProblem", page1Model.SkinProblem);
                page1.SetParameterValue("Allergies", page1Model.Allergies);

                page1.SetParameterValue("DoyouSmoke", page1Model.DoyouSmoke);
                page1.SetParameterValue("Surgeries", page1Model.Surgeries);
                page1.SetParameterValue("Infectious", page1Model.Infectious);
                page1.SetParameterValue("DizzinessFainting", page1Model.DizzinessFainting);
                page1.SetParameterValue("Lossofconsciousness", page1Model.Lossofconsciousness);
                page1.SetParameterValue("PsychiatricProblem", page1Model.PsychiatricProblem);
                page1.SetParameterValue("Depression", page1Model.Depression);
                page1.SetParameterValue("Attemptedsuicide", page1Model.Attemptedsuicide);
                page1.SetParameterValue("Lossofmemory", page1Model.Lossofmemory);
                page1.SetParameterValue("BalanceProblems", page1Model.BalanceProblems);
                page1.SetParameterValue("SevereHeadAches", page1Model.SevereHeadAches);
                page1.SetParameterValue("Vasculardisease", page1Model.Vasculardisease);
                page1.SetParameterValue("RestrictedMobility", page1Model.RestrictedMobility);


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



                page2.SetParameterValue("Epilipsy", page2Model.Epilipsy);
                page2.SetParameterValue("SickleCell", page2Model.SickleCell);
                page2.SetParameterValue("Herinas", page2Model.Herinas);
                page2.SetParameterValue("GenitalDisorders", page2Model.GenitalDisorders);
                page2.SetParameterValue("Sleepproblem", page2Model.Sleepproblem);
                page2.SetParameterValue("BackJointProblem", page2Model.BackJointProblem);
                page2.SetParameterValue("Amputation", page2Model.Amputation);
                page2.SetParameterValue("FracturesDislocation", page2Model.FracturesDislocation);
                page2.SetParameterValue("Covid19", page2Model.Covid19);



                page2.SetParameterValue("Repatriated", page2Model.Repatriated);
                page2.SetParameterValue("Hospitalized", page2Model.Hospitalized);
                page2.SetParameterValue("SeaDuty", page2Model.SeaDuty);
                page2.SetParameterValue("Revoke", page2Model.Revoke);
                page2.SetParameterValue("ConsiderDisease", page2Model.ConsiderDisease);
                page2.SetParameterValue("FitToPerformDuries", page2Model.FitToPerformDuries);
                page2.SetParameterValue("AllergicToAnyMedication", page2Model.AllergicToAnyMedication);
                page2.SetParameterValue("AlternativeSupliment", page2Model.AlternativeSupliment);

                page2.SetParameterValue("Comment1", page2Model.Comment1);
                page2.SetParameterValue("Comment2", page2Model.Comment2);
                page2.SetParameterValue("Comment3", page2Model.Comment3);
                page2.SetParameterValue("Comment4", page2Model.Comment4);
                page2.SetParameterValue("Comment5", page2Model.Comment5);
                page2.SetParameterValue("Pregnancy", page2Model.Pregnancy);
                page2.SetParameterValue("AlternativeSuplimentComment1", page2Model.AlternativeSuplimentComment1);
                page2.SetParameterValue("AlternativeSuplimentComment2", page2Model.AlternativeSuplimentComment2);
                page2.SetParameterValue("AlternativeSuplimentComment3", page2Model.AlternativeSuplimentComment3);
                page2.SetParameterValue("AlternativeSuplimentComment4", page2Model.AlternativeSuplimentComment4);
                page2.SetParameterValue("AlternativeSuplimentComment5", page2Model.AlternativeSuplimentComment5);



                //page2.SetDataSource(data);
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


                page3.SetParameterValue("TakenMedications", page3Model.TakenMedications);
                page3.SetParameterValue("TakenMedicationsComment1", page3Model.TakenMedicationsComment1);
                page3.SetParameterValue("TakenMedicationsComment2", page3Model.TakenMedicationsComment2);
                page3.SetParameterValue("TakenMedicationsComment3", page3Model.TakenMedicationsComment3);
                page3.SetParameterValue("TakenMedicationsComment4", page3Model.TakenMedicationsComment4);
                page3.SetParameterValue("TakenMedicationsComment5", page3Model.TakenMedicationsComment5);
                page3.SetParameterValue("ContactInCovidPositive", page3Model.ContactInCovidPositive);
                page3.SetParameterValue("CovidTest", page3Model.CovidTest);
                page3.SetParameterValue("CovidDateTest", page3Model.CovidDateTest);
                page3.SetParameterValue("HadFeverLast30Days", page3Model.HadFeverLast30Days);
                page3.SetParameterValue("VaccinationCovid", page3Model.VaccinationCovid);
                page3.SetParameterValue("VaccineType", page3Model.VaccineType);
                page3.SetParameterValue("NumberofDoses", page3Model.NumberofDoses);
                page3.SetParameterValue("Booster", page3Model.Booster);
                page3.SetParameterValue("Day", page3Model.Day);
                page3.SetParameterValue("Month", page3Model.Month);
                page3.SetParameterValue("Year", page3Model.Year);
                page3.SetParameterValue("NameOfUndergoingExamination", page3Model.NameOfUndergoingExamination);




                //page3.SetDataSource(data);
                Viewer1.ReportSource = page3;


            }
            else if (pageIndex == 4)
            {
                PanamaPage4 page4 = new PanamaPage4();
                Viewer1.ReportSource = page4;
                btn_page1.BackColor = SystemColors.Control;
                btn_page2.BackColor = SystemColors.Control;
                btn_page3.BackColor = SystemColors.Control;
                btn_page4.BackColor = SystemColors.ActiveCaption;
                btn_page5.BackColor = SystemColors.Control;
                btn_page6.BackColor = SystemColors.Control;
                btn_page7.BackColor = SystemColors.Control;
                btn_page8.BackColor = SystemColors.Control;


                page4.SetParameterValue("NameOfWitness", page4Model.NameOfWitness);             
                page4.SetParameterValue("UndergoingExamination", page4Model.UndergoingExamination);
                page4.SetParameterValue("UndergoingDate", page4Model.UndergoingDate);
                page4.SetParameterValue("NameOfWitness2", page4Model.NameOfWitness2);
                page4.SetParameterValue("PreviousMedical", page4Model.PreviousMedical);
                page4.SetParameterValue("Height", page4Model.Height);
                page4.SetParameterValue("HeartRate", page4Model.HeartRate);
                page4.SetParameterValue("BloodPressure", page4Model.BloodPressure);
                page4.SetParameterValue("Weight", page4Model.Weight);
                page4.SetParameterValue("BMI", page4Model.BMI);
                page4.SetParameterValue("Oxygen", page4Model.Oxygen);
                page4.SetParameterValue("Respiratory", page4Model.Respiratory);
                page4.SetParameterValue("Diastolic", page4Model.Diastolic);
                page4.SetParameterValue("UnaidedRightEyeDistant", page4Model.UnaidedRightEyeDistant);
                page4.SetParameterValue("UnaidedRightEyeShort", page4Model.UnaidedRightEyeShort);
                page4.SetParameterValue("UnAidedLeftEyeDistant", page4Model.UnAidedLeftEyeDistant);
                page4.SetParameterValue("UnAidedLeftEyeShort", page4Model.UnAidedLeftEyeShort);
                page4.SetParameterValue("UnAidedBonocularDistant", page4Model.UnAidedBonocularDistant);
                page4.SetParameterValue("UnAidedBonocularShort", page4Model.UnAidedBonocularShort);
                page4.SetParameterValue("AidedRightEyeDistant", page4Model.AidedRightEyeDistant);
                page4.SetParameterValue("AidedRightEyeShort", page4Model.AidedRightEyeShort);
                page4.SetParameterValue("AidedLeftEyeDistant", page4Model.AidedLeftEyeDistant);
                page4.SetParameterValue("AidedLeftEyeShort", page4Model.AidedLeftEyeShort);
                page4.SetParameterValue("AidedBinocularDistant", page4Model.AidedBinocularDistant);
                page4.SetParameterValue("AidedBinocularShort", page4Model.AidedBinocularShort);
                page4.SetParameterValue("NormalRightEye", page4Model.NormalRightEye);
                page4.SetParameterValue("DefectiveRightEye", page4Model.DefectiveRightEye);
                page4.SetParameterValue("NormalLeftEye", page4Model.NormalLeftEye);
                page4.SetParameterValue("DefectiveLeftEye", page4Model.DefectiveLeftEye);
                page4.SetParameterValue("ColorVision", page4Model.ColorVision);
                page4.SetParameterValue("Ishihara", page4Model.Ishihara.ToUpper());



                //page.SetDataSource(data);
                Viewer1.ReportSource = page4;




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

                page5.SetParameterValue("_500HzRightEar", page5Model._500HzRightEar);
                page5.SetParameterValue("_500HzLeftEar", page5Model._500HzLeftEar);
                page5.SetParameterValue("_1kRightEar", page5Model._1kRightEar);
                page5.SetParameterValue("_1kLeftEar", page5Model._1kLeftEar);
                page5.SetParameterValue("_2kRightEar", page5Model._2kRightEar);
                page5.SetParameterValue("_2kLeftEar", page5Model._2kLeftEar);
                page5.SetParameterValue("_3kRightEar", page5Model._3kRightEar);
                page5.SetParameterValue("_3kLeftEar", page5Model._3kLeftEar);
                page5.SetParameterValue("HeadYes", page5Model.HeadYes);
                page5.SetParameterValue("MouthYes", page5Model.MouthYes);
                page5.SetParameterValue("Dental", page5Model.Dental);
                page5.SetParameterValue("Ears", page5Model.Ears);
                page5.SetParameterValue("Tympanic", page5Model.Tympanic);
                page5.SetParameterValue("Eyes", page5Model.Eyes);
                page5.SetParameterValue("Pupils", page5Model.Pupils);
                page5.SetParameterValue("OfThalmoscopy", page5Model.OfThalmoscopy);
                page5.SetParameterValue("EyeMovement", page5Model.EyeMovement);
                page5.SetParameterValue("Lungs", page5Model.Lungs);
                page5.SetParameterValue("Breast", page5Model.Breast);
                page5.SetParameterValue("Heart", page5Model.Heart);
                page5.SetParameterValue("Skin", page5Model.Skin);
                page5.SetParameterValue("VaricoseVenis", page5Model.VaricoseVenis);
                page5.SetParameterValue("Vascular", page5Model.Vascular);
                page5.SetParameterValue("Abnomen", page5Model.Abnomen);
                page5.SetParameterValue("Hernias", page5Model.Hernias);
                page5.SetParameterValue("Anus", page5Model.Anus);
                page5.SetParameterValue("Gu", page5Model.Gu);
                page5.SetParameterValue("Upper", page5Model.Upper);
                page5.SetParameterValue("Spine", page5Model.Spine);
                page5.SetParameterValue("Neurologic", page5Model.Neurologic);
                page5.SetParameterValue("Psychiatric", page5Model.Psychiatric);
                page5.SetParameterValue("GeneralAppearance", page5Model.GeneralAppearance);
                page5.SetParameterValue("PhysicalExploration1", page5Model.PhysicalExploration1);
                page5.SetParameterValue("PhysicalExploration2", page5Model.PhysicalExploration2);
                page5.SetParameterValue("PhysicalExploration3", page5Model.PhysicalExploration3);
                page5.SetParameterValue("PhysicalExploration4", page5Model.PhysicalExploration4);
                page5.SetParameterValue("Hemogram", page5Model.Hemogram);
                page5.SetParameterValue("HemogramNormal", page5Model.HemogramNormal);
                page5.SetParameterValue("HemogramAbNormal", page5Model.HemogramAbNormal);
                page5.SetParameterValue("HemogramOservation", page5Model.HemogramOservation);



                //page5.SetDataSource(data);
                Viewer1.ReportSource = page5;



            }
            else if (pageIndex == 6)
            {
                //PanamaPage6 page6 = new PanamaPage6();
                //Viewer1.ReportSource = page6;

                //btn_page1.BackColor = SystemColors.Control;
                //btn_page2.BackColor = SystemColors.Control;
                //btn_page3.BackColor = SystemColors.Control;
                //btn_page4.BackColor = SystemColors.Control;
                //btn_page5.BackColor = SystemColors.Control;
                //btn_page6.BackColor = SystemColors.ActiveCaption;
                //btn_page7.BackColor = SystemColors.Control;
                //btn_page8.BackColor = SystemColors.Control;

                //page6.SetDataSource(data);


                //Viewer1.ReportSource = page6;



            }
            else if (pageIndex == 7)
            {
                //PanamaPage7 page = new PanamaPage7();
                //Viewer1.ReportSource = page;

                //btn_page1.BackColor = SystemColors.Control;
                //btn_page2.BackColor = SystemColors.Control;
                //btn_page3.BackColor = SystemColors.Control;
                //btn_page4.BackColor = SystemColors.Control;
                //btn_page5.BackColor = SystemColors.Control;
                //btn_page6.BackColor = SystemColors.Control;
                //btn_page7.BackColor = SystemColors.ActiveCaption;
                //btn_page8.BackColor = SystemColors.Control;

                //page.SetDataSource(data);


                //Viewer1.ReportSource = page;



            }
            else if (pageIndex == 8)
            {
                //PanamaPage8 page = new PanamaPage8();
                //Viewer1.ReportSource = page;

                //btn_page1.BackColor = SystemColors.Control;
                //btn_page2.BackColor = SystemColors.Control;
                //btn_page3.BackColor = SystemColors.Control;
                //btn_page4.BackColor = SystemColors.Control;
                //btn_page5.BackColor = SystemColors.Control;
                //btn_page6.BackColor = SystemColors.Control;
                //btn_page7.BackColor = SystemColors.Control;
                //btn_page8.BackColor = SystemColors.ActiveCaption;

                //page.SetDataSource(data);


                //TextObject txtexpirationDay = (TextObject)page.ReportDefinition.ReportObjects["txtexpirationDay"];
                //TextObject txtexpirationMonth = (TextObject)page.ReportDefinition.ReportObjects["txtexpirationMonth"];
                //TextObject txtexpirationYear = (TextObject)page.ReportDefinition.ReportObjects["txtexpirationYear"];
                //txtexpirationDay.Text = "Day: " + expirationDay;
                //txtexpirationMonth.Text = "Month: " + expirationMonth;
                //txtexpirationYear.Text = "Year: " + expirationYear;

                //TextObject txtissuedDay = (TextObject)page.ReportDefinition.ReportObjects["txtissuedDay"];
                //TextObject txtissuedMonth = (TextObject)page.ReportDefinition.ReportObjects["txtissuedMonth"];
                //TextObject txtissuedYear = (TextObject)page.ReportDefinition.ReportObjects["txtissuedYear"];
                //txtissuedDay.Text = "Day: " + issuedDay;
                //txtissuedMonth.Text = "Month: " + issuedMonth;
                //txtissuedYear.Text = "Year: " + issuedYear;

                //TextObject txtPhysicianName = (TextObject)page.ReportDefinition.ReportObjects["txtPhysicianName"];
                //txtPhysicianName.Text = physicianName;
                //Viewer1.ReportSource = page;



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
