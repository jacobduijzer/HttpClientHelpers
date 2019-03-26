using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace HttpClientHelpersLibrary.IntegrationTests
{
    public interface ITestApi
    {
        [Get("/todos")]
        Task<List<ToDoItem>> GetToDoListAsync();

        [Get("/posts")]
        Task<List<Post>> GetPostsAsync();
    }
}
