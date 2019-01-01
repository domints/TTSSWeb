using System.Collections.Generic;
using System.Threading.Tasks;
using TTSSWeb.Models;

namespace TTSSWeb.Services
{
    public interface IAutocompleteService
    {
         Task<ICollection<StopBase>> GetAutocomplete(string query);
    }
}