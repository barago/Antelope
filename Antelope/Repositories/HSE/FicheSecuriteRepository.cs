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

        public List<FicheSecurite> GetFromParams(RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel)
        {
            var queryFicheSecurite = from a in _db.FicheSecurites 
                                     //join 
                                     select a;


    //        var innerJoinQuery =
    //from cust in customers
    //join dist in distributors on cust.City equals dist.City
    //select new { CustomerName = cust.Name, DistributorName = dist.Name };

            //if (RechercheFicheSecuriteParamModel.SiteId != null && RechercheFicheSecuriteParamModel.SiteId != 0)
            //{
            //    queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == RechercheFicheSecuriteParamModel.SiteId);
            //}
            if (RechercheFicheSecuriteParamModel.ZoneId != null && RechercheFicheSecuriteParamModel.ZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == RechercheFicheSecuriteParamModel.ZoneId);
            }
            if (RechercheFicheSecuriteParamModel.LieuId != null && RechercheFicheSecuriteParamModel.LieuId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == RechercheFicheSecuriteParamModel.LieuId);
            }
            if (RechercheFicheSecuriteParamModel.ResponsableNom != null && RechercheFicheSecuriteParamModel.ResponsableNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.GUID == RechercheFicheSecuriteParamModel.ResponsableGuid);
            }




            List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();

            return AllFicheSecurite;

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