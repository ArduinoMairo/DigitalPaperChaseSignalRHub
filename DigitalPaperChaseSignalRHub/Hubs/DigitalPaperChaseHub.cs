using DigitalPaperChaseSignalRHub.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPaperChaseSignalRHub.Hubs
{
    public class DigitalPaperChaseHub : Hub
    {
        private IDigitalPaperChase DigitalPaperChase { get; }


        public DigitalPaperChaseHub(IDigitalPaperChase digitalPaperChase)
        {
            this.DigitalPaperChase = digitalPaperChase;
        }

        public Task<List<int>> QuellQuestionID()
        {
            return this.DigitalPaperChase.QuellQuestionID();
        }

        public Task<List<int>> GetSubjectAreasId()
        {
            return this.DigitalPaperChase.GetSubjectAreasId();
        }

        public Task<List<string>> PaperchaseName()
        {
            return this.DigitalPaperChase.PaperchaseName();
        }

        public Task<List<int>> TargetQuestion()
        {
            return this.DigitalPaperChase.TargetQuestion();
        }

        public Task<List<string>> AnswerContent()
        {
            return this.DigitalPaperChase.AnswerContent();
        }

        public Task<List<int>> PointsOfaPlayer()
        {
            return this.DigitalPaperChase.PointsOfaPlayer();
        }

        public Task<List<bool>> CorrectAnswer()
        {
            return this.DigitalPaperChase.CorrectAnswer();
        }

        public Task<List<string>> GetAllSubjectAreas()
        {
            return this.DigitalPaperChase.GetAllSubjectAreas();
            
        }

        public Task<List<string>> GetCategories()
        {
            return this.DigitalPaperChase.GetCategories();
        }

        public  Task<List<string>> QuestionContentandId()
        {
            return this.DigitalPaperChase.QuestionContentandId();
        }


        public Task<List<string>> PlayerNickName()
        {
            return this.DigitalPaperChase.PlayerNickName();
        }

        public Task AddQuestion(string category, string content, List<IDigitalPaperChase.Answer> answers)
        {
            return this.DigitalPaperChase.AddQuestion(category, content, answers);
        }

        public Task AddNickName(string nickName)
        {
            return this.DigitalPaperChase.AddNickName(nickName);
        }

        public Task AddCategory(string category, int subjectareaId)
        {
            return this.DigitalPaperChase.AddCategory(category, subjectareaId);
        }

        public Task AddSubjectarea(string subjectarea)
        {
            return this.DigitalPaperChase.AddSubjectarea(subjectarea);
        }

        public Task AddNewPaperchase(string paperchase, int categoryId)
        {
            return this.DigitalPaperChase.AddNewPaperchase(paperchase, categoryId);
        }
    }
}
