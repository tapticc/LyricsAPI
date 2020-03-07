using LyricsAPI.Interfaces;
using LyricsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LyricsAPI.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly ILyricsService _lyricsService;

        public ArtistController(IArtistService artistService, ILyricsService lyricsService)
        {
            _artistService = artistService;
            _lyricsService = lyricsService;
        }

        public IActionResult Index()
        {
            var artistSelectViewModel = new ArtistSelectViewModel();
            return View(artistSelectViewModel);
        }

        [HttpPost]
        public IActionResult Index(ArtistSelectViewModel artistSelectViewModel)
        {
            artistSelectViewModel.ValidationMessage = "";

            if (string.IsNullOrEmpty(artistSelectViewModel.ArtistName))
            {
                artistSelectViewModel.ValidationMessage = "Please confirm the artist name";
                return View("Index", artistSelectViewModel);
            }

            var artists = _artistService.GetByName(artistSelectViewModel.ArtistName).Result;
            var artistConfirmViewModel = new ArtistConfirmViewModel
            {
                ArtistSearchName = artistSelectViewModel.ArtistName
            };

            foreach (var artist in artists)
            {
                artistConfirmViewModel.Artists.Add(new ArtistViewModel
                {
                    Id = artist.Id,
                    Name = artist.Name + " (" + artist.Country + ")"
                });
            }
      
            return View("Confirm", artistConfirmViewModel);
        }

        [HttpPost]
        public IActionResult Confirm(ArtistConfirmViewModel artistConfirmViewModel)
        {
            artistConfirmViewModel.ValidationMessage = "";

            if (string.IsNullOrEmpty(artistConfirmViewModel.SelectedArtistId)) 
            {
                artistConfirmViewModel.ValidationMessage = "Please confirm the artist name";
                return View(artistConfirmViewModel);
            }

            string selectedArtistName = "";
            foreach(var artist in artistConfirmViewModel.Artists)
            {
                if (artist.Id == artistConfirmViewModel.SelectedArtistId)
                {
                    selectedArtistName = artist.Name;
                    break;
                }
            }

            var recordingsViewModel = _lyricsService.GetRecordingsByArtistId(artistConfirmViewModel.SelectedArtistId, 
                selectedArtistName).Result;
       
            return View("ShowRecordingsSummary", recordingsViewModel);
        }

        public IActionResult ShowLyricSummary(RecordingsViewModel lyricsViewModel)
        {
            return View(lyricsViewModel);
        }
    }
}