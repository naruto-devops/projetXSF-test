using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
//namespace Reposiotries.Contracts

namespace Repositories.Contracts
{
    public interface IArticleGeneriqueRepository
    {
        List<ArticleGenerique> GetAll();
        ArticleGenerique GetById(int id);
        IEnumerable<ArticleGenerique> GetByPO(string id);

    }
}
