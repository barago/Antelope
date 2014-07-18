using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;
using Antelope.Models;

namespace Antelope.Repositories.HSE
{
    public class FicheSecuriteRepository
    {

        public AntelopeContext _db { get; set; }

        //public FicheSecuriteRepository() : this(new TestContext())
        //{

        //}

        public FicheSecuriteRepository(AntelopeContext db)
        {
            _db = db;
        }

        public FicheSecurite Get(int id)
        {
            return _db.FicheSecurites.SingleOrDefault(r => r.FicheSecuriteID == id);
        }

        //public IQueryable<Review> GetAll()
        //{
        //    return _db.Reviews;
        //}

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