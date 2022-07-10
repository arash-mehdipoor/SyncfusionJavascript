using Zamin.Core.Domain.Entities;

namespace SampleApp.Core.Domain.Blogs.Entities
{
    public class Blog : Entity
    {
        #region Properties
        public string Title { get; private set; }
        public string Description { get; private set; }
        #endregion

        #region Constructors
        private Blog()
        {
        }
        #endregion

    }
}
