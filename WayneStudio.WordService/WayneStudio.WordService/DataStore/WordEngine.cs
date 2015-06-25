using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using WayneStudio.WordService.Core;
using WayneStudio.WordService.Models;

namespace WayneStudio.WordService.DataStore
{
    public class WordEngine
    {
        public void AddWords(UpdateWordRequest request)
        {
            throw new NotImplementedException();
        }

        public List<Word> GetWordList()
        {
            var query = @"
                SELECT Word AS Text, CreatedBy
                FROM Word
                WHERE IsBlocked = 0 AND IsExpired = 0";
            var queryResult = SQLiteHelper.ExecuteDataTable(query);
            return queryResult.AsEnumerable()
                .Select(l =>
                {
                    var word = new Word();
                    word.LoadFromDataTable(l);
                    return word;
                })
                .ToList();
        }

        public void Expire(UpdateWordRequest request)
        {
            throw new NotImplementedException();
        }

        public void Block(UpdateWordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}