namespace MMDb.Web.Services.Contracts
{
    using System.Collections.Generic;

    using MMDb.Data.Models;

    public interface IFavoriteService
    {
        bool Add(int id, string username);

        void Remove(int id, string username);

        IEnumerable<FavoriteMovie> All(string username);
    }
}
