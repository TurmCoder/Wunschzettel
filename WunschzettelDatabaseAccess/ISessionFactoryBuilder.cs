using NHibernate;

namespace Wunschzettel
{
    public interface ISessionFactoryBuilder
    {
        ISessionFactory CreateSessionFactory(Schema schema);
    }
}