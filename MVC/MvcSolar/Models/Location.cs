namespace MvcSolar.Models
{
    public class Location
    {
        public Location(double l, double lo)
        {
            latitude = l;
            longitude = lo;
        }
 
        public double latitude { get; set; }
     
        public double longitude { get; set; }



    }
}