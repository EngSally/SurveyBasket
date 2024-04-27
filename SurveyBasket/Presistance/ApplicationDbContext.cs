

using Microsoft.Extensions.Options;

namespace SurveyBasket.Presistance;

public class ApplicationDbContext (DbContextOptions<ApplicationDbContext>  options):DbContext (options)
{


}
