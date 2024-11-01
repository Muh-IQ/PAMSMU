using PAMSMU_Data;

namespace PAMSMU_Business
{
    public class clsScientific
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode;

        public clsScientific()
        {
            _Mode = _enMode.AddNew;
            PrimarySchoolCertificateInformation = string.Empty;
            InformationAboutTheIntermediateCertificate = string.Empty;
            InformationAboutPreparatoryCertificate = string.Empty;
            InformationAboutInstituteCertificate = string.Empty;
            CollegeCertificateInformation = string.Empty;
            InformationAboutBasicCourse = string.Empty;
            InformationAboutOtherCourses = string.Empty;
            InformationAboutHigherDegrees = string.Empty;
        }

        public clsScientific(int scientificID, string primarySchoolCertificateInformation,
            string informationAboutTheIntermediateCertificate, string informationAboutPreparatoryCertificate,
            string informationAboutInstituteCertificate, string collegeCertificateInformation,
            string informationAboutBasicCourse, string informationAboutOtherCourses,
            string informationAboutHigherDegrees)
        {
            _Mode = _enMode.Update;
            ScientificID = scientificID;
            PrimarySchoolCertificateInformation = primarySchoolCertificateInformation;
            InformationAboutTheIntermediateCertificate = informationAboutTheIntermediateCertificate;
            InformationAboutPreparatoryCertificate = informationAboutPreparatoryCertificate;
            InformationAboutInstituteCertificate = informationAboutInstituteCertificate;
            CollegeCertificateInformation = collegeCertificateInformation;
            InformationAboutBasicCourse = informationAboutBasicCourse;
            InformationAboutOtherCourses = informationAboutOtherCourses;
            InformationAboutHigherDegrees = informationAboutHigherDegrees;
        }

        public int ScientificID { get; set; }
        public string PrimarySchoolCertificateInformation { get; set; }
        public string InformationAboutTheIntermediateCertificate { get; set; }
        public string InformationAboutPreparatoryCertificate { get; set; }
        public string InformationAboutInstituteCertificate { get; set; }
        public string CollegeCertificateInformation { get; set; }
        public string InformationAboutBasicCourse { get; set; }
        public string InformationAboutOtherCourses { get; set; }
        public string InformationAboutHigherDegrees { get; set; }

        public static clsScientific Find(int ScientificID)
        {
            string PrimarySchoolCertificateInformation = string.Empty, InformationAboutTheIntermediateCertificate = string.Empty,
                CollegeCertificateInformation = string.Empty, InformationAboutPreparatoryCertificate = string.Empty,
                InformationAboutInstituteCertificate = string.Empty, InformationAboutBasicCourse = string.Empty,
                InformationAboutOtherCourses = string.Empty, InformationAboutHigherDegrees = string.Empty;
            if (ScientificData.GetInfoScientific(ScientificID, ref PrimarySchoolCertificateInformation, ref InformationAboutTheIntermediateCertificate, ref InformationAboutPreparatoryCertificate, ref InformationAboutInstituteCertificate, ref CollegeCertificateInformation, ref InformationAboutBasicCourse, ref InformationAboutOtherCourses, ref InformationAboutHigherDegrees))
            {
                return new clsScientific(ScientificID, PrimarySchoolCertificateInformation, InformationAboutTheIntermediateCertificate, InformationAboutPreparatoryCertificate, InformationAboutInstituteCertificate, CollegeCertificateInformation, InformationAboutBasicCourse, InformationAboutOtherCourses, InformationAboutHigherDegrees);
            }
            return null;
        }
        private bool _AddNew()
        {
            return (this.ScientificID = ScientificData.AddNewScientific(PrimarySchoolCertificateInformation,
                InformationAboutTheIntermediateCertificate, InformationAboutPreparatoryCertificate,
                InformationAboutInstituteCertificate, CollegeCertificateInformation, InformationAboutBasicCourse,
                InformationAboutOtherCourses, InformationAboutHigherDegrees)) > -1;
        }

        private bool _Update()
        {
            return ScientificData.UpdateScientific(ScientificID, PrimarySchoolCertificateInformation, InformationAboutTheIntermediateCertificate, InformationAboutPreparatoryCertificate, InformationAboutInstituteCertificate, CollegeCertificateInformation, InformationAboutBasicCourse, InformationAboutOtherCourses, InformationAboutHigherDegrees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    return false;
                case _enMode.Update:
                    return _Update();
            }
            return false;
        }
    }
}
