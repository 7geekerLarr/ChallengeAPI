using ChallengeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengePersistence
{
    public interface IData
    {
        Task<List<PostModel>> GetPosts();

        Task<List<PostModel>> Add(CommentModel entity);
        Task<PostModel> GetPost(int id);


    }
}
