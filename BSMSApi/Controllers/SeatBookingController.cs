using BSMSEntity;
using BSMSInterface;
using BSMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BSMSApi.Controllers
{
    public class SeatBookingController : ApiController
    {
        private ISeatBookingRepository seatBookingRepository;

        public SeatBookingController()
        {
            this.seatBookingRepository = new SeatBookingRepository();
        }

        public IHttpActionResult Get()
        {

            List<SeatBooking> SeatBookingList = seatBookingRepository.GetAll();
            return Ok(this.seatBookingRepository.GetAll());

        }
        //GetById
        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            SeatBooking seatBooking = seatBookingRepository.Get(id);
            if (seatBooking == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(seatBooking);
            }
        }



        public IHttpActionResult Put([FromBody]SeatBooking seatBooking, [FromUri]string id)
        {
            seatBooking.Id = id;
            this.seatBookingRepository.Update(seatBooking);
            return Ok(seatBooking);
        }
    }
}