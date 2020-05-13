using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidli.Dtos;
using Vidli.Models;

namespace Vidli.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/Rentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("No Movie Ids given");
            var customerId = rentalDto.CustomerId;
            var customerInDb = _context.Customers.Single(c => c.Id == customerId);

            if (customerInDb == null)
                return BadRequest("CustomerId is invalid");
            var movieIds = rentalDto.MovieIds.ToList();
            var moviesInDb = _context.Movies.Where( m =>  movieIds.Contains(m.Id)).ToList();

            // these if statement polluted the code, it's call very defensive approach for validation. 
            if (moviesInDb.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or More Movie Ids are Invalid");
            // var rentalDetail = new RentalDto();
            // var movieIdsList = new List<int>();
            // rentalDetail.CustomerId = rentalDto.CustomerId;
            // rentalDetail.DateRented = rentalDto.DateRented;
            // rentalDetail.DateReturned = rentalDto.DateReturned;
            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");
                movie.NumberAvailable--;
               
                var rental = new RentalModel
                {
                    Customer = customerInDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            // rentalDetail.MovieIds = movieIdsList;

            // var rentals = Mapper.Map<RentalDto, RentalModel >(rentalDetail);
            // _context.Rentals.Add(rentals);
            return Ok();
            throw new NotImplementedException();
        }
    }
}
