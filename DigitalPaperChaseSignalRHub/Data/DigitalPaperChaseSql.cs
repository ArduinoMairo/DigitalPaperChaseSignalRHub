using DigitalPaperChaseSignalRHub.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPaperChaseSignalRHub.Data
{
    public class DigitalPaperChaseSql : IDigitalPaperChase
    {
        private SchnitzeljagdContext db { get; }

        public DigitalPaperChaseSql(SchnitzeljagdContext schnitzeljagdContext)
        {
            this.db = schnitzeljagdContext;
        }

        public Task<List<int>> GetSubjectAreasId()
        {
            var subjectareasId =
                from s in db.Fachbereiches
                select s.FachbereichId;

            return subjectareasId.ToListAsync();
        }

        public Task<List<string>> PaperchaseName()
        {
            var paperchaseName =
                from paperchase in db.Schnitzeljagdens
                select paperchase.Bezeichnung;

            return paperchaseName.ToListAsync();
        }

        public Task<List<int>> TargetQuestion()
        {
            var targetq =
                from tq in db.Links
                select tq.QuellfrageId;

            return targetq.ToListAsync();
        }

        public Task<List<int>> QuellQuestionID()
        {
            var quellquestionid =
                from qqid in db.Links
                select qqid.QuellfrageId;

            return quellquestionid.ToListAsync();
        }

        public Task<List<int>> PointsOfaPlayer()
        {
            var points =
                from p in db.Punktes
                select p.Punkte1;

            return points.ToListAsync();
        }

        public Task<List<string>> AnswerContent()
        {
            var answerContent =
                from a in db.Loesungens
                select a.Inhalt + " id:" + a.FragenId;

            return answerContent.ToListAsync();
        }


        public Task<List<bool>> CorrectAnswer()
        {
            var correctanswer =
                from correct in db.Loesungens
                select correct.Korrekt;

            return correctanswer.ToListAsync();
        }

        public Task<List<string>> GetAllSubjectAreas()
        {
            var subjectAreas =
                from sa in db.Fachbereiches
                select sa.Bezeichnung;

            return subjectAreas.ToListAsync();
        }

        public Task<List<string>> GetCategories()
        {
            var category =
                from ca in db.Kategoriens
                select ca.Bezeichnung + " id:" + ca.KategorieId;

            return category.ToListAsync();
        }

        public Task<List<string>> QuestionContentandId()
        {
            var question =
                from q in db.Fragens
                select q.Inhalt + " id:" + q.FragenId;
            
             return question.ToListAsync();
        }

        public Task<List<string>> QuestionContentandCatId()
        {
            var question =
                from q in db.Fragens
                select q.Inhalt + " id:" + q.KategorieId;

            return question.ToListAsync();
        }

        public Task<List<string>> PlayerNickName()
        {
            var playername =
                from p in db.Spielers
                select p.Nickname;

            return playername.ToListAsync();
        }
        
        public async Task AddQuestion(string category, string content, List<IDigitalPaperChase.Answer> answers)
        {
            Kategorien kategorie = await db.Kategoriens.Where(c => c.Bezeichnung == category).FirstAsync();
                                   
            Fragen frage = new Fragen();
            frage.Kategorie = kategorie;
            frage.Inhalt = content;

            db.Fragens.Add(frage);

            foreach (IDigitalPaperChase.Answer answer in answers)
            {
                Loesungen loesung = new Loesungen();
                loesung.Fragen = frage;
                loesung.Inhalt = answer.Content;
                loesung.Korrekt = answer.Correct;

                db.Add(loesung);

                
            }

            await db.SaveChangesAsync();
        }

        public async Task AddNickName(string nickName)
        {
            Spieler player = new Spieler();
            player.Nickname = nickName;
            db.Spielers.Add(player);

            await db.SaveChangesAsync();
        }

        public async Task AddCategory(string category, int subjectareaId)
        {
            Kategorien kategorien = new Kategorien();
            kategorien.Bezeichnung = category;
            kategorien.FachbereichId = subjectareaId;
            db.Kategoriens.Add(kategorien);

            await db.SaveChangesAsync();
        }

        public async Task AddSubjectarea(string subjectarea)
        {
            Fachbereiche fachbereiche = new Fachbereiche();
            fachbereiche.Bezeichnung = subjectarea;
            db.Fachbereiches.Add(fachbereiche);

            await db.SaveChangesAsync();
        }

        public async Task AddNewPaperchase(string paperchase, int categoryId)
        {
            Schnitzeljagden schnitzeljagden = new Schnitzeljagden();
            schnitzeljagden.Bezeichnung = paperchase;
            schnitzeljagden.KategorieId = categoryId;
            db.Schnitzeljagdens.Add(schnitzeljagden);
            
            await db.SaveChangesAsync();
        }
    }
}
