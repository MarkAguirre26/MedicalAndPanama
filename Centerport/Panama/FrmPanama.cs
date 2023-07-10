﻿using MedicalManagementSoftware.Class;
using MedicalManagementSoftware.Model;
using MedicalManagementSoftware.Panama;
using MedicalManagementSoftware.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManagementSoftware
{
    public partial class FrmPanama : Form, MyInter
    {
        Main fmain;
        //public static TextBox pin;
        //public static string cn_SeabaseResultMain;
        public DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public List<Panama_SeaMLC> Panama_SeaMLC_model = new List<Panama_SeaMLC>();

        private string fitnessdate;
        public FrmPanama(Main main)
        {
            InitializeComponent();
            //HideAllTabsOnTabControl(tabControl1);
            fmain = main;

            //pin = txtPapin;
        }

        public void New()
        {

            //fmain.tsPanamaNew.Enabled = false;
            fmain.tsPanamaEdit.Enabled = false;
            fmain.tsPanamaDelete.Enabled = false;
            fmain.tsPanamaSave.Enabled = true;
            fmain.tsPanamaCancel.Enabled = true;
            fmain.tsPanamaPrint.Enabled = true;
            fmain.tsPanamaSearch.Enabled = false;



        }

        public void Search()
        {

        }

        public void ClearAll()
        {
            newItem();
        }
        public void Save()
        {

            savePanamaRecord(true);


            //fmain.tsPanamaNew.Enabled = true;
            fmain.tsPanamaEdit.Enabled = true;
            fmain.tsPanamaDelete.Enabled = false;
            fmain.tsPanamaSave.Enabled = false;
            fmain.tsPanamaCancel.Enabled = false;
            fmain.tsPanamaSearch.Enabled = true;
            fmain.tsPanamaPrint.Enabled = true;



            Availability(tabPage1Overlay, false);
            Availability(tabPage2overlay, false);
            Availability(tabPage3overlay, false);
            Availability(tabPage4overlay, false);
            Availability(tabPage5overlay, false);
            Availability(tabPage6overlay, false);
            Availability(tabPage7overlay, false);
            Availability(tabPage8overlay, false);


        }

        public void Edit()
        {
            //fmain.tsPanamaNew.Enabled = false;
            fmain.tsPanamaEdit.Enabled = false;
            fmain.tsPanamaDelete.Enabled = false;
            fmain.tsPanamaSave.Enabled = true;
            fmain.tsPanamaCancel.Enabled = true;
            fmain.tsPanamaPrint.Enabled = false;
            fmain.tsPanamaSearch.Enabled = false;

            Availability(tabPage1Overlay, true);
            Availability(tabPage2overlay, true);
            Availability(tabPage3overlay, true);
            Availability(tabPage4overlay, true);
            Availability(tabPage5overlay, true);
            Availability(tabPage6overlay, true);
            Availability(tabPage7overlay, true);
            Availability(tabPage8overlay, true);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            //fmain.tsPanamaNew.Enabled = true;
            fmain.tsPanamaEdit.Enabled = true;
            fmain.tsPanamaDelete.Enabled = false;
            fmain.tsPanamaSave.Enabled = false;
            fmain.tsPanamaCancel.Enabled = false;
            fmain.tsPanamaPrint.Enabled = true;
            fmain.tsPanamaSearch.Enabled = true;



            Availability(tabPage1Overlay, false);
            Availability(tabPage2overlay, false);
            Availability(tabPage3overlay, false);
            Availability(tabPage4overlay, false);
            Availability(tabPage5overlay, false);
            Availability(tabPage6overlay, false);
            Availability(tabPage7overlay, false);
            Availability(tabPage8overlay, false);


        }




        public void Print()
        {


            FrmPanamaReport print = new FrmPanamaReport();
            print.page1Model = prepareThePage1();
            print.page2Model = prepareThePage2();
            print.page3Model = prepareThePage3();
            print.page4Model = prepareThePage4();
            print.page5Model = prepareThePage5();
            print.ShowDialog();

        }

        private Page1Model prepareThePage1()
        {
            Page1Model model = new Page1Model();

            model.Fullname = txtFullaname.Text;
            model.HomeAddress = txtHomeAddress.Text;
            model.Department = txtDepartment.Text;
            model.Position = txtPosition.Text;

            if (rbMale.Checked == true)
            {
                model.Gender = "Male";
            }
            else
            {
                model.Gender = "Female";
            }

            model.Birthdate = "";
            model.Day = txtbDay.Text;
            model.Month = txtBMonth.Text;
            model.Year = txtBYear.Text;
            model.PassportSeamanBookNo = txtPassportNumber.Text;
            model.LookOutDuties = txtPerformLookout.Text;
            model.EmergencyDuties = txtRoutine.Text;




            model.RhTyping = txtRhType.Text;



            if (rbContainer.Checked == true)
            {
                model.TypeOfShip = "container";
            }
            else if (rbTanker.Checked == true)
            {
                model.TypeOfShip = "tanker";
            }
            else if (rbPassener.Checked == true)
            {

                model.TypeOfShip = "passenger";
            }
            else
            {
                model.TypeOfShip = txtTypeShipOther.Text;
            }


            if (rbCoastal.Checked == true)
            {
                model.TradeArea = "coastal";
            }
            else if (rbTropical.Checked == true)
            {
                model.TradeArea = "tropical";
            }
            else if (rbWorldWide.Checked == true)
            {
                model.TradeArea = "worldwide";
            }

            model.HighBloodPressure = getCheckBoxValue(cbHighBloodPressureYes);
            model.EyeProblem = getCheckBoxValue(cbEyeproblemYes);
            model.EarNoseThroat = getCheckBoxValue(cbEarNoseThroatYes);
            model.HeartSurgery = getCheckBoxValue(cbHeartSurgeryYes);
            model.VaricoseVeins = getCheckBoxValue(cbVaricoseveinsYes);
            model.AsthmaBronchitis = getCheckBoxValue(cbAsthmaBronchitisYes);
            model.BloodDisorder = getCheckBoxValue(cbBloodDisorderYes);
            model.Diabetes = getCheckBoxValue(cbDiabetesYes_);
            model.ThyroidProblem = getCheckBoxValue(cbThyroidProblemYes);
            model.DigestiveDisorders = getCheckBoxValue(cbDigestiveDisordersYes);
            model.KidneyDisorders = getCheckBoxValue(cbKidneyDisordersYes);
            model.SkinProblem = getCheckBoxValue(cbSkinProblemYes);
            model.Allergies = getCheckBoxValue(cbAllergiesYes);

            model.DoyouSmoke = getCheckBoxValue(cbDoyouSmokeYes);
            model.Surgeries = getCheckBoxValue(cbSurgeriesYes);
            model.Infectious = getCheckBoxValue(cbInfectiousYes);
            model.DizzinessFainting = getCheckBoxValue(cbDizzinessFaintingYes);
            model.Lossofconsciousness = getCheckBoxValue(cbLossofconsciousnessYes);
            model.PsychiatricProblem = getCheckBoxValue(cbPsychiatricProblemYes);
            model.Depression = getCheckBoxValue(cbDepressionYes);
            model.Attemptedsuicide = getCheckBoxValue(cbAttemptedsuicideYes);
            model.Lossofmemory = getCheckBoxValue(cbLossofmemoryYes);
            model.BalanceProblems = getCheckBoxValue(cbBalanceProblemsYes);
            model.SevereHeadAches = getCheckBoxValue(cbSevereHeadAchesYes);
            model.Vasculardisease = getCheckBoxValue(cbVasculardiseaseYes);
            model.RestrictedMobility = getCheckBoxValue(cbRestrictedMobilityYes);




            return model;
        }




        private Page2Model prepareThePage2()
        {
            Page2Model model = new Page2Model();

            model.Epilipsy = getCheckBoxValue(cbEpilipsyYes);
            model.SickleCell = getCheckBoxValue(cbSickleCellYes);
            model.Herinas = getCheckBoxValue(cbHerinasYes);
            model.GenitalDisorders = getCheckBoxValue(cbGenitalDisordersYes);
            model.Pregnancy = getCheckBoxValue(cbPregnancyYes);
            model.Sleepproblem = getCheckBoxValue(cbSleepproblemYes);
            model.BackJointProblem = getCheckBoxValue(cbBackJointProblemYes);
            model.Amputation = getCheckBoxValue(cbAmputationYes);
            model.FracturesDislocation = getCheckBoxValue(cbFracturesDislocationYes);


            model.Covid19 = getCheckBoxValue(cbCovidYes);

            model.Repatriated = getCheckBoxValue(cbRepatriatedYes);
            model.Hospitalized = getCheckBoxValue(cbHospitalizedYes);
            model.SeaDuty = getCheckBoxValue(cbSeaDutyYes);
            model.Revoke = getCheckBoxValue(cbRevokeYes);
            model.ConsiderDisease = getCheckBoxValue(cbConsiderDiseaseYes);
            model.FitToPerformDuries = getCheckBoxValue(cbFitToPerformDuriesYes);
            model.AllergicToAnyMedication = getCheckBoxValue(cbAllergicToAnyMedicationYes);
            model.AlternativeSupliment = getCheckBoxValue(cbAllergicAlternativeSuplimentYes);
            model.AlternativeSuplimentComment1 = txtAlternativeComment1.Text;
            model.AlternativeSuplimentComment2 = txtAlternativeComment2.Text;
            model.AlternativeSuplimentComment3 = txtAlternativeComment3.Text;
            model.AlternativeSuplimentComment4 = txtAlternativeComment4.Text;
            model.AlternativeSuplimentComment5 = txtAlternativeComment5.Text;
            model.Pregnancy = getCheckBoxValue(cbPregnancyYes);
            model.Comment1 = txtExamineeComment1.Text;
            model.Comment2 = txtExamineeComment2.Text;
            model.Comment3 = txtExamineeComment3.Text;
            model.Comment4 = txtExamineeComment4.Text;
            model.Comment5 = txtExamineeComment5.Text;


            return model;
        }



        private Page3Model prepareThePage3()
        {
            Page3Model model = new Page3Model();
            model.ContactInCovidPositive = getCheckBoxValue(cbContactInCovidPositiveYes);
            model.TakenMedications = "No";
            if (cbTakenMedicationsYes.Checked)
            {
                model.TakenMedications = "Yes";

            }
            model.TakenMedicationsComment1 = txtmedicationsComment1.Text;
            model.TakenMedicationsComment2 = txtmedicationsComment2.Text;
            model.TakenMedicationsComment3 = txtmedicationsComment3.Text;
            model.TakenMedicationsComment4 = txtmedicationsComment4.Text;
            model.TakenMedicationsComment5 = txtmedicationsComment5.Text;

            model.ContactInCovidPositive = "No";
            if (cbContactInCovidPositiveYes.Checked)
            {
                model.ContactInCovidPositive = "Yes";
            }

            model.CovidTest = "No";
            if (cbCovidTestYes.Checked)
            {
                model.CovidTest = "Yes";
            }

            model.CovidDateTest = txtCividTestDate.Text;
            model.HadFeverLast30Days = "No";
            if (cbHadFeverLast30DaysYes.Checked)
            {
                model.HadFeverLast30Days = "Yes";
            }
            model.VaccinationCovid = "No";
            if (cbVaccinationCovidYes.Checked)
            {
                model.VaccinationCovid = "Yes";
            }
            model.VaccineType = txtVaccineType.Text;
            model.NumberofDoses = txtNumberofDoses.Text;
            model.Booster = txtBooster.Text;

            model.NameOfUndergoingExamination = txtFullaname.Text;




            char delimiter = '/';
            string[] substrings = fitnessdate.Split(delimiter);


            model.Day = substrings[0];
            model.Month = substrings[1];
            model.Year = substrings[2];

            return model;
        }


        private Page4Model prepareThePage4()
        {
            Page4Model model = new Page4Model();
            model.NameOfWitness = txtNameOfWitness.Text;
            model.DoctorName = txtDoctorName.Text;
            model.UndergoingExamination = txtUndergoingExamination.Text;
            model.UndergoingDate = txtUndergoingDate.Text;
            model.NameOfWitness2 = txtNameOfWitness2.Text;
            model.PreviousMedical = txtPreviousMedical.Text;
            model.Height = txtHeight.Text;
            model.HeartRate = txtHeartRate.Text;
            model.BloodPressure = txtBloodPressure.Text;
            model.Weight = txtWeight.Text;
            model.BMI = txtBMI.Text;
            model.Oxygen = txtOxygen.Text;
            model.Respiratory = txtRespiratory.Text;
            model.Diastolic = txtDiastolic.Text;
            model.UnaidedRightEyeDistant = txtUnaidedRightEyeDistant.Text;
            model.UnaidedRightEyeShort = txtUnaidedRightEyeShort.Text;
            model.UnAidedLeftEyeDistant = txtUnAidedLeftEyeDistant.Text;
            model.UnAidedLeftEyeShort = txtUnAidedLeftEyeShort.Text;
            model.UnAidedBonocularDistant = txtUnAidedBonocularDistant.Text;
            model.UnAidedBonocularShort = txtUnAidedBonocularShort.Text;
            model.AidedRightEyeDistant = txtAidedRightEyeDistant.Text;
            model.AidedRightEyeShort = txtAidedRightEyeShort.Text;
            model.AidedLeftEyeDistant = txtAidedLeftEyeDistant.Text;
            model.AidedLeftEyeShort = txtAidedLeftEyeShort.Text;
            model.AidedBinocularDistant = txtAidedBinocularDistant.Text;
            model.AidedBinocularShort = txtAidedBinocularShort.Text;
            model.NormalRightEye = txtNormalRightEye.Text;
            model.DefectiveRightEye = txtDefectiveRightEye.Text;
            model.NormalLeftEye = txtNormalLeftEye.Text;
            model.DefectiveLeftEye = txtDefectiveLeftEye.Text;
            string ColorVision = "";
            if (cbNonTestedColorVision.Checked)
            {
                ColorVision = "NonTestedColorVision";
            }
            else if (cbNormalColorVision.Checked)
            {
                ColorVision = "NormalColorVision";
            }
            else if (cbDoubtfulColorVision.Checked)
            {
                ColorVision = "DoubtfulColorVision";
            }
            else if (cbDefectiveColorVision.Checked)
            {
                ColorVision = "DefectiveColorVision";
            }


            model.ColorVision = ColorVision;
            model.Ishihara = "Ishihara";


            return model;
        }


        private Page5Model prepareThePage5()
        {
            Page5Model model = new Page5Model();
            model._500HzRightEar = txt500HzRightEar.Text;
            model._500HzLeftEar = txt500HzLeftEar.Text;
            model._1kRightEar = txt1kRightEar.Text;
            model._1kLeftEar = txt1kLeftEar.Text;
            model._2kRightEar = txt2kRightEar.Text;
            model._2kLeftEar = txt2kLeftEar.Text;
            model._3kRightEar = txt3kRightEar.Text;
            model._3kLeftEar = txt3kLeftEar.Text;
            model.HeadYes = getCheckBoxValue(cbHeadYes);
            model.MouthYes = getCheckBoxValue(cbMouthYes);
            model.Dental = getCheckBoxValue(cbDental);
            model.Ears = getCheckBoxValue(cbEars);
            model.Tympanic = getCheckBoxValue(cbTympanic);
            model.Eyes = getCheckBoxValue(cbEyes);
            model.Pupils = getCheckBoxValue(cbPupils);
            model.OfThalmoscopy = getCheckBoxValue(cbOfThalmoscopy);
            model.EyeMovement = getCheckBoxValue(cbEyeMovement);
            model.Lungs = getCheckBoxValue(cbLungs);
            model.Breast = getCheckBoxValue(cbBreast);
            model.Heart = getCheckBoxValue(cbHeart);
            model.Skin = getCheckBoxValue(cbSkin); 
            model.VaricoseVenis = getCheckBoxValue(cbVaricoseVenis);
            model.Vascular = getCheckBoxValue(cbVascular);
            model.Abnomen = getCheckBoxValue(cbAbnomen);
            model.Hernias = getCheckBoxValue(cbHernias);
            model.Anus = getCheckBoxValue(cbAnus);
            model.Gu = getCheckBoxValue(cbGu);
            model.Upper = getCheckBoxValue(cbUpper);
            model.Spine = getCheckBoxValue(cbSpine);
            model.Neurologic = getCheckBoxValue(cbNeurologic);
            model.Psychiatric = getCheckBoxValue(cbPsychiatric);
            model.GeneralAppearance = getCheckBoxValue(cbGeneralAppearance);

            model.PhysicalExploration1 = txtPhysicalExploration1.Text;
            model.PhysicalExploration2 = txtPhysicalExploration2.Text;
            model.PhysicalExploration3 = txtPhysicalExploration3.Text;
            model.PhysicalExploration4 = txtPhysicalExploration4.Text;
            model.Hemogram = "";
            if (cbHemogram.Checked)
            {
                model.Hemogram = "Yes";
            }

            model.HemogramNormal = txtHemogramNormal.Text;
            model.HemogramAbNormal = txtHemogramAbNormal.Text;
            model.HemogramOservation = txtHemogramOservation.Text;

            return model;
        }




        private void FrmPanama_Load(object sender, EventArgs e)
        {
            Availability(tabPage1Overlay, false);
            Availability(tabPage2overlay, false);
            Availability(tabPage3overlay, false);
            Availability(tabPage4overlay, false);
            Availability(tabPage5overlay, false);
            Availability(tabPage6overlay, false);
            Availability(tabPage7overlay, false);
            Availability(tabPage8overlay, false);


        }


        public void Availability(Control overlay, bool bl)
        {

            if (bl == true)
            {
                overlay.Visible = false;
                overlay.SendToBack();
            }
            else
            {
                overlay.Visible = true;
                overlay.BringToFront();
            }

        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                DataClasses2DataContext d = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
                var list = d.Panama_SeaMLC("%");
                Cursor.Current = Cursors.WaitCursor;
                foreach (var i in list)
                {
                    Panama_SeaMLC_model.Add(new Panama_SeaMLC
                    {
                        cn = i.cn,
                        papin = i.papin,
                        resultID = i.resultid,
                        patientName = i.PatientName,
                        resultDate = i.result_date,
                        recommendation = i.recommendation

                    });



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
        }




        private void pnlClientArea_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPatients_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                if ((Application.OpenForms["FrmSearchPanama"] as FrmSearchPanama) != null)
                { (Application.OpenForms["FrmSearchPanama"] as FrmSearchPanama).FillDataGridView(); }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }








        private void btnNext_Click(object sender, EventArgs e)
        {
            //fmain.OpenChildForm(() => new FormPatients(), sender);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }




        private void setDateFormat(CheckBox cb, DateTimePicker dt)
        {
            dt.Format = DateTimePickerFormat.Custom;
            dt.CustomFormat = "dd/MM/yyyy";

            if (cb.Checked)
            {
                dt.CustomFormat = "00/00/0000";
            }
        }






        //public void printPreview()
        //{
        //    if (txtPapin.Text == "")
        //    {
        //        RJMessageBox.Show("No Data to be print", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {

        //        savePatient(false);
        //        using (FormPrintReport formPrint = new FormPrintReport())
        //        {
        //            formPrint.physicianName = txtPhysicianName.Text;
        //            formPrint.NameOfWitness1 = txtNameOfWitness.Text;
        //            formPrint.Tag = txtPapin.Text;
        //            formPrint.ShowDialog();
        //        }
        //    }
        //}


        void newItem()
        {


            txtValidUntilDate.Text = "00/00/0000";
            txtIssuedDate.Text = "00/00/0000";
            txtUndergoingDate.Text = "00/00/0000";


            rbWorldWide.Checked = true;
            cbNormalColorVision.Checked = true;

            setRadioButtonValue(cbHighBloodPressureYes, cbHighBloodPressureNo, "No");
            setRadioButtonValue(cbEyeproblemYes, cbEyeproblemNo, "No");
            setRadioButtonValue(cbEarNoseThroatYes, cbEarNoseThroatNo, "No");
            setRadioButtonValue(cbHeartSurgeryYes, cbHeartSurgeryNo, "No");
            setRadioButtonValue(cbVaricoseveinsYes, cbVaricoseveinsNo, "No");
            setRadioButtonValue(cbAsthmaBronchitisYes, cbAsthmaBronchitisNo, "No");
            setRadioButtonValue(cbBloodDisorderYes, cbBloodDisorderNo, "No");
            setRadioButtonValue(cbDiabetesYes_, cbDiabetesNo, "No");
            setRadioButtonValue(cbThyroidProblemYes, cbThyroidProblemNo, "No");
            setRadioButtonValue(cbDigestiveDisordersYes, cbDigestiveDisordersNo, "No");
            setRadioButtonValue(cbKidneyDisordersYes, cbKidneyDisordersNo_, "No");
            setRadioButtonValue(cbSkinProblemYes, cbSkinProblemNo, "No");
            setRadioButtonValue(cbAllergiesYes, cbAllergiesNo, "No");
            setRadioButtonValue(cbEpilipsyYes, cbEpilipsyNo, "No");
            setRadioButtonValue(cbSickleCellYes, cbSickleCellNo, "No");
            setRadioButtonValue(cbHerinasYes, cbHerinasNo, "No");
            setRadioButtonValue(cbGenitalDisordersYes, cbGenitalDisordersNo, "No");
            setRadioButtonValue(cbPregnancyYes, cbPregnancyNo, "No");

            setRadioButtonValue(cbSleepproblemYes, cbSleepproblemNo, "No");
            setRadioButtonValue(cbDoyouSmokeYes, cbDoyouSmokeNo, "No");
            setRadioButtonValue(cbSurgeriesYes, cbSurgeriesNo, "No");
            setRadioButtonValue(cbInfectiousYes, cbInfectiousNo, "No");
            setRadioButtonValue(cbDigestiveDisordersYes, cbDigestiveDisordersNo, "No");
            setRadioButtonValue(cbLossofconsciousnessYes, cbLossofconsciousnessNo, "No");
            setRadioButtonValue(cbPsychiatricProblemYes, cbPsychiatricProblemNo, "No");
            setRadioButtonValue(cbDepressionYes, cbDepressionNo, "No");
            setRadioButtonValue(cbAttemptedsuicideYes, cbAttemptedsuicideNo, "No");
            setRadioButtonValue(cbLossofmemoryYes, cbLossofmemoryNo, "No");
            setRadioButtonValue(cbBalanceProblemsYes, cbBalanceProblemsNo, "No");
            setRadioButtonValue(cbSevereHeadAchesYes, cbSevereHeadAchesNo, "No");



            setRadioButtonValue(cbRestrictedMobilityYes, cbRestrictedMobilityNo, "No");
            setRadioButtonValue(cbBackJointProblemYes, cbBackJointProblemNo, "No");
            setRadioButtonValue(cbAmputationYes, cbAmputationNo, "No");
            setRadioButtonValue(cbFracturesDislocationYes, cbFracturesDislocationNo, "No");
            setRadioButtonValue(cbCovidYes, cbCovidNo, "No");
            setRadioButtonValue(cbRepatriatedYes, cbRepatriatedNo, "No");
            setRadioButtonValue(cbHospitalizedYes, cbHospitalizedNo, "No");



            //PHYSICAL EXPLORATION


            setRadioButtonValue(cbHeadYes, cbHeadNo, "Yes");
            setRadioButtonValue(cbMouthYes, cbMouthNo, "Yes");
            setRadioButtonValue(cbDental, cbDentalNo, "Yes");
            setRadioButtonValue(cbEars, cbEarsNo, "Yes");
            setRadioButtonValue(cbTympanic, cbTympanicNo, "Yes");
            setRadioButtonValue(cbEyes, cbEyesNo, "Yes");
            setRadioButtonValue(cbPupils, cbPupilsNo, "Yes");
            setRadioButtonValue(cbOfThalmoscopy, cbOfThalmoscopyNo, "Yes");
            setRadioButtonValue(cbEyeMovement, cbEyeMovementNo, "Yes");
            setRadioButtonValue(cbLungs, cbLungsNo, "Yes");
            setRadioButtonValue(cbBreast, cbBreastNo, "Yes");
            setRadioButtonValue(cbHeart, cbHeartNo, "Yes");
            setRadioButtonValue(cbSkin, cbSkinNo, "Yes");
            setRadioButtonValue(cbVaricoseVenis, cbVaricoseVenisNo, "Yes");
            setRadioButtonValue(cbVascular, cbVascularNo, "Yes");
            setRadioButtonValue(cbAbnomen, cbAbnomenNo, "Yes");
            setRadioButtonValue(cbHernias, cbHerniasNo, "Yes");
            setRadioButtonValue(cbAnus, cbAnusNo, "Yes");
            setRadioButtonValue(cbGu, cbGuNo, "Yes");
            setRadioButtonValue(cbDizzinessFaintingYes, cbDizzinessFaintingNo, "Yes");

            setRadioButtonValue(cbUpper, cbUpperNo, "Yes");
            setRadioButtonValue(cbSpine, cbSpineNo, "Yes");
            setRadioButtonValue(cbNeurologic, cbNeurologicNo, "Yes");
            setRadioButtonValue(cbPsychiatric, cbPsychiatricNo, "Yes");
            setRadioButtonValue(cbGeneralAppearance, cbGeneralAppearanceNo, "Yes");

            txtPhysicalExploration1.Text = "";
            txtPhysicalExploration2.Text = "";
            txtPhysicalExploration3.Text = "";
            txtPhysicalExploration4.Text = "";



            //DIAGNOSTIC TEST AND RESULTS 
            setCheckBoxValue(cbHemogram, cbHidden, "Yes");
            txtHemogramNormal.Text = "X";

            setCheckBoxValue(cbLipid, cbHidden, "Yes");
            txtLipidNormal.Text = "X";

            setCheckBoxValue(cbCreatinine, cbHidden, "Yes");
            txtCreatinineNormal.Text = "X";

            setCheckBoxValue(cbCholesterol, cbHidden, "Yes");
            txtCholesterolNormal.Text = "X";

            setCheckBoxValue(cbTriglycerides, cbHidden, "Yes");
            txtTriglyceridesNormal.Text = "X";

            setCheckBoxValue(cbGlucose, cbHidden, "Yes");
            txtGlucoseNormal.Text = "X";

            setCheckBoxValue(cbNitrogen, cbHidden, "Yes");
            txtNitrogenNormal.Text = "X";

            setCheckBoxValue(cbRhTyping, cbHidden, "No");
            txtRhTypingNormal.Text = "+";

            setCheckBoxValue(cbHiv, cbHidden, "Yes");
            txtHivNormal.Text = "X";

            setCheckBoxValue(cbVdrl, cbHidden, "Yes"); ;
            txtVdrlNormal.Text = "X";

            setCheckBoxValue(cbGch, cbHidden, "Yes");
            txtGchNormal.Text = "N/A";

            setCheckBoxValue(cbGeneralUrien, cbHidden, "Yes");
            txtGeneralUrineNormal.Text = "X";

            setCheckBoxValue(cbStool, cbHidden, "Yes");
            txtStoolNormal.Text = "X";

            setCheckBoxValue(cbDrugtest, cbHidden, "Yes");
            txtDrugTestNormal.Text = "X";

            setCheckBoxValue(cbAlcohol, cbHidden, "Yes");
            txtAlcoholNormal.Text = "X";


            //cbBreast.Checked = false;



            txtLipidAbNormal.Text = "";
            txtCreatinineAbnormal.Text = "";
            txtCholesterolAbnormal.Text = "";
            txtTriglyceridesAbnormal.Text = "";
            txtGlucoseAbNormal.Text = "";
            txtNitrogenAbnormal.Text = "";
            txtRhTypingAbnormal.Text = "";
            txtHivAbnormal.Text = "";
            txtVdrlAbnormal.Text = "";
            txtGchAbnormal.Text = "";
            txtGeneralUrineAbNormal.Text = "";
            txtStoolAbNormal.Text = "";
            txtDrugTestAbNormal.Text = "";
            txtAlcoholAbNormal.Text = "";

            txtLipidObservation.Text = "";
            txtCreatinineObservation.Text = "";
            txtCholesterolObservation.Text = "";
            txtTriglyceridesObservation.Text = "";
            txtGlucoseObservation.Text = "";
            txtNitrogenObservation.Text = "";
            txtRhTypingObservation.Text = "";
            txtHivObservation.Text = "";
            txtVdrlObservation.Text = "";
            txtGchObservation.Text = "";
            txtGeneralUrineObservation.Text = "";
            txtStoolObservation.Text = "";
            txtDrugTestObservation.Text = "";
            txtAlcoholObservation.Text = "";

            txtBreastExaminationAbNormal.Text = "";
            txtPapAbnormal.Text = "";
            txtPsaAbNormal.Text = "";

            txtBreastExaminationObservation.Text = "";
            txtPapObservation.Text = "";
            txtPsaObservation.Text = "";


            setCheckBoxValue(cbBreastExamination, cbHidden, "No");
            txtBreastExaminationNormal.Text = "N/A";

            setCheckBoxValue(cbPapTest, cbHidden, "No");
            txtPaptestJNormal.Text = "N/A";

            setCheckBoxValue(cbPsa, cbHidden, "No");
            txtPsaNormal.Text = "N/A";
            setCheckBoxValue(cbXray, cbHidden, "No");
            txtXrayObservation.Text = "NORMAL";
            setCheckBoxValue(cbEkg, cbHidden, "Yes");

            txtEkgObservation.Text = "NORMAL";

            txtSarsCovidByAntigens.Text = "";

            txtNameOfWitness.Text = "MARIA VICTORIA T. NOHAY";

            txtNameOfWitness2.Text = "MARIA VICTORIA T. NOHAY";


            txtPhysicianName.Text = "MA. LUCIA B. LAGUIMUN, M.D.  -  License No. 0077460";



            //dtXrayDate.Value = DateTime.Now;
            //checkBox109.Checked = false;


            //dtEkg.Value = DateTime.Now;
            //checkBox110.Checked = false;
            txtXrayPerformed.Text = "";
            txtEZGPerformed.Text = "";


            //dtUndergoingExamination.Value = DateTime.Now;
            //checkBox107.Checked = false;
            txtundergoingExaminationDate.Text = fitnessdate;






            rbFitForLookOut.Checked = true;
            cbWithOutRestrictions.Checked = true;
            cbVisualAidRequiredNo.Checked = true;

            txtAssessmentComment1.Text = "";
            txtAssessmentComment2.Text = "";
            txtAssessmentComment3.Text = "";
            txtAssessmentComment4.Text = "";
            txtAssessmentComment5.Text = "";



            txtSarsCovidByPcr.Text = "";
            txtSarsCovidByAntigens.Text = "";


            txtOtherDiagnosticTest.Text = "";
            txtOtherDiagnosticResult.Text = "";
            txtOtherDiagnosticComment1.Text = "";
            txtOtherDiagnosticComment2.Text = "";
            txtOtherDiagnosticComment3.Text = "";
            txtOtherDiagnosticComment4.Text = "";


            cbDeckServiceFit.Checked = true;
            cbDeckServiceUnFit.Checked = false;
            cbEngineFit.Checked = false;
            cbEngineUnFit.Checked = false;
            cbCateringFit.Checked = false;
            cbCateringUnFit.Checked = false;
            cbOtherServiceFit.Checked = false;
            cbOtherUnFit.Checked = false;

        }


        //public void searchPatient(string keyWord)
        //{
        //    try
        //    {

        //        DataClasses1DataContext db = new DataClasses1DataContext(Database.connectionString);
        //        var i = db.PANAMA_SELECT(keyWord).FirstOrDefault();


        //        if (i != null)
        //        {

        //            txtFullaname.Text = i.Fullname;
        //            txtPersonundergoingExamination.Text = i.Fullname;
        //            txtUndergoingExamination.Text = i.Fullname;

        //            txtSpecimenNo.Text = i.specimen_no;


        //            txtHomeAddress.Text = i.HomeAddress;
        //            txtDepartment.Text = i.Department;
        //            txtPosition.Text = i.position;
        //            txtSex.Text = i.gender;
        //            //dateBirth.Text = i.birthdate;
        //            //
        //            DateTime bdate = Convert.ToDateTime(i.birthdate);
        //            txtbDay.Text = bdate.Day.ToString();
        //            txtBMonth.Text = bdate.ToString("MMM");
        //            txtBYear.Text = bdate.Year.ToString();

        //            txtPassportNumber.Text = i.PassportSeamanBookNo;
        //            PatientPicture.Image = ImageUtil.bytetoimage(i.picture.ToArray());

        //            txtPerformLookout.Text = i.LookOutDuties;
        //            txtRoutine.Text = i.EmergencyDuties;


        //            newItem();


        //            if (i.countvalidator > 0)
        //            {

        //                txtRhType.Text = i.RhTypingProfile;

        //                if (i.TypeOfShip != null)
        //                {

        //                    switch (i.TypeOfShip.ToLower())
        //                    {
        //                        case "container":
        //                            rbContainer.Checked = true;
        //                            break;
        //                        case "tanker":
        //                            rbTanker.Checked = true;
        //                            break;
        //                        case "passenger":
        //                            rbPassener.Checked = true;
        //                            break;

        //                        default:
        //                            rbTypeOfShipOther.Checked = true;
        //                            txtTypeShipOther.Text = i.TypeOfShip;
        //                            break;
        //                    }

        //                }


        //                if (txtTypeShipOther.Text != "")
        //                {
        //                    rbContainer.Checked = false;
        //                    rbTanker.Checked = false;
        //                    rbPassener.Checked = false;
        //                    rbTypeOfShipOther.Checked = true;
        //                }



        //                if (i.TradeArea != null)
        //                {
        //                    switch (i.TradeArea.ToLower())
        //                    {
        //                        case "coastal":
        //                            rbCoastal.Checked = true;
        //                            break;
        //                        case "tropical":
        //                            rbTropical.Checked = true;
        //                            break;
        //                        case "worldwide":
        //                            rbWorldWide.Checked = true;
        //                            break;
        //                        default:
        //                            // TO DO
        //                            break;
        //                    }
        //                }
        //                //EXAMINEE PERSONAL DECLARATION
        //                setCheckBoxValue(cbHighBloodPressureYes, cbHighBloodPressureNo, i.HighBloodPressure);
        //                setCheckBoxValue(cbEyeproblemYes, cbEyeproblemNo, i.Eyeproblem);
        //                setCheckBoxValue(cbEarNoseThroatYes, cbEarNoseThroatNo, i.EarNoseThroat);
        //                setCheckBoxValue(cbHeartSurgeryYes, cbHeartSurgeryNo, i.HeartSurgery);
        //                setCheckBoxValue(cbVaricoseveinsYes, cbVaricoseveinsNo, i.Varicoseveins);
        //                setCheckBoxValue(cbAsthmaBronchitisYes, cbAsthmaBronchitisNo, i.AsthmaBronchitis);
        //                setCheckBoxValue(cbBloodDisorderYes, cbBloodDisorderNo, i.BloodDisorder);
        //                setCheckBoxValue(cbDiabetesYes_, cbDiabetesNo, i.Diabetes);
        //                setCheckBoxValue(cbThyroidProblemYes, cbThyroidProblemNo, i.ThyroidProblem);
        //                setCheckBoxValue(cbDigestiveDisordersYes, cbDigestiveDisordersNo, i.DigestiveDisorders);
        //                setCheckBoxValue(cbKidneyDisordersYes, cbKidneyDisordersNo_, i.KidneyDisorders);
        //                setCheckBoxValue(cbSkinProblemYes, cbSkinProblemNo, i.SkinProblem);
        //                setCheckBoxValue(cbAllergiesYes, cbAllergiesNo, i.Allergies);
        //                setCheckBoxValue(cbEpilipsyYes, cbEpilipsyNo, i.Epilipsy);
        //                setCheckBoxValue(cbSickleCellYes, cbSickleCellNo, i.SickleCell);
        //                setCheckBoxValue(cbHerinasYes, cbHerinasNo, i.Herinas);
        //                setCheckBoxValue(cbGenitalDisordersYes, cbGenitalDisordersNo, i.GenitalDisorders);
        //                setCheckBoxValue(cbPregnancyYes, cbPregnancyNo, i.Pregnancy);

        //                setCheckBoxValue(cbSleepproblemYes, cbSleepproblemNo, i.Sleepproblem);
        //                setCheckBoxValue(cbDoyouSmokeYes, cbDoyouSmokeNo, i.DoyouSmoke);
        //                setCheckBoxValue(cbSurgeriesYes, cbSurgeriesNo, i.Surgeries);
        //                setCheckBoxValue(cbInfectiousYes, cbInfectiousNo, i.Infectious);
        //                setCheckBoxValue(cbDigestiveDisordersYes, cbDigestiveDisordersNo, i.DizzinessFainting);
        //                setCheckBoxValue(cbLossofconsciousnessYes, cbLossofconsciousnessNo, i.Lossofconsciousness);
        //                setCheckBoxValue(cbPsychiatricProblemYes, cbPsychiatricProblemNo, i.PsychiatricProblem);
        //                setCheckBoxValue(cbDepressionYes, cbDepressionNo, i.Depression);
        //                setCheckBoxValue(cbLossofmemoryYes, cbLossofmemoryNo, i.Attemptedsuicide);


        //                setCheckBoxValue(cbRestrictedMobilityYes, cbRestrictedMobilityNo, i.RestrictedMobility);
        //                setCheckBoxValue(cbBackJointProblemYes, cbBackJointProblemNo, i.BackJointProblem);
        //                setCheckBoxValue(cbAmputationYes, cbAmputationNo, i.Amputation);
        //                setCheckBoxValue(cbFracturesDislocationYes, cbFracturesDislocationNo, i.FracturesDislocation);
        //                setCheckBoxValue(cbCovidYes, cbCovidNo, i.Covid19);
        //                setCheckBoxValue(cbRepatriatedYes, cbRepatriatedNo, i.Repatriated);
        //                setCheckBoxValue(cbHospitalizedYes, cbHospitalizedNo, i.Hospitalized);
        //                setCheckBoxValue(cbSeaDutyYes, cbSeaDutyNo, i.SeaDuty);
        //                setCheckBoxValue(cbRevokeYes, cbRevokeNo, i.Revoke);
        //                setCheckBoxValue(cbConsiderDiseaseYes, cbConsiderDiseaseNo, i.ConsiderDisease);
        //                setCheckBoxValue(cbFitToPerformDuriesYes, cbFitToPerformDuriesNo, i.FitToPerformDuries);

        //                setCheckBoxValue(cbAllergicToAnyMedicationYes, cbAllergicToAnyMedicationNo, i.AllergicToAnyMedication);
        //                setCheckBoxValue(cbAllergicAlternativeSuplimentYes, cbAllergicAlternativeSuplimentNo, i.AlternativeSupliment);

        //                txtAlternativeComment1.Text = i.AlternativeSuplimentComment1;
        //                txtAlternativeComment2.Text = i.AlternativeSuplimentComment2;
        //                txtAlternativeComment3.Text = i.AlternativeSuplimentComment3;
        //                txtAlternativeComment4.Text = i.AlternativeSuplimentComment4;
        //                txtAlternativeComment5.Text = i.AlternativeSuplimentComment5;
        //                txtAlternativeComment6.Text = i.AlternativeSuplimentComment6;
        //                setCheckBoxValue(cbTakenMedicationsYes, cbTakenMedicationsNo, i.TakenMedications);
        //                txtmedicationsComment1.Text = i.TakenMedicationsComment1;
        //                txtmedicationsComment2.Text = i.TakenMedicationsComment2;
        //                txtmedicationsComment3.Text = i.TakenMedicationsComment3;
        //                txtmedicationsComment4.Text = i.TakenMedicationsComment4;
        //                txtmedicationsComment5.Text = i.TakenMedicationsComment5;
        //                //txtmedicationsComment6.Text = i.TakenMedicationsComment6;
        //                txtExamineeComment1.Text = i.Comment1;
        //                txtExamineeComment2.Text = i.Comment2;
        //                txtExamineeComment3.Text = i.Comment3;
        //                txtExamineeComment4.Text = i.Comment4;
        //                txtExamineeComment5.Text = i.Comment5;


        //                // Data Related  to covid
        //                setCheckBoxValue(cbContactInCovidPositiveYes, cbContactInCovidPositiveNo, i.ContactInCovidPositive);
        //                setCheckBoxValue(cbCovidTestYes, cbCovidTestNo, i.CovidTest);
        //                validateDate(i.CovidDateTest, dtCovidDateTest, checkBox106);
        //                setCheckBoxValue(cbHadFeverLast30DaysYes, cbHadFeverLast30DaysNo, i.HadFeverLast30Days);
        //                setCheckBoxValue(cbVaccinationCovidYes, cbVaccinationCovidNo, i.VaccinationCovid);
        //                txtVaccineType.Text = i.VaccineType;
        //                txtNumberofDoses.Text = i.NumberofDoses;
        //                txtBooster.Text = i.Booster;

        //                //STATEMENT
        //                //txtPersonundergoingExamination.Text = i.PersonundergoingExamination;
        //                //validateDate(i.UndergoingExaminationDate, dtUndergoingExamination, checkBox107);
        //                string s = i.fitness_date;
        //                string[] d = s.Split('/');

        //                txtStaetementDay.Text = d[0];
        //                txtStaetementMonth.Text = Convert.ToDateTime(i.fitness_date).ToString("MMM");
        //                txtStaetementYear.Text = d[2];


        //                txtNameOfWitness.Text = i.NameOfWitness;
        //                txtDoctorName.Text = i.DoctorName;
        //                //txtUndergoingExamination.Text = i.UndergoingExamination;
        //                //validateDate(i.UndergoingExaminationDate2, dtUndergoingExamination2, checkBox108);

        //                string p4 = i.fitness_date;
        //                string[] d4 = s.Split('/');

        //                txtp4Day.Text = d4[0];
        //                txtp4Month.Text = Convert.ToDateTime(i.fitness_date).ToString("MMM");
        //                txtp4Year.Text = d4[2];






        //                txtNameOfWitness2.Text = i.NameOfWitness2;
        //                txtPreviousMedical.Text = i.PreviousMedical;

        //                //MEDICAL EXAMINATION
        //                txtHeight.Text = i.Height;
        //                txtWeight.Text = i.Weight;
        //                txtBMI.Text = i.BMI;
        //                txtOxygen.Text = i.Oxygen;
        //                txtHeartRate.Text = i.HeartRate;
        //                txtRespiratory.Text = i.Respiratory;
        //                txtBloodPressure.Text = i.BloodPressure;
        //                txtDiastolic.Text = i.Diatolic;
        //                txtUnaidedRightEyeDistant.Text = i.UnaidedRightEyeDistant;
        //                txtUnAidedLeftEyeDistant.Text = i.UnAidedLeftEyeDistant;
        //                txtUnAidedBonocularDistant.Text = i.UnAidedBonocularDistant;
        //                txtAidedRightEyeDistant.Text = i.AidedRightEyeDistant;
        //                txtAidedLeftEyeDistant.Text = i.AidedLeftEyeDistant;
        //                txtAidedBinocularDistant.Text = i.AidedBinocularDistant;
        //                txtUnaidedRightEyeShort.Text = i.UnaidedRightEyeShort;
        //                txtUnAidedLeftEyeShort.Text = i.UnAidedLeftEyeShort;
        //                txtUnAidedBonocularShort.Text = i.UnAidedBonocularShort;
        //                txtAidedRightEyeShort.Text = i.AidedRightEyeShort;
        //                txtAidedLeftEyeShort.Text = i.AidedLeftEyeShort;
        //                txtAidedBinocularShort.Text = i.AidedBinocularShort;


        //                setCheckBoxValue(cbNonTestedColorVision, cbHidden, i.NonTestedColorVision);
        //                setCheckBoxValue(cbNormalColorVision, cbHidden, i.NormalColorVision);
        //                setCheckBoxValue(cbDoubtfulColorVision, cbHidden, i.DoubtfulColorVision);
        //                setCheckBoxValue(cbDefectiveColorVision, cbHidden, i.DefectiveColorVision);


        //                txtNormalRightEye.Text = i.NormalRightEye;
        //                txtNormalLeftEye.Text = i.NormalLeftEye;
        //                txtDefectiveRightEye.Text = i.DefectiveRightEye;
        //                txtDefectiveLeftEye.Text = i.DefectiveLeftEye;
        //                txtSightComment.Text = "ISHIHARA 38";
        //                txt500HzRightEar.Text = i._500HzRightEar;
        //                txt1kRightEar.Text = i._1kRightEar;
        //                txt2kRightEar.Text = i._2kRightEar;
        //                txt3kRightEar.Text = i._3kRightEar;
        //                txt500HzLeftEar.Text = i._500HzLeftEar;
        //                txt1kLeftEar.Text = i._1kLeftEar;
        //                txt2kLeftEar.Text = i._2kLeftEar;
        //                txt3kLeftEar.Text = i._3kLeftEar;

        //                //PHYSICAL EXPLORATION
        //                setCheckBoxValue(cbHeadYes, cbHeadNo, i.Head);
        //                setCheckBoxValue(cbMouthYes, cbMouthNo, i.Mouth);
        //                setCheckBoxValue(cbDental, cbDentalNo, i.Dental);
        //                setCheckBoxValue(cbEars, cbEarsNo, i.Ears);
        //                setCheckBoxValue(cbTympanic, cbTympanicNo, i.Tympanic);
        //                setCheckBoxValue(cbEyes, cbEyesNo, i.Eyes);
        //                setCheckBoxValue(cbPupils, cbPupilsNo, i.Pupils);
        //                setCheckBoxValue(cbOfThalmoscopy, cbOfThalmoscopyNo, i.OfThalmoscopy);
        //                setCheckBoxValue(cbEyeMovement, cbEyeMovementNo, i.EyeMovement);
        //                setCheckBoxValue(cbLungs, cbLungsNo, i.Lungs);
        //                setCheckBoxValue(cbBreast, cbBreastNo, i.Breast);
        //                setCheckBoxValue(cbHeart, cbHeartNo, i.Heart);
        //                setCheckBoxValue(cbSkin, cbSkinNo, i.Skin);
        //                setCheckBoxValue(cbVaricoseVenis, cbVaricoseVenisNo, i.VaricoseVenis);
        //                setCheckBoxValue(cbVascular, cbVascularNo, i.Vascular);
        //                setCheckBoxValue(cbAbnomen, cbAbnomenNo, i.Abdomen);
        //                setCheckBoxValue(cbHernias, cbHerniasNo, i.Hernias);
        //                setCheckBoxValue(cbAnus, cbAnusNo, i.Anus);
        //                setCheckBoxValue(cbGu, cbGuNo, i.Gu);
        //                setCheckBoxValue(cbUpper, cbUpperNo, i.Upper);
        //                setCheckBoxValue(cbSpine, cbSpineNo, i.Spine);
        //                setCheckBoxValue(cbNeurologic, cbNeurologicNo, i.Neurologic);
        //                setCheckBoxValue(cbPsychiatric, cbPsychiatricNo, i.Psychiatric);
        //                setCheckBoxValue(cbGeneralAppearance, cbGeneralAppearanceNo, i.GeneralAppearance);
        //                txtPhysicalExploration1.Text = i.PhysicalExplorationComment1;

        //                //DIAGNOSTIC TEST AND RESULTS 
        //                setCheckBoxValue(cbHemogram, cbHidden, i.Hemogram);
        //                txtHemogramNormal.Text = i.HemogramNormal;
        //                txtHemogramAbNormal.Text = i.HemogramAbNormal;
        //                txtHemogramOservation.Text = i.HemogramOservation;
        //                setCheckBoxValue(cbLipid, cbHidden, i.Lipid);
        //                txtLipidNormal.Text = i.LipidNormal;
        //                txtLipidAbNormal.Text = i.LipidAbNormal; ;
        //                txtLipidObservation.Text = i.LipidObservation;
        //                setCheckBoxValue(cbCreatinine, cbHidden, i.Creatinine);
        //                txtCreatinineNormal.Text = i.CreatinineNormal;
        //                txtCreatinineAbnormal.Text = i.CreatinineAbnormal;
        //                txtCreatinineObservation.Text = i.CreatinineObservation;
        //                setCheckBoxValue(cbCholesterol, cbHidden, i.Cholesterol);
        //                txtCholesterolNormal.Text = i.CholesterolNormal;
        //                txtCholesterolAbnormal.Text = i.CholesterolAbnormal;
        //                txtCholesterolObservation.Text = i.CholesterolObservation;
        //                setCheckBoxValue(cbTriglycerides, cbHidden, i.Triglycerides);
        //                txtTriglyceridesNormal.Text = i.TriglyceridesNormal;
        //                txtTriglyceridesAbnormal.Text = i.TriglyceridesAbnormal;
        //                txtTriglyceridesObservation.Text = i.TriglyceridesObservation;
        //                setCheckBoxValue(cbGlucose, cbHidden, i.Glucose);
        //                txtGlucoseNormal.Text = i.GlucoseNormal;
        //                txtGlucoseAbNormal.Text = i.GlucoseAbNormal;
        //                txtGlucoseObservation.Text = i.GlucoseObservation;
        //                setCheckBoxValue(cbNitrogen, cbHidden, i.Nitrogen);
        //                txtNitrogenNormal.Text = i.NitrogenNormal;
        //                txtNitrogenAbnormal.Text = i.NitrogenAbnormal;
        //                txtNitrogenObservation.Text = i.NitrogenObservation;
        //                setCheckBoxValue(cbRhTyping, cbHidden, i.RhTyping);
        //                txtRhTypingNormal.Text = i.RhTypingNormal;
        //                txtRhTypingAbnormal.Text = i.RhTypingAbnormal;
        //                txtRhTypingObservation.Text = i.RhTypingObservation;
        //                setCheckBoxValue(cbHiv, cbHidden, i.Hiv);
        //                txtHivNormal.Text = i.HivNormal;
        //                txtHivAbnormal.Text = i.HivAbnormal;
        //                txtHivObservation.Text = i.HivObservation;
        //                setCheckBoxValue(cbVdrl, cbHidden, i.Vdrl);
        //                txtVdrlNormal.Text = i.VdrlNormal;
        //                txtVdrlAbnormal.Text = i.VdrlAbnormal;
        //                txtVdrlObservation.Text = i.VdrlObservation;
        //                setCheckBoxValue(cbGch, cbHidden, i.Gch);
        //                txtGchNormal.Text = i.GchNormal.Replace("NA", "N/A");
        //                txtGchAbnormal.Text = i.GchAbnormal;
        //                txtGchObservation.Text = i.GchObservation;
        //                setCheckBoxValue(cbGeneralUrien, cbHidden, i.GeneralUrien);
        //                txtGeneralUrineNormal.Text = i.GeneralUrineNormal;
        //                txtGeneralUrineAbNormal.Text = i.GeneralUrineAbNormal;
        //                txtGeneralUrineObservation.Text = i.GeneralUrineObservation;
        //                setCheckBoxValue(cbStool, cbHidden, i.Stool);
        //                txtStoolNormal.Text = i.StoolNormal;
        //                txtStoolAbNormal.Text = i.StoolAbNormal;
        //                txtStoolObservation.Text = i.StoolObservation;
        //                setCheckBoxValue(cbDrugtest, cbHidden, i.Drugtest);
        //                txtDrugTestNormal.Text = i.DrugTestNormal;
        //                txtDrugTestAbNormal.Text = i.DrugTestAbNormal;
        //                txtDrugTestObservation.Text = i.DrugTestObservation;
        //                setCheckBoxValue(cbAlcohol, cbHidden, i.Alcohol);
        //                txtAlcoholNormal.Text = i.AlcoholNormal;
        //                txtAlcoholAbNormal.Text = i.AlcoholAbNormal;
        //                txtAlcoholObservation.Text = i.AlcoholObservation;
        //                setCheckBoxValue(cbBreast, cbHidden, i.Breast);
        //                txtBreastExaminationNormal.Text = i.BreastExaminationNormal.Replace("NA", "N/A");
        //                txtBreastExaminationAbNormal.Text = i.BreastExaminationAbNormal;
        //                txtBreastExaminationObservation.Text = i.BreastExaminationObservation;
        //                setCheckBoxValue(cbPapTest, cbHidden, i.PapTest);
        //                txtPaptestJNormal.Text = i.PaptestJNormal.Replace("NA", "N/A");
        //                txtPapAbnormal.Text = i.PapAbnormal;
        //                txtPapObservation.Text = i.PapObservation;
        //                setCheckBoxValue(cbPsa, cbHidden, i.Psa);
        //                txtPsaNormal.Text = i.PsaNormal.Replace("NA", "N/A");
        //                txtPsaAbNormal.Text = i.PsaAbNormal;
        //                txtPsaObservation.Text = i.PsaObservation;
        //                setCheckBoxValue(cbXray, cbHidden, i.Xray);

        //                validateDate(i.XrayDate, dtXrayDate, checkBox109);
        //                txtXrayObservation.Text = i.XrayObservation;
        //                setCheckBoxValue(cbEkg, cbHidden, i.Ekg);
        //                validateDate(i.Ekg, dtEkg, checkBox110);
        //                txtEkgObservation.Text = i.EkgObservation;


        //                txtSarsCovidByPcr.Text = i.SarsCovidByPcr;
        //                txtSarsCovidByAntigens.Text = i.SarsCovidByAntigens;


        //                txtOtherDiagnosticTest.Text = i.OtherTest;
        //                txtOtherDiagnosticResult.Text = i.OtherTestResult;
        //                txtOtherDiagnosticComment1.Text = i.DiagnosticComment1;
        //                txtOtherDiagnosticComment2.Text = i.DiagnosticComment2;
        //                txtOtherDiagnosticComment3.Text = i.DiagnosticComment3;
        //                txtOtherDiagnosticComment4.Text = i.DiagnosticComment4;


        //                //ASSESSMENT OF FITNESS FOR SERVICE AT SEA  /// RESULT MAIN
        //                string reco = "";
        //                if (i.recommendation.ToLower().Equals("FIT FOR SEA DUTY"))
        //                {
        //                    reco = "Yes";
        //                }
        //                else
        //                {
        //                    reco = "No";
        //                }
        //                setRadioButtonValue(rbFitForLookOut, reco);


        //                string deck_srvc_flag_ = i.deck_srvc_flag.ToString();
        //                if (deck_srvc_flag_ == "Y") { cbDeckServiceFit.Checked = true; } else if (deck_srvc_flag_ == "N") { cbDeckServiceUnFit.Checked = true; } else { cbDeckServiceFit.Checked = false; cbDeckServiceUnFit.Checked = false; }

        //                string t_engine_srvc_flag_ = i.engine_srvc_flag.ToString();
        //                if (t_engine_srvc_flag_ == "Y") { this.cbEngineFit.Checked = true; } else if (t_engine_srvc_flag_ == "N") { this.cbEngineUnFit.Checked = true; } else { cbEngineFit.Checked = false; cbEngineUnFit.Checked = false; }

        //                string t_catering_srvc_flag_ = i.catering_srvc_flag.ToString();
        //                if (t_catering_srvc_flag_ == "Y") { this.cbCateringFit.Checked = true; } else if (t_catering_srvc_flag_ == "N") { this.cbCateringUnFit.Checked = true; } else { cbCateringFit.Checked = false; cbCateringUnFit.Checked = false; }

        //                string t_other_srvc_flag_ = i.other_srvc_flag.ToString();
        //                if (t_other_srvc_flag_ == "Y") { this.cbOtherServiceFit.Checked = true; } else if (t_other_srvc_flag_ == "N") { this.cbOtherUnFit.Checked = true; } else { cbOtherServiceFit.Checked = false; cbOtherUnFit.Checked = false; }



        //                setCheckBoxValue(cbWithOutRestrictions, cbHidden, i.WithOutRestrictions);
        //                setCheckBoxValue(cbWithRestrictions, cbHidden, i.WithRestrictions);
        //                setCheckBoxValue(cbVisualAidYes, cbHidden, i.cbVisualAidRequiredYes);
        //                setCheckBoxValue(cbVisualAidRequiredNo, cbHidden, i.cbVisualAidRequiredNo);
        //                txtAssessmentComment1.Text = i.assessmentComment1;
        //                txtAssessmentComment2.Text = i.assessmentComment2;
        //                txtAssessmentComment3.Text = i.assessmentComment3;
        //                txtAssessmentComment4.Text = i.assessmentComment4;
        //                txtAssessmentComment5.Text = i.assessmentComment5;
        //                //validateDate(i.MedicalCertificateExpiration, dtMedicalCertificateExpiration, checkBox111);
        //                //validateDate(i.MedicalCertificateIssued, dtMedicalCertificateIssued, checkBox112);

        //                string[] e = i.valid_until.Split('/');
        //                expirateDay.Text = e[0];
        //                expirateMonth.Text = Convert.ToDateTime(i.fitness_date).ToString("MMM");
        //                expirateYear.Text = e[2];


        //                string[] iss = i.fitness_date.Split('/');
        //                issuedDay.Text = iss[0];
        //                issuedMonth.Text = Convert.ToDateTime(i.fitness_date).ToString("MMM");
        //                issuedYear.Text = iss[2];




        //                txtNumberOfMedicalCertificate.Text = i.NumberOfMedicalCertificate;
        //                txtPhysicianName.Text = "MA. LUCIA B. LAGUIMUN, M.D.  -  License No. 77460";

        //            }

        //        }
        //        else
        //        {
        //            RJMessageBox.Show("This patient have no record yet from medical software", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
        //        RJMessageBox.Show(string.Format("An error occured {0}", ex.Message), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void savePanamaRecord(bool isfromBtnSave)
        {
            string uID = UID.Generate();

            if (txtPapin.Text != "")
            {

                string typeOfShip = "";
                if (rbContainer.Checked)
                {
                    typeOfShip = "Container";
                }
                else if (rbTanker.Checked)
                {
                    typeOfShip = "Tanker";
                }
                else if (rbPassener.Checked)
                {
                    typeOfShip = "Passenger";
                }
                else if (rbTypeOfShipOther.Checked)
                {
                    typeOfShip = txtTypeShipOther.Text;
                }



                string tradeArea = "";
                if (rbCoastal.Checked)
                {
                    tradeArea = "Coastal";
                }
                else if (rbTropical.Checked)
                {
                    tradeArea = "Tropical";
                }
                else if (rbWorldWide.Checked)
                {
                    tradeArea = "WorldWide";
                }

                string papin = txtPapin.Text; //Get the papin  fron tag of txtFullaname;

                Patients_Model patientModel = new Patients_Model();
                patientModel.SavePatient(papin, txtRhType.Text, txtPerformLookout.Text, txtRoutine.Text, typeOfShip, tradeArea);
                PanamaExamineePersonalDeclarationSave(papin, txtResultID.Text);
                PanamaDataRelatedCovidSave(papin, txtResultID.Text);
                PanamaMedicalExaminationSave(papin, txtResultID.Text);
                PanamaPhysicalExplorationSave(papin, txtResultID.Text);
                PanamaDiagnosticTestSave(papin, txtResultID.Text);
                PanamaResultMainSave(papin, txtResultID.Text);//Assesment Table



            }
        }

        //private void PanamaExamineeSave(string papin, string uid)
        //{
        //    PanamaExamineeModel examinee = new PanamaExamineeModel();
        //    examinee.Save(papin,
        //                   uid,
        //                   getCheckBoxValue(cbHighBloodPressureYes, cbHighBloodPressureNo),
        //                   getCheckBoxValue(cbEyeproblemYes, cbEyeproblemNo),
        //                   getCheckBoxValue(cbEarNoseThroatYes, cbEarNoseThroatNo),
        //                   getCheckBoxValue(cbHeartSurgeryYes, cbHeartSurgeryNo),
        //                   getCheckBoxValue(cbVaricoseveinsYes, cbVaricoseveinsNo),
        //                   getCheckBoxValue(cbAsthmaBronchitisYes, cbAsthmaBronchitisNo),
        //                   getCheckBoxValue(cbBloodDisorderYes, cbBloodDisorderNo),
        //                   getCheckBoxValue(cbDiabetesYes_, cbDiabetesNo),
        //                   getCheckBoxValue(cbThyroidProblemYes, cbThyroidProblemNo),
        //                   getCheckBoxValue(cbDigestiveDisordersYes, cbDigestiveDisordersNo),

        //                   getCheckBoxValue(cbKidneyDisordersYes, cbKidneyDisordersNo_),
        //                   getCheckBoxValue(cbSkinProblemYes, cbSkinProblemNo),
        //                   getCheckBoxValue(cbAllergiesYes, cbAllergiesNo),
        //                   getCheckBoxValue(cbEpilipsyYes, cbEpilipsyNo),
        //                   getCheckBoxValue(cbSickleCellYes, cbSickleCellNo),
        //                   getCheckBoxValue(cbHerinasYes, cbHerinasNo),
        //                   getCheckBoxValue(cbGenitalDisordersYes, cbGenitalDisordersNo),
        //                   getCheckBoxValue(cbPregnancyYes, cbPregnancyNo),

        //                   getCheckBoxValue(cbSleepproblemYes, cbSleepproblemNo),
        //                   getCheckBoxValue(cbDoyouSmokeYes, cbDoyouSmokeNo),
        //                   getCheckBoxValue(cbSurgeriesYes, cbSurgeriesNo),
        //                   getCheckBoxValue(cbInfectiousYes, cbInfectiousNo),
        //                   getCheckBoxValue(cbDigestiveDisordersYes, cbDigestiveDisordersNo),
        //                   getCheckBoxValue(cbLossofconsciousnessYes, cbLossofconsciousnessNo),
        //                   getCheckBoxValue(cbPsychiatricProblemYes, cbPsychiatricProblemNo),
        //                   getCheckBoxValue(cbDepressionYes, cbDepressionNo),
        //                   getCheckBoxValue(cbAttemptedsuicideYes, cbAttemptedsuicideNo),
        //                   getCheckBoxValue(cbLossofmemoryYes, cbLossofmemoryNo),
        //                   getCheckBoxValue(cbBalanceProblemsYes, cbBalanceProblemsNo),

        //                   getCheckBoxValue(cbSevereHeadAchesYes, cbSevereHeadAchesNo),
        //                   getCheckBoxValue(cbVasculardiseaseYes, cbVasculardiseaseNo),
        //                   getCheckBoxValue(cbRestrictedMobilityYes, cbRestrictedMobilityNo),
        //                   getCheckBoxValue(cbBackJointProblemYes, cbBackJointProblemNo),
        //                   getCheckBoxValue(cbAmputationYes, cbAmputationNo),
        //                   getCheckBoxValue(cbFracturesDislocationYes, cbFracturesDislocationNo),
        //                   getCheckBoxValue(cbCovidYes, cbCovidNo),
        //                   getCheckBoxValue(cbRepatriatedYes, cbRepatriatedNo),
        //                   getCheckBoxValue(cbHospitalizedYes, cbHospitalizedNo),
        //                   getCheckBoxValue(cbSeaDutyYes, cbSeaDutyNo),
        //                   getCheckBoxValue(cbRevokeYes, cbRevokeNo),
        //                   getCheckBoxValue(cbConsiderDiseaseYes, cbConsiderDiseaseNo),
        //                   getCheckBoxValue(cbFitToPerformDuriesYes, cbFitToPerformDuriesNo),
        //                   getCheckBoxValue(cbAllergicToAnyMedicationYes, cbAllergicToAnyMedicationNo),
        //                   getCheckBoxValue(cbAllergicAlternativeSuplimentYes, cbAllergicAlternativeSuplimentNo),
        //                   txtAlternativeComment1.Text,
        //                   getCheckBoxValue(cbTakenMedicationsYes, cbTakenMedicationsNo),
        //                   txtmedicationsComment1.Text,
        //                                 txtExamineeComment1.Text,
        //                                 txtExamineeComment2.Text,
        //                                 txtExamineeComment3.Text,
        //                                 txtExamineeComment4.Text,
        //                                 txtExamineeComment5.Text,
        //                                 txtAlternativeComment2.Text,
        //                                 txtAlternativeComment3.Text,
        //                                 txtAlternativeComment4.Text,
        //                                 txtAlternativeComment5.Text,
        //                                 txtmedicationsComment2.Text,
        //                                 txtmedicationsComment3.Text,
        //                                txtmedicationsComment4.Text,
        //    txtmedicationsComment5.Text,
        //    txtAlternativeComment6.Text);
        //}

        //private void PanamaDataRelatedCovidSave(string papin, string uid)
        //{
        //    PanamaDataRelatedCovidModel dataRelatedCovid = new PanamaDataRelatedCovidModel();
        //    dataRelatedCovid.Save(papin,
        //        uid,
        //        getCheckBoxValue(cbContactInCovidPositiveYes, cbContactInCovidPositiveNo),
        //        getCheckBoxValue(cbCovidTestYes, cbCovidTestNo),
        //        dtCovidDateTest.Text,
        //        getCheckBoxValue(cbHadFeverLast30DaysYes, cbHadFeverLast30DaysNo),
        //        getCheckBoxValue(cbVaccinationCovidYes, cbVaccinationCovidNo),
        //        txtVaccineType.Text,
        //        txtNumberofDoses.Text,
        //        txtBooster.Text);
        //}

        //private void PanamaStatementsSave(string papin, string uid)
        //{
        //    string d = string.Concat(txtStaetementDay.Text, "/", txtStaetementMonth.Text, "/", txtStaetementYear.Text);
        //    string p = string.Concat(txtp4Day.Text, "/", txtp4Month.Text, "/", txtp4Year.Text);
        //    PanamaStatementsModel statement = new PanamaStatementsModel();
        //    statement.Save(papin,
        //        uid,
        //        txtPersonundergoingExamination.Text,
        //       d,
        //        txtNameOfWitness.Text,
        //        txtDoctorName.Text,
        //        txtUndergoingExamination.Text,
        //        p,
        //        txtNameOfWitness2.Text,
        //        txtPreviousMedical.Text);
        //}

        //private void PanamaMedicalExaminationSave(string papin, string uid)
        //{
        //    PanamaMedicalExaminationModel medicalExamination = new PanamaMedicalExaminationModel();
        //    medicalExamination.Save(papin,
        //        uid,
        //        txtHeight.Text,
        //        txtWeight.Text,
        //        txtBMI.Text,
        //        txtOxygen.Text,
        //        txtHeartRate.Text,
        //        txtRespiratory.Text,
        //        txtBloodPressure.Text,
        //        txtDiastolic.Text,
        //        txtUnaidedRightEyeDistant.Text,
        //        txtUnAidedLeftEyeDistant.Text,
        //        txtUnAidedBonocularDistant.Text,
        //        txtAidedRightEyeDistant.Text,
        //        txtAidedLeftEyeDistant.Text,
        //        txtAidedBinocularDistant.Text,
        //        txtUnaidedRightEyeShort.Text,
        //        txtUnAidedLeftEyeShort.Text,
        //        txtUnAidedBonocularShort.Text,
        //        txtAidedRightEyeShort.Text,
        //        txtAidedLeftEyeShort.Text,
        //        txtAidedBinocularShort.Text,
        //        getCheckBoxValue(cbNonTestedColorVision, cbHidden),
        //        getCheckBoxValue(cbNormalColorVision, cbHidden),
        //        getCheckBoxValue(cbDoubtfulColorVision, cbHidden),
        //        getCheckBoxValue(cbDefectiveColorVision, cbHidden),
        //        txtNormalRightEye.Text,
        //        txtNormalLeftEye.Text,
        //        txtDefectiveRightEye.Text,
        //        txtDefectiveLeftEye.Text,
        //        txtSightComment.Text,
        //        txt500HzRightEar.Text,
        //        txt1kRightEar.Text,
        //        txt2kRightEar.Text,
        //        txt3kRightEar.Text,
        //        txt500HzLeftEar.Text,
        //        txt1kLeftEar.Text,
        //        txt2kLeftEar.Text,
        //        txt3kLeftEar.Text);

        //}

        //public void PanamaPhysicalExplorationSave(string papin, string uid)
        //{
        //    PanamaPhysicalExplorationModel physicalExploration = new PanamaPhysicalExplorationModel();
        //    physicalExploration.Save(papin, uid,
        //        getCheckBoxValue(cbHeadYes, cbHeadNo),
        //        getCheckBoxValue(cbMouthYes, cbMouthNo),
        //        getCheckBoxValue(cbDental, cbDentalNo),
        //        getCheckBoxValue(cbEars, cbEarsNo),
        //        getCheckBoxValue(cbTympanic, cbTympanicNo),
        //        getCheckBoxValue(cbEyes, cbEyesNo),
        //        getCheckBoxValue(cbPupils, cbPupilsNo),
        //        getCheckBoxValue(cbOfThalmoscopy, cbOfThalmoscopyNo),
        //        getCheckBoxValue(cbEyeMovement, cbEyeMovementNo),
        //        getCheckBoxValue(cbLungs, cbLungsNo),
        //        getCheckBoxValue(cbBreast, cbBreastNo),
        //        getCheckBoxValue(cbHeart, cbHeartNo),
        //        getCheckBoxValue(cbSkin, cbSkinNo),
        //        getCheckBoxValue(cbVaricoseVenis, cbVaricoseVenisNo),
        //        getCheckBoxValue(cbVascular, cbVascularNo),
        //        getCheckBoxValue(cbAbnomen, cbAbnomenNo),
        //        getCheckBoxValue(cbHernias, cbHerniasNo),
        //        getCheckBoxValue(cbAnus, cbAnusNo),
        //        getCheckBoxValue(cbGu, cbGuNo),
        //        getCheckBoxValue(cbUpper, cbUpperNo),
        //        getCheckBoxValue(cbSpine, cbSpineNo),
        //        getCheckBoxValue(cbNeurologic, cbNeurologicNo),
        //        getCheckBoxValue(cbPsychiatric, cbPsychiatricNo),
        //        getCheckBoxValue(cbGeneralAppearance, cbGeneralAppearanceNo),
        //        txtPhysicalExploration1.Text,
        //        txtPhysicalExploration2.Text,
        //        txtPhysicalExploration3.Text,
        //        txtPhysicalExploration4.Text);
        //}

        //public void PanamaDiagnosticTestSave(string papin, string uid)
        //{
        //    PanamaDiagnosticTestModel diagnostic = new PanamaDiagnosticTestModel();
        //    diagnostic.Save(papin, uid,
        //        getCheckBoxValue(cbHemogram, cbHidden),
        //        txtHemogramNormal.Text,
        //        txtHemogramAbNormal.Text,
        //        txtHemogramOservation.Text,
        //        getCheckBoxValue(cbLipid, cbHidden),
        //        txtLipidNormal.Text,
        //        txtLipidAbNormal.Text,
        //        txtLipidObservation.Text,
        //        getCheckBoxValue(cbCreatinine, cbHidden),
        //        txtCreatinineNormal.Text,
        //        txtCreatinineAbnormal.Text,
        //        txtCreatinineObservation.Text,
        //        getCheckBoxValue(cbCholesterol, cbHidden),
        //        txtCholesterolNormal.Text,
        //        txtCholesterolAbnormal.Text,
        //        txtCholesterolObservation.Text,
        //        getCheckBoxValue(cbTriglycerides, cbHidden),
        //        txtTriglyceridesNormal.Text,
        //        txtTriglyceridesAbnormal.Text,
        //        txtTriglyceridesObservation.Text,
        //        getCheckBoxValue(cbGlucose, cbHidden),
        //        txtGlucoseNormal.Text,
        //        txtGlucoseAbNormal.Text,
        //        txtGlucoseObservation.Text,
        //        getCheckBoxValue(cbNitrogen, cbHidden),
        //        txtNitrogenNormal.Text,
        //        txtNitrogenAbnormal.Text,
        //        txtNitrogenObservation.Text,
        //        getCheckBoxValue(cbRhTyping, cbHidden),
        //        txtRhTypingNormal.Text,
        //        txtRhTypingAbnormal.Text,
        //        txtRhTypingObservation.Text,
        //        getCheckBoxValue(cbHiv, cbHidden),
        //        txtHivNormal.Text,
        //        txtHivAbnormal.Text,
        //        txtHivObservation.Text,
        //        getCheckBoxValue(cbVdrl, cbHidden),
        //        txtVdrlNormal.Text,
        //        txtVdrlAbnormal.Text,
        //        txtVdrlObservation.Text,
        //        getCheckBoxValue(cbGch, cbHidden),
        //        txtGchNormal.Text.Replace("/", ""),
        //        txtGchAbnormal.Text,
        //        txtGchObservation.Text,
        //        getCheckBoxValue(cbGeneralUrien, cbHidden),
        //        txtGeneralUrineNormal.Text,
        //        txtGeneralUrineAbNormal.Text,
        //        txtGeneralUrineObservation.Text,
        //        getCheckBoxValue(cbStool, cbHidden),
        //        txtStoolNormal.Text,
        //        txtStoolAbNormal.Text,
        //        txtStoolObservation.Text,
        //        getCheckBoxValue(cbDrugtest, cbHidden),
        //        txtDrugTestNormal.Text,
        //        txtDrugTestAbNormal.Text,
        //        txtDrugTestObservation.Text,
        //        getCheckBoxValue(cbAlcohol, cbHidden),
        //        txtAlcoholNormal.Text,
        //        txtAlcoholAbNormal.Text,
        //        txtAlcoholObservation.Text,
        //        getCheckBoxValue(cbBreast, cbHidden),
        //        txtBreastExaminationNormal.Text.Replace("/", ""),
        //        txtBreastExaminationAbNormal.Text,
        //        txtBreastExaminationObservation.Text,
        //        getCheckBoxValue(cbPapTest, cbHidden),
        //        txtPaptestJNormal.Text.Replace("/", ""),
        //        txtPapAbnormal.Text,
        //        txtPapObservation.Text,
        //        getCheckBoxValue(cbPsa, cbHidden),
        //        txtPsaNormal.Text.Replace("/", ""),
        //        txtPsaAbNormal.Text,
        //        txtPsaObservation.Text,
        //        getCheckBoxValue(cbXray, cbHidden),
        //        dtXrayDate.Text,
        //        txtXrayObservation.Text,
        //        getCheckBoxValue(cbEkg, cbHidden),
        //        dtEkg.Text,
        //        txtEkgObservation.Text,
        //        txtSarsCovidByPcr.Text,
        //        txtSarsCovidByAntigens.Text,
        //        txtOtherDiagnosticTest.Text,
        //        txtOtherDiagnosticResult.Text,
        //        txtOtherDiagnosticComment1.Text,
        //        txtOtherDiagnosticComment2.Text,
        //        txtOtherDiagnosticComment3.Text,
        //        txtOtherDiagnosticComment4.Text);

        //}

        //private void PanamaResultMainSave(string papin, string uid)
        //{
        //    string expiration = string.Concat(expirateDay.Text, "-", expirateMonth.Text, "-", expirateYear.Text);
        //    string issued = string.Concat(issuedDay.Text, "-", issuedMonth.Text, "-", issuedYear.Text);

        //    PanamaResultMainModel resultMain = new PanamaResultMainModel();
        //    resultMain.Save(uid,
        //                    papin,
        //                   getRadioButtonValue(rbFitForLookOut),
        //                   getRadioButtonValue(rbNonFitForLookOut),
        //                   getCheckBoxValue(cbDeckServiceFit, cbHidden),
        //                   getCheckBoxValue(cbEngineFit, cbHidden),
        //                   getCheckBoxValue(cbCateringFit, cbHidden),
        //                   getCheckBoxValue(cbOtherServiceFit, cbHidden),
        //                   getCheckBoxValue(cbDeckServiceUnFit, cbHidden),
        //                   getCheckBoxValue(cbEngineUnFit, cbHidden),
        //                   getCheckBoxValue(cbCateringUnFit, cbHidden),
        //                   getCheckBoxValue(cbOtherUnFit, cbHidden),
        //                   getCheckBoxValue(cbWithOutRestrictions, cbHidden),
        //                   getCheckBoxValue(cbWithRestrictions, cbHidden),
        //                   getCheckBoxValue(cbVisualAidYes, cbHidden),
        //                   getCheckBoxValue(cbVisualAidYes, cbVisualAidRequiredNo),
        //                    txtAssessmentComment1.Text,
        //                    expiration,
        //                   issued,
        //                    txtNumberOfMedicalCertificate.Text,
        //                    txtPhysicianName.Text,
        //                    txtAssessmentComment2.Text,
        //                    txtAssessmentComment3.Text,
        //                    txtAssessmentComment4.Text,
        //                     txtAssessmentComment5.Text);
        //}



        private void rbCoastal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private string getCheckBoxValue(RadioButton cbYes)
        {
            string val = "No";
            if (cbYes.Checked == true)
            {
                val = "Yes";
            }


            return val;
        }


        private string getCheckBoxValue(CheckBox cbYes)
        {
            string val = "No";
            if (cbYes.Checked == true)
            {
                val = "Yes";
            }


            return val;
        }


        private void setRadioButtonValue(RadioButton cbYes, RadioButton cbNo, string val)
        {
            if (val == "Yes")
            {
                cbYes.Checked = true;
                cbNo.Checked = false;

            }
            else
            {
                cbYes.Checked = false;
                cbNo.Checked = true;
            }

        }

        private void setCheckBoxValue(CheckBox cbYes, CheckBox cbNo, string val)
        {
            if (val == "Yes")
            {
                cbYes.Checked = true;
                cbNo.Checked = false;

            }
            else
            {
                cbYes.Checked = false;
                cbNo.Checked = true;
            }

        }

        private void validateDate(string dt, DateTimePicker dtp, CheckBox cb)
        {


            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";

            DateTime val;
            if (DateTime.TryParse(dt, out val) == true)
            {
                dtp.CustomFormat = "dd/MM/yyyy";
                dtp.Value = Convert.ToDateTime(dt).Date;
                cb.Checked = false;

            }
            else
            {
                dtp.CustomFormat = "00/00/0000";
                cb.Checked = true; ;
            }
        }



        private string getRadioButtonValue(CheckBox cb)
        {
            string val = "No";
            if (cb.Checked)
            {
                val = "Yes";
            }
            return val;
        }

        private void setRadioButtonValue(CheckBox rb, string val)
        {
            rb.Checked = true;
            if (val == "Yes")
            {
                rb.Checked = true;
            }
            else
            {
                rb.Checked = false;
            }

        }


        public void navigateNextPage()
        {
            ////(Application.OpenForms["MainForm"] as MainForm).btnNextPage.Enabled = true;
            //if (tabControl1.SelectedTab == tabPage1)
            //{
            //    tabControl1.SelectedTab = tabPage2;
            //    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 2";
            //}
            //else if (tabControl1.SelectedTab == tabPage2)
            //{
            //    tabControl1.SelectedTab = tabPage3;
            //    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 3";
            //}
            //else if (tabControl1.SelectedTab == tabPage3)
            //{
            //    tabControl1.SelectedTab = tabPage4;

            //    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 4";
            //}
            //else if (tabControl1.SelectedTab == tabPage4)
            //{
            //    tabControl1.SelectedTab = tabPage5;
            //    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 5";
            //}
            //else if (tabControl1.SelectedTab == tabPage5)
            //{
            //    tabControl1.SelectedTab = tabPage6;
            //    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 6";
            //}
            //else if (tabControl1.SelectedTab == tabPage6)
            //{
            //    tabControl1.SelectedTab = tabPage7;
            //    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 7";
            //}
            //else if (tabControl1.SelectedTab == tabPage7)
            //{
            //    tabControl1.SelectedTab = tabPage8;
            //    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 8";
            //    //(Application.OpenForms["MainForm"] as MainForm).btnNextPage.Enabled = false;
            //}
            ////else if (tabControl1.SelectedTab == tabPage8)
            ////{
            ////    tabControl1.SelectedTab = tabPage1;
            ////    (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 1";
            ////}





        }

        //public void navigatePreviousPage()
        //{
        //    //(Application.OpenForms["MainForm"] as MainForm).btnPreviousPage.Enabled = true;
        //    if (tabControl1.SelectedTab == tabPage8)
        //    {
        //        tabControl1.SelectedTab = tabPage7;
        //        (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 7";
        //    }
        //    else if (tabControl1.SelectedTab == tabPage7)
        //    {
        //        tabControl1.SelectedTab = tabPage6;
        //        (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 6";
        //    }
        //    else if (tabControl1.SelectedTab == tabPage6)
        //    {
        //        tabControl1.SelectedTab = tabPage5;
        //        (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 5";
        //    }
        //    else if (tabControl1.SelectedTab == tabPage5)
        //    {
        //        tabControl1.SelectedTab = tabPage4;
        //        (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 4";
        //    }
        //    else if (tabControl1.SelectedTab == tabPage4)
        //    {
        //        tabControl1.SelectedTab = tabPage3;
        //        (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 3";
        //    }
        //    else if (tabControl1.SelectedTab == tabPage3)
        //    {
        //        tabControl1.SelectedTab = tabPage2;

        //        (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 2";

        //    }
        //    else if (tabControl1.SelectedTab == tabPage2)
        //    {
        //        tabControl1.SelectedTab = tabPage1;
        //        (Application.OpenForms["MainForm"] as MainForm).lblPageLabel.Text = "Page 1";
        //        //(Application.OpenForms["MainForm"] as MainForm).btnPreviousPage.Enabled =  false;


        //    }

        //}
        private void FormPanama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                savePanamaRecord(true);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
            {
                OpenSearchList();
            }





        }

        public void OpenSearchList()
        {
            //using (FromSearchPanama frmSearch = new FromSearchPanama(this))
            //{
            //    frmSearch.ShowDialog();
            //}
        }

        private void txtNumberOfMedicalCertificate_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSeaDutyYes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPsaNormal_TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox1_onTextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel55_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmPanama_Load_1(object sender, EventArgs e)
        {

        }

        private void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void cbLipid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmPanama_Enter(object sender, EventArgs e)
        {

            Panama_SeaMLC_model.Clear();
            if (!backgroundWorker1.IsBusy)
            { backgroundWorker1.RunWorkerAsync(); }
        }

        private void txtPapin_TextChanged(object sender, EventArgs e)
        {
            if (txtPapin.Text != "")
            {
                searchPatient(txtPapin.Text);
            }

        }




        private void PanamaExamineePersonalDeclarationSave(string papin, string uid)
        {
            PanamaExamineeModel examinee = new PanamaExamineeModel();
            examinee.Save(papin,
                           uid,
                           getCheckBoxValue(cbHighBloodPressureYes),
                           getCheckBoxValue(cbEyeproblemYes),
                           getCheckBoxValue(cbEarNoseThroatYes),
                           getCheckBoxValue(cbHeartSurgeryYes),
                           getCheckBoxValue(cbVaricoseveinsYes),
                           getCheckBoxValue(cbAsthmaBronchitisYes),
                           getCheckBoxValue(cbBloodDisorderYes),
                           getCheckBoxValue(cbDiabetesYes_),
                           getCheckBoxValue(cbThyroidProblemYes),
                           getCheckBoxValue(cbDigestiveDisordersYes),

                           getCheckBoxValue(cbKidneyDisordersYes),
                           getCheckBoxValue(cbSkinProblemYes),
                           getCheckBoxValue(cbAllergiesYes),
                           getCheckBoxValue(cbEpilipsyYes),
                           getCheckBoxValue(cbSickleCellYes),
                           getCheckBoxValue(cbHerinasYes),
                           getCheckBoxValue(cbGenitalDisordersYes),
                           getCheckBoxValue(cbPregnancyYes),

                           getCheckBoxValue(cbSleepproblemYes),
                           getCheckBoxValue(cbDoyouSmokeYes),
                           getCheckBoxValue(cbSurgeriesYes),
                           getCheckBoxValue(cbInfectiousYes),
                           getCheckBoxValue(cbDizzinessFaintingYes),
                           getCheckBoxValue(cbLossofconsciousnessYes),
                           getCheckBoxValue(cbPsychiatricProblemYes),
                           getCheckBoxValue(cbDepressionYes),
                           getCheckBoxValue(cbAttemptedsuicideYes),
                           getCheckBoxValue(cbLossofmemoryYes),

                           getCheckBoxValue(cbBalanceProblemsYes),
                           getCheckBoxValue(cbSevereHeadAchesYes),
                           getCheckBoxValue(cbVasculardiseaseYes),
                           getCheckBoxValue(cbRestrictedMobilityYes),

                           getCheckBoxValue(cbBackJointProblemYes),
                           getCheckBoxValue(cbAmputationYes),
                           getCheckBoxValue(cbFracturesDislocationYes),
                           getCheckBoxValue(cbCovidYes),
                           getCheckBoxValue(cbRepatriatedYes),
                           getCheckBoxValue(cbHospitalizedYes),
                           getCheckBoxValue(cbSeaDutyYes),
                           getCheckBoxValue(cbRevokeYes),
                           getCheckBoxValue(cbConsiderDiseaseYes),
                           getCheckBoxValue(cbFitToPerformDuriesYes),
                           getCheckBoxValue(cbAllergicToAnyMedicationYes),
                           getCheckBoxValue(cbAllergicAlternativeSuplimentYes),
                           txtAlternativeComment1.Text,
                           getCheckBoxValue(cbTakenMedicationsYes),
                           txtmedicationsComment1.Text,
                                         txtExamineeComment1.Text,
                                         txtExamineeComment2.Text,
                                         txtExamineeComment3.Text,
                                         txtExamineeComment4.Text,
                                         txtExamineeComment5.Text,
                                         txtAlternativeComment2.Text,
                                         txtAlternativeComment3.Text,
                                         txtAlternativeComment4.Text,
                                         txtAlternativeComment5.Text,
                                         txtmedicationsComment2.Text,
                                         txtmedicationsComment3.Text,
                                        txtmedicationsComment4.Text,
            txtmedicationsComment5.Text,
            txtAlternativeComment6.Text);
        }

        private void PanamaDataRelatedCovidSave(string papin, string uid)
        {
            PanamaDataRelatedCovidModel dataRelatedCovid = new PanamaDataRelatedCovidModel();
            dataRelatedCovid.Save(papin,
                uid,
                getCheckBoxValue(cbContactInCovidPositiveYes),
                getCheckBoxValue(cbCovidTestYes),
                txtCividTestDate.Text,
                getCheckBoxValue(cbHadFeverLast30DaysYes),
                getCheckBoxValue(cbVaccinationCovidYes),
                txtVaccineType.Text,
                txtNumberofDoses.Text,
                txtBooster.Text);
        }

        //private void PanamaStatementsSave(string papin, string uid)
        //{
        //    //string d = string.Concat(txtStaetementDay.Text, "/", txtStaetementMonth.Text, "/", txtStaetementYear.Text);
        //    string p = string.Concat(txtp4Day.Text, "/", txtp4Month.Text, "/", txtp4Year.Text);
        //    PanamaStatementsModel statement = new PanamaStatementsModel();
        //    statement.Save(papin,
        //        uid,
        //        txtPersonundergoingExamination.Text,
        //       txtundergoingExaminationDate.Text,
        //        txtNameOfWitness.Text,
        //        txtDoctorName.Text,
        //        txtUndergoingExamination.Text,
        //        p,
        //        txtNameOfWitness2.Text,
        //        txtPreviousMedical.Text);
        //}

        private string getCheckBoxValue(RadioButton cbYes, CheckBox cbNo)
        {
            string val = "No";
            if (cbYes.Checked == true)
            {
                val = "Yes";
            }
            else if (cbNo.Checked == true)
            {
                val = "No";
            }

            return val;
        }



        private void PanamaMedicalExaminationSave(string papin, string uid)
        {
            PanamaMedicalExaminationModel medicalExamination = new PanamaMedicalExaminationModel();
            medicalExamination.Save(papin,
                uid,
                txtHeight.Text,
                txtWeight.Text,
                txtBMI.Text,
                txtOxygen.Text,
                txtHeartRate.Text,
                txtRespiratory.Text,
                txtBloodPressure.Text,
                txtDiastolic.Text,
                txtUnaidedRightEyeDistant.Text,
                txtUnAidedLeftEyeDistant.Text,
                txtUnAidedBonocularDistant.Text,
                txtAidedRightEyeDistant.Text,
                txtAidedLeftEyeDistant.Text,
                txtAidedBinocularDistant.Text,
                txtUnaidedRightEyeShort.Text,
                txtUnAidedLeftEyeShort.Text,
                txtUnAidedBonocularShort.Text,
                txtAidedRightEyeShort.Text,
                txtAidedLeftEyeShort.Text,
                txtAidedBinocularShort.Text,
                getCheckBoxValue(cbNonTestedColorVision, cbHidden),
                getCheckBoxValue(cbNormalColorVision, cbHidden),
                getCheckBoxValue(cbDoubtfulColorVision, cbHidden),
                getCheckBoxValue(cbDefectiveColorVision, cbHidden),
                txtNormalRightEye.Text,
                txtNormalLeftEye.Text,
                txtDefectiveRightEye.Text,
                txtDefectiveLeftEye.Text,
                txtSightComment.Text,
                txt500HzRightEar.Text,
                txt1kRightEar.Text,
                txt2kRightEar.Text,
                txt3kRightEar.Text,
                txt500HzLeftEar.Text,
                txt1kLeftEar.Text,
                txt2kLeftEar.Text,
                txt3kLeftEar.Text);

        }

        public void PanamaPhysicalExplorationSave(string papin, string uid)
        {
            PanamaPhysicalExplorationModel physicalExploration = new PanamaPhysicalExplorationModel();
            physicalExploration.Save(papin,
                uid,
                getCheckBoxValue(cbHeadYes),
                getCheckBoxValue(cbMouthYes),
                getCheckBoxValue(cbDental),
                getCheckBoxValue(cbEars),
                getCheckBoxValue(cbTympanic),
                getCheckBoxValue(cbEyes),
                getCheckBoxValue(cbPupils),
                getCheckBoxValue(cbOfThalmoscopy),
                getCheckBoxValue(cbEyeMovement),
                getCheckBoxValue(cbLungs),
                getCheckBoxValue(cbBreast),
                getCheckBoxValue(cbHeart),
                getCheckBoxValue(cbSkin),
                getCheckBoxValue(cbVaricoseVenis),
                getCheckBoxValue(cbVascular),
                getCheckBoxValue(cbAbnomen),
                getCheckBoxValue(cbHernias),
                getCheckBoxValue(cbAnus),
                getCheckBoxValue(cbGu),
                getCheckBoxValue(cbUpper),
                getCheckBoxValue(cbSpine),
                getCheckBoxValue(cbNeurologic),
                getCheckBoxValue(cbPsychiatric),
                getCheckBoxValue(cbGeneralAppearance),
                txtPhysicalExploration1.Text,
                txtPhysicalExploration2.Text,
                txtPhysicalExploration3.Text,
                txtPhysicalExploration4.Text);
        }

        //private string getRadioButtonValue(CheckBox cb)
        //{
        //    string val = "No";
        //    if (cb.Checked)
        //    {
        //        val = "Yes";
        //    }
        //    return val;
        //}


        public void PanamaDiagnosticTestSave(string papin, string uid)
        {
            PanamaDiagnosticTestModel diagnostic = new PanamaDiagnosticTestModel();
            diagnostic.Save(papin, uid,
                getCheckBoxValue(cbHemogram),
                txtHemogramNormal.Text,
                txtHemogramAbNormal.Text,
                txtHemogramOservation.Text,
                getCheckBoxValue(cbLipid),
                txtLipidNormal.Text,
                txtLipidAbNormal.Text,
                txtLipidObservation.Text,
                getCheckBoxValue(cbCreatinine),
                txtCreatinineNormal.Text,
                txtCreatinineAbnormal.Text,
                txtCreatinineObservation.Text,
                getCheckBoxValue(cbCholesterol),
                txtCholesterolNormal.Text,
                txtCholesterolAbnormal.Text,
                txtCholesterolObservation.Text,
                getCheckBoxValue(cbTriglycerides),
                txtTriglyceridesNormal.Text,
                txtTriglyceridesAbnormal.Text,
                txtTriglyceridesObservation.Text,
                getCheckBoxValue(cbGlucose),
                txtGlucoseNormal.Text,
                txtGlucoseAbNormal.Text,
                txtGlucoseObservation.Text,
                getCheckBoxValue(cbNitrogen),
                txtNitrogenNormal.Text,
                txtNitrogenAbnormal.Text,
                txtNitrogenObservation.Text,
                getCheckBoxValue(cbRhTyping),
                txtRhTypingNormal.Text,
                txtRhTypingAbnormal.Text,
                txtRhTypingObservation.Text,
                getCheckBoxValue(cbHiv),
                txtHivNormal.Text,
                txtHivAbnormal.Text,
                txtHivObservation.Text,
                getCheckBoxValue(cbVdrl),
                txtVdrlNormal.Text,
                txtVdrlAbnormal.Text,
                txtVdrlObservation.Text,
                getCheckBoxValue(cbGch),
                txtGchNormal.Text.Replace("/", ""),
                txtGchAbnormal.Text,
                txtGchObservation.Text,
                getCheckBoxValue(cbGeneralUrien),
                txtGeneralUrineNormal.Text,
                txtGeneralUrineAbNormal.Text,
                txtGeneralUrineObservation.Text,
                getCheckBoxValue(cbStool),
                txtStoolNormal.Text,
                txtStoolAbNormal.Text,
                txtStoolObservation.Text,
                getCheckBoxValue(cbDrugtest),
                txtDrugTestNormal.Text,
                txtDrugTestAbNormal.Text,
                txtDrugTestObservation.Text,
                getCheckBoxValue(cbAlcohol),
                txtAlcoholNormal.Text,
                txtAlcoholAbNormal.Text,
                txtAlcoholObservation.Text,
                getCheckBoxValue(cbBreastExamination),
                txtBreastExaminationNormal.Text.Replace("/", ""),
                txtBreastExaminationAbNormal.Text,
                txtBreastExaminationObservation.Text,
                getCheckBoxValue(cbPapTest),
                txtPaptestJNormal.Text.Replace("/", ""),
                txtPapAbnormal.Text,
                txtPapObservation.Text,
                getCheckBoxValue(cbPsa),
                txtPsaNormal.Text.Replace("/", ""),
                txtPsaAbNormal.Text,
                txtPsaObservation.Text,
                getCheckBoxValue(cbXray),
                txtXrayPerformed.Text,
                txtXrayObservation.Text,
                getCheckBoxValue(cbEkg),
                txtEZGPerformed.Text,
                txtEkgObservation.Text,
                txtSarsCovidByPcr.Text,
                txtSarsCovidByAntigens.Text,
                txtOtherDiagnosticTest.Text,
                txtOtherDiagnosticResult.Text,
                txtOtherDiagnosticComment1.Text,
                txtOtherDiagnosticComment2.Text,
                txtOtherDiagnosticComment3.Text,
                txtOtherDiagnosticComment4.Text);

        }



        private string getRadioButtonValue(RadioButton cb)
        {
            string val = "No";
            if (cb.Checked)
            {
                val = "Yes";
            }
            return val;
        }

        public void searchPanamaRecord(string papin)
        {
            txtPapin.Text = papin;

            searchPanamaPatient();
            searchPanamaExamineePersonalDeclaration();
            searchPanamaDataRelatedCovid();
            searchPanamaMedicalExamination();
            searchPhysicalExploration();
            searchsearchPhysicalExploration();
            searchPanamaResultMain();



        }

        private void searchPanamaResultMain()
        {
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
            var i = db.PanamaResultMainSelect(txtResultID.Text, txtPapin.Text).FirstOrDefault();

            if (i != null)
            {





                cbWithRestrictions.Checked = true;
                if (i.WithOutRestrictions.Equals("Yes"))
                {
                    cbWithOutRestrictions.Checked = true;
                }

                cbWithOutRestrictions.Checked = true;
                if (i.WithRestrictions.Equals("Yes"))
                {
                    cbWithRestrictions.Checked = true;
                }



                txtAssessmentComment1.Text = i.assessmentComment1;
                txtAssessmentComment2.Text = i.assessmentComment2;
                txtAssessmentComment3.Text = i.assessmentComment3;
                txtAssessmentComment4.Text = i.assessmentComment4;
                txtAssessmentComment5.Text = i.assessmentComment5;




                string deck_srvc_flag_ = i.DeckServiceFit.ToString();
                if (deck_srvc_flag_ == "Yes") { cbDeckServiceFit.Checked = true; } else if (deck_srvc_flag_ == "No") { cbDeckServiceUnFit.Checked = true; } else { cbDeckServiceFit.Checked = false; cbDeckServiceUnFit.Checked = false; }

                string t_engine_srvc_flag_ = i.EngineFit.ToString();
                if (t_engine_srvc_flag_ == "Yes") { this.cbEngineFit.Checked = true; } else if (t_engine_srvc_flag_ == "No") { this.cbEngineUnFit.Checked = true; } else { cbEngineFit.Checked = false; cbEngineUnFit.Checked = false; }

                string t_catering_srvc_flag_ = i.CateringFit.ToString();
                if (t_catering_srvc_flag_ == "Yes") { this.cbCateringFit.Checked = true; } else if (t_catering_srvc_flag_ == "No") { this.cbCateringUnFit.Checked = true; } else { cbCateringFit.Checked = false; cbCateringUnFit.Checked = false; }

                string t_other_srvc_flag_ = i.OtherServiceFit.ToString();
                if (t_other_srvc_flag_ == "Yes") { this.cbOtherServiceFit.Checked = true; } else if (t_other_srvc_flag_ == "No") { this.cbOtherUnFit.Checked = true; } else { cbOtherServiceFit.Checked = false; cbOtherUnFit.Checked = false; }





                txtNumberOfMedicalCertificate.Text = i.NumberOfMedicalCertificate;
                txtPhysicianName.Text = "MA. LUCIA B. LAGUIMUN, M.D.  -  License No. 77460";

            }
        }

        private void searchsearchPhysicalExploration()
        {
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
            var i = db.PanamaDiagnosticTestSelect(txtResultID.Text, txtPapin.Text).FirstOrDefault();

            if (i != null)
            {
                //DIAGNOSTIC TEST AND RESULTS 
                setCheckBoxValue(cbHemogram, cbHidden, i.Hemogram);
                txtHemogramNormal.Text = i.HemogramNormal;
                txtHemogramAbNormal.Text = i.HemogramAbNormal;
                txtHemogramOservation.Text = i.HemogramOservation;
                setCheckBoxValue(cbLipid, cbHidden, i.Lipid);
                txtLipidNormal.Text = i.LipidNormal;
                txtLipidAbNormal.Text = i.LipidAbNormal; ;
                txtLipidObservation.Text = i.LipidObservation;
                setCheckBoxValue(cbCreatinine, cbHidden, i.Creatinine);
                txtCreatinineNormal.Text = i.CreatinineNormal;
                txtCreatinineAbnormal.Text = i.CreatinineAbnormal;
                txtCreatinineObservation.Text = i.CreatinineObservation;
                setCheckBoxValue(cbCholesterol, cbHidden, i.Cholesterol);
                txtCholesterolNormal.Text = i.CholesterolNormal;
                txtCholesterolAbnormal.Text = i.CholesterolAbnormal;
                txtCholesterolObservation.Text = i.CholesterolObservation;
                setCheckBoxValue(cbTriglycerides, cbHidden, i.Triglycerides);
                txtTriglyceridesNormal.Text = i.TriglyceridesNormal;
                txtTriglyceridesAbnormal.Text = i.TriglyceridesAbnormal;
                txtTriglyceridesObservation.Text = i.TriglyceridesObservation;
                setCheckBoxValue(cbGlucose, cbHidden, i.Glucose);
                txtGlucoseNormal.Text = i.GlucoseNormal;
                txtGlucoseAbNormal.Text = i.GlucoseAbNormal;
                txtGlucoseObservation.Text = i.GlucoseObservation;
                setCheckBoxValue(cbNitrogen, cbHidden, i.Nitrogen);
                txtNitrogenNormal.Text = i.NitrogenNormal;
                txtNitrogenAbnormal.Text = i.NitrogenAbnormal;
                txtNitrogenObservation.Text = i.NitrogenObservation;
                setCheckBoxValue(cbRhTyping, cbHidden, i.RhTyping);
                txtRhTypingNormal.Text = i.RhTypingNormal;
                txtRhTypingAbnormal.Text = i.RhTypingAbnormal;
                txtRhTypingObservation.Text = i.RhTypingObservation;
                setCheckBoxValue(cbHiv, cbHidden, i.Hiv);
                txtHivNormal.Text = i.HivNormal;
                txtHivAbnormal.Text = i.HivAbnormal;
                txtHivObservation.Text = i.HivObservation;
                setCheckBoxValue(cbVdrl, cbHidden, i.Vdrl);
                txtVdrlNormal.Text = i.VdrlNormal;
                txtVdrlAbnormal.Text = i.VdrlAbnormal;
                txtVdrlObservation.Text = i.VdrlObservation;
                setCheckBoxValue(cbGch, cbHidden, i.Gch);
                txtGchNormal.Text = i.GchNormal.Replace("NA", "N/A");
                txtGchAbnormal.Text = i.GchAbnormal;
                txtGchObservation.Text = i.GchObservation;
                setCheckBoxValue(cbGeneralUrien, cbHidden, i.GeneralUrien);
                txtGeneralUrineNormal.Text = i.GeneralUrineNormal;
                txtGeneralUrineAbNormal.Text = i.GeneralUrineAbNormal;
                txtGeneralUrineObservation.Text = i.GeneralUrineObservation;
                setCheckBoxValue(cbStool, cbHidden, i.Stool);
                txtStoolNormal.Text = i.StoolNormal;
                txtStoolAbNormal.Text = i.StoolAbNormal;
                txtStoolObservation.Text = i.StoolObservation;
                setCheckBoxValue(cbDrugtest, cbHidden, i.Drugtest);
                txtDrugTestNormal.Text = i.DrugTestNormal;
                txtDrugTestAbNormal.Text = i.DrugTestAbNormal;
                txtDrugTestObservation.Text = i.DrugTestObservation;
                setCheckBoxValue(cbAlcohol, cbHidden, i.Alcohol);
                txtAlcoholNormal.Text = i.AlcoholNormal;
                txtAlcoholAbNormal.Text = i.AlcoholAbNormal;
                txtAlcoholObservation.Text = i.AlcoholObservation;

                setCheckBoxValue(cbBreastExamination, cbHidden, i.Breast);

                txtBreastExaminationNormal.Text = i.BreastExaminationNormal.Replace("NA", "N/A");
                txtBreastExaminationAbNormal.Text = i.BreastExaminationAbNormal;
                txtBreastExaminationObservation.Text = i.BreastExaminationObservation;
                setCheckBoxValue(cbPapTest, cbHidden, i.PapTest);
                txtPaptestJNormal.Text = i.PaptestJNormal.Replace("NA", "N/A");
                txtPapAbnormal.Text = i.PapAbnormal;
                txtPapObservation.Text = i.PapObservation;
                setCheckBoxValue(cbPsa, cbHidden, i.Psa);
                txtPsaNormal.Text = i.PsaNormal.Replace("NA", "N/A");
                txtPsaAbNormal.Text = i.PsaAbNormal;
                txtPsaObservation.Text = i.PsaObservation;
                setCheckBoxValue(cbXray, cbHidden, i.Xray);

                //validateDate(i.XrayDate, dtXrayDate, checkBox109);
                txtXrayPerformed.Text = i.XrayDate;
                txtXrayObservation.Text = i.XrayObservation;
                setCheckBoxValue(cbEkg, cbHidden, i.Ekg);
                //validateDate(i.Ekg, dtEkg, checkBox110);
                txtEZGPerformed.Text = i.Ekg;
                txtEkgObservation.Text = i.EkgObservation;


                txtSarsCovidByPcr.Text = i.SarsCovidByPcr;
                txtSarsCovidByAntigens.Text = i.SarsCovidByAntigens;


                txtOtherDiagnosticTest.Text = i.OtherTest;
                txtOtherDiagnosticResult.Text = i.OtherTestResult;
                txtOtherDiagnosticComment1.Text = i.DiagnosticComment1;
                txtOtherDiagnosticComment2.Text = i.DiagnosticComment2;
                txtOtherDiagnosticComment3.Text = i.DiagnosticComment3;
                txtOtherDiagnosticComment4.Text = i.DiagnosticComment4;



            }
        }

        private void searchPhysicalExploration()
        {
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);

            var i = db.PanamaPhysicalExplorationSelect(txtPapin.Text, txtResultID.Text).FirstOrDefault();


            if (i != null)
            {
                //PHYSICAL EXPLORATION
                setRadioButtonState(cbHeadYes, cbHeadNo, i.Head);
                setRadioButtonState(cbMouthYes, cbMouthNo, i.Mouth);
                setRadioButtonState(cbDental, cbDentalNo, i.Dental);
                setRadioButtonState(cbEars, cbEarsNo, i.Ears);
                setRadioButtonState(cbTympanic, cbTympanicNo, i.Tympanic);
                setRadioButtonState(cbEyes, cbEyesNo, i.Eyes);
                setRadioButtonState(cbPupils, cbPupilsNo, i.Pupils);
                setRadioButtonState(cbOfThalmoscopy, cbOfThalmoscopyNo, i.OfThalmoscopy);
                setRadioButtonState(cbEyeMovement, cbEyeMovementNo, i.EyeMovement);
                setRadioButtonState(cbLungs, cbLungsNo, i.Lungs);
                setRadioButtonState(cbBreast, cbBreastNo, i.Breast);
                setRadioButtonState(cbHeart, cbHeartNo, i.Heart);
                setRadioButtonState(cbSkin, cbSkinNo, i.Skin);
                setRadioButtonState(cbVaricoseVenis, cbVaricoseVenisNo, i.VaricoseVenis);
                setRadioButtonState(cbVascular, cbVascularNo, i.Vascular);
                setRadioButtonState(cbAbnomen, cbAbnomenNo, i.Abdomen);
                setRadioButtonState(cbHernias, cbHerniasNo, i.Hernias);
                setRadioButtonState(cbAnus, cbAnusNo, i.Anus);
                setRadioButtonState(cbGu, cbGuNo, i.Gu);
                setRadioButtonState(cbUpper, cbUpperNo, i.Upper);
                setRadioButtonState(cbSpine, cbSpineNo, i.Spine);
                setRadioButtonState(cbNeurologic, cbNeurologicNo, i.Neurologic);
                setRadioButtonState(cbPsychiatric, cbPsychiatricNo, i.Psychiatric);
                setRadioButtonState(cbGeneralAppearance, cbGeneralAppearanceNo, i.GeneralAppearance);
                txtPhysicalExploration1.Text = i.PhysicalExplorationComment1;
                txtPhysicalExploration2.Text = i.PhysicalExplorationComment2;
                txtPhysicalExploration3.Text = i.PhysicalExplorationComment3;
                txtPhysicalExploration4.Text = i.PhysicalExplorationComment4;


            }
        }

        private void searchPanamaMedicalExamination()
        {
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);

            var i = db.PanamaClinicalDataSelect(txtPapin.Text, txtResultID.Text).FirstOrDefault();


            if (i != null)
            {
                //PanamaClinicalDataSelect
                txtHeight.Text = i.Height;
                txtWeight.Text = i.Weight;
                txtBMI.Text = i.BMI;
                txtOxygen.Text = i.Oxygen;
                txtHeartRate.Text = i.HeartRate;
                txtRespiratory.Text = i.Respiratory;
                txtBloodPressure.Text = i.BloodPressure;
                txtDiastolic.Text = i.Diatolic;

            }


            var sight = db.PanamaSightSelect(txtPapin.Text, txtResultID.Text).FirstOrDefault();


            if (sight != null)
            {
                //PanamaSightSelect

                txtUnaidedRightEyeDistant.Text = sight.UnaidedRightEyeDistant;
                txtUnAidedLeftEyeDistant.Text = sight.UnAidedLeftEyeDistant;
                txtUnAidedBonocularDistant.Text = sight.UnAidedBonocularDistant;
                txtAidedRightEyeDistant.Text = sight.AidedRightEyeDistant;
                txtAidedLeftEyeDistant.Text = sight.AidedLeftEyeDistant;
                txtAidedBinocularDistant.Text = sight.AidedBinocularDistant;
                txtUnaidedRightEyeShort.Text = sight.UnaidedRightEyeShort;
                txtUnAidedLeftEyeShort.Text = sight.UnAidedLeftEyeShort;
                txtUnAidedBonocularShort.Text = sight.UnAidedBonocularShort;
                txtAidedRightEyeShort.Text = sight.AidedRightEyeShort;
                txtAidedLeftEyeShort.Text = sight.AidedLeftEyeShort;
                txtAidedBinocularShort.Text = sight.AidedBinocularShort;


                if (sight.NonTestedColorVision.Equals("Yes"))
                {
                    cbNonTestedColorVision.Checked = true;
                }
                else if (sight.NormalColorVision.Equals("Yes"))
                {
                    cbNormalColorVision.Checked = true;
                }
                else if (sight.DoubtfulColorVision.Equals("Yes"))
                {
                    cbDoubtfulColorVision.Checked = true;
                }
                else if (sight.DefectiveColorVision.Equals("Yes"))
                {
                    cbDefectiveColorVision.Checked = true;
                }
                else
                {
                    cbNonTestedColorVision.Checked = false;
                    cbNormalColorVision.Checked = false;
                    cbDoubtfulColorVision.Checked = false;
                    cbDefectiveColorVision.Checked = false;
                }





                txtNormalRightEye.Text = sight.NormalRightEye;
                txtNormalLeftEye.Text = sight.NormalLeftEye;
                txtDefectiveRightEye.Text = sight.DefectiveRightEye;
                txtDefectiveLeftEye.Text = sight.DefectiveLeftEye;
                txtSightComment.Text = "ISHIHARA 38";


            }


            var hearing = db.PanamaHearingSelect(txtPapin.Text, txtResultID.Text).FirstOrDefault();


            if (hearing != null)
            {


                txt500HzRightEar.Text = hearing._500HzRightEar;
                txt1kRightEar.Text = hearing._1kRightEar;
                txt2kRightEar.Text = hearing._2kRightEar;
                txt3kRightEar.Text = hearing._3kRightEar;
                txt500HzLeftEar.Text = hearing._500HzLeftEar;
                txt1kLeftEar.Text = hearing._1kLeftEar;
                txt2kLeftEar.Text = hearing._2kLeftEar;
                txt3kLeftEar.Text = hearing._3kLeftEar;

            }









        }


        private void searchPanamaDataRelatedCovid()
        {
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);

            var i = db.PanamaDataRelatedCovidSelect(txtResultID.Text, txtPapin.Text).FirstOrDefault();


            if (i != null)
            {
                // Data Related  to covid
                setRadioButtonState(cbContactInCovidPositiveYes, cbContactInCovidPositiveNo, i.ContactInCovidPositive);
                setRadioButtonState(cbCovidTestYes, cbCovidTestNo, i.CovidTest);
                txtCividTestDate.Text = i.CovidDateTest;
                setRadioButtonState(cbHadFeverLast30DaysYes, cbHadFeverLast30DaysNo, i.HadFeverLast30Days);
                setRadioButtonState(cbVaccinationCovidYes, cbVaccinationCovidNo, i.VaccinationCovid);
                txtVaccineType.Text = i.VaccineType;
                txtNumberofDoses.Text = i.NumberofDoses;
                txtBooster.Text = i.Booster;


            }
        }

        private void searchPanamaExamineePersonalDeclaration()
        {
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);

            var i = db.PanamaExamineePersonalDeclarationSelect(txtPapin.Text, txtResultID.Text).FirstOrDefault();


            if (i != null)
            {
                //EXAMINEE PERSONAL DECLARATION
                setRadioButtonValue(cbHighBloodPressureYes, cbHighBloodPressureNo, i.HighBloodPressure);
                setRadioButtonValue(cbEyeproblemYes, cbEyeproblemNo, i.Eyeproblem);
                setRadioButtonValue(cbEarNoseThroatYes, cbEarNoseThroatNo, i.EarNoseThroat);
                setRadioButtonValue(cbHeartSurgeryYes, cbHeartSurgeryNo, i.HeartSurgery);
                setRadioButtonValue(cbVaricoseveinsYes, cbVaricoseveinsNo, i.Varicoseveins);
                setRadioButtonValue(cbAsthmaBronchitisYes, cbAsthmaBronchitisNo, i.AsthmaBronchitis);
                setRadioButtonValue(cbBloodDisorderYes, cbBloodDisorderNo, i.BloodDisorder);
                setRadioButtonValue(cbDiabetesYes_, cbDiabetesNo, i.Diabetes);
                setRadioButtonValue(cbThyroidProblemYes, cbThyroidProblemNo, i.ThyroidProblem);
                setRadioButtonValue(cbDigestiveDisordersYes, cbDigestiveDisordersNo, i.DigestiveDisorders);
                setRadioButtonValue(cbKidneyDisordersYes, cbKidneyDisordersNo_, i.KidneyDisorders);
                setRadioButtonValue(cbSkinProblemYes, cbSkinProblemNo, i.SkinProblem);
                setRadioButtonValue(cbAllergiesYes, cbAllergiesNo, i.Allergies);
                setRadioButtonValue(cbEpilipsyYes, cbEpilipsyNo, i.Epilipsy);
                setRadioButtonValue(cbSickleCellYes, cbSickleCellNo, i.SickleCell);
                setRadioButtonValue(cbHerinasYes, cbHerinasNo, i.Herinas);
                setRadioButtonValue(cbGenitalDisordersYes, cbGenitalDisordersNo, i.GenitalDisorders);
                setRadioButtonValue(cbPregnancyYes, cbPregnancyNo, i.Pregnancy);
                setRadioButtonValue(cbSleepproblemYes, cbSleepproblemNo, i.Sleepproblem);
                setRadioButtonValue(cbDoyouSmokeYes, cbDoyouSmokeNo, i.DoyouSmoke);
                setRadioButtonValue(cbSurgeriesYes, cbSurgeriesNo, i.Surgeries);
                setRadioButtonValue(cbInfectiousYes, cbInfectiousNo, i.Infectious);
                setRadioButtonValue(cbDizzinessFaintingYes, cbDizzinessFaintingNo, i.DizzinessFainting);
                setRadioButtonValue(cbLossofconsciousnessYes, cbLossofconsciousnessNo, i.Lossofconsciousness);
                setRadioButtonValue(cbPsychiatricProblemYes, cbPsychiatricProblemNo, i.PsychiatricProblem);
                setRadioButtonValue(cbDepressionYes, cbDepressionNo, i.Depression);
                setRadioButtonValue(cbAttemptedsuicideYes, cbAttemptedsuicideNo, i.Attemptedsuicide);
                setRadioButtonValue(cbLossofmemoryYes, cbLossofmemoryNo, i.Lossofmemory);
                setRadioButtonValue(cbBalanceProblemsYes, cbBalanceProblemsNo, i.BalanceProblems);
                setRadioButtonValue(cbSevereHeadAchesYes, cbSevereHeadAchesNo, i.SevereHeadAches);
                setRadioButtonValue(cbVasculardiseaseYes, cbVasculardiseaseNo, i.Vasculardisease);
                setRadioButtonValue(cbRestrictedMobilityYes, cbRestrictedMobilityNo, i.RestrictedMobility);
                setRadioButtonValue(cbBackJointProblemYes, cbBackJointProblemNo, i.BackJointProblem);
                setRadioButtonValue(cbAmputationYes, cbAmputationNo, i.Amputation);
                setRadioButtonValue(cbFracturesDislocationYes, cbFracturesDislocationNo, i.FracturesDislocation);
                setRadioButtonValue(cbCovidYes, cbCovidNo, i.Covid19);
                setRadioButtonValue(cbRepatriatedYes, cbRepatriatedNo, i.Repatriated);
                setRadioButtonValue(cbHospitalizedYes, cbHospitalizedNo, i.Hospitalized);
                setRadioButtonValue(cbSeaDutyYes, cbSeaDutyNo, i.SeaDuty);
                setRadioButtonValue(cbRevokeYes, cbRevokeNo, i.Revoke);
                setRadioButtonValue(cbConsiderDiseaseYes, cbConsiderDiseaseNo, i.ConsiderDisease);
                setRadioButtonValue(cbFitToPerformDuriesYes, cbFitToPerformDuriesNo, i.FitToPerformDuries);
                setRadioButtonValue(cbAllergicToAnyMedicationYes, cbAllergicToAnyMedicationNo, i.AllergicToAnyMedication);
                setRadioButtonValue(cbAllergicAlternativeSuplimentYes, cbAllergicAlternativeSuplimentNo, i.AlternativeSupliment);
                txtAlternativeComment1.Text = i.AlternativeSuplimentComment1;
                txtAlternativeComment2.Text = i.AlternativeSuplimentComment2;
                txtAlternativeComment3.Text = i.AlternativeSuplimentComment3;
                txtAlternativeComment4.Text = i.AlternativeSuplimentComment4;
                txtAlternativeComment5.Text = i.AlternativeSuplimentComment5;
                txtAlternativeComment6.Text = i.AlternativeSuplimentComment6;
                setRadioButtonValue(cbTakenMedicationsYes, cbTakenMedicationsNo, i.TakenMedications);
                txtmedicationsComment1.Text = i.TakenMedicationsComment1;
                txtmedicationsComment2.Text = i.TakenMedicationsComment2;
                txtmedicationsComment3.Text = i.TakenMedicationsComment3;
                txtmedicationsComment4.Text = i.TakenMedicationsComment4;
                txtmedicationsComment5.Text = i.TakenMedicationsComment5;
                txtExamineeComment1.Text = i.Comment1;
                txtExamineeComment2.Text = i.Comment2;
                txtExamineeComment3.Text = i.Comment3;
                txtExamineeComment4.Text = i.Comment4;
                txtExamineeComment5.Text = i.Comment5;

            }
        }



        private void searchPanamaPatient()
        {

            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
            var i = db.Panama_patient(txtPapin.Text).FirstOrDefault();



            if (i != null)
            {




                txtFullaname.Text = i.Fullname;
                txtPersonundergoingExamination.Text = i.Fullname;
                txtUndergoingExamination.Text = i.Fullname;
                txtSpecimenNo.Text = i.specimen_no;
                txtundergoingExaminationDate.Text = i.fitness_date;
                fitnessdate = i.fitness_date;

                txtDoctorName.Text = i.pathologist;
                txtHomeAddress.Text = i.HomeAddress;
                txtDepartment.Text = i.Department;
                txtPosition.Text = i.position;
                if (i.gender.ToLower().Equals("Male") || i.gender.ToLower().Equals("M"))
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }

                DateTime bdate = Convert.ToDateTime(i.birthdate);
                txtbDay.Text = bdate.Day.ToString();
                txtBMonth.Text = bdate.ToString("MMM");
                txtBYear.Text = bdate.Year.ToString();
                txtPassportNumber.Text = i.PassportSeamanBookNo;
                txtPerformLookout.Text = i.LookOutDuties;
                txtRoutine.Text = i.EmergencyDuties;


                newItem();


                txtRhType.Text = i.RhTyping;
                txtValidUntilDate.Text = i.valid_until;
                txtIssuedDate.Text = i.fitness_date;
                txtUndergoingDate.Text = i.fitness_date;

                if (i.TypeOfShip != null)
                {

                    switch (i.TypeOfShip.ToLower())
                    {
                        case "container":
                            rbContainer.Checked = true;
                            break;
                        case "tanker":
                            rbTanker.Checked = true;
                            break;
                        case "passenger":
                            rbPassener.Checked = true;
                            break;

                        default:
                            rbTypeOfShipOther.Checked = true;
                            txtTypeShipOther.Text = i.TypeOfShip;
                            break;
                    }

                }


                if (txtTypeShipOther.Text != "")
                {
                    rbContainer.Checked = false;
                    rbTanker.Checked = false;
                    rbPassener.Checked = false;
                    rbTypeOfShipOther.Checked = true;
                }



                if (i.TradeArea != null)
                {
                    switch (i.TradeArea.ToLower())
                    {
                        case "coastal":
                            rbCoastal.Checked = true;
                            break;
                        case "tropical":
                            rbTropical.Checked = true;
                            break;
                        case "worldwide":
                            rbWorldWide.Checked = true;
                            break;
                        default:
                            // TO DO
                            break;
                    }
                }



            }
        }
        private void PanamaResultMainSave(string papin, string uid)
        {
            //string expiration = string.Concat(expirateDay.Text, "-", expirateMonth.Text, "-", expirateYear.Text);
            //string issued = string.Concat(issuedDay.Text, "-", issuedMonth.Text, "-", issuedYear.Text);

            PanamaResultMainModel resultMain = new PanamaResultMainModel();
            resultMain.Save(uid,
                            papin,
                           getRadioButtonValue(rbFitForLookOut),
                           getRadioButtonValue(rbNonFitForLookOut),
                           getCheckBoxValue(cbDeckServiceFit),
                           getCheckBoxValue(cbEngineFit),
                           getCheckBoxValue(cbCateringFit),
                           getCheckBoxValue(cbOtherServiceFit),
                           getCheckBoxValue(cbDeckServiceUnFit),
                           getCheckBoxValue(cbEngineUnFit),
                           getCheckBoxValue(cbCateringUnFit),
                           getCheckBoxValue(cbOtherUnFit),
                           getCheckBoxValue(cbWithOutRestrictions),
                           getCheckBoxValue(cbWithRestrictions),
                           getCheckBoxValue(cbVisualAidYes),
                           getCheckBoxValue(cbVisualAidYes),
                            txtAssessmentComment1.Text,
                            txtValidUntilDate.Text,
                           txtIssuedDate.Text,
                            txtNumberOfMedicalCertificate.Text,
                            txtPhysicianName.Text,
                            txtAssessmentComment2.Text,
                            txtAssessmentComment3.Text,
                            txtAssessmentComment4.Text,
                             txtAssessmentComment5.Text);
        }





        public void searchPatient(string keyWord)
        {
            try
            {

                DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
                var i = db.Panama_patient(keyWord).FirstOrDefault();


                if (i.papin != null || i.papin != "")
                {

                    txtFullaname.Text = i.Fullname;
                    txtPersonundergoingExamination.Text = i.Fullname;
                    txtUndergoingExamination.Text = i.Fullname;

                    txtSpecimenNo.Text = i.specimen_no;


                    txtHomeAddress.Text = i.HomeAddress;
                    txtDepartment.Text = i.Department;
                    txtPosition.Text = i.position;


                    if (i.gender.ToLower().Equals("male"))
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }

                    DateTime bdate = Convert.ToDateTime(i.birthdate);
                    txtbDay.Text = bdate.Day.ToString();
                    txtBMonth.Text = bdate.ToString("MMM");
                    txtBYear.Text = bdate.Year.ToString();

                    txtPassportNumber.Text = i.PassportSeamanBookNo;


                    txtPerformLookout.Text = i.LookOutDuties;
                    txtRoutine.Text = i.EmergencyDuties;

                    txtResultID.Text = "";
                    txtResultID.Text = i.resultid;

                    txtValidUntilDate.Text = i.valid_until.ToString();
                    txtIssuedDate.Text = i.fitness_date.ToString();



                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void setRadioButtonState(RadioButton rbYes, RadioButton rbNo, string input)
        {
            if (input.Contains("Yes"))
            {
                rbYes.Checked = true;
                rbNo.Checked = false;
            }
            else
            {
                rbYes.Checked = false;
                rbNo.Checked = true;
            }

        }

        public void searchPEPD(string keyword)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var i = db.PanamaPEPD(keyword).FirstOrDefault();

                if (i != null)
                {


                    //EXAMINEE PERSONAL DECLARATION
                    setRadioButtonState(cbHighBloodPressureYes, cbHighBloodPressureNo, i.HighBloodPressure);
                    setRadioButtonState(cbEyeproblemYes, cbEyeproblemNo, i.Eyeproblem);
                    setRadioButtonState(cbEarNoseThroatYes, cbEarNoseThroatNo, i.EarNoseThroat);
                    setRadioButtonState(cbHeartSurgeryYes, cbHeartSurgeryNo, i.HeartSurgery);
                    setRadioButtonState(cbVaricoseveinsYes, cbVaricoseveinsNo, i.Varicoseveins);
                    setRadioButtonState(cbAsthmaBronchitisYes, cbAsthmaBronchitisNo, i.AsthmaBronchitis);
                    setRadioButtonState(cbBloodDisorderYes, cbBloodDisorderNo, i.BloodDisorder);
                    setRadioButtonState(cbDiabetesYes_, cbDiabetesNo, i.Diabetes);
                    setRadioButtonState(cbThyroidProblemYes, cbThyroidProblemNo, i.ThyroidProblem);
                    setRadioButtonState(cbDigestiveDisordersYes, cbDigestiveDisordersNo, i.DigestiveDisorders);
                    setRadioButtonState(cbKidneyDisordersYes, cbKidneyDisordersNo_, i.KidneyDisorders);
                    setRadioButtonState(cbSkinProblemYes, cbSkinProblemNo, i.SkinProblem);
                    setRadioButtonState(cbAllergiesYes, cbAllergiesNo, i.Allergies);
                    setRadioButtonState(cbEpilipsyYes, cbEpilipsyNo, i.Epilipsy);
                    setRadioButtonState(cbSickleCellYes, cbSickleCellNo, i.SickleCell);
                    setRadioButtonState(cbHerinasYes, cbHerinasNo, i.Herinas);
                    setRadioButtonState(cbGenitalDisordersYes, cbGenitalDisordersNo, i.GenitalDisorders);
                    setRadioButtonState(cbPregnancyYes, cbPregnancyNo, i.Pregnancy);

                    setRadioButtonState(cbSleepproblemYes, cbSleepproblemNo, i.Sleepproblem);
                    setRadioButtonState(cbDoyouSmokeYes, cbDoyouSmokeNo, i.DoyouSmoke);
                    setRadioButtonState(cbSurgeriesYes, cbSurgeriesNo, i.Surgeries);
                    setRadioButtonState(cbInfectiousYes, cbInfectiousNo, i.Infectious);
                    setRadioButtonState(cbDigestiveDisordersYes, cbDigestiveDisordersNo, i.DizzinessFainting);
                    setRadioButtonState(cbLossofconsciousnessYes, cbLossofconsciousnessNo, i.Lossofconsciousness);
                    setRadioButtonState(cbPsychiatricProblemYes, cbPsychiatricProblemNo, i.PsychiatricProblem);
                    setRadioButtonState(cbDepressionYes, cbDepressionNo, i.Depression);
                    setRadioButtonState(cbLossofmemoryYes, cbLossofmemoryNo, i.Attemptedsuicide);


                    setRadioButtonState(cbRestrictedMobilityYes, cbRestrictedMobilityNo, i.RestrictedMobility);
                    setRadioButtonState(cbBackJointProblemYes, cbBackJointProblemNo, i.BackJointProblem);
                    setRadioButtonState(cbAmputationYes, cbAmputationNo, i.Amputation);
                    setRadioButtonState(cbFracturesDislocationYes, cbFracturesDislocationNo, i.FracturesDislocation);
                    setRadioButtonState(cbCovidYes, cbCovidNo, i.Covid19);
                    setRadioButtonState(cbRepatriatedYes, cbRepatriatedNo, i.Repatriated);
                    setRadioButtonState(cbHospitalizedYes, cbHospitalizedNo, i.Hospitalized);
                    setRadioButtonState(cbSeaDutyYes, cbSeaDutyNo, i.SeaDuty);
                    setRadioButtonState(cbRevokeYes, cbRevokeNo, i.Revoke);
                    setRadioButtonState(cbConsiderDiseaseYes, cbConsiderDiseaseNo, i.ConsiderDisease);
                    setRadioButtonState(cbFitToPerformDuriesYes, cbFitToPerformDuriesNo, i.FitToPerformDuries);

                    setRadioButtonState(cbAllergicToAnyMedicationYes, cbAllergicToAnyMedicationNo, i.AllergicToAnyMedication);
                    setRadioButtonState(cbAllergicAlternativeSuplimentYes, cbAllergicAlternativeSuplimentNo, i.AlternativeSupliment);

                    txtAlternativeComment1.Text = i.AlternativeSuplimentComment1;
                    txtAlternativeComment2.Text = i.AlternativeSuplimentComment2;
                    txtAlternativeComment3.Text = i.AlternativeSuplimentComment3;
                    txtAlternativeComment4.Text = i.AlternativeSuplimentComment4;
                    txtAlternativeComment5.Text = i.AlternativeSuplimentComment5;
                    txtAlternativeComment6.Text = i.AlternativeSuplimentComment6;
                    //setCheckBoxValue(cbTakenMedicationsYes, cbTakenMedicationsNo, i.TakenMedications);
                    txtmedicationsComment1.Text = i.TakenMedicationsComment1;
                    txtmedicationsComment2.Text = i.TakenMedicationsComment2;
                    txtmedicationsComment3.Text = i.TakenMedicationsComment3;
                    txtmedicationsComment4.Text = i.TakenMedicationsComment4;
                    txtmedicationsComment5.Text = i.TakenMedicationsComment5;
                    //txtmedicationsComment6.Text = i.TakenMedicationsComment6;
                    txtExamineeComment1.Text = i.Comment1;
                    txtExamineeComment2.Text = i.Comment2;
                    txtExamineeComment3.Text = i.Comment3;
                    txtExamineeComment4.Text = i.Comment4;
                    txtExamineeComment5.Text = i.Comment5;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Examinee Personal Declaration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void txtResultID_TextChanged(object sender, EventArgs e)
        {
            if (txtResultID.Text != "")
            {
                searchPEPD(txtResultID.Text);
                searchPanamaDataRelatedCovid();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTypeOfShipOther.Checked == true)
            {
                txtTypeShipOther.Text = "BLUCK";
            }
            else
            {
                txtTypeShipOther.Text = "";
            }
        }

        private void rbContainer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbContainer.Checked == true)
            {
                txtTypeShipOther.Text = "";
            }

        }

        private void rbTanker_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTanker.Checked == true)
            {
                txtTypeShipOther.Text = "";
            }
        }

        private void rbPassener_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPassener.Checked == true)
            {
                txtTypeShipOther.Text = "";
            }
        }



    }
}
