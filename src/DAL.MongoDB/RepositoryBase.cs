using Common.Interfaces;
using Common.Classes;

namespace DAL.MongoDB
{
    public class RepositoryBase
    {
        protected internal IAppSettings appSettings { get; set; }

        public RepositoryBase() {
            this.appSettings = new AppSettings();
        }

        protected internal RsMongoContext GetContext() {
            return new RsMongoContext();
        }
    }
}