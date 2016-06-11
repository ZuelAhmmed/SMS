using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using SMS.Models;
using SMS.Models.DbModels;
using SMS.PrimaryModels;
using SMS.Security;

namespace SMS.Security
{
    public class PrimaryDataManager
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void CreatePrimaryData()
        {
          //  CreateSecurityRoleTableData();
            CreateCatAddressTableData();
            CreateCatClassOrYearTableData();
            CreateCatConfirmTableData();
            CreateCatDesignationTableData();
            CreateCatOccupationTableData();
            CreateCatGroupTableData();
            CreateCatEducationBoardTableData();
            CreateCatEducationLevelTableData();
            CreateCatBloodGroupTableData();
            CreateCatSubjectTableData();
        }

        private void SaveAddressCatagory(AddressCatagory addressCatagory)
        {
            AddressCatagory catagory = db.AddressCatagories.Find(addressCatagory.Code);
            if (catagory == null)
            {
                db.AddressCatagories.Add(addressCatagory);
                db.SaveChanges();
            }
        }

        private void CreateCatAddressTableData()
        {
            foreach (string catagory in CatAddress.GetCatagoryList())
            {
                AddressCatagory addressCatagory = new AddressCatagory();
                addressCatagory.Code = catagory;
                addressCatagory.Name = catagory;
                SaveAddressCatagory(addressCatagory);
            }
        }

        private void SaveClassOrYear(ClassOrYear classOrYear)
        {
            ClassOrYear classyear = db.ClassOrYears.Find(classOrYear.Code);
            if (classyear == null)
            {
                db.ClassOrYears.Add(classOrYear);
                db.SaveChanges();
            }
        }

        private void CreateCatClassOrYearTableData()
        {
            foreach (string newClassOrYear in CatClassOrYear.GetCatagoryList())
            {
                ClassOrYear classOrYear = new ClassOrYear(newClassOrYear, newClassOrYear);
                classOrYear.Code = newClassOrYear;
                classOrYear.Name = newClassOrYear;
                SaveClassOrYear(classOrYear);
            }
        }

        private void SaveConfirmationCatagory(ConfirmationCatagory confirmationCatagory)
        {
            ConfirmationCatagory confirmation = db.ConfirmationCatagories.Find(confirmationCatagory.Code);
            if (confirmation == null)
            {
                db.ConfirmationCatagories.Add(confirmationCatagory);
                db.SaveChanges();
            }
        }

        private void CreateCatConfirmTableData()
        {
            foreach (string cat in CatConfirmation.GetCatagoryList())
            {
                ConfirmationCatagory catagory = new ConfirmationCatagory();
                catagory.Code = cat;
                catagory.Name = cat;
                SaveConfirmationCatagory(catagory);
            }
        }

        private void SaveDesignation(Designation designation)
        {
            Designation aDesignation = db.Designations.Find(designation.DesignationCode);
            if (aDesignation == null)
            {
                db.Designations.Add(designation);
                db.SaveChanges();
            }
        }

        private void CreateCatDesignationTableData()
        {
            foreach (string cat in CatDesignation.GetCatagoryList())
            {
                Designation catagory = new Designation();
                catagory.DesignationCode = cat;
                catagory.Name = cat;
                SaveDesignation(catagory);
            }
        }

        private void SaveOccupation(Occupation occupation)
        {
            Occupation anOccupation = db.Occupations.Find(occupation.Code);
            if (anOccupation == null)
            {
                db.Occupations.Add(occupation);
                db.SaveChanges();
            }
        }

        private void CreateCatOccupationTableData()
        {
            foreach (string cat in CatOccupation.GetCatagoryList())
            {
                Occupation catagory = new Occupation();
                catagory.Code = cat;
                catagory.Name = cat;
                SaveOccupation(catagory);
            }
        }

        private void SaveGroup(Group group)
        {
            Group aGroup = db.Groups.Find(group.GroupCode);
            if (aGroup == null)
            {
                db.Groups.Add(group);
                db.SaveChanges();
            }
        }

        private void CreateCatGroupTableData()
        {
            foreach (string cat in CatGroup.GetCatagoryList())
            {
                Group catagory = new Group();
                catagory.GroupCode = cat;
                catagory.Name = cat;
                SaveGroup(catagory);
            }
        }

        private void SaveEducationBoard(EducationBoard board)
        {
            EducationBoard educationBoard = db.EducationBoards.Find(board.BoardCode);
            if (educationBoard == null)
            {
                db.EducationBoards.Add(board);
                db.SaveChanges();
            }
        }

        private void CreateCatEducationBoardTableData()
        {
            foreach (string cat in CatEducationBoard.GetCatagoryList())
            {
                EducationBoard catagory = new EducationBoard();
                catagory.BoardCode = cat;
                catagory.Name = cat;
                SaveEducationBoard(catagory);
            }
        }

        private void SaveEducationLevel(EducationLevel level)
        {
            EducationLevel educationLevel = db.EducationLevels.Find(level.EducationLevelCode);
            if (educationLevel == null)
            {
                db.EducationLevels.Add(level);
                db.SaveChanges();
            }
        }

        private void CreateCatEducationLevelTableData()
        {
            foreach (string cat in CatEducationLevel.GetCatagoryList())
            {
                EducationLevel catagory = new EducationLevel();
                catagory.EducationLevelCode = cat;
                catagory.Name = cat;
                SaveEducationLevel(catagory);
            }
        }

        private void SaveBloodGroup(BloodGroup group)
        {
            BloodGroup blood = db.BloodGroups.Find(group.BloodGroupCode);
            if (blood == null)
            {
                db.BloodGroups.Add(group);
                db.SaveChanges();
            }
        }

        private void CreateCatBloodGroupTableData()
        {
            foreach (string cat in CatBloodGroup.GetCatagoryList())
            {
                BloodGroup catagory = new BloodGroup();
                catagory.BloodGroupCode = cat;
                catagory.Name = cat;
                SaveBloodGroup(catagory);
            }
        }

        private void SaveSubjectCatagory(SubjectCatagory subjectCatagory)
        {
            SubjectCatagory catagory = db.SubjectCatagories.Find(subjectCatagory.SubCatCode);
            if (catagory == null)
            {
                db.SubjectCatagories.Add(subjectCatagory);
                db.SaveChanges();
            }
        }

        private void CreateCatSubjectTableData()
        {
            foreach (string cat in CatSubject.GetCatagoryList())
            {
                SubjectCatagory catagory = new SubjectCatagory();
                catagory.SubCatCode = cat;
                catagory.Name = cat;
                SaveSubjectCatagory(catagory);
            }
        }

    }
}