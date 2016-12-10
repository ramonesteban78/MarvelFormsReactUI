
using System.Threading.Tasks;
using MarvelFormsReactUI.Core.Models;

namespace MarvelFormsReactUI.Core.Services
{
	public interface IMarvelApiService
	{
		Task<MarvelApiData<Characters>> GetCharacters (string filter = null, int limit = 0, int offset = 0);
	}
}

