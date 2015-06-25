using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using WayneStudio.WordService.Core;
using WayneStudio.WordService.Models;
using System.Data.SQLite;

namespace WayneStudio.WordService.DataStore
{
    public class WordEngine
    {
        public void AddWords(UpdateWordRequest request)
        {
            var query = @"
                INSERT INTO Word (Word, CreatedBy)
                VALUES (@Word,@CreatedBy)";

            var existed = GetAllWords()
                .Select(l => l.Text).ToList();

            var wordsToBeSaved = request.Words
            .Where(l => !existed.Contains(l, StringComparer.OrdinalIgnoreCase))
            .ToList();

            foreach (var item in wordsToBeSaved)
            {
                var parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("Word", item));
                parameters.Add(new SQLiteParameter("CreatedBy", request.CreatedBy));

                try
                {
                    SQLiteHelper.ExecuteNonQuery(query, parameters.ToArray());
                }
                catch (SQLiteException) { }
            }
        }

        public List<Word> GetWordList()
        {
            var query = @"
                SELECT Word AS Text, CreatedBy
                FROM Word
                WHERE IsBlocked = 0 AND IsExpired = 0";

            return GetWordListByQuery(query);
        }

        private List<Word> GetAllWords()
        {
            var query = @"
                SELECT Word AS Text, CreatedBy
                FROM Word";

            return GetWordListByQuery(query);
        }

        private static List<Word> GetWordListByQuery(string query)
        {
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
            var query = @"
                UPDATE Word
                SET IsExpired = 1, ExpiredAt = CURRENT_TIMESTAMP
                WHERE Word=@Word";

            foreach (var item in request.Words)
            {
                var parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("Word", item));
                try
                {
                    SQLiteHelper.ExecuteNonQuery(query, parameters.ToArray());
                }
                catch (SQLiteException) { }
            }
        }

        public void Block(UpdateWordRequest request)
        {
            var query = @"
                UPDATE Word
                SET IsExpired = 1, ExpiredAt = CURRENT_TIMESTAMP, IsBlocked = 1
                WHERE Word=@Word";

            foreach (var item in request.Words)
            {
                var parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("Word", item));
                try
                {
                    SQLiteHelper.ExecuteNonQuery(query, parameters.ToArray());
                }
                catch (SQLiteException) { }
            }
        }
    }
}