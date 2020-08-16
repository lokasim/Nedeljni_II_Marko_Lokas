using MedicalInstitution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitution.Services
{
    class Service
    {
        /// <summary>
        /// Method for adding new Patient
        /// </summary>
        /// <param name="user">new patient</param>
        /// <returns></returns>
        public tblPatient AddPatient(tblPatient user)
        {
            try
            {

                using (MedicalInstitutionNedeljniEntities context = new MedicalInstitutionNedeljniEntities())
                {
                    if (user.PatientID == 0)
                    {
                        tblPatient newUser = new tblPatient
                        {
                            PatientID = user.PatientID,
                            NameSurname = user.NameSurname,
                            BLK = user.BLK,
                            Gender = user.Gender,
                            DateOfBirth = user.DateOfBirth,
                            Citizenship = user.Citizenship,
                            UsernameLogin = user.UsernameLogin,
                            PasswordLogin = user.PasswordLogin,
                            HealthInsuranceCardNumber = user.HealthInsuranceCardNumber,
                            ExpirationDateHealthInsurance = user.ExpirationDateHealthInsurance,
                            UniqueNumberDoctor = user.UniqueNumberDoctor
                        };

                        context.tblPatients.Add(newUser);
                        context.SaveChanges();
                        user.PatientID = newUser.PatientID;
                        return user;
                    }
                    else
                    {
                        tblPatient userToEdit = (from r in context.tblPatients where r.PatientID == user.PatientID select r).First();

                        userToEdit.PatientID = user.PatientID;
                        userToEdit.NameSurname = user.NameSurname;
                        userToEdit.BLK = user.BLK;
                        userToEdit.Gender = user.Gender;
                        userToEdit.DateOfBirth = user.DateOfBirth;
                        userToEdit.Citizenship = user.Citizenship;
                        userToEdit.UsernameLogin = user.UsernameLogin;
                        userToEdit.PasswordLogin = user.PasswordLogin;
                        userToEdit.HealthInsuranceCardNumber = user.HealthInsuranceCardNumber;
                        userToEdit.ExpirationDateHealthInsurance = user.ExpirationDateHealthInsurance;
                        userToEdit.UniqueNumberDoctor = user.UniqueNumberDoctor;
                        context.SaveChanges();
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nešto je pošlo po zlu prilikom registracije", "Greška");
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetPatientUsername(string username)
        {
            try
            {
                using (MedicalInstitutionNedeljniEntities context = new MedicalInstitutionNedeljniEntities())
                {
                    tblPatient user = (from e in context.tblPatients where e.UsernameLogin.Equals(username) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetPatientBLK(string blk)
        {
            try
            {
                using (MedicalInstitutionNedeljniEntities context = new MedicalInstitutionNedeljniEntities())
                {
                    tblPatient user = (from e in context.tblPatients where e.BLK.Equals(blk) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetPatientHealthInsuranceCardNumber(string cardNumber)
        {
            try
            {
                using (MedicalInstitutionNedeljniEntities context = new MedicalInstitutionNedeljniEntities())
                {
                    tblPatient user = (from e in context.tblPatients where e.HealthInsuranceCardNumber.Equals(cardNumber) select e).First();


                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblDoctor> GetAllDoctor()
        {
            try
            {
                using (MedicalInstitutionNedeljniEntities context = new MedicalInstitutionNedeljniEntities())
                {
                    List<tblDoctor> list = new List<tblDoctor>();
                    list = (from x in context.tblDoctors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
    }
}
