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

namespace ChallengeAplication.Post
{
    public class GetPost
    {
        #region Execute
        public class Execute : IRequest<PostModel>
        {
            public int Id { get; set; }

        }
        #endregion
        #region ExecuteValidator
        public class ExecuteValidator : AbstractValidator<Execute>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }


        }
        #endregion
        #region HandlerClass

        public class HandlerClass : IRequestHandler<Execute, PostModel>
        {
            private readonly IData _DataRepository;
            public HandlerClass(IData DataRepository)
            {
                _DataRepository = DataRepository;
            }
            public async Task<PostModel> Handle(Execute request, CancellationToken cancellationToken)
            {
                
                #region Handle           
                var Result = await _DataRepository.GetPost(request.Id);
                return Result;
                #endregion
            }
        }
        #endregion
    }
}
