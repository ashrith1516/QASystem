using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QASystem.DLTableAdapters;
using System.Data;

namespace QASystem
{
    public class BLL
    {
        //Business Logice Layer is a class which contains class members and member functions
        //here we invoke the queries from the data layer

        tblAdminTableAdapter adminObj = new tblAdminTableAdapter();
        tblTypesTableAdapter typeObj = new tblTypesTableAdapter();
        tblWordsTableAdapter wordObj = new tblWordsTableAdapter();
        tblMembersTableAdapter memberObj = new tblMembersTableAdapter();

        tblQuestionsTableAdapter questionObj = new tblQuestionsTableAdapter();
        tblAnswersTableAdapter answerObj = new tblAnswersTableAdapter();
        tblTextsTableAdapter txtObj = new tblTextsTableAdapter();
        tblPhotosTableAdapter photoObj = new tblPhotosTableAdapter();
        tblVideosTableAdapter videoObj = new tblVideosTableAdapter();

        DataTable1TableAdapter dt1Obj = new DataTable1TableAdapter();

        #region --------- Visitor -----------------

        //function for the user registration
        public void InsertMember(string emailId, string password, string fName, string lName, string address, string contactNo, string occupation, string photo, DateTime date)
        {
            memberObj.InsertMember(emailId, password, fName, lName, address, contactNo, occupation, photo, date);
        }

        //function to check the member login
        public DataTable CheckMemberLogin(string emailId, string password)
        {
            return memberObj.CheckMemberLogin(emailId, password);            
        }

        //function to check the admin login
        public bool CheckAdminLogin(string adminId, string password)
        {
            int cnt = int.Parse(adminObj.CheckAdminLogin(adminId, password).ToString());

            if (cnt == 1)

                return true;

            return false;
        }

