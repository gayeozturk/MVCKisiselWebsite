using MVCKisiselWebsite.DAL;

namespace MVCKisiselWebsite.Models
{
    public class IndexViewModel
    {
        public List<Slider> Slider { get; set; }

        public List<CalismaAlani> CalismaAlani { get; set; }

        public List<Video> Video { get; set; }
    }
}
