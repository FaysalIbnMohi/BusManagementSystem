using System;
using System.Collections.Generic;
using System.Web.Http;
using BSMSInterface; //ERROR
using BSMSEntity;
using System.Web.Mvc;
using System.Net;
using BSMSRepository;

namespace BSMSApi.Controllers
{
        [System.Web.Http.RoutePrefix("api/Transport")]
        public class TransportController : ApiController
        {
            private ITransportRepository transportRepository;
           
            public TransportController()
            {
                this.transportRepository = new TransportRepository();
            }
            [System.Web.Http.Route("")]
            public IHttpActionResult Post(Transport transport)
            {

            transport.TransPortId = Guid.NewGuid();
            transport.IsActive = true;
            this.transportRepository.Insert(transport);
            string uri = Url.Link("GetById", new { id = transport.Id });
            return Created(uri, transport);
        }

        // GET: TransportList
            [System.Web.Http.Route("")]
            public IHttpActionResult Get()
            {
                return Ok(this.transportRepository.GetAllTransport());
            }
            //GetById
            [System.Web.Http.Route("{id}")]
            public IHttpActionResult Get(int id)
            {
                Transport transport = transportRepository.Get(id);
                if (transport == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return Ok(transport);
                }
            }
            [System.Web.Http.Route("{id}")]
            public IHttpActionResult Put([FromBody]Transport transport, [FromUri]int id)
            {
                transport.Id = id;
                this.transportRepository.Update(transport);
                return Ok(transport);
            }

            [System.Web.Http.Route("{id}")]
            public IHttpActionResult Delete(int id)
            {
                this.transportRepository.DeleteTransport(this.transportRepository.Get(id));
                 return StatusCode(HttpStatusCode.NoContent);
            }



    }

}