using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPaperChaseSignalRHub.Data
{
    public interface IDigitalPaperChase
    {
        public class Answer
        {
            public string Content { get; }
            public bool Correct { get; }

            public Answer(string content, bool correct)
            {
                Content = content;
                Correct = correct;
            }
        }

        Task<List<string>> GetAllSubjectAreas();
        Task<List<int>> GetSubjectAreasId();
        Task<List<string>> GetCategories();
        Task<List<string>> QuestionContentandId();
        Task<List<string>> PlayerNickName();
        Task<List<string>> PaperchaseName();
        Task<List<string>> AnswerContent();
        Task<List<bool>> CorrectAnswer();
        Task<List<int>> PointsOfaPlayer();
        Task<List<int>> QuellQuestionID();
        Task<List<int>> TargetQuestion();
        Task AddQuestion(string category, string content, List<Answer> answers);
        Task AddNickName(string nickName);
        Task AddCategory(string category, int subjectareaId);
        Task AddSubjectarea(string subjectarea);
        Task AddNewPaperchase(string paperchase, int categoryId);
                
    }
}
