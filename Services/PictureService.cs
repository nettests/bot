using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace bot.Services
{
	public class PictureService
	{
		private readonly HttpClient http;

		public PictureService(HttpClient http)
		{
			this.http = http;
		}

		public async Task<Stream> GetCatPictureAsync()
		{
			var resp = await http.GetAsync("https://cataas.com/cat");
			return await resp.Content.ReadAsStreamAsync();
		}

        public async Task<Stream> GetPictureAsync()
        {
            var res = await http.GetAsync("https://pp.userapi.com/c846220/v846220205/3d938/OdWh1UCeNJk.jpg");
            return await res.Content.ReadAsStreamAsync();
        }
	}
}