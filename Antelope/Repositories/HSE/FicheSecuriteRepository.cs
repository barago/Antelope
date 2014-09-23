using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;
using Antelope.Models;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;

namespace Antelope.Repositories.HSE
{
    public class FicheSecuriteRepository
    {

        public AntelopeContext _db { get; set; }

        public FicheSecuriteRepository() : this(new AntelopeContext())
        {

        }

        public FicheSecuriteRepository(AntelopeContext db)
        {
            _db = db;
        }

        public FicheSecurite Get(int id)
        {
            FicheSecurite ficheSecurite = _db.FicheSecurites.SingleOrDefault(r => r.FicheSecuriteID == id);
            return ficheSecurite;
        }

        public List<FicheSecurite> GetAll()
        {
            return _db.FicheSecurites.ToList();
        }

        public FicheSecuritePaginatedList GetFromParams(RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel)
        {
            IQueryable<FicheSecurite> queryFicheSecurite = from a in _db.FicheSecurites
                                     orderby  a.WorkFlowCloturee, a.WorkFlowASEValidee,a.WorkFlowASERejetee, a.WorkFlowAttenteASEValidation, a.WorkFlowDiffusee
                                     select a;


            if (RechercheFicheSecuriteParamModel.SiteId != null && RechercheFicheSecuriteParamModel.SiteId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == RechercheFicheSecuriteParamModel.SiteId);
            }
            if (RechercheFicheSecuriteParamModel.ZoneId != null && RechercheFicheSecuriteParamModel.ZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == RechercheFicheSecuriteParamModel.ZoneId);
            }
            if (RechercheFicheSecuriteParamModel.LieuId != null && RechercheFicheSecuriteParamModel.LieuId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == RechercheFicheSecuriteParamModel.LieuId);
            }
            if (RechercheFicheSecuriteParamModel.FicheSecuriteTypeId != null && RechercheFicheSecuriteParamModel.FicheSecuriteTypeId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecuriteTypeId == RechercheFicheSecuriteParamModel.FicheSecuriteTypeId);
            }
            if (RechercheFicheSecuriteParamModel.Code != null && RechercheFicheSecuriteParamModel.Code != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Code == RechercheFicheSecuriteParamModel.Code);
            }
            if (RechercheFicheSecuriteParamModel.Age != null && RechercheFicheSecuriteParamModel.Age != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Age == RechercheFicheSecuriteParamModel.Age);
            }
            if (RechercheFicheSecuriteParamModel.PosteDeTravailId != null && RechercheFicheSecuriteParamModel.PosteDeTravailId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PosteDeTravailId == RechercheFicheSecuriteParamModel.PosteDeTravailId);
            }
            if (RechercheFicheSecuriteParamModel.ServiceId != null && RechercheFicheSecuriteParamModel.ServiceId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ServiceId == RechercheFicheSecuriteParamModel.ServiceId);
            }
            if (RechercheFicheSecuriteParamModel.DateEvenementDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement >= RechercheFicheSecuriteParamModel.DateEvenementDebut);
            }
            if (RechercheFicheSecuriteParamModel.DateEvenementFin != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement <= RechercheFicheSecuriteParamModel.DateEvenementFin);
            }
            if (RechercheFicheSecuriteParamModel.PersonneConcerneeNom != null && RechercheFicheSecuriteParamModel.PersonneConcerneeNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PersonneConcernee.Nom == RechercheFicheSecuriteParamModel.PersonneConcerneeNom);
            }
            if (RechercheFicheSecuriteParamModel.ResponsableNom != null && RechercheFicheSecuriteParamModel.ResponsableNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Nom == RechercheFicheSecuriteParamModel.ResponsableNom);
            }
            if (RechercheFicheSecuriteParamModel.CotationFrequence != null && RechercheFicheSecuriteParamModel.CotationFrequence != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence == RechercheFicheSecuriteParamModel.CotationFrequence);
            }
            if (RechercheFicheSecuriteParamModel.CotationGravite != null && RechercheFicheSecuriteParamModel.CotationGravite != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationGravite == RechercheFicheSecuriteParamModel.CotationGravite);
            }
            if (RechercheFicheSecuriteParamModel.RisqueId != null && RechercheFicheSecuriteParamModel.RisqueId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.RisqueId == RechercheFicheSecuriteParamModel.RisqueId);
            }
            if (RechercheFicheSecuriteParamModel.DangerId != null && RechercheFicheSecuriteParamModel.DangerId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DangerId == RechercheFicheSecuriteParamModel.DangerId);
            }
            if (RechercheFicheSecuriteParamModel.CorpsHumainZoneId != null && RechercheFicheSecuriteParamModel.CorpsHumainZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CorpsHumainZoneId == RechercheFicheSecuriteParamModel.CorpsHumainZoneId);
            }
            if (RechercheFicheSecuriteParamModel.PlageHoraireId != null && RechercheFicheSecuriteParamModel.PlageHoraireId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PlageHoraireId == RechercheFicheSecuriteParamModel.PlageHoraireId);
            }
            if (RechercheFicheSecuriteParamModel.ResponsableGuid != null && RechercheFicheSecuriteParamModel.ResponsableGuid != new Guid())
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.GUID == RechercheFicheSecuriteParamModel.ResponsableGuid);
            }


            int TotalRowCount = queryFicheSecurite.Count();

            queryFicheSecurite = queryFicheSecurite.Skip(RechercheFicheSecuriteParamModel.PageSize * (RechercheFicheSecuriteParamModel.Page - 1)).Take(RechercheFicheSecuriteParamModel.PageSize);
            //queryFicheSecurite = queryFicheSecurite.Skip(0).Take(4);


                //.ThenBy(q => q.WorkFlowAttenteASEValidation)
                //.ThenBy(q => q.WorkFlowASERejetee)
                //.ThenBy(q => q.WorkFlowASEValidee)
                //.ThenBy(q => q.WorkFlowCloturee);

            List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();

            FicheSecuritePaginatedList FicheSecuritePaginatedList = new FicheSecuritePaginatedList()
            {
                AllFicheSecurite = AllFicheSecurite,
                Page = RechercheFicheSecuriteParamModel.Page,
                PageSize = RechercheFicheSecuriteParamModel.PageSize,
                RowCount = TotalRowCount
            };

            return FicheSecuritePaginatedList;

        }

        //public Review Add(Review review)
        //{
        //    _db.Reviews.Add(review);
        //    _db.SaveChanges();
        //    return review;
        //}

        //public Review Update(Review review)
        //{
        //    _db.Entry(review).State = EntityState.Modified;
        //    _db.SaveChanges();
        //    return review;
        //}

        //public void Delete(int reviewId)
        //{
        //    var review = Get(reviewId);
        //    _db.Reviews.Remove(review);
        //}

        //public IEnumerable<Review> GetByCategory(Category category)
        //{
        //    return _db.Reviews.Where(r => r.CategoryId == category.Id);
        //}

        //public IEnumerable<Comment> GetReviewComments(int id)
        //{
        //    return _db.Comments.Where(c => c.ReviewId == id);
        //}




    }
}