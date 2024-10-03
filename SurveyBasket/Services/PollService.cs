
namespace SurveyBasket.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _poll =
        [
            new Poll{
                Id = 1,
                Title = "Test",
                Description = "Description"
            }
        ];
        public IEnumerable<Poll> GetAll()=>_poll;

        public Poll? GetById(int id) => _poll.SingleOrDefault(d => d.Id == id);
        public Poll Add(Poll poll)
        {
            poll.Id = _poll.Count + 1;
            _poll.Add(poll);
            return poll;
        }
        public bool? Update(int id,Poll poll)
        {
            var currpoll = _poll.SingleOrDefault(d => d.Id == id);
            if (currpoll is null)
            {
                return false;
                
            }
            currpoll.Title = poll.Title;
            currpoll.Description = poll.Description;
            return true;
        }

        public bool? Delete(int id)
        {
            var poll = _poll.SingleOrDefault(d => d.Id == id);
            
            if (poll is null)
                return false;
            _poll.Remove(poll);
            return true;
        }
    }
}
