using ChallengeDomain;
using ChallengePersistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeAplication.Comment
{
    public class AddComment
    {
        #region Execute
        public class Execute : IRequest<List<PostModel>>
        {            
            public string Name { get; set; }
            public string Email { get; set; }
            public string Body { get; set; }
            public int PostId { get; set; }

        }
        #endregion
        #region ExecuteValidator
        public class ExecuteValidator : AbstractValidator<Execute>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Body).NotEmpty();
                RuleFor(x => x.PostId).NotEmpty();
            }


        }
        #endregion
        #region HandlerClass

        public class HandlerClass : IRequestHandler<Execute,  List<PostModel>>
        {
            private readonly IData _DataRepository;
            public HandlerClass(IData DataRepository)
            {
                _DataRepository = DataRepository;
            }
            public async Task<List<PostModel>> Handle(Execute request, CancellationToken cancellationToken)
            {
                CommentModel entity = new CommentModel();
                entity.PostId = request.PostId;
                entity.Name = request.Name;
                entity.Email = request.Email;
                entity.Body = request.Body;
                #region Handle           
                var Result = await _DataRepository.Add(entity);
                return Result.ToList();
                #endregion
            }
        }
        #endregion
    }
}
