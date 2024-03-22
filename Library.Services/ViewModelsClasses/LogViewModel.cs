using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModelsClasses
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public bool IsReturned {  get; set; }
        public string BookTitle { get; set; }
        public string LibraryCardName { get; set; }
    }
}
