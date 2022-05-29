using ChallengeAplication.Comment;
using ChallengeAplication.Post;
using ChallengeDomain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;
        public PostController( IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<PostModel>>> Get()
        {
            return await _mediator.Send(new GetPostAll.ExecuteList());        
        }        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> Details(int id)
        {
            return await _mediator.Send(new GetPost.Execute { Id = id });
        }
        [HttpPost("Comment")]
        public async Task<ActionResult<List<PostModel>>> Add(AddComment.Execute data)
        {
            var result = await _mediator.Send(data);
            return result ;
            
        }
    }


}
