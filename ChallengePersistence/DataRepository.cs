using ChallengeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ChallengePersistence
{
    public class DataRepository : IData
    {
        private readonly string FileName;
        public  DataRepository()
        { 
            FileName = Directory.GetCurrentDirectory() + @"\Post.json";
        }
       #region Add
        public async  Task<List<PostModel>> Add(CommentModel entity)
        {
            
            try
            {
                List<PostModel> PostData = new List<PostModel>();
                List<CommentModel> comment = new List<CommentModel>();
                int i = 1;

                //string fileName = "C:\\LAB\\Post.json";
                string jsonString = File.ReadAllText(FileName);
                List<PostModel> PostData1 =  JsonSerializer.Deserialize<List<PostModel>>(jsonString)!;



                PostData = PostData1;
                foreach (var item in PostData)
                {
                    if (item.Id == entity.PostId)
                    {
                        if (item.Comments != null)
                        {
                            foreach (var det in item.Comments)
                            {
                                comment.Add(new CommentModel()
                                {
                                    PostId = det.PostId,
                                    Id = det.Id,
                                    Email = det.Email,
                                    Body = det.Body,
                                    Name = det.Name
                                });
                                i++;
                            }
                        }
                        comment.Add(new CommentModel()
                        {
                            Name = entity.Name,
                            Email = entity.Email,
                            Body = entity.Body,
                            Id = i,
                            PostId = entity.PostId,
                        });
                        item.Comments = comment;
                    }

                }
                string json = JsonConvert.SerializeObject(PostData, Formatting.Indented);
                // File.WriteAllText(@"C:\LAB\Post.json", json);
                File.WriteAllText(FileName, json);
                Data.PostDataAll = PostData.ToList();
                return await Task.FromResult(Data.PostDataAll);

            }
            catch (Exception)
            {
                
                return null;
            }
            

        }
        #endregion
        #region GetPosts
        public Task<List<PostModel>> GetPosts()
        {

            try
            {
               // string fileName = Directory.GetCurrentDirectory() + @"\Post.json";
                if (File.Exists(FileName))
                {
                    string jsonString = File.ReadAllText(FileName);
                    List<PostModel> PostData1 = JsonSerializer.Deserialize<List<PostModel>>(jsonString)!;
                    if (PostData1.Count > 0)
                    {
                        return Task.FromResult(PostData1);
                    }
                }

                List<PostModel> PostData = new List<PostModel>()
                {
                    new PostModel() 
                    {Id = 1, 
                     Title = "What is Lorem Ipsum?", 
                     Body  = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,"},
                    new PostModel() 
                    {Id = 2, 
                     Title = "Where does it come from?",
                     Body  = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock,"},
                    new PostModel()
                    {Id = 3,
                     Title = "Why do we use it?",
                     Body  = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout."},
                    new PostModel()
                    {Id = 4,
                     Title = "Where can I get some?",
                     Body  = "Suspendisse potenti. Praesent sodales sem ultricies maximus lobortis. Aliquam fringilla nisl sit amet scelerisque accumsan. "},
                    new PostModel()
                    {Id = 5,
                     Title = "The standard Lorem Ipsum passage, used since the 1500s",
                     Body  = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. "},
                     new PostModel()
                    {Id = 6,
                     Title = "Ut dignissim neque sit amet leo malesuada lacinia.",
                     Body  = "Ut nec dapibus tortor. Ut in dapibus arcu, eu consequat diam. In hac habitasse platea dictumst."},
                     new PostModel()
                    {Id = 7,
                     Title = "Nunc efficitur turpis a eros porta scelerisque.",
                     Body  = "Vestibulum at lobortis eros. Phasellus quis elit sed erat tempor iaculis ac nec justo. Aenean vitae nisl aliquet, convallis lectus id, vulputate est. Suspendisse a suscipit velit"},
                };
                string json = JsonConvert.SerializeObject(PostData, Formatting.Indented);
                File.WriteAllText(FileName, json);
                return Task.FromResult(PostData);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        #region GetPosts
        public Task<PostModel> GetPost(int id)
        {

            try
            {
                
                if (File.Exists(FileName))
                {
                    string jsonString = File.ReadAllText(FileName);
                    List<PostModel> PostData1 = JsonSerializer.Deserialize<List<PostModel>>(jsonString)!;
                    PostModel PostData = new PostModel(); 
                    if (PostData1.Count > 0)
                    {
                        foreach (var item in PostData1)
                        {
                            if (item.Id == id)
                            {

                                PostData.Id = item.Id;
                                PostData.Body = item.Body;
                                PostData.Title = item.Title;
                                PostData.Comments = item.Comments;
                            }

                        }
                        return Task.FromResult(PostData);
                    }
                }


                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
