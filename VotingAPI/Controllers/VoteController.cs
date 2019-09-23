using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VotingAPI.BusinessObjects;
using VotingAPI.DataAccessObjects;


namespace VotingAppAPI.Controllers
{
    [RoutePrefix("api/Voting")]
    public class VoteController : ApiController
    {

        private readonly DataObjects _dataObjects;
        private readonly PostObjects _postObjects;
        public VoteController(DataObjects dataObjects,PostObjects postObjects)
        {
            _dataObjects = dataObjects;
            _postObjects = postObjects;
        }


        [HttpGet]
        [Route("GetAllStudents")]
        public List<Students> GetAllStudents()
        {

            var students = _dataObjects.GetStudents();
            return students;
        }

        [HttpPost]
        [Route("insertVote")]
        public bool Insert([FromBody] List<VoteData> vote)
        {
            var insert = _postObjects.InsertVotes(vote);

            return insert;
        }

        // GET: api/Vote
        [HttpGet]
        [Route]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("GetById")]
        public string GetById()
        {
            //var question = _dataObjects.GetQuestionById(id);
            return "Waley";
        }


        //// GET: api/Vote/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Vote   
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Vote/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Vote/5
        //public void Delete(int id)
        //{
        //}
    }
}
