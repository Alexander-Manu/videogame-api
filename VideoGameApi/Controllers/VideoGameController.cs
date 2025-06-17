using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {

        //This is a hardcoded list of data into the API

        //static private List<VideoGame> videoGames = new List<VideoGame>
        //{
        //    new VideoGame
        //    {
        //        Id = 1,
        //        Title = "Spider-Man 2",
        //        Platform = "PS5",
        //        Developer = "Insomniac Games",
        //        Publisher = "Sony Interactive Entertainment"
        //    },
        //     new VideoGame
        //    {
        //        Id = 2,
        //        Title = "The Legend of Zelda: Breath of the Wild",
        //        Platform = "Nintendo Switch",
        //        Developer = "Nintendo EPD",
        //        Publisher = "Nintendo"
        //    },
        //      new VideoGame
        //    {
        //        Id = 3,
        //        Title = "CyberpuNK 2077",
        //        Platform = "PC",
        //        Developer = "CD Projekt Red",
        //        Publisher = "CD Projekt"
        //    }
        //};

        //Various HTTP requests for the Stateless API

        //[HttpGet]
        //public ActionResult<List<VideoGame>> GetVideoGames()
        //{
        //    return Ok(videoGames);
        //}

        //[HttpGet ("{id}")]
        //public ActionResult<VideoGame> GetVideoGameById(int id) {
        //    var game = videoGames.FirstOrDefault(g => g.Id == id);
        //    if (game == null) 
        //        return NotFound();

        //    return Ok(game);
        //}

        //[HttpPost]
        //public ActionResult<VideoGame> AddVideoGane(VideoGame newGame)
        //{
        //    if (newGame == null)
        //        return BadRequest();

        //    newGame.Id = videoGames.Max(g => g.Id) + 1;
        //    videoGames.Add(newGame);
        //    return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateVideoGame(int id, VideoGame updatedGame)
        //{
        //    var game = videoGames.FirstOrDefault(g => g.Id == id);
        //    if (game is null)
        //        return NotFound();

        //    game.Title = updatedGame.Title;
        //    game.Platform = updatedGame.Platform;
        //    game.Developer = updatedGame.Developer;
        //    game.Publisher = updatedGame.Publisher;

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteVideoGame(int id) { 
        //    var game = videoGames.FirstOrDefault(game => game.Id == id);
        //    if (game is null) return NotFound();

        //    videoGames.Remove(game);
        //    return NoContent();
        //}


        //Injecting the datacontext to access the database table
        private readonly VideoGameDbContext _context;

        public VideoGameController(VideoGameDbContext context)
        {
            _context = context;
        }


        //Various HTTP requests methods for the database
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGane(VideoGame newGame)
        {
            if (newGame == null)
                return BadRequest();

            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync(); 
            
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();

            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;

            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null) return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
} 