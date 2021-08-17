using System;
using System.Collections.Generic;
using System.Linq;
using UnblockMe_App.Models;

namespace UnblockMe_App.Services
{
    public class UserService
    {
        private readonly UnblockMeContext dbContext;

        public UserService(UnblockMeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Services
        public User GetUserById(string id)
        {
            return dbContext.User.Find(id);
        }
        
        public List<Car> GetUserCarsByUserId(string id)
        {
            return dbContext.Car.Where(car => car.OwnerId == id).ToList();
        }

        public void UpdateUserStatus(string id, string newStatus)
        {
            var user = GetUserById(id);
            user.AdditionalInfo = newStatus;
            dbContext.SaveChanges();
        }

        public UserRating GetUserRatingByIds(string userRatedId, string userRatingId)
        {
            if(userRatedId == userRatingId)
            {
                return null;
            }
            return dbContext.UserRating.FirstOrDefault(rating => (rating.UserRatedId == userRatedId && rating.UserRatingId == userRatingId));
        }

        public void DeleteRatingByUserRatingId(User userRated, User userRating)
        {
            var userRatingToDelete = GetUserRatingByIds(userRated.Id, userRating.Id);
            if (userRatingToDelete == null)
            {
                return;
            }
            dbContext.UserRating.Remove(userRatingToDelete);
            UpdateUserAverageRating(userRated, true);
            dbContext.SaveChanges();
        }

        public void AddUpdateRatingToUser(User userRated, User userRating, int rating, string comment)
        {
            if(userRated.Id== userRating.Id)
            {
                return;
            }

            var userRatingFirst = GetUserRatingByIds(userRated.Id, userRating.Id);

            if (userRatingFirst!=null)
            {
                userRatingFirst.Rating = rating;
                userRatingFirst.Comment = comment;
                dbContext.UserRating.Update(userRatingFirst);
            }
            else
            {
                var newUserRating = new UserRating()
                {
                    Id = Guid.NewGuid(),
                    UserRatedId = userRated.Id,
                    UserRatingId = userRating.Id,
                    UserRated = userRated,
                    UserRatingNavigation = userRating,
                    Rating = rating,
                    Comment = comment
                };
                dbContext.UserRating.Add(newUserRating);
            }
            UpdateUserAverageRating(userRated, false);
            dbContext.SaveChanges();
        }

        public void DeleteAdditionalInfoOfUser(User user)
        {
            user.AdditionalInfo = null;
            dbContext.User.Update(user);
            dbContext.SaveChanges();
        }

        public void UpdateUserAverageRating(User user, bool ratingWasDeleted)
        {
            float sum = 0;
            foreach (var rating in user.UserRatingUserRated)
            {
                sum += rating.Rating;
            }
            if(ratingWasDeleted && user.UserRatingUserRated.Count==1)
            {
                user.AverageRating = null;
            }
            else
            {
                double averageRating = sum / user.UserRatingUserRated.Count;
                user.AverageRating = averageRating;
            }
            dbContext.User.Update(user);
        }
    }
}
