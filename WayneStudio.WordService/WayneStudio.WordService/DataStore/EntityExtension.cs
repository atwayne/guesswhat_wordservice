using System.Data;
using WayneStudio.WordService.Models;

namespace WayneStudio.WordService.DataStore
{
    public static class EntityExtension
    {
        public static void LoadFromDataTable(this Word entity, DataRow dataRow)
        {
            entity.Text = dataRow.Field<string>("Text");
            entity.CreatedBy = dataRow.Field<string>("CreatedBy");
        }
    }
}