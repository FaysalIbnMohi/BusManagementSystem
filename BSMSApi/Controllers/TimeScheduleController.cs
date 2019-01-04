using System;
using System.Collections.Generic;
using System.Web.Http;
using BSMSInterface; //ERROR
using BSMSEntity;
using System.Net;
using System.Web.Mvc;
using BSMSRepository;

namespace BSMSApi.Controllers
{
    [System.Web.Http.RoutePrefix("Api/TimeSchedule")]
    public class TimeScheduleController : ApiController
    {
        private ITimeScheduleRepository timeScheduleRepository;
        private ITransportRepository transportRepository;

        public TimeScheduleController()
            {
                this.timeScheduleRepository = new TimeScheduleRepository();
                this.transportRepository = new TransportRepository();
        }

        // GET: TimeScheduleList
        [System.Web.Http.Route("")]
        public IHttpActionResult Get()
            {
                List<TimeSchedule> TimeScheduleList = timeScheduleRepository.GetAll();
                return Ok(this.timeScheduleRepository.GetAllScehedule());

            }

        [System.Web.Http.Route("")]
        public IHttpActionResult Post(TimeSchedule timeSchedule)
        {

            //timeSchedule.Id = Guid.NewGuid()

            timeSchedule.IsActive = true;
            this.timeScheduleRepository.Insert(timeSchedule);
            string uri = Url.Link("GetById", new { id = timeSchedule.Id });
            return Created(uri, timeSchedule);
        }
        //GetById
        [System.Web.Http.Route("{id}")]
            public IHttpActionResult Get(int id)
            {
                TimeSchedule timeSchedule = timeScheduleRepository.Get(id);
                if (timeSchedule == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return Ok(timeSchedule);
                }
            }


        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Put([FromBody]TimeSchedule timeSchedule, [FromUri]int id)
            {
                timeSchedule.Id = id;
                this.timeScheduleRepository.UpdateTimeSchedule(timeSchedule);
                return Ok(timeSchedule);
            }

        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            this.timeScheduleRepository.DeleteTimeSchedule(this.timeScheduleRepository.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}