        //function to check the member emailid
        public bool CheckMemberEmailId(string emailId)
        {
            int cnt = int.Parse(memberObj.CheckMemberEmailId(emailId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }


        #endregion

        #region --------- Administrator -----------------

        //View Registered Member Module (functions)
        //function to retrive all registered members
        public DataTable GetMembers()
        {
            return memberObj.GetData();
        }              

        //function to delete member registration details
        public void DeleteMember(int memberId)
        {
            memberObj.DeleteMember(memberId);
        }

        //Admin Update Password Module (functions)
        //function to get the admin details
        public DataTable GetAdminById(string adminId)
        {
            return adminObj.GetAdminById(adminId);
        }

        //function to update the admin password
        public void UpdateAdminPassword(string password, string adminId)
        {
            adminObj.ChangeAdminPassword(password, adminId);
        }

        //Question Type Module
        //function to insert new question type
        public void InsertType(string type)
        {
            typeObj.InsertType(type);
        }

        //function to delete question type
        public void DeleteType(int typeId)
        {
            typeObj.DeleteType(typeId);
        }

        //function to retrive all question types
        public DataTable GetTypes()
        {
            return typeObj.GetData();
        }

        //function to retrive question type by id
        public DataTable GetTypeById(int typeId)
        {
            return typeObj.GetTypeById(typeId);
        }

        public bool CheckType(string type)
        {
            int cnt = int.Parse(typeObj.CheckType(type).ToString());

            if (cnt == 1)

                return false;

            return true;

        }

        //Set Keywords Module (functions)
        //function to check keyword based on contenttype
        public bool CheckKeyword(int typeId, string keyword)
        {
            int cnt = int.Parse(wordObj.CheckWord(typeId, keyword).ToString());

            if (cnt == 1)

                return false;

            return true;

        }

        //function to insert keyword
        public void InsertKeyword(int tyepId, string keyword)
        {
            wordObj.InsertWord(tyepId, keyword);
        }

        //function to delete keyword
        public void DeleteKeyword(int keyId)
        {
            wordObj.DeleteWord(keyId);
        }

        //function to get all keywords
        public DataTable GetAllKeywords()
        {
            return wordObj.GetData();
        }

        //function to get keywords based on type
        public DataTable GetKeywordsByType(int tyepId)
        {
            return wordObj.GetWordsByType(tyepId);
        }

        //function to delete keywords by type
        public void DeleteKeywordsByType(int tyepId)
        {
            wordObj.DeleteWordsByType(tyepId);
        }

        //QA Module
        //function to retrive all questions
        public DataTable GetAllQuestions()
        {
            return questionObj.GetData();
        }

        //function to retrive questions based on question type
        public DataTable GetQuestionsByType(int typeId)
        {
            return questionObj.GetQuestionsByType(typeId);
        }

        //function to retrive answers based on question
        public DataTable GetAnswersByQuestionId(int questionId)
        {
            return answerObj.GetAnswersByQuestionId(questionId);
        }

        //function to get the text by answerId
        public DataTable GetTextsByAnswerId(int answerId)
        {
            return txtObj.GetTextByAnswerId(answerId);
        }

        //function to get the photos by answerId
        public DataTable GetPhotosByAnswerId(int answerId)
        {
            return photoObj.GetPhotosByAnswerId(answerId);
        }

        //function to get the vedios by answerId
        public DataTable GetVediosByAnswerId(int answeId)
        {
            return videoObj.GetVediosByAnswerId(answeId);
        }

        //function to get answer by Id
        public DataTable GetAnswerById(int answerId)
        {
            return answerObj.GetAnswerById(answerId);
        }

        //function to retrive the answers based on status
        public DataTable GetAnswersByStatus(int questionId, string status)
        {
            return answerObj.GetAnswersByStatus(questionId, status);
        }

        //function to update the status
        public void UpdateStatus(string status, int answerId)
        {
            answerObj.UpdateStatus(status, answerId);
        }

        //function to delete the answer
        public void DeleteAnswer(int answerId)
        {
            answerObj.DeleteAnswer(answerId);
        }

        //function to delete the question
        public void DeleteQuestion(int questionId)
        {
            questionObj.DeleteQuestion(questionId);
        }

        //function to delete the answers based on questionId
        public void DeleteAnswersByQuestionId(int questionId)
        {
            answerObj.DeleteAnswersByQuestionId(questionId);
        }

        //function to delete the text
        public void DeleteText(int answerId)
        {
            txtObj.DeleteTextByAnswerId(answerId);
        }

        //function to delete the photos
        public void DeletePhotos(int answerId)
        {
            photoObj.DeletePhotosByAnswerId(answerId);
        }

        //function to delete the videos
        public void DeleteVideos(int answerId)
        {
            videoObj.DeleteVideosByAnswerId(answerId);
        }


        #endregion

        #region --------- Member -----------------

        //Member Update Password Module (functions)
        //function to retrive member details based on memberId
        public DataTable GetMemberById(int memberId)
        {
            return memberObj.GetMemberById(memberId);
        }

        //function to update the admin password
        public void UpdateMemberPassword(string password, int memberId)
        {
            memberObj.ChangeMemberPassword(password, memberId);
        }

        //function to retrive the QA by memberId
        public DataTable GetQAByMemberId(int memberId)
        {
            return dt1Obj.GetQAByMemberId(memberId);
        }

        //function to retrive the QA by memberId and TypeId
        public DataTable GetQAByMemberIdandType(int memberId, int typeId)
        {
            return dt1Obj.GetQAByMemberIdandType(memberId, typeId);
        }

        //function to insert question
        public void InsertQuestion(int memberId, int typeId, string question, DateTime date)
        {
            questionObj.InsertQuestion(memberId, typeId, question, date);
        }

        //function to check the question
        public bool CheckQuestion(string question)
        {
            int cnt = int.Parse(questionObj.CheckQuestion(question).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert the answer
        public void InsertAnswer(int questionId, int memberId, string answerType, DateTime date, string status)
        {
            answerObj.InsertAnswer(questionId, memberId, answerType, date, status);
        }

        //function to get the max of answerId
        public int GetMaxAnswerId()
        {
            return (int)answerObj.GetMaxAnswerId();
        }

        //function to insert the text
        public void InsertText(int answerId, string text)
        {
            txtObj.InsertText(answerId, text);
        }

        //function to insert photos
        public void InsertPhoto(int answerId, string text, string photo)
        {
            photoObj.InsertPhoto(answerId, text, photo);
        }

        //function to insert video
        public void InserVideo(int answerId, string text, string video)
        {
            videoObj.InsertVedio(answerId, text, video);
        }

        //function to retrive the max of photoId
        public int GetMaxPhotoId()
        {
            return (int)photoObj.GetMaxPhotoId();
        }

        //function to get the question by Id
        public DataTable GetQuestionById(int questionId)
        {
            return questionObj.GetQuestionById(questionId);
        }

        //function to get the questions by date
        public DataTable GetQuestionsByDate(int typeId, DateTime startDate, DateTime endDate)
        {
            return questionObj.GetQuestionsByDateandType(typeId, startDate, endDate);
        }

        //function to get the questions by date and memberId
        public DataTable GetQuestionsByDateandMemberId(int memberId,int typeId, DateTime startDate, DateTime endDate)
        {
            return questionObj.GetQuestionsByDateandMemberIdandTypeId(memberId,typeId, startDate, endDate);
        }

        //function to update the member profile
        public void UpdateMember(string fName, string lName, string address, string contactNo, string occupdation, int memberId)
        {
            memberObj.UpdateMember(fName, lName, address, contactNo, occupdation, memberId);
        }

        #endregion


    }
}