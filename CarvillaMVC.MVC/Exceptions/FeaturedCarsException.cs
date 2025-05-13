namespace CarvillaMVC.MVC.Exceptions
{
    public class FeaturedCarsException:Exception
    {

        public FeaturedCarsException():base("Default exception message")
        {
            
        }
        public FeaturedCarsException(string errorMessage):base(errorMessage)
        {
            
        }
    }
}
