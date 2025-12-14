using Microsoft.EntityFrameworkCore;
using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTourism.Repositories
{
    public class TripRepository : ITrip
    {
     
        public  IEnumerable<TripDTO> GetAllTrips()
        {
            var context = new AppDbContext();
            
                var Trips = context.Trips.
                            Select(Trip => new TripDTO{
                                TripId = Trip.TripId,
                                Title  = Trip.Title,
                                Description = Trip.Description,
                                StartDate = (DateTime)Trip.StartDate,
                                EndDate = (DateTime)Trip.EndDate,
                                Price = (decimal)Trip.Price,
                            }).ToList();
            
                return Trips;
    }
        public List<TripDTO> FindTripByID(int Id)
        {
            var context = new AppDbContext();

            var Trip = context.Trips.Where(Trip => Trip.TripId == Id).
                Select(Trip => new TripDTO
                {
                    TripId = Trip.TripId,
                    Title = Trip.Title,
                    Description = Trip.Description,
                    StartDate = (DateTime)Trip.StartDate,
                    EndDate = (DateTime)Trip.EndDate,
                    Price = (decimal)Trip.Price,
                }).ToList();

            return Trip;
        }
        public  int AddNewTrip(Trip NewTrip)
        {
            var context = new AppDbContext();

            int Id = 0;


            try
            {
            context.Trips.Add(NewTrip);
                context.SaveChanges();
                    Id = NewTrip.TripId;
            }
            catch (Exception e)
            {
                Id = 0;
            }

            return Id;
        }
        public  bool UpdateTrip(Trip Trip)
        {
            var context = new AppDbContext();

            bool IsUpdate = false; 

                try
                {
            context.Trips.Update(Trip);
                context.SaveChanges();
                        IsUpdate = true;
                }
                catch (Exception e)
                {
                    IsUpdate = false;
                }
            
            return IsUpdate;
        }
        public bool DeleteTrip(int ID)
        {
            var context = new AppDbContext();

            var Trip = context.Trips.Find(ID);

            bool IsDeleted = false;
            try
            {
                if (Trip != null)
                {
                    context.Trips.Remove(Trip);
                    context.SaveChanges();
                    IsDeleted = true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                IsDeleted = false;
            }

            return IsDeleted;
        }

    }
    }
