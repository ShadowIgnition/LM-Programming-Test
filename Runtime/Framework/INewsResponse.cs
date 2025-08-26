using System.Collections;
using System.Collections.Generic;

namespace InfinityHeroes.News.Framework
{
    public interface INewsResponse
    {
        public INewsArticle[] NewsItems { get; }

    }
}
