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
    [System.Web.Http.RoutePrefix("api/Passenger")]
    public class PassengerController : ApiController
    {
        private IPassengerRepository passengerRepository;

        public PassengerController()
        {
            this.passengerRepository = new PassengerRepository();
        }
        [System.Web.Http.Route("")]
        public IHttpActionResult Get()
        {

            List<Passenger> PassengerList = passengerRepository.GetAll();
            return Ok(this.passengerRepository.GetAll());

        }

        /*private IHttpActionResult Ok(List<Passenger> list)
        {
            throw new NotImplementedException();
        }
        */

        //GetById
        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Passenger passenger = passengerRepository.Get(id);
            if (passenger == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(passenger);
            }
        }


        [System.Web.Http.Route("")]
        public IHttpActionResult Post([FromBody]Passenger passenger)
        {

            passenger.PassengerId = Guid.NewGuid();
            //passenger.IsActive = true;
            this.passengerRepository.Insert(passenger);
            string uri = Url.Link("GetById", new { id = passenger.Id });
            return Created(uri, passenger);
        }
        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Put([FromBody]Passenger passenger, [FromUri]int id)
        {
            passenger.Id = id;
            this.passengerRepository.UpdatePassenger(passenger);
            return Ok(passenger);
        }
    }
}