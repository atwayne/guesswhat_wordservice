using System.Collections.Generic;

namespace WayneStudio.WordService.Models
{
    public class UpdateWordRequest
    {
        public string CreatedBy { get; set; }
        public List<string> Words { get; set; }
    }
}