using ChallengeDomain;
using ChallengePersistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeAplication.Post
{
    public class GetPostAll
    {

        

        public class ExecuteList : IRequest<List<PostModel>> { }

        public class HandlerClass : IRequestHandler<ExecuteList, List<PostModel>>
        {

            private readonly IData _DataRepository;
            public HandlerClass(IData DataRepository)
            {
                _DataRepository = DataRepository;
            }
            public async Task<List<PostModel>> Handle(ExecuteList request, CancellationToken cancellationToken)
            {

                #region Handle           
                var Result = await _DataRepository.GetPosts();
                return Result.ToList();
                #endregion



                 
            }

            

        }
    }

}
