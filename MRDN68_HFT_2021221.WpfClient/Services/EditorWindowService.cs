using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.WpfClient.Services
{
    class EditorWindowService : IEditorWindowService
    {
        public void EditDirector()
        {
            new DirectorWindow().ShowDialog();
        }
        public void EditMovie()
        {
            new MovieWindow().ShowDialog();
        }
        public void EditShowtime()
        {
            new ShowtimeWindow().ShowDialog();
        }
        public void ShowQueries()
        {
            new QueryWindow().ShowDialog();
        }
    }
}